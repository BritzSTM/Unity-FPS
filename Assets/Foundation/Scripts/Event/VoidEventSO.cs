using UnityEngine;
using UnityEngine.Events;

namespace Fd
{
    [CreateAssetMenu(fileName = "new void event so", menuName = "Fd/Event/Void")]
    public class VoidEventSO : CommentableSO
    {
        public event UnityAction OnEvent;

        public void RaiseEvent()
        {
            if (OnEvent != null)
                OnEvent.Invoke();
        }
    }
}