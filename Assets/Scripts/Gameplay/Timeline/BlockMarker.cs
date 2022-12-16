using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Gameplay.Timeline {
    public class BlockMarker : Marker, INotification {
        public PropertyName id => "Hot";

        public BlockType BlockType;
        public Direction Direction;
    }
}