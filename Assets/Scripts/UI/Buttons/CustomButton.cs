using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Buttons {
    public class CustomButton : Button {

        public static event Action<CustomButton> OnAnyButtonHovered;
        
        public static event Action<CustomButton> OnAnyButtonClicked;

        public override void OnPointerEnter(PointerEventData eventData) {
            base.OnPointerEnter(eventData);
            OnAnyButtonHovered?.Invoke(this);
        }

        public override void OnPointerDown(PointerEventData eventData) {
            base.OnPointerDown(eventData);
            OnAnyButtonClicked?.Invoke(this);
        }
    }
}