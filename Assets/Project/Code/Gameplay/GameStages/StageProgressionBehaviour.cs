using Project.Code.Gameplay.ObjectGenerator;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.GameStages
{
    public class StageProgressionBehaviour : MonoBehaviour
    {
        [SerializeField] private PlatformGenerator _platformGenerator;
        
        private StageProgression _stageProgression;

        [Inject]
        private void Construct(StageProgression stageProgression)
        {
            _stageProgression = stageProgression;
        }

        private void OnEnable()
        {
            _stageProgression.SubscribeToEvents();
        }

        private void OnDisable()
        {
            _stageProgression.UnsubscribeFromEvents();
        }
    }
}