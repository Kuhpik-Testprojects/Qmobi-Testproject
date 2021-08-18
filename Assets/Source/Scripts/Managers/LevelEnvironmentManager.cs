using Source.Scripts.Data.Interfaces;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.Managers
{
    [DefaultExecutionOrder(20)]
    public class LevelEnvironmentManager : MonoBehaviour
    {
        [SerializeField] GameObject _blockPrefab;

        void Start()
        {
            var monoBehaviours = FindObjectsOfType<MonoBehaviour>();
            var levelConfigProvider = monoBehaviours.OfType<ILevelConfigProvider>().First();
            var gameFieldProvider = monoBehaviours.OfType<IGameFieldProvider>().First();
            var config = levelConfigProvider.Config;

            if (config.Environment != string.Empty)
            {
            
            }
        }
    }
}
