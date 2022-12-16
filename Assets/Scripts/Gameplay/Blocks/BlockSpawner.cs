using UnityEngine;
using UnityEngine.Playables;

namespace Gameplay.Blocks {
    public class BlockSpawner : MonoBehaviour, INotificationReceiver {
        public void OnNotify(Playable origin, INotification notification, object context) {
            
        }
    }
}