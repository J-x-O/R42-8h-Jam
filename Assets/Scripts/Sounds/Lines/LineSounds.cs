using System;
using System.Collections.Generic;
using Beta.Audio;
using Gameplay.Blocks;
using UnityEngine;

namespace Sounds.Lines {

    public class LineSounds : MonoBehaviour {

        [SerializeField] private SFXAudioEvent _hit;
        [SerializeField] private SFXAudioEvent _miss;
        [SerializeField] private SFXAudioEvent _out;
        
        private Line _line;
        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _line = GetComponent<Line>();
        }

        private void OnEnable() {
            _line.OnBlockClicked += PlayHit;
            _line.OnBlockMissed += PlayMiss; 
            _line.OnBlockDied += PlayOut;
            
        }

        private void OnDisable() {
            _line.OnBlockClicked -= PlayHit;
            _line.OnBlockMissed -= PlayMiss;
            _line.OnBlockDied -= PlayOut;
            
        }

        private void PlayHit(Block block) {
            _hit.Play(_audioSource);
        }
        
        private void PlayMiss(Block block) {
            _miss.Play(_audioSource);
        }
        
        private void PlayOut(Block block) {
            _out.Play(_audioSource);
        }
    }

}
