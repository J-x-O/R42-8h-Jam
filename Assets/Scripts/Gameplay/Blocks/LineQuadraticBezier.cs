using System;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Blocks {
    public class LineQuadraticBezier : Line {

        [SerializeField] private Transform _start;
        [SerializeField] private Transform _middle;
        [SerializeField] private Transform _end;
        
        // https://en.wikibooks.org/wiki/Cg_Programming/Unity/B%C3%A9zier_Curves
        public override Vector3 EvaluatePosition(float progressPercent) {
            Vector3 p0 = _start.transform.position;
            Vector3 p1 = _middle.transform.position;
            Vector3 p2 = _end.transform.position;

            return (1.0f - progressPercent) * (1.0f - progressPercent) * p0 
                   + 2.0f * (1.0f - progressPercent) * progressPercent * p1
                   + progressPercent * progressPercent * p2;
        }

        private void OnDrawGizmos() {
            Vector3 lastPosition = _start.transform.position;
            const float stepSize = 0.1f;
            for (float progress = stepSize; progress < 1.1f; progress += stepSize) {
                Vector3 newPosition = EvaluatePosition(progress);
                Gizmos.DrawLine(lastPosition, newPosition);
                lastPosition = newPosition;
            }
        }
    }
}