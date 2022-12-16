using System;
using Gameplay;
using UnityEngine;

namespace UI.HeatGauge {
    
    public class HeatIndicator : MonoBehaviour {

        [SerializeField] private HeatManager _heatManager;

        [SerializeField] private RectTransform _indicator;

        [SerializeField] private float _minDegree;
        [SerializeField] private float _maxDegree;
        [SerializeField] private float _vibratingSpeed;

        private void Start() {
            _indicator.rotation = Quaternion.Euler(Vector3.back * 90);
        }

        private void Update() {
            UpdateRotation();
            if (_heatManager.SweetSpot) {
                SickerShake();
            }
        }

        private void UpdateRotation() {
            _indicator.rotation = Quaternion.Euler(Vector3.back 
                * Mathf.Lerp(_minDegree, _maxDegree, _heatManager.HeatPercent));
        }

        private void SickerShake() {
            _indicator.rotation = Quaternion.Euler(_indicator.rotation.eulerAngles + Vector3.back * (Mathf.Sin(Time.time * _vibratingSpeed) * 2));
        }
    }
}