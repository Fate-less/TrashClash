using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace CardHouse
{
    public class ClickDetector : Toggleable
    {
        public UnityEvent OnPress;
        public UnityEvent OnButtonClicked;
        public float holdDurationBeforeDrag;

        public GateCollection<NoParams> ClickGates;

        private float holdCountdown;
        private bool currentlyClicked;

        void OnMouseDown()
        {
            currentlyClicked = true;
            if (IsActive && ClickGates.AllUnlocked(null))
            {
                OnPress.Invoke();
            }
        }

        void OnMouseUpAsButton()
        {
            currentlyClicked = false;
            if (IsActive && ClickGates.AllUnlocked(null))
            {
                if(holdCountdown < holdDurationBeforeDrag)
                {
                    OnButtonClicked.Invoke();
                }
            }
            holdCountdown = 0;
        }

        private void Update()
        {
            if (currentlyClicked)
            {
                holdCountdown += Time.deltaTime;
            }
        }
    }
}
