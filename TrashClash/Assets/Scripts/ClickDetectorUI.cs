using UnityEngine.Events;

namespace CardHouse
{
    public class ClickDetectorUI : Toggleable
    {
        public UnityEvent OnPress;

        public void OnNextTurn()
        {
            if (IsActive)
            {
                OnPress.Invoke();
            }
        }
    }
}
