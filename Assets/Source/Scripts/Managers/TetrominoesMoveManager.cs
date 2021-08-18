using Source.Scripts.Data.Interfaces;
using Source.Scripts.Entities;
using Source.Scripts.Statics.Environment;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.Managers
{
    public class TetrominoesMoveManager : MonoBehaviour
    {
        [SerializeField] [Tooltip("In seconds")] float _delayBetweenMovement;
        [SerializeField] [Tooltip("In seconds. Must be bigger that delay betwee movement")] float _delayBetweenFall;
        [SerializeField] float _additionalTimeAfterMovingSideway;

        IGameFieldProvider _gameFieldProvider;
        Tetromino _targetTetromino;

        Vector2Int _down = Vector2Int.down;
        Vector2Int _up = Vector2Int.up;

        float _timer;
        float _fallTimer;

        void Start()
        {
            GameEvents.UserInputEvent += OnInput;
            GameEvents.TetrominoSpawnedEvent += OnTetrominoChanged;
            _gameFieldProvider = FindObjectsOfType<MonoBehaviour>().OfType<IGameFieldProvider>().First();
        }

        void Update()
        {
            _timer += Time.deltaTime;
            _fallTimer += Time.deltaTime;

            if (_fallTimer >= _delayBetweenFall)
            {
                FallDown();
            }
        }

        void OnInput(Vector2Int direction)
        {
            if (direction != _up && _timer >= _delayBetweenMovement)
            {
                if (CanMove(direction))
                {
                    _targetTetromino.transform.Translate(new Vector3(direction.x, direction.y, 0), Space.World);
                    _fallTimer -= _additionalTimeAfterMovingSideway;
                    _timer = 0;

                    CheckPlacement();
                }
            }
        }

        void FallDown()
        {
            _targetTetromino.transform.Translate(Vector3.down, Space.World);
            CheckPlacement();
            _fallTimer = 0;
        }

        void OnTetrominoChanged(Tetromino tetromino)
        {
            _targetTetromino = tetromino;
            enabled = true;
        }

        void CheckPlacement()
        {
            foreach (var block in _targetTetromino.Blocks)
            {
                var lowerBlockIndex = block.PositionY - 1;

                if (lowerBlockIndex == -1 || // In the bottom
                    _gameFieldProvider.Blocks[block.PositionX, lowerBlockIndex] != null) //Or has a block underneath
                {
                    enabled = false; //Stops update function to prevent falling twice in cases where both timers are the same.
                    GameEvents.BlockPlacedEvent?.Invoke();
                    break;
                }
            }
        }

        bool CanMove(Vector2Int direction)
        {
            var canMove = true;

            foreach (var block in _targetTetromino.Blocks)
            {
                if (block.PositionX + direction.x > _gameFieldProvider.FieldSize.x - 1 ||
                    block.PositionX + direction.x < 0)
                {
                    canMove = false;
                    break;
                }
            }

            return canMove;
        }
    }
}
