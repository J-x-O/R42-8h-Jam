using Gameplay.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace Gameplay {
    public class LevelAsset : ScriptableObject {

        public static LevelAsset Current;

        public TimelineAsset Asset => _asset;
        [SerializeField] private TimelineAsset _asset;
        
        public float AppearTime => _appearTime;
        [SerializeField] private float _appearTime = 2;
        
        public float DecayRate => _decayRate;
        [SerializeField] private float _decayRate = 0.1f;
        

    }
}