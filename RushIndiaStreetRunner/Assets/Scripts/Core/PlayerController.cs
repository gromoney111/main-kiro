using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Controls the player character: lane switching, jumping, sliding.
    /// Handles collision detection with obstacles and collectibles.
    /// Mobile-optimized with smooth interpolation.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Lane Settings")]
        [SerializeField] private float laneWidth = 3f;       // Distance between lanes
        [SerializeField] private float laneSwitchSpeed = 12f; // How fast player moves between lanes

        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float gravity = -30f;

        [Header("Slide Settings")]
        [SerializeField] private float slideDuration = 0.8f;
        [SerializeField] private float slideColliderHeight = 0.5f;
        [SerializeField] private float normalColliderHeight = 2f;

        [Header("State")]
        [SerializeField] private bool isAlive = true;

        // Lane: -1 = left, 0 = center, 1 = right
        private int currentLane = 0;
        private float targetXPosition;

        // Physics
        private CharacterController controller;
        private Vector3 moveDirection;
        private float verticalVelocity;

        // Sliding
        private bool isSliding;
        private float slideTimer;

        // Powerup state
        private bool hasShield;
        private bool hasMagnet;

        // Events
        public System.Action OnPlayerDeath;
        public System.Action<string> OnCollectItem; // Passes item tag
        public System.Action OnPlayerJump;
        public System.Action OnPlayerSlide;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            // Subscribe to swipe events
            if (SwipeManager.Instance != null)
            {
                SwipeManager.Instance.OnSwipeLeft += MoveLeft;
                SwipeManager.Instance.OnSwipeRight += MoveRight;
                SwipeManager.Instance.OnSwipeUp += Jump;
                SwipeManager.Instance.OnSwipeDown += Slide;
            }
        }

        private void OnDisable()
        {
            // Unsubscribe to prevent memory leaks
            if (SwipeManager.Instance != null)
            {
                SwipeManager.Instance.OnSwipeLeft -= MoveLeft;
                SwipeManager.Instance.OnSwipeRight -= MoveRight;
                SwipeManager.Instance.OnSwipeUp -= Jump;
                SwipeManager.Instance.OnSwipeDown -= Slide;
            }
        }

        private void Update()
        {
            if (!isAlive) return;
            if (GameManager.Instance == null || GameManager.Instance.CurrentState != GameState.Playing) return;

            // Forward movement (handled by environment scrolling, player stays in place on Z)
            // Lateral movement (lane switching)
            HandleLaneMovement();

            // Gravity and vertical movement
            HandleVerticalMovement();

            // Slide timer
            HandleSlideTimer();

            // Apply movement
            ApplyMovement();
        }

        #region Lane Movement

        /// <summary>
        /// Smoothly move player to target lane position.
        /// </summary>
        private void HandleLaneMovement()
        {
            targetXPosition = currentLane * laneWidth;
            float currentX = transform.position.x;
            float newX = Mathf.MoveTowards(currentX, targetXPosition, laneSwitchSpeed * Time.deltaTime);

            // Apply lateral movement through CharacterController
            moveDirection.x = (newX - currentX) / Time.deltaTime;
        }

        /// <summary>
        /// Switch to left lane (-1 minimum).
        /// </summary>
        private void MoveLeft()
        {
            if (!isAlive) return;
            if (currentLane > -1)
            {
                currentLane--;
                // TODO: Play lane switch animation
            }
        }

        /// <summary>
        /// Switch to right lane (+1 maximum).
        /// </summary>
        private void MoveRight()
        {
            if (!isAlive) return;
            if (currentLane < 1)
            {
                currentLane++;
                // TODO: Play lane switch animation
            }
        }

        #endregion

        #region Jump & Slide

        /// <summary>
        /// Apply gravity and handle jump physics.
        /// </summary>
        private void HandleVerticalMovement()
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -1f; // Small downward force to stay grounded
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime;
            }

            moveDirection.y = verticalVelocity;
        }

        /// <summary>
        /// Jump if grounded.
        /// </summary>
        private void Jump()
        {
            if (!isAlive) return;
            if (!controller.isGrounded) return;

            // Cancel slide if jumping
            if (isSliding) EndSlide();

            verticalVelocity = jumpForce;
            OnPlayerJump?.Invoke();
            // TODO: Trigger jump animation
        }

        /// <summary>
        /// Start sliding (shrink collider, play animation).
        /// </summary>
        private void Slide()
        {
            if (!isAlive) return;
            if (isSliding) return;

            isSliding = true;
            slideTimer = slideDuration;

            // Shrink collider for sliding under obstacles
            controller.height = slideColliderHeight;
            controller.center = new Vector3(0, slideColliderHeight / 2f, 0);

            OnPlayerSlide?.Invoke();
            // TODO: Trigger slide animation
        }

        /// <summary>
        /// Count down slide duration and restore collider.
        /// </summary>
        private void HandleSlideTimer()
        {
            if (!isSliding) return;

            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0f)
            {
                EndSlide();
            }
        }

        /// <summary>
        /// End slide state and restore normal collider.
        /// </summary>
        private void EndSlide()
        {
            isSliding = false;
            controller.height = normalColliderHeight;
            controller.center = new Vector3(0, normalColliderHeight / 2f, 0);
            // TODO: End slide animation
        }

        #endregion

        #region Movement Application

        /// <summary>
        /// Apply calculated movement vector through CharacterController.
        /// </summary>
        private void ApplyMovement()
        {
            // Forward speed comes from GameManager (environment moves, or player moves)
            float forwardSpeed = GameManager.Instance != null ? GameManager.Instance.CurrentSpeed : 8f;
            moveDirection.z = forwardSpeed;

            controller.Move(moveDirection * Time.deltaTime);
        }

        #endregion

        #region Collision Handling

        /// <summary>
        /// Handle trigger collisions (collectibles, powerups).
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (!isAlive) return;

            switch (other.tag)
            {
                case "Coin":
                    OnCollectItem?.Invoke("Coin");
                    other.gameObject.SetActive(false); // Return to pool
                    break;

                case "Gem":
                    OnCollectItem?.Invoke("Gem");
                    other.gameObject.SetActive(false);
                    break;

                case "Powerup":
                    OnCollectItem?.Invoke("Powerup");
                    other.gameObject.SetActive(false);
                    break;

                case "Obstacle":
                    HandleObstacleHit();
                    break;
            }
        }

        /// <summary>
        /// Handle physical collision with obstacles.
        /// </summary>
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!isAlive) return;

            if (hit.gameObject.CompareTag("Obstacle"))
            {
                HandleObstacleHit();
            }
        }

        /// <summary>
        /// Process obstacle hit - shield absorbs or player dies.
        /// </summary>
        private void HandleObstacleHit()
        {
            if (hasShield)
            {
                // Shield absorbs hit
                hasShield = false;
                // TODO: Play shield break VFX
                return;
            }

            Die();
        }

        #endregion

        #region Death & Powerups

        /// <summary>
        /// Kill the player and trigger game over.
        /// </summary>
        private void Die()
        {
            if (!isAlive) return;

            isAlive = false;
            // TODO: Play death animation
            // TODO: Play death SFX

            OnPlayerDeath?.Invoke();
            GameManager.Instance?.TriggerGameOver();
        }

        /// <summary>
        /// Activate shield powerup (absorbs one hit).
        /// </summary>
        public void ActivateShield()
        {
            hasShield = true;
            // TODO: Show shield VFX
        }

        /// <summary>
        /// Activate coin magnet (attracts nearby coins).
        /// </summary>
        public void ActivateMagnet(bool active)
        {
            hasMagnet = active;
            // TODO: Enable magnet collider radius
        }

        /// <summary>
        /// Reset player for new game.
        /// </summary>
        public void ResetPlayer()
        {
            isAlive = true;
            currentLane = 0;
            verticalVelocity = 0f;
            hasShield = false;
            hasMagnet = false;
            isSliding = false;
            transform.position = Vector3.zero;
        }

        #endregion
    }
}
