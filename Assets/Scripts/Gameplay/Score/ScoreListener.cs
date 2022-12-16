using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Blocks;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay {
    public class ScoreListener : MonoBehaviour {

        [SerializeField] private HeatManager _heat;
        [SerializeField] private float _sweetSpotRate = 2;
        //private Coroutine _sweetRoutine;
        
        
        [SerializeField] private int _scoreBlock;
        [SerializeField] private List<Line> _lines;

        private void OnEnable() {
            ScoreManager.ResetScore();
            foreach (Line line in _lines) {
                line.OnBlockClicked += HandleBlockClick;
            }
            //_heat.OnSweetSpotRestored += HandleSweetSpot;
        }

        private void OnDisable() {
            foreach (Line line in _lines) {
                line.OnAnyBlockDied -= HandleBlockClick;
            }
            //_heat.OnSweetSpotRestored -= HandleSweetSpot;
        }
        
        // private void HandleSweetSpot() {
        //     if(_sweetRoutine != null) _sweetRoutine = StartCoroutine(AddPoints());
        // }
        //
        // private IEnumerator AddPoints() {
        //     while (_heat.SweetSpot) {
        //         yield return new WaitForSeconds(_sweetSpotRate);
        //         ScoreManager.AddScore(1);
        //     }
        //     _sweetRoutine = null;
        // }


        
        private void HandleBlockClick(Block obj) {
            float multiplier = _heat.SweetSpot ? _sweetSpotRate : 1;
            ScoreManager.AddScore((int)(obj.CalculateAccuracy() * _scoreBlock * multiplier));
        }

    }
}