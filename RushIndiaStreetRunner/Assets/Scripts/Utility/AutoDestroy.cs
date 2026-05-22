using UnityEngine;

namespace RushIndia.Utility
{
    /// <summary>
    /// Automatically destroys or deactivates a GameObject after a time delay.
    /// Useful for particle effects, temporary UI elements, etc.
    /// </summary>
    public class AutoDestroy : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float lifetime = 2f;
        [SerializeField] private bool deactivateInsteadOfDestroy = true; // For pooled objects

        private float timer;

        private void OnEnable()
        {
            timer = lifetime;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (deactivateInsteadOfDestroy)
                    gameObject.SetActive(false);
                else
                    Destroy(gameObject);
            }
        }
    }
}
