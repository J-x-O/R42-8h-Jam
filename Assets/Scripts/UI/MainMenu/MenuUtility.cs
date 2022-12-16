using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu {
    public class MenuUtility : MonoBehaviour {

        public void LoadScene(string identifier) {
            SceneManager.LoadScene(identifier, LoadSceneMode.Additive);
        }
        
        public void QuitGame() {
            Application.Quit();
        }
        
    }
}