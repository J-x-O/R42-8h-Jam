using System;
using System.Threading;
using Gameplay.Timeline;
using UnityEngine;
using UnityEngine.Playables;

namespace Gameplay.Blocks {
    public class BlockSpawner : MonoBehaviour, INotificationReceiver {
        
        [SerializeField] private Block _hotPrefab;
        [SerializeField] private Block _icePrefab;

        [SerializeField] private Line _top;
        [SerializeField] private Line _right;
        [SerializeField] private Line _bot;
        [SerializeField] private Line _left;
        
        public void OnNotify(Playable origin, INotification notification, object context) {
            if (notification is not BlockMarker marker) return;
            
            Block spawned = marker.BlockType switch {
                BlockType.Cold => Instantiate(_icePrefab, transform),
                BlockType.Hot => Instantiate(_hotPrefab, transform),
                _ => throw new ArgumentOutOfRangeException()
            };
            Line target = marker.Direction switch {
                Direction.Top => _top,
                Direction.Right => _right,
                Direction.Bot => _bot,
                Direction.Left => _left,
                _ => throw new ArgumentOutOfRangeException()
            };
            target.SentBlock(spawned);
        }
    }
}