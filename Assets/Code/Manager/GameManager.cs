
using Code.Helper;
using Lagger.Code.Level;
using Lagger.Code.Player;
using Lagger.Code.TimeGame;
using UnityEngine;
using UnityEngine.Events;


namespace Lagger.Code.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private bool _isPause = false;
        [SerializeField] private bool _isWin = false;
        [SerializeField] private bool _isLose = false;
        
        public UnityEvent OnWin;
        public UnityEvent OnLose;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private TimeInGame _timeInGame;
        [SerializeField] private PlayerManager _playerManager;
        
        public bool IsPause
        {
            get => _isPause;
            set
            {
                _isPause = value;
            }
        }
        public bool IsWin => _isWin;
        public bool IsLose => _isLose;
        public void Win()
        {
            _isWin = true;
            EventManger<int>.RaiseEvent("AddMoney",_levelManager.GetRewardLevel());
            int star = Helper.CaculateStar(_timeInGame.timelimit, _timeInGame.playtime);
            _levelManager.SaveDataLevel(star);
            EventManager.RaisEvent("OpenUIAfterGame");
            OnWin?.Invoke();
        }
        public void Pause()
        {
            _isPause = true;
           EventManager.RaisEvent("ResposPlayer");
        }
        public void Lose()
        {
            _isLose = true;
            OnLose?.Invoke();
            EventManager.RaisEvent("OpenUIDead");
        }

        public void PlayGame()
        {
            Clear();
            _levelManager.LoadCurrentLevel();
            _playerManager.ActivePlayer();
            _timeInGame.InitTime(_levelManager.GetTimeCurLevel());
            _playerManager.SetPosPlayer(_levelManager.GetPosSpawnPlayer());
            EventManager.RaisEvent("CloseCurrentUI");
            EventManager.RaisEvent("ActiveUIInGame");
            EventManager.RaisEvent("ResetPlayerHeal");
           
        }
        
        public void NextLevel()
        {
            Clear();
            _levelManager.NextLevel();
            EventManager.RaisEvent("CloseUIAfterGame");
            PlayGame();
            
        }
        public void RePlay()
        {
            Clear();
            EventManager.RaisEvent("HealRePlay");
            EventManager.RaisEvent("ResposPlayer");
            _timeInGame.AddTimeRePlay();
        }

        public void Reload()
        {
            Clear();
            EventManager.RaisEvent("CloseUIAfterGame");
            PlayGame();
        }

        private void Clear()
        {
            _isPause = false;
            _isLose = false;
            _isWin = false;
        }
    }

}
