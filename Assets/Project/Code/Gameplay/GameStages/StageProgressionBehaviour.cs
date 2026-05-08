using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.GameStages
{
    public class StageProgressionBehaviour : MonoBehaviour
    {
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