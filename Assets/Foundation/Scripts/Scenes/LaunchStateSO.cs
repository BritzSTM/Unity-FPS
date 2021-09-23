using System;
using UnityEngine;

namespace Fd
{
    [CreateAssetMenu(fileName = "new launch state so", menuName = "Fd/Scene/LaunchStateSO")]
    public class LaunchStateSO : CommentableSO
    {
        [NonSerialized] public bool IsLaunched;
        [NonSerialized] public bool IsColdLaunched;

        public void Launch() => IsLaunched = true;
    }
}