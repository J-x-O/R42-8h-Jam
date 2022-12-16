using Gameplay.Blocks;
using UnityEngine;

namespace Gameplay {
    public class InputHure : MonoBehaviour {

        [SerializeField] private HeatManager _manager;
        [SerializeField] private float _spaceIncrement;
        
        [SerializeField] private Line _top;
        [SerializeField] private Line _right;
        [SerializeField] private Line _bot;
        [SerializeField] private Line _left;

        private void Update() {
            if(Input.GetKeyDown("w")) _top.Click();
            if(Input.GetKeyDown("d")) _right.Click();
            if(Input.GetKeyDown("s")) _bot.Click();
            if(Input.GetKeyDown("a")) _left.Click();
            
            if(Input.GetKeyDown("space")) _manager.HeatUp(_spaceIncrement);
        }
    }
}