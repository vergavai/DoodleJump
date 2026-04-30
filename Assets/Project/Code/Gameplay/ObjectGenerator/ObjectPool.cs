using System.Collections.Generic;
using UnityEngine;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class ObjectPool
    {
        private List<GameObject> _pool = new List<GameObject>();
        
        public bool TryGetRandomObject(out GameObject result)
        {
            List<GameObject> disabledObjects = GetDisabledObjects();
            
            for (int i = 0; i < disabledObjects.Count;)
            {
                int randomIndex = Random.Range(0, disabledObjects.Count);
                result = disabledObjects[randomIndex];
                return result;
            }

            result = null;
            return result;
        }

        public void AddPlatforms(List<GameObject> platforms)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                _pool.Add(platforms[i]);
            }
        }

        public void DisableObjectsBelowCamera(float cameraY, float offset)
        {
            for (var i = 0; i < _pool.Count; i++)
            {
                GameObject item = _pool[i];
                if (item.activeSelf && item.transform.position.y < cameraY - offset)
                {
                    item.SetActive(false);
                }
            }
        }

        private List<GameObject> GetDisabledObjects()
        {
            List<GameObject> result = new List<GameObject>();
            
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeSelf)
                {
                    result.Add(_pool[i]);
                }
            }
            
            return result;
        }
    }
}