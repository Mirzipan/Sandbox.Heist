using Mirzipan.Heist.Processors;
using Reflex.Attributes;
using Sandbox.Heist.ExampleC.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Heist.ExampleC
{
    public class AudioSettingsBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Slider _musicVolumeSlider;
        [SerializeField]
        private Slider _vfxVolumneSlider;
        [SerializeField]
        private Button _applyButton;
        [SerializeField]
        private Button _resetButton;

        [Inject]
        private IClientProcessor _processor;
        
        #region Lifecycle

        [Inject]
        private void Init()
        {
            _applyButton.onClick.AddListener(OnApplyClicked);
            _resetButton.onClick.AddListener(OnResetClicked);
        }

        #endregion Lifecycle

        #region Bindings

        private void OnApplyClicked()
        {
            _processor.Process(new ApplySoundSettings.Action
            {
                MusicVolume = _musicVolumeSlider.value,
                VFXVolume = _vfxVolumneSlider.value,
            });
        }

        private void OnResetClicked()
        {
            _processor.Process(new ResetSoundSettings.Action());
        }

        #endregion Bindings
    }
}