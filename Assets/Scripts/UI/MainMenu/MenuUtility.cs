using Gameplay;
using Gameplay.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

namespace UI.MainMenu {
    public class MenuUtility : MonoBehaviour {

        public void LoadLevel(LevelAsset asset) {
            LevelAsset.Current = asset;
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
        
        public void LoadScene(string identifier) {
            SceneManager.LoadScene(identifier, LoadSceneMode.Single);
        }
        
        public void QuitGame() {
            Application.Quit();
        }
        
    }
}