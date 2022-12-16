using Beta.Audio;
using Gameplay.Timeline;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Timeline;

namespace Gameplay {
    [CreateAssetMenu(menuName = "ScriptableObjects/Level")]
    public class LevelAsset : ScriptableObject {

        public static LevelAsset Current;

        public static TimelineAsset GetAsset() => Current != null ? Current.Asset : null;
        public TimelineAsset Asset => _asset;
        [SerializeField] private TimelineAsset _asset;
        
        public static float GetAppearTime() => Current != null ? Current.AppearTime : 2;
        public float AppearTime => _appearTime;
        [SerializeField] private float _appearTime = 2;
        
        public static float GetDecayRate() => Current != null ? Current.DecayRate : 0.01f;
        public float DecayRate => _decayRate;
        [SerializeField] private float _decayRate = 0.1f;
        
        public static SFXAudioEvent GetAudioTrack() => Current != null ? Current.AudioTrack : null;
        public SFXAudioEvent AudioTrack => _audioTrack;
        [SerializeField] private SFXAudioEvent _audioTrack;
    }
}