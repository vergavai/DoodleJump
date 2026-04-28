using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.Tracker
{
    public class PlayerTrackerBehaviour : MonoBehaviour
    {
        [SerializeField] private float _yOffset;
        
        private PlayerTracker _tracker;

        [Inject]
        private void Construct(PlayerMovementBehaviour player)
        {
            
            _tracker = new PlayerTracker(player, transform, _yOffset);
        }

        private void Update()
        {
            _tracker.UpdatePosition();
        }
    }
}
