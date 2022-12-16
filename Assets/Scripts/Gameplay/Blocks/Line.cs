using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay.Blocks {
    public abstract class Line : MonoBehaviour {

        public event Action OnAnyClick;
        public event Action<Block> OnAnyBlockDied;
        
        public event Action<Block> OnBlockClicked;
        public event Action<Block> OnBlockMissed;
        public event Action<Block> OnBlockDied;
        
        [SerializeField] private BlockData _data;
        [SerializeField] private HeatManager _manager;

        private readonly List<Block> _runningBlocks = new();

        public bool Click() {
            OnAnyClick.TryInvoke();
            if (_runningBlocks.Count <= 0) return false;
            
            Block first = _runningBlocks.ElementAt(0);
            bool result = first.IsClickable();
            if (result) OnBlockClicked.TryInvoke(first);
            else OnBlockMissed.TryInvoke(first);
            StopBlock(first, result);
            return result;
        }

        private void StopBlock(Block target, bool result = false) {
            OnAnyBlockDied.TryInvoke(target);
            _runningBlocks.Remove(target);
            target.StopBlock(result);
        }
        
        public void SentBlock(Block target) {
            _runningBlocks.Add(target);
            target.RunBlock(this, () => {
                _runningBlocks.Remove(target);
                OnBlockDied.TryInvoke(target);
                StopBlock(target);
            });
        }
        
        public abstract Vector3 EvaluatePosition(float progressPercent);


        
    }
}