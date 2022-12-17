using System;
using Gameplay.Blocks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay {
    public class InputHure : MonoBehaviour {

        private InputMap _input;
        
        [SerializeField] private HeatManager _manager;
        [SerializeField] private float _spaceIncrement;

        [SerializeField] private Line _top;
        [SerializeField] private Line _right;
        [SerializeField] private Line _bot;
        [SerializeField] private Line _left;

        private void Awake() {
            _input = new InputMap();
            _input.Enable();
        }

        private void OnEnable() {
            _input.Ingame.Up.performed += TopClick;
            _input.Ingame.Right.performed += RightClick;
            _input.Ingame.Down.performed += BotClick;
            _input.Ingame.Left.performed += LeftClick;
            _input.Ingame.HeatUp.performed += HeatUp;
        }
        
        private void OnDisable() {
            _input.Ingame.Up.performed -= TopClick;
            _input.Ingame.Right.performed -= RightClick;
            _input.Ingame.Down.performed -= BotClick;
            _input.Ingame.Left.performed -= LeftClick;
            _input.Ingame.HeatUp.performed -= HeatUp;
        }
        
        private void HeatUp(InputAction.CallbackContext obj) => _manager.HeatUp(_spaceIncrement);
        private void TopClick(InputAction.CallbackContext obj) => _top.Click();
        private void RightClick(InputAction.CallbackContext obj) => _right.Click();
        private void BotClick(InputAction.CallbackContext obj) => _bot.Click();
        private void LeftClick(InputAction.CallbackContext obj) => _left.Click();
    }
}