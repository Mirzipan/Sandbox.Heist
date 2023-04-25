using UnityEngine;
using UnityEngine.Audio;

namespace Sandbox.Heist.ExampleC
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer _mixer;

        public void SetMusicVolume(float volume)
        {
            //_mixer.SetFloat("music", volume);
            Debug.Log($"[Audio] Music volume set to {volume}");
        }

        public void SetVFXVolume(float volume)
        {
            //_mixer.SetFloat("vfx", volume);
            Debug.Log($"[Audio] VFX volume set to {volume}");
        }

        public void ResetMusicVolume()
        {
            SetMusicVolume(1);
        }

        public void ResetVFXVolume()
        {
            SetVFXVolume(1);
        }
    }
}