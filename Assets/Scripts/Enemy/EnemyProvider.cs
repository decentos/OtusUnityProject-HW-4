using System;
using UnityEngine;
using MVCExample.Events;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

namespace MVCExample
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy /*, IGameOverEvent, IScoreAddEvent*/
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private CompositeMove _compositeMove;
        private IGameOverEvent _gameOverEventImplementation;

        // public event GameOverEventHandler GameOver = delegate { };
        // public event ScoreAddEventHandler ScoreAdded = delegate { };
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.position - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.position).normalized;
                _rigidbody2D.velocity = dir * _speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //TODO поменять на теги
            if (string.Equals(other.gameObject.name, "player") )
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //!TODO Need some eventManager
                // GameOver();
            }
            else if (string.Equals(other.gameObject.name, "bullet"))
            {
                //!TODO Need some eventManager
                // ScoreAdded();               
            }
        }

        public void SerializeGameData(CompositeMove compositeMove)
        {
            _compositeMove = compositeMove;
        }

        private void OnDisable()
        {
            _compositeMove.RemoveUnit(this);
        }
    }
}
