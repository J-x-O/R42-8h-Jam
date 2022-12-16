using UnityEngine;

namespace Gameplay.Blocks {
    public class Line : MonoBehaviour {

        [SerializeField] private Transform _start;
        [SerializeField] private Transform _end;

        public Vector3 EvaluatePosition(float progressPercent) {
            return Vector3.Lerp(_start.position, _end.position, progressPercent);
        }
    }
}