using UnityEngine;

namespace Assets.Scripts
{
    public class BackButton : MonoBehaviour
    {
        public void GoBack()
        {
            transform.GetComponentInParent<MovablePanel>().GoBack();
        }
    }
}
