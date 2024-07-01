
using System;
using System.Collections.Generic;
using Lagger.Code.Player;
using UnityEngine;

namespace Lagger.Code.Level
{
    public class LevelManager : Singleton<LevelManager>
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

        public void SaveDataLevel(int star)
        {
            if(_listLevels[_currentLevel].stars <= star) return;
            _listLevels[_currentLevel].stars = star;
        }

        public LevelConfig GetCurrentLevel()
        {
            return _listLevels[_currentLevel];
        }
        
    }

}
