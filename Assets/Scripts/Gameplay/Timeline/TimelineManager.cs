using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Gameplay.Timeline {
    public class TimelineManager : MonoBehaviour {

        [SerializeField] private PlayableDirector _director;

        private void Start() {
            //if(_director.playableAsset is TimelineAsset
            _director.Play();
        }
    }
}
