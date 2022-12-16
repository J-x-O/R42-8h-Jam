using UnityEngine;

namespace Gameplay.Blocks {
    
    [CreateAssetMenu(menuName = "ScriptableObjects/BlockData")]
    public class BlockData : ScriptableObject {

        public float LineDuration => _lineDuration;
        [SerializeField] private float _lineDuration;
        public float HitWindow => _hitWindow;
        [SerializeField] private float _hitWindow;

        public float HotAdd => _hotAdd;
        [SerializeField] private float _hotAdd;
        
        public float ColdAdd => _coldAdd;
        [SerializeField] private float _coldAdd;
        
        public AnimationCurve SuccessCurve => _successCurve;
        [SerializeField] private AnimationCurve _successCurve;
    }
}