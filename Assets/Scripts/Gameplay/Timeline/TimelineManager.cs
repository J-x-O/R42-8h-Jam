using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Gameplay.Timeline {
    public class TimelineManager : MonoBehaviour {

        [SerializeField] private PlayableDirector _director;

        private void Start() {
            if(LevelAsset.Current != null) _director.playableAsset = LevelAsset.Current.Asset;
            _director.Play();
        }
    }
}
