using Beta.Audio;
using UnityEngine;
using UnityEngine.Timeline;

namespace Gameplay {
    [CreateAssetMenu(menuName = "ScriptableObjects/Level")]
    public class LevelAsset : ScriptableObject {

        public static LevelAsset Current;
        
        public TimelineAsset Asset => _asset;
        public float AppearTime => _appearTime;
        public float DecayRate => _decayRate;
        public SFXAudioEvent AudioTrack => _audioTrack;
        public float HotAdd => _hotAdd;
        public float ColdAdd => _coldAdd;
        public float HitWindow => _hitWindow;
        public AnimationCurve SuccessCurve => _successCurve;
        
        
        [SerializeField] private TimelineAsset _asset;
        [SerializeField] private SFXAudioEvent _audioTrack;
        
        [Space]
        [SerializeField] private float _appearTime = 2;
        [SerializeField] private float _decayRate = 0.1f;
        [SerializeField] private float _hotAdd = 0.1f;
        [SerializeField] private float _coldAdd = 0.1f;
        [SerializeField] private float _hitWindow = 0.4f;
        [SerializeField] private AnimationCurve _successCurve = AnimationCurve.EaseInOut(0,0, 1, 1);
        
        public static TimelineAsset GetAsset() => Current != null ? Current.Asset : null;
        public static SFXAudioEvent GetAudioTrack() => Current != null ? Current.AudioTrack : null;
        
        public static float GetAppearTime() => Current != null ? Current.AppearTime : 2;
        public static float GetDecayRate() => Current != null ? Current.DecayRate : 0.01f;
        public static float GetHotAdd() => Current != null ? Current.HotAdd : 0.1f;
        public static float GetColdAdd() => Current != null ? Current.ColdAdd : 0.1f;
        public static float GetHitWindow() => Current != null ? Current.HitWindow : 0.4f;
        public static AnimationCurve GetSuccessCurve() => Current != null ? Current.SuccessCurve : AnimationCurve.EaseInOut(0,0, 1, 1);

    }
}