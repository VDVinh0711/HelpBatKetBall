using System;
using System.Collections;
using Lagger.Code.Manager;
using UnityEngine;



namespace  Lagger.Code.TimeGame
{
    public class TimeInGame : MonoBehaviour
    {
        [SerializeField] private int _playTime;
        [SerializeField] private int _timeLimit;
        Coroutine timecounter;
        public Action<int> ActionChangeTime;
        public int playtime => _playTime;
        public int timelimit => _timeLimit;


        private void OnEnable()
        {
            EventManger<int>.Registerevent("InitTime",InitTime);
        }

        public void InitTime(int timelimit)
        {
            _playTime = timelimit;
            _timeLimit = timelimit;
            if(timecounter!=null) StopCoroutine(timecounter);
            timecounter = StartCoroutine(TimeCounter());
        }
        IEnumerator TimeCounter()
        {
            while (_playTime >0)
            {
                var gamemanager = GameManager.Instance;
                _playTime -= gamemanager.IsPause || gamemanager.IsWin || gamemanager.IsLose  ? 0 : 1;
                OnActionChangeTime();
                yield return new WaitForSeconds(1);
            }
            GameManager.Instance.Lose();
        }
        public void OnActionChangeTime()
        {
            ActionChangeTime?.Invoke(_playTime);
        }
        
        private void OnDisable()
        {
            EventManger<int>.Removeevent("InitTime",InitTime);
        }

        public void AddTimeRePlay()
        {
            _playTime += 30;
        }
    }

}
