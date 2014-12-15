using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
    [ExecuteInEditMode]
    public class ListExpander : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            var children = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }
            var height = children.Sum(a => a.GetComponent<RectTransform>().rect.height);

            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
    }
}
