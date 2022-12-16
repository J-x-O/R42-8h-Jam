using System;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;

namespace Gameplay {
    public class ObservableBool {

        public bool Value { get; private set; }
        public event Action<bool> OnValueChanged;

        public void Set(bool newValue) {
            bool oldValue = Value;
            Value = newValue;
            if (oldValue != newValue) OnValueChanged.TryInvoke(newValue);
        }
        
        private ObservableBool(bool b) {
            Value = b;
        }
        
        public static implicit operator bool(ObservableBool d) => d.Value;
        public static implicit operator ObservableBool(bool d) => new ObservableBool(d);
        
    }
}