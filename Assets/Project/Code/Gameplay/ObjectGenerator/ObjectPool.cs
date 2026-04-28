using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class ObjectPool
    {
        private GameObject _container;
        private Camera _camera;
        private List<GameObject> _pool = new List<GameObject>();

        public List<GameObject> Pool => _pool;

        public ObjectPool(GameObject container, Camera camera)
        {
            _container = container;
            _camera = camera;
        }

        public void Shuffle()
        {
            int n = _pool.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (_pool[i], _pool[j]) = (_pool[j], _pool[i]);
            }
        }

        public void ResetPool()
        {
            foreach (GameObject item in _pool)
            {
                item.SetActive(false);
            }
        }

        public bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => !p.activeSelf);

            return result;
        }
        
        public bool TryGetRandomObject(out GameObject result)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                int randomIndex = Random.Range(0, _pool.Count);
                if (!_pool[randomIndex].activeSelf)
                {
                    result = _pool[randomIndex];
                    return result;
                }
            }

            result = null;
            return result;
        }
        
        public void AddNewType(GameObject prefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject spawned = Object.Instantiate(prefab, _container.transform);
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
        }

        public void RemoveRandomObjects(int count)
        {
            List<GameObject> inactiveObjects = _pool.Where(p => !p.activeSelf).ToList();
            
            if (inactiveObjects.Count <= 0)
                return;

            if (count > inactiveObjects.Count)
            {
                count = inactiveObjects.Count;
            }
            
            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(0, inactiveObjects.Count);
                
                GameObject item = inactiveObjects[randomIndex];
                
                Object.Destroy(item);
                
                inactiveObjects.RemoveAt(randomIndex);
                
                _pool.Remove(item);
            }
        }
        
        public int GetActiveCount()
        {
            int count = 0;
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].activeSelf)
                    count++;
            }
            return count;
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
    }
}