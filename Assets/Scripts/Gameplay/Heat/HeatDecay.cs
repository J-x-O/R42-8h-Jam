using System;
using UnityEngine;

namespace Gameplay {
    public class HeatDecay : MonoBehaviour {
        
        [SerializeField] private HeatManager _manager;
        [SerializeField] private float _decayRate = 0.1f;
        
        public void Update() {
            _manager.Cooldown(_decayRate);
        }
    }
}