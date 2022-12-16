﻿using System;
using System.Collections.Generic;
using Gameplay.Blocks;
using UnityEngine;

namespace Gameplay {
    public class HeatLink : MonoBehaviour {

        [SerializeField] private HeatManager _manager;
        [SerializeField] private BlockData _data;
        [SerializeField] private List<Line> _lines;

        private void OnEnable() {
            foreach (Line line in _lines) {
                line.OnAnyBlockDied += HandleBlockDeath;
            }
        }
        
        private void OnDisable() {
            foreach (Line line in _lines) {
                line.OnAnyBlockDied += HandleBlockDeath;
            }
        }

        private void HandleBlockDeath(Block block) {
            switch (block.Type) {
                case BlockType.Cold: _manager.Cooldown(_data.ColdAdd); break;
                case BlockType.Hot: _manager.HeatUp(_data.HotAdd); break;
            }
        }
    }
}