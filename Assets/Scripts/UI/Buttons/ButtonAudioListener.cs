using Beta.Audio;
using UnityEngine;

namespace UI.Buttons {
    
    public class ButtonAudioListener : MonoBehaviour {
        
        [SerializeField] private SFXAudioEvent _uiHoverSfx;
    
        [SerializeField] private SFXAudioEvent _uiClickSfx;
        
        [SerializeField] private SFXManager _sfxManager;
        
        private void Start() {
            CustomButton.OnAnyButtonHovered += HandleAnyButtonHovered;
            CustomButton.OnAnyButtonClicked += HandleAnyButtonClicked;
        }
    
    
        private void OnDestroy() {
            CustomButton.OnAnyButtonHovered -= HandleAnyButtonHovered;
            CustomButton.OnAnyButtonClicked -= HandleAnyButtonClicked;
        }
     
        
        private void HandleAnyButtonHovered(CustomButton button) => _sfxManager.PlaySFX(_uiHoverSfx);
        private void HandleAnyButtonClicked(CustomButton button) => _sfxManager.PlaySFX(_uiClickSfx);
    }
}