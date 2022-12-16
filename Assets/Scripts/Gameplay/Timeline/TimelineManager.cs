using System;
using System.Collections;
using System.Linq;
using Beta.Audio;
using Plugins.Audio.AudioManagers;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.VFX;

namespace Gameplay.Timeline {
    public class TimelineManager : MonoBehaviour {

        [SerializeField] private HeatManager _heat;
        
        [SerializeField] private PlayableDirector _director;
        [SerializeField] private SFXManager _sfxManager;
        [SerializeField] private SFXAudioEvent _fallBackAudio;

        private SoundToken<SFXAudioEvent> _token;

        private void Start() {
            if(LevelAsset.Current != null) _director.playableAsset = LevelAsset.Current.Asset;

            float startTime = 0;
            if (_director.playableAsset is TimelineAsset asset) {
                try {
                    TrackAsset audioTrack = asset.GetOutputTrack(1);
                    TimelineClip first = audioTrack.GetClips().FirstOrDefault();
                    startTime = (float) first.start;
                }
                catch { /* ignored */ }
            }

            DelayedAction(LevelAsset.GetAppearTime() + startTime, StartSound);
            _director.Play();
        }

        private void OnEnable() => _heat.OnDeath += HandleDeath;
        private void OnDisable() => _heat.OnDeath -= HandleDeath;

        private void HandleDeath() {
            _director.Stop();
            _sfxManager.StopSFX(_token);
        }

        private void StartSound() => _sfxManager.PlaySFX(LevelAsset.GetAudioTrack() ?? _fallBackAudio);

        private void DelayedAction(float delay, Action action) {
            StartCoroutine(DelayedActionRoutine(delay, action));
        }
        
        private IEnumerator DelayedActionRoutine(float delay, Action action) {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }
    }
}
