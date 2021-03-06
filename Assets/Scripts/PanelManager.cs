﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PanelManager : MonoBehaviour
    {
        public static readonly Vector2 OffScreenLeftPos = new Vector2(-2000, 0);
        public static readonly Vector2 OffScreenRightPos = -OffScreenLeftPos;
        public MovablePanel CurrentPanel { get; private set; }
        public MovablePanel LastPanel { get; private set; }

        public readonly Stack<MovablePanel> PanelStack = new Stack<MovablePanel>();


        private void Start()
        {
            GameObject.Find("MainMenuPanel").GetComponent<MovablePanel>().ShowMe();
        }

        public static PanelManager Instance
        {
            get
            {
                var panelManagers = FindObjectsOfType<PanelManager>();
                if (panelManagers.Count() > 1)
                    Debug.Log("dafuq, too many panel managers");
                return panelManagers[0];
            }
        }


        public void GoToPanel(MovablePanel panel)
        {
            if (PanelStack.Any(a => a.IsTransitioning))
                return;
            if (PanelStack.Contains(panel))
            {
                while (PanelStack.Peek() != panel)
                {
                    PanelStack.Pop().TransitionOut(OffScreenRightPos);
                }
            }
            else
            {
                PanelStack.Push(panel);
                panel.GetComponent<RectTransform>().localPosition = OffScreenRightPos;
            }
            if (CurrentPanel)
                CurrentPanel.TransitionOut(OffScreenLeftPos);

            CurrentPanel = PanelStack.Peek();
            CurrentPanel.TransitionIn();
        }

        /// <summary>
        /// Discards the current panel and "rewinds" to the last panel
        /// </summary>
        public void GoBack()
        {
            if (PanelStack.Count <= 1 || PanelStack.Any(a => a.IsTransitioning)) return;
            var panelToHide = PanelStack.Pop();
            panelToHide.TransitionOut(OffScreenRightPos);
            CurrentPanel = PanelStack.Peek();
            CurrentPanel.TransitionIn();
        }


    }
}
