
using Code.Helper;
using Lagger.Code.Level;
using Lagger.Code.Player;
using Lagger.Code.TimeGame;
using Lagger.Code.Untils;
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

        public bool IsPause => _isPause;
       
        public bool IsWin => _isWin;
        public bool IsLose => _isLose;
        public void Win()
        {
            _isWin = true;
            int star = Helper.CaculateStar(_timeInGame.timelimit, _timeInGame.playtime);
            _levelManager.InsertDataLevel(star);
            _levelManager.UnLockNextLevel();
            EventManager.RaisEvent(SafeNameEvent.OpenUiAfterGame);
            EventManger<int>.RaiseEvent(SafeNameEvent.AddMoney,_levelManager.GetRewardLevel());
            OnWin?.Invoke();
        }
        public void Pause()
        {
            //Implement More Logic for PauseGame
            _isPause = true;
        }

        public void ResumGame()
        {
            //Implement More Logic for ResumeGame
            _isPause = false;
        }
        public void Lose()
        {
            _isLose = true;
            OnLose?.Invoke();
            EventManager.RaisEvent(SafeNameEvent.OpenUIDead);
        }

        public void PlayGame()
        {
            Clear();
            _levelManager.LoadCurrentLevel();
            _playerManager.ActivePlayer();
            _timeInGame.InitTime(_levelManager.GetTimeCurLevel());
            _playerManager.SetPosPlayer(_levelManager.GetPosSpawnPlayer());
            EventManager.RaisEvent(SafeNameEvent.CloseCurUIPanelMainMenu);
            EventManager.RaisEvent(SafeNameEvent.ActiveUIInGame);
            EventManager.RaisEvent(SafeNameEvent.ResetPlayerHeal);
           
        }
        
        public void NextLevel()
        {
            Clear();
            _levelManager.NextLevel();
            EventManager.RaisEvent(SafeNameEvent.CloseUIAfterGame);
            PlayGame();
            
        }
        public void RePlay()
        {
            Clear();
            EventManager.RaisEvent(SafeNameEvent.HealRePlay);
            EventManager.RaisEvent(SafeNameEvent.RePosPlayer);
            _timeInGame.AddTimeRePlay();
        }

        public void Reload()
        {
            Clear();
            EventManager.RaisEvent(SafeNameEvent.CloseUIAfterGame);
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
