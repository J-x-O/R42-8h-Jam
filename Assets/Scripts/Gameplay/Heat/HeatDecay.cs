using System;
using UnityEngine;

namespace Gameplay {
    public class HeatDecay : MonoBehaviour {
        
        [SerializeField] private HeatManager _manager;
        [SerializeField] private float _baseDecay = 0.1f;
        private float DecayRate => LevelAsset.Current != null
            ? LevelAsset.Current.DecayRate : _baseDecay;
        
        public void Update() => _manager.Cooldown(DecayRate * Time.deltaTime);
    }
}