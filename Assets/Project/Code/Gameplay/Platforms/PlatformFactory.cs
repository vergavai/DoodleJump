using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Platforms
{
    public class PlatformFactory : PlaceholderFactory<GameObject, Platform>
    {
        public List<Platform> CreateMany(GameObject prefab, int count, Transform parent)
        {
            List<Platform> platforms = new List<Platform>();

            for (int i = 0; i < count; i++)
            {
                Platform platform = Create(prefab);
                platform.gameObject.SetActive(false);
                platforms.Add(platform);
                platform.transform.SetParent(parent);
            }
            
            return platforms;
        }
    }
}