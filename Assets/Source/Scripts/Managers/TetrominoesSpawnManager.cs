using Source.Scripts.Data.Interfaces;
using Source.Scripts.Entities;
using Source.Scripts.Statics.Environment;
using Source.Scripts.Statics.Extensions;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.Managers
{
    [DefaultExecutionOrder(100)]
    public class TetrominoesSpawnManager : MonoBehaviour
    {
        [SerializeField] string _tetrominoesPath;

        IGameFieldProvider _gameFieldProvider;
        GameObject[] _tetrominoPrefabs;

        void Start()
        {
            _gameFieldProvider = FindObjectsOfType<MonoBehaviour>().OfType<IGameFieldProvider>().First();
            _tetrominoPrefabs = Resources.LoadAll<GameObject>(_tetrominoesPath);
            GameEvents.BlockPlacedEvent += Spawn;
            Spawn();
        }

        void Spawn()
        {
            var spawnPosition = new Vector3(_gameFieldProvider.FieldSize.x / 2, _gameFieldProvider.FieldSize.y, 0);
            var tetrominoPrefab = _tetrominoPrefabs.GetRandom();
            var tetrominoComponent = tetrominoPrefab.GetComponent<Tetromino>();

            spawnPosition.x += tetrominoComponent.PlacementOffset.x;
            spawnPosition.y += tetrominoComponent.PlacementOffset.y;

            var tetromino = Instantiate(tetrominoPrefab, spawnPosition, Quaternion.identity).GetComponent<Tetromino>();

            GameEvents.TetrominoSpawnedEvent?.Invoke(tetromino);
        }
    }
}
