using Source.Scripts.Configs;
using Source.Scripts.Data.Interfaces;
using Source.Scripts.Statics.Environment;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.Managers
{
    [DefaultExecutionOrder(10)]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] string _levelConfigsPath;

        void Start()
        {
            // TODO: Add some basic DI for performance purposes.
            var monoBehaviours = FindObjectsOfType<MonoBehaviour>(); 
            var configs = Resources.LoadAll<LevelConfig>(_levelConfigsPath);
            var levelConfigProvider = monoBehaviours.OfType<ILevelConfigProvider>().First();
            var levelNumberProvider = monoBehaviours.OfType<ILevelNumberProvider>().First();

            // Levels are looped
            var level = levelNumberProvider.Level % configs.Length;
            var config = configs[level];

            levelConfigProvider.SetCurrentConfig(config);
            GameEvents.LevelStartedEvent?.Invoke(levelNumberProvider.Level);
        }
    }
}
