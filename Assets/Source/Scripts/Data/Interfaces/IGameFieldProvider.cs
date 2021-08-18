using Source.Scripts.Entities;
using UnityEngine;

namespace Source.Scripts.Data.Interfaces
{
    public interface IGameFieldProvider
    {
        Block[,] Blocks { get; }
        Vector2Int FieldSize { get; }
    }
}
