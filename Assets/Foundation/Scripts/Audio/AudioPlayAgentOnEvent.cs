using UnityEngine;

namespace Fd
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayAgentOnEvent : MonoBehaviour
    {
        [SerializeField] private AudioClipEventSO _onPlayEventSO;
        [SerializeField] private AudioClipEventSO _onPlayOneShotEventSO;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            if (_onPlayEventSO != null)
                _onPlayEventSO.OnEvent += OnPlay;

            if (_onPlayOneShotEventSO != null)
                _onPlayOneShotEventSO.OnEvent += OnPlayOneShot;
        }

        private void OnDisable()
        {
            if (_onPlayEventSO != null)
                _onPlayEventSO.OnEvent -= OnPlay;

            if (_onPlayOneShotEventSO != null)
                _onPlayOneShotEventSO.OnEvent -= OnPlayOneShot;
        }

        private void OnPlay(AudioClipDesc desc)
        {
            _audioSource.clip = desc.clip;
            _audioSource.Play();
        }

        private void OnPlayOneShot(AudioClipDesc desc)
        {
            _audioSource.PlayOneShot(desc.clip);
        }
    }
}