using UnityEngine.Events;

namespace Fd
{
    public class TEventBaseSO<T> : CommentableSO
    {
        public event UnityAction<T> OnEvent;

        public void RaiseEvent(T arg)
        {
            if (OnEvent != null)
                OnEvent.Invoke(arg);
        }
    }
}