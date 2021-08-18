using UnityEngine;

namespace Source.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] string _environment = string.Empty;

        /// <summary>
        /// Returns pre-generated level environment in Json format. 
        /// Empty string means there is no pre-generated blocks.
        /// </summary>
        public string Environment => _environment;
    }
}