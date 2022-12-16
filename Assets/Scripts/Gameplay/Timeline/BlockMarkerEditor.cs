using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace Gameplay.Timeline {
    [CustomTimelineEditor(typeof(BlockMarker))]
    public class BlockMarkerEditor : MarkerEditor {
        
        public override void DrawOverlay(IMarker marker, MarkerUIStates uiState, MarkerOverlayRegion region) {
            if (marker is BlockMarker block) {
                Color color = block.BlockType == BlockType.Hot ? Color.red : Color.cyan;
                EditorGUI.DrawRect(region.markerRegion,  color);
            }
        }
    }
}