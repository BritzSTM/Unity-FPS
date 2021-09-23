using UnityEngine;

namespace Fd
{
    public struct AudioClipDesc
    {
        public AudioClip clip;
    }

    [CreateAssetMenu(fileName = "new audio clip play event so", menuName = "Fd/Event/AudioClip")]
    public class AudioClipEventSO : TEventBaseSO<AudioClipDesc>
    {

    }
}