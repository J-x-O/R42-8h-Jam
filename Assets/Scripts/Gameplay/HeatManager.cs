using System;
using System.Collections;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay {
    public class HeatManager : MonoBehaviour {
        
        public event Action OnSweetSpotRestored;
        public event Action OnSweetSpotLost;
        
        public float Heat { get; private set; }
        public readonly ObservableBool SweetSpot = true;
        public readonly ObservableBool Freezing = true;
        public readonly ObservableBool Overheating = true;
        
        [SerializeField] private float _lowestValue;
        public float LowestValue => _lowestValue;
        [SerializeField] private float _lowSweetSpot;
        [SerializeField] private float _highSweetSpot;
        [SerializeField] private float _highestValue;
        public float HighestValue => _highestValue;

        public event Action OnDeath;
        public float Troubelometer { get; private set; }
        [SerializeField] private float _troubleTolerance;
        [SerializeField] private float _troubleGainPerSecond;
        [SerializeField] private float _troubleDecayPerSecond;
        private Coroutine _deathRoutine;

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

        private void Update() {
            if (Input.GetKey(KeyCode.A)) {
                OnTooCold?.Invoke();
            }
            if (Input.GetKey(KeyCode.S)) {
                OnTooHot?.Invoke();
            }
            if (Input.GetKey(KeyCode.D)) {
                OnSweetSpotRestored?.Invoke();
            }
        }
    }
}