using UnityEngine;

namespace RushIndia.Utility
{
    /// <summary>
    /// Automatically adjusts a UI RectTransform to fit within the device safe area.
    /// Prevents UI from being hidden behind notches, rounded corners, etc.
    /// 
    /// HOW TO USE:
    /// 1. On your Canvas, create a child Panel called "SafeArea"
    /// 2. Make it stretch to fill the canvas (anchor min 0,0 max 1,1)
    /// 3. Add this script to it
    /// 4. Put all your UI elements INSIDE this SafeArea panel
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect lastSafeArea = Rect.zero;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            // Check if safe area changed (orientation change, etc.)
            if (Screen.safeArea != lastSafeArea)
            {
                ApplySafeArea();
            }
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;
            lastSafeArea = safeArea;

            // Convert safe area from screen space to anchors (0-1 range)
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }
    }
}
