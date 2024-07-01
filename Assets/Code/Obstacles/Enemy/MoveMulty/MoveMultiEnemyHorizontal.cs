using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace  Lagger.Code.Obstacles
{
    public class MoveMultiEnemyHorizontal : MonoBehaviour,IObstaclesControll
    {

        [SerializeField] private List<Movehorizontal> _listEnemy = new();
        public float _timeIncludeE = 0.3f;


        private void Start()
        {
            SetUpBegin();
        }

        private void SetUpBegin()
        {
            StartCoroutine(SetMove());
        }
        IEnumerator SetMove()
        {
            int countEnemy = _listEnemy.Count;
            for (int i = 0; i < countEnemy; i++)
            {
                _listEnemy[i].gameObject.GetComponent<IObstaclesControll>().StartObs();
                yield return new  WaitForSeconds(_timeIncludeE);
            }
        }
        
        public void StartObs()
        {
            int countEnemy = _listEnemy.Count;
            for (int i = 0; i < countEnemy; i++)
            {
                _listEnemy[i].gameObject.GetComponent<IObstaclesControll>().StartObs();
            }
        }

        public void PauseObs()
        {
            int countEnemy = _listEnemy.Count;
            for (int i = 0; i < countEnemy; i++)
            {
                _listEnemy[i].gameObject.GetComponent<IObstaclesControll>().PauseObs();
               
            }
        }
    }

}
