using UnityEngine;

namespace RushIndia.Core
{
    /// <summary>
    /// Detects swipe gestures on mobile touchscreens.
    /// Fires events for swipe directions: Left, Right, Up, Down.
    /// Also supports keyboard input for testing in Editor.
    /// </summary>
    public class SwipeManager : MonoBehaviour
    {
        public static SwipeManager Instance { get; private set; }

        [Header("Swipe Settings")]
        [SerializeField] private float minSwipeDistance = 50f;  // Minimum pixels to register swipe
        [SerializeField] private float maxSwipeTime = 0.5f;     // Max time for a valid swipe

        // Events fired on swipe detection
        public System.Action OnSwipeLeft;
        public System.Action OnSwipeRight;
        public System.Action OnSwipeUp;
        public System.Action OnSwipeDown;

        // Touch tracking
        private Vector2 touchStartPos;
        private float touchStartTime;
        private bool isSwiping;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            // Skip input if game is not playing
            if (GameManager.Instance != null &&
                GameManager.Instance.CurrentState != GameState.Playing)
                return;

            DetectTouchSwipe();
            DetectKeyboardInput(); // For Editor testing
        }

        /// <summary>
        /// Detect swipe from touch input (mobile).
        /// </summary>
        private void DetectTouchSwipe()
        {
            if (Input.touchCount == 0) return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    touchStartTime = Time.time;
                    isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    if (!isSwiping) return;
                    isSwiping = false;

                    // Check if swipe was fast enough
                    float swipeTime = Time.time - touchStartTime;
                    if (swipeTime > maxSwipeTime) return;

                    // Calculate swipe vector
                    Vector2 swipeDelta = touch.position - touchStartPos;

                    // Check minimum distance
                    if (swipeDelta.magnitude < minSwipeDistance) return;

                    // Determine direction (horizontal vs vertical)
                    ProcessSwipe(swipeDelta);
                    break;

                case TouchPhase.Canceled:
                    isSwiping = false;
                    break;
            }
        }

        /// <summary>
        /// Keyboard input for testing in Unity Editor.
        /// Arrow keys or WASD map to swipe directions.
        /// </summary>
        private void DetectKeyboardInput()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                OnSwipeLeft?.Invoke();
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                OnSwipeRight?.Invoke();
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                OnSwipeUp?.Invoke();
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                OnSwipeDown?.Invoke();
#endif
        }

        /// <summary>
        /// Process swipe vector to determine direction and fire event.
        /// </summary>
        private void ProcessSwipe(Vector2 delta)
        {
            // Compare absolute values to determine primary axis
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                // Horizontal swipe
                if (delta.x > 0)
                    OnSwipeRight?.Invoke();
                else
                    OnSwipeLeft?.Invoke();
            }
            else
            {
                // Vertical swipe
                if (delta.y > 0)
                    OnSwipeUp?.Invoke();
                else
                    OnSwipeDown?.Invoke();
            }
        }
    }
}
