using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Code.Gameplay.Platforms
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovingPlatform : Platform
    {
        Rigidbody2D _rigidbody;

        private Vector3 _leftEdge;
        private Vector3 _rightEdge;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, -Camera.main.transform.position.z));
            _rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, -Camera.main.transform.position.z));
        }

        private void OnEnable()
        {
            _rigidbody.velocity = Random.Range(0, 1) == 0 ? Vector2.right : Vector2.left;
        }

        private void FixedUpdate()
        {
            MoveAround();
        }

        private void MoveAround()
        {
            if (transform.position.x < _leftEdge.x)
            {
                _rigidbody.velocity = Vector2.right;
            }
            else if (transform.position.x > _rightEdge.x)
            {
                _rigidbody.velocity = Vector2.left;
            }
        }
    }
}
