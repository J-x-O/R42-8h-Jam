using Gameplay.Timeline;
using UnityEngine;
using UnityEngine.Playables;

namespace Gameplay.Blocks {
    public class BlockSpawner : MonoBehaviour, INotificationReceiver {

        [Tooltip("How long it takes for a block to go down a line")]
        [SerializeField] private float _blockSpeed;
        [SerializeField] private Block _blockPrefab;

        [SerializeField] private HeatManager _manager;
        
        [SerializeField] private Line _top;
        [SerializeField] private Line _right;
        [SerializeField] private Line _bot;
        [SerializeField] private Line _left;
        
        public void OnNotify(Playable origin, INotification notification, object context) {

            if (notification is BlockMarker marker) {
                Block spawned = Instantiate(_blockPrefab);
            }
        }
    }
}