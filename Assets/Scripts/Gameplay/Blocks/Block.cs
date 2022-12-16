using System;
using System.Collections;
using System.Security.Cryptography;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay.Blocks {
    public class Block : MonoBehaviour {

        public event Action OnStop;
        
        public BlockType Type => _type;
        [SerializeField] private BlockType _type;

        public float Progress { get; private set; }
        public float ProgressPercent => Progress / _data.LineDuration;
        
        [SerializeField] private BlockData _data;

        private Coroutine _routine;
        
        public void RunBlock(Line target, Action onFinished) {
            _routine = StartCoroutine(MoveBlock(target, onFinished));
        }
        
        private IEnumerator MoveBlock(Line target, Action onFinished) {
            Progress = 0;
            
            while (Progress < _data.LineDuration + _data.HitWindow / 2) {
                Progress += Time.deltaTime;
                transform.position = target.EvaluatePosition(Mathf.Clamp01(Progress / _data.LineDuration));
                yield return null;
            }
            onFinished.TryInvoke();
        }

        public void StopBlock() {
            OnStop.TryInvoke();
            Destroy(gameObject);
        }


        public bool IsClickable() {
            return IsBetween(Progress - _data.LineDuration, -_data.HitWindow / 2, +_data.HitWindow / 2);
        }

        public float CalculateAccuracy() {
            float accuracy01 = Mathf.Clamp01(Mathf.Abs(Progress - _data.LineDuration) / (_data.HitWindow / 2));
            return _data.SuccessCurve.Evaluate(accuracy01);
        }
        
        private static bool IsBetween(float value, float lower, float higher) {
            return lower < value && value < higher;
        }

        private void OnDestroy() {
            if(_routine != null) StopCoroutine(_routine);
        }

        
    }
}