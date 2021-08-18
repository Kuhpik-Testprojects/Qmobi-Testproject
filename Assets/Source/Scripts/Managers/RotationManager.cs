using Source.Scripts.Entities;
using Source.Scripts.Statics.Environment;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Scripts.Managers
{
    public class RotationManager : MonoBehaviour
    {
        [SerializeField] [Tooltip("In seconds")] float _delayBetweenRotations;

        const float _rotationAngle = 90;
        Tetromino _currentTetromino;
        float _rotationValue;
        float _timer;

        void Start()
        {
            GameEvents.TetrominoSpawnedEvent += SetTetromino;
        }

        void Update()
        {
            _timer += Time.deltaTime;
        }

        void SetTetromino(Tetromino tetromino)
        {
            _currentTetromino = tetromino;
            _rotationValue = 0;
        }

        void Rotate()
        {
            if (_timer >= _delayBetweenRotations)
            {
                _rotationValue += _rotationAngle;
                _currentTetromino.transform.rotation = Quaternion.Euler(0, 0, _rotationValue);
                _timer = 0;
            }
        }

        /// <summary>
        /// Used in Player Input component via Inspector
        /// </summary>
        public void OnPlayerInput(InputAction.CallbackContext context)
        {
            Rotate();
        }
    }
}
