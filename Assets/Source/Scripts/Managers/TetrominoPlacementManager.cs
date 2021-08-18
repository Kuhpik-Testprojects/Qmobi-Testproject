using Source.Scripts.Data.Interfaces;
using Source.Scripts.Entities;
using Source.Scripts.Statics.Environment;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.Managers
{
    public class TetrominoPlacementManager : MonoBehaviour
    {
        IGameFieldProvider _gameFieldProvider;
        Tetromino _currentTetromino;

        void Start()
        {
            _gameFieldProvider = FindObjectsOfType<MonoBehaviour>().OfType<IGameFieldProvider>().First();
            GameEvents.TetrominoSpawnedEvent += SetTetromino;
            GameEvents.BlockPlacedEvent += Place;
        }

        void SetTetromino(Tetromino tetromino)
        {
            _currentTetromino = tetromino;
        }

        void Place()
        {
            foreach (var block in _currentTetromino.Blocks)
            {
                _gameFieldProvider.Blocks[block.PositionX, block.PositionY] = block;
                block.transform.SetParent(null, true);
            }

            // TODO: Break filled row
            // TODO: Game over

            Destroy(_currentTetromino);
        }
    }
}