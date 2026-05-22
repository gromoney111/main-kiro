using UnityEngine;

namespace RushIndia.Utility
{
    /// <summary>
    /// Simple script to make coins/gems rotate and bob in place.
    /// Attach to any collectible prefab for visual appeal.
    /// No setup needed - just drag onto the object!
    /// </summary>
    public class CoinRotator : MonoBehaviour
    {
        [Header("Rotation")]
        [SerializeField] private float rotationSpeed = 180f; // Degrees per second
        [SerializeField] private Vector3 rotationAxis = Vector3.up;

        [Header("Bobbing (up/down float)")]
        [SerializeField] private bool enableBobbing = true;
        [SerializeField] private float bobHeight = 0.3f;
        [SerializeField] private float bobSpeed = 2f;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            // Rotate
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

            // Bob up and down
            if (enableBobbing)
            {
                float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }

        /// <summary>
        /// Call when object is re-activated from pool to reset bob position.
        /// </summary>
        private void OnEnable()
        {
            startPosition = transform.position;
        }
    }
}
