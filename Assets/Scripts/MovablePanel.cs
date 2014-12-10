using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovablePanel : MonoBehaviour
    {
        public bool IsTransitioning { get; private set; }

        public void TransitionOut(Vector2 newPos)
        {
            StartCoroutine(AnimateMove(newPos, .5f, false));
        }

        public void TransitionIn()
        {
            StartCoroutine(AnimateMove(Vector2.zero, .5f, true));
        }

        public void ShowMe()
        {
            PanelManager.Instance.GoToPanel(this);
        }

        public void GoBack()
        {
            PanelManager.Instance.GoBack();
        }

        IEnumerator AnimateMove(Vector3 to, float transitionTime, bool easeIn)
        {
            var controlPoint = easeIn ? new Vector2(0, 1) : new Vector2(1, 0);
            IsTransitioning = true;
            var rectTransform = gameObject.GetComponent<RectTransform>();
            var startPos = rectTransform.localPosition;
            var time = 0f;
            while (time < 1)
            {
                time += Time.deltaTime / transitionTime;
                var value = Scripts.Common.Util.CalculateBezierPoint(time, Vector2.zero, controlPoint, controlPoint, Vector2.one).y;
                rectTransform.localPosition = Vector3.Lerp(startPos, to, value);
                yield return null;
            }
            rectTransform.localPosition = to;
            IsTransitioning = false;
        }

    }
}
