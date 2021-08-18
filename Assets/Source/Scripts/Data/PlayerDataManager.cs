using Source.Scripts.Data.Interfaces;
using Source.Scripts.Statics.Environment;
using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    public class PlayerDataManager : MonoBehaviour, ILevelNumberProvider
    {
        const string saveKey = "Playerdata";

        PlayerData _data;
        int ILevelNumberProvider.Level => _data.Level;
        int ILevelNumberProvider.UniqueLevelsPassed => _data.UniqueLevels;

        void Start()
        {
            //Save progress before next level begins
            GameEvents.NextLevelEvent += Save;

            Load();
        }

        void Save()
        {
            var json = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString(saveKey, json);
        }

        void Load()
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                var json = PlayerPrefs.GetString(saveKey);
                _data = JsonUtility.FromJson<PlayerData>(json);
            }

            else
            {
                _data = new PlayerData();
            }
        }
    }

    [Serializable]
    public class PlayerData
    {
        public int Level;
        public int UniqueLevels;
    }
}