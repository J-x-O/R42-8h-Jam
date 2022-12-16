using System;
using Gameplay.Blocks;
using UnityEngine;

namespace Gameplay {
    public class DeathListener : MonoBehaviour {

        [SerializeField] private HeatManager _heat;
        [SerializeField] private GameObject _screen;

        private void Awake() => _screen.SetActive(false);

        private void OnEnable() => _heat.OnDeath += HandleDeath;

        private void OnDisable() => _heat.OnDeath -= HandleDeath;


        private void HandleBlockClick(Block obj) {
            
        }
        
        private void HandleDeath() => _screen.SetActive(true);
    }
}