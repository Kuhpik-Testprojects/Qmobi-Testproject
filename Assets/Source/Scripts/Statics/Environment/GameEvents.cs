using Source.Scripts.Entities;
using System;
using UnityEngine;

namespace Source.Scripts.Statics.Environment
{
    /// <summary>
    /// Collection of game related events. Use these for writing decoupled code.
    /// Note: Don't forget to call Clear() method everytime you begin new level.
    /// </summary>
    public static class GameEvents
    {
        // For my own projects I often use Signals plugin
        // It has friendly API and allows set specific order for listeners.
        // https://openupm.com/packages/com.supyrb.signals/
        // ...

        public static Action<float> ScoreChangedEvent;
        public static Action BlockPlacedEvent;
        public static Action RowCompleteEvent;
        public static Action RowDestroyedEvent;

        public static Action<Vector2Int> UserInputEvent;

        public static Action<Tetromino> TetrominoSpawnedEvent;

        /// <summary>
        /// Can be used to display level number in UI.
        /// </summary>
        public static Action<int> LevelStartedEvent;

        /// <summary>
        /// Fired when level ends
        /// </summary>
        public static Action LevelEndEvent;

        /// <summary>
        /// Fired before loading new scene
        /// </summary>
        public static Action NextLevelEvent;

        /// <summary>
        /// Clears all listeners from events
        /// </summary>
        public static void Clear()
        {
            ScoreChangedEvent = null;
            BlockPlacedEvent = null;
            RowCompleteEvent = null;
            RowDestroyedEvent = null;
            UserInputEvent = null;
            TetrominoSpawnedEvent = null;
            LevelStartedEvent = null;

            LevelEndEvent = null;
            NextLevelEvent = null;
        }
    }
}
