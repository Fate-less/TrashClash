using UnityEngine.Events;

namespace CardHouse
{
    public class ClickDetectorUI : Toggleable
    {
        public UnityEvent OnPress;

        public GateCollection<NoParams> ClickGates;

        public void OnNextTurn()
        {
            if (IsActive && ClickGates.AllUnlocked(null))
            {
                OnPress.Invoke();
            }
        }
    }
}
