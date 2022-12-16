using System.Collections;
using UnityEngine;

namespace Gameplay.Blocks {
    public class Block : MonoBehaviour {

        [SerializeField] private float _overshootTiming;

        private HeatManager _manager;
        private Line _line;
        private float _duration;
        private Direction _direction;
        
        public void Initialize(HeatManager manager, Line line, float duration, Direction direction) {
            _manager = manager;
            _line = line;
            _duration = duration;
            _direction = direction;
        }

        // private IEnumerator MoveBlock() {
        //     
        // }
    }
}