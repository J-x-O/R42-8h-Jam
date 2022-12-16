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

        private AudioSource _audioSource;

        private void Start() {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable() {
            _heatManager.Freezing.OnValueChanged += PlayFreeze;
            _heatManager.Overheating.OnValueChanged += PlayHeat;
            _heatManager.OnSweetSpotRestored += PlaySweetspot;
        }

        private void OnDisable() {
            _heatManager.Freezing.OnValueChanged -= PlayFreeze;
            _heatManager.Overheating.OnValueChanged -= PlayHeat;
            _heatManager.OnSweetSpotRestored -= PlaySweetspot;
        }

        private void PlayFreeze(bool start) {
            if(start) _freeze.Play(_audioSource);
        }
        
        private void PlayHeat(bool start) {
            if(start) _heat.Play(_audioSource);
        }
        
        private void PlaySweetspot() {
            _sweetSpot.Play(_audioSource);
        }
    }

}
