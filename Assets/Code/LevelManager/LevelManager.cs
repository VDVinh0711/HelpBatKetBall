
using System;
using System.Collections.Generic;
using Lagger.Code.Data;
using Lagger.Code.Model;
using Lagger.Code.Player;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace Lagger.Code.Level
{
    public class LevelManager : Singleton<LevelManager>,ISaveData
    {
        private const int maxLevel = 3;
        [SerializeField] private List<LevelConfig> _listLevels = new();
        [SerializeField] private int _currentLevel = 0;
        private Transform _currentLevelSawn;
        
        public int MaxLevel => maxLevel;
        public List<LevelConfig> ListLevel => _listLevels;
        
        public void LoadCurrentLevel()
        {
            if(_currentLevelSawn!=null && _listLevels[_currentLevel].mapPrefabs.name != _currentLevelSawn.name) Destroy(_currentLevelSawn.gameObject);
            if (_currentLevelSawn == null || _listLevels[_currentLevel].mapPrefabs.name != _currentLevelSawn.name)
            {
                _currentLevelSawn = Instantiate(_listLevels[_currentLevel].mapPrefabs);
                _currentLevelSawn.name = _listLevels[_currentLevel].mapPrefabs.name;
            }
            _currentLevelSawn.position = Vector2.zero;
        }
        
        public void LoadLastLevelUnLock()
        {
            for (int i = 0; i < maxLevel; i++)
            {
                if(!_listLevels[i].isLock) continue;
                _currentLevel = i-1;
                break;
            }
        }
        
        
        public void NextLevel()
        {
            _currentLevel++;
        }
        public void UnLockNextLevel()
        {
            _listLevels[_currentLevel].isLock = false;
        }
        public void LoadLevelIndex(int index)
        {
            _currentLevel = index;
        }
        public Vector2 GetPosSpawnPlayer()
        {
            return _listLevels[_currentLevel].posPlayer;
        }
        public int GetTimeCurLevel()
        {
            return _listLevels[_currentLevel].timeRequird;
        }
        public int GetRewardLevel()
        {
              return _listLevels[_currentLevel].mapReward;
        }
        public void InsertDataLevel(int star)
        {
            if(_listLevels[_currentLevel].stars <= star) return;
            _listLevels[_currentLevel].stars = star;
        }

        public LevelConfig GetCurrentLevel()
        {
            return _listLevels[_currentLevel];
        }

        
        public string Save()
        {
            List<ModelLevel> datalevel = new();
            foreach (var level in _listLevels)
            {
                if(level.isLock) break;
                ModelLevel dataAdd = new ModelLevel(level.idLevel, level.stars);
                datalevel.Add(dataAdd);
            }
            return JsonConvert.SerializeObject(datalevel);
        }

        public void Load(string obj)
        {
            print("Data Level");
            var dataLoads = JsonConvert.DeserializeObject<List<ModelLevel>>(obj);
            foreach (var data in dataLoads)
            {
                foreach (var level in _listLevels)
                {
                    if (data.idLevel == level.idLevel)
                    {
                        level.LoadDataLevelConfig(data.starOfLevel);
                    }
                }
            }
        }
    }

}
