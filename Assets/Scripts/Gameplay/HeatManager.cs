using System;
using System.Collections;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay {
    public class HeatManager : MonoBehaviour {

        public event Action OnTooCold;
        public event Action OnTooHot;
        public event Action OnComfy;
        public event Action OnSweetSpotRestored;
        public event Action OnSweetSpotLost;
        
        //public float Heat { get; private set; }
        public readonly ObservableBool SweetSpot = true;
        public readonly ObservableBool Freezing = true;
        public readonly ObservableBool Overheating = true;
        
        [SerializeField] private float _lowestValue;
        public float LowestValue => _lowestValue;
        [SerializeField] private float _lowSweetSpot = 40;
        [SerializeField] private float _highSweetSpot = 60;
        [SerializeField] private float _highestValue = 100;
        public float HighestValue => _highestValue;

        /// <summary>
        /// delete
        /// </summary>
        public float Heat;
        
        public event Action OnDeath;
        public float Troubelometer { get; private set; }
        [SerializeField] private float _troubleTolerance;
        [SerializeField] private float _troubleGainPerSecond;
        [SerializeField] private float _troubleDecayPerSecond;
        private Coroutine _deathRoutine;

        public void OnValidate() {
            _lowestValue = Mathf.Min(_lowestValue, 0, _lowSweetSpot);
            _lowSweetSpot = Mathf.Clamp(_lowSweetSpot, _lowestValue, 0);
            _highSweetSpot = Mathf.Clamp(_highSweetSpot, 0, _highSweetSpot);
            _highestValue = Mathf.Max(_highestValue, 0, _highSweetSpot);
        }

        public void HeatUp(float value) => SetHeat(Heat + value);
        public void Cooldown(float value) => SetHeat(Heat - value);

        private void SetHeat(float newValue) {
            Heat = newValue;
            SweetSpot.Set(IsInSweetSpot());
            Overheating.Set(IsOverheating());
            Freezing.Set(IsFreezing());
            if (IsInTrouble() && _deathRoutine != null) StartCoroutine(DeathRoutine());
        }

        private bool IsInSweetSpot() => Heat > _lowSweetSpot && Heat < _highSweetSpot;
        private bool IsInTrouble() => IsFreezing() || IsOverheating();
        private bool IsFreezing() => Heat < _lowestValue;
        private bool IsOverheating() => Heat > _highestValue;

        private IEnumerator DeathRoutine() {
            Troubelometer = 0;
            while (Troubelometer >= 0) {
                if (IsInTrouble()) Troubelometer += _troubleGainPerSecond * Time.deltaTime;
                else Troubelometer -= _troubleDecayPerSecond * Time.deltaTime;
                
                if(Troubelometer > _troubleTolerance) OnDeath.TryInvoke();
                yield return null;
            }
            _deathRoutine = null;
        }
    }
}