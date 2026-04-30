using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Platforms
{
    public class MovingPlatformFactory : PlaceholderFactory<MovingPlatform>
    {
        public List<MovingPlatform> CreateMany(int count, Transform parent)
        {
            List<MovingPlatform> platforms = new List<MovingPlatform>();

            for (int i = 0; i < count; i++)
            {
                MovingPlatform platform = Create();
                platforms.Add(platform);
                platform.transform.SetParent(parent);
            }
            
            return platforms;
        }
    }
}