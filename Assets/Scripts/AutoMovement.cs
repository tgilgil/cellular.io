using System.Diagnostics;
using UnityEngine;

namespace Assets
{
    public class AutoMovement : MonoBehaviour
    {
        public float Speed = 2;
        public int TimeBetweenDirectionChangeInMs = 100;

        private Vector3 _lastDirection;
        private Stopwatch _stopwatch = new Stopwatch();

        void FixedUpdate()
        {
            Move();
        }

        private Vector2 GenerateRandomDirectionalVector()
        {
            var x = Random.Range(0, 2);
            var y = Random.Range(0, 2);

            return new Vector2(
                x == 1 ? 1 : -1,
                y == 1 ? 1 : -1);
        }

        private void Move()
        {
            _stopwatch.Start();
            Vector2 direction;

            if (_stopwatch.ElapsedMilliseconds > TimeBetweenDirectionChangeInMs)
            {
                direction = GenerateRandomDirectionalVector().normalized;
                _stopwatch.Reset();
            }
            else
            {
                direction = _lastDirection;
            }

            transform.Translate(direction * Speed * Time.fixedDeltaTime);
            _lastDirection = direction;
        }
    }
}
