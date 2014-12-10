using UnityEngine;

namespace Assets.Scripts
{
    public class CanvasManager : MonoBehaviour
    {
        private Camera uiCamera;
        private Canvas canvas;
        // Use this for initialization
        void Start()
        {
            uiCamera = GetComponent<Camera>();
            canvas = FindObjectOfType<Canvas>();
        }

        // Update is called once per frame
        void Update()
        {
            canvas.enabled = uiCamera.enabled;
        }
    }
}
