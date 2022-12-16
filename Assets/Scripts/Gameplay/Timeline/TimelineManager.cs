using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Gameplay.Timeline {
    public class TimelineManager : MonoBehaviour {

        public static TimelineAsset Map { get; set; }
        
        [SerializeField] private PlayableDirector _director;

        private void Start() {
            if(Map != null) _director.playableAsset = Map;
            _director.Play();
        }
    }
}
