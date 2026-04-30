using UnityEngine;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class PlatformContainer
    {
        public PlatformContainer(Transform container)
        {
            Container = container;
        }

        public Transform Container { get; }
    }
}