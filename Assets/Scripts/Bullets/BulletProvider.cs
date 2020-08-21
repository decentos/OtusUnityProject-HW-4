using System;
using System.Collections;
using UnityEngine;

namespace MVCExample
{
    public class BulletProvider : MonoBehaviour, IBullet, IMove
    {
        private static Camera _camera;
        
        private Vector3 _moveDirection;
        private Transform _transform;
        [SerializeField] 
        private float _speed;
        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
        }

        public void Pull()
        {
            _transform.position = Vector3.zero;
            gameObject.SetActive(true);
            _moveDirection = ((Vector2)_camera.ScreenToWorldPoint(Input.mousePosition)).normalized;
        }

        public void Move(Vector3 point)
        {
            _transform.Translate(_moveDirection * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.SetActive(false);
            //TODO Add score event
        }
    }
}