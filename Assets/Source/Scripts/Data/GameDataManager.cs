using Source.Scripts.Configs;
using Source.Scripts.Data.Interfaces;
using Source.Scripts.Entities;
using UnityEngine;

namespace Source.Scripts.Data
{
    public class GameDataManager : MonoBehaviour, IGameFieldProvider, ILevelConfigProvider
    {
        Block[,] _blocks;
        Block[,] IGameFieldProvider.Blocks => _blocks;

        //Default tetris field size
        Vector2Int _fieldSize = new Vector2Int(10, 22);
        Vector2Int IGameFieldProvider.FieldSize => _fieldSize;

        LevelConfig _config;
        LevelConfig ILevelConfigProvider.Config => _config;

        void Start()
        {
            _blocks = new Block[_fieldSize.x, _fieldSize.y];
        }

        void ILevelConfigProvider.SetCurrentConfig(LevelConfig config)
        {
            _config = config;
        }
    }
}