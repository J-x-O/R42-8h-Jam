using System;
using Gameplay.Blocks;
using UnityEngine;

namespace Gameplay {
    public class InputHure : MonoBehaviour {
        
        [SerializeField] private Line _top;
        [SerializeField] private Line _right;
        [SerializeField] private Line _bot;
        [SerializeField] private Line _left;

        private void Update() {
            if(Input.GetKeyDown("w")) _top.Click();
            if(Input.GetKeyDown("d")) _right.Click();
            if(Input.GetKeyDown("s")) _bot.Click();
            if(Input.GetKeyDown("a")) _left.Click();

            if (Input.GetKeyDown(KeyCode.UpArrow)) _top.Click();
            if (Input.GetKeyDown(KeyCode.RightArrow)) _right.Click();
            if (Input.GetKeyDown(KeyCode.DownArrow)) _bot.Click();
            if (Input.GetKeyDown(KeyCode.LeftArrow)) _left.Click();
        }
    }
}