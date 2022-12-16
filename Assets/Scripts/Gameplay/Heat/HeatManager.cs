using System;
using System.Collections;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay {
    public class HeatManager : MonoBehaviour {
        
        public event Action OnSweetSpotRestored;
        public event Action OnSweetSpotLost;
        
        public float Heat { get; private set; }
        public float HeatPercent => ValueToThreshold(Heat);
        public readonly ObservableBool SweetSpot = false;
        public readonly ObservableBool Freezing = false;
        public readonly ObservableBool Overheating = false;

        [SerializeField] private Vector2 _range = new Vector2(-1, 1);
        [SerializeField, Range(0,1)] private float _FreezingThreshold;
        [SerializeField, Range(0,1)] private float _ColdThreshold;
        [SerializeField, Range(0,1)] private float _HotThreshold;
        [SerializeField, Range(0,1)] private float _BurningThreshold;

        public event Action OnDeath;
        public float Troubelometer { get; private set; }
        [SerializeField] private float _troubleDuration;
        [SerializeField] private float _troubleGainPerSecond;
        [SerializeField] private float _troubleDecayPerSecond;
        private Coroutine _deathRoutine;

        public void Awake() {
            SetHeat(Mathf.Lerp(_range.x, _range.y, 0.5f));
        }

        public void HeatUp(float value) => SetHeat(Heat + value);
        public void Cooldown(float value) => SetHeat(Heat - value);

        private void SetHeat(float newValue) {
            Heat = Mathf.Clamp(newValue, _range.x, _range.y);
            SweetSpot.Set(IsInSweetSpot());
            Overheating.Set(IsOverheating());
            Freezing.Set(IsFreezing());
            if (IsInTrouble() && _deathRoutine == null) StartCoroutine(DeathRoutine());
        }
        
        private float ThresholdToValue(float threshold) {
            float width = _range.y - _range.x;
            return _range.x + width * threshold;
        }

        private float ValueToThreshold(float value) {
            float width = _range.y - _range.x;
            return (value - _range.x) / width;
        }

        private bool IsInSweetSpot() => HeatPercent > _ColdThreshold && HeatPercent < _HotThreshold;
        private bool IsInTrouble() => IsFreezing() || IsOverheating();
        private bool IsFreezing() => HeatPercent < _FreezingThreshold;
        private bool IsOverheating() => HeatPercent > _BurningThreshold;

        private IEnumerator DeathRoutine() {
            Troubelometer = 0;
            while (Troubelometer >= 0) {
                if (IsInTrouble()) Troubelometer += _troubleGainPerSecond * Time.deltaTime;
                else Troubelometer -= _troubleDecayPerSecond * Time.deltaTime;
                
                if(Troubelometer > _troubleDuration) OnDeath.TryInvoke();
                yield return null;
            }
            _deathRoutine = null;
        }
    }
}