using System;
using Beta.Audio;
using Gameplay;
using UnityEngine;

namespace Sounds.HeatGauge {

    public class GaugeSounds : MonoBehaviour {

        [SerializeField] private HeatManager _heatManager;
        
        [SerializeField] private SFXAudioEvent _freeze;
        [SerializeField] private SFXAudioEvent _heat;
        [SerializeField] private SFXAudioEvent _sweetSpot;

        [SerializeField] private SFXManager _manager;

        private void OnEnable() {
            _heatManager.Freezing.OnValueChanged += PlayFreeze;
            _heatManager.Overheating.OnValueChanged += PlayHeat;
            _heatManager.SweetSpot.OnValueChanged += PlaySweetspot;
        }

        private void OnDisable() {
            _heatManager.Freezing.OnValueChanged -= PlayFreeze;
            _heatManager.Overheating.OnValueChanged -= PlayHeat;
            _heatManager.SweetSpot.OnValueChanged -= PlaySweetspot;
        }

        private void PlayFreeze(bool start) {
            if(start) _manager.PlaySFX(_freeze);
        }
        
        private void PlayHeat(bool start) {
            if(start) _manager.PlaySFX(_heat);
        }
        
        private void PlaySweetspot(bool start) {
            if(start) _manager.PlaySFX(_sweetSpot);
        }
    }

}
