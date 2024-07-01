
using System.Collections.Generic;
using DG.Tweening;
using Lagger.Code.Obstacles;
using UnityEngine;


namespace  MoveMulty
{
    public class MoveMultiEnemySquare : MonoBehaviour,IObstaclesControll
    {
        [SerializeField]  private List<BaseObstacles> listEnemy = new();
        [SerializeField] private float _duration = 5f; 
        [SerializeField] private float _diagonal = 5f;
        [SerializeField] private Transform _center;
        [SerializeField] private Sequence[] sequences;
        private void Start()
        {
          
            SetUpSBegin();
            MoveSquare();
            StartObs();
        }

        private void SetUpSBegin()
        {
            sequences = new Sequence[listEnemy.Count];
        }
        
        public void MoveSquare()
        {
            int objectCount = listEnemy.Count;
            Vector3[] pointPath = CalculateSquareCorners(_center.position);
            for(int i = 0; i < objectCount; i++)
            {
                sequences[i] = DOTween.Sequence();
                Vector2 startPosition = pointPath[i];
                listEnemy[i].transform.position = startPosition;
                sequences[i].Append(listEnemy[i].transform.DOPath(CaculatorPointMove(startPosition), _duration, PathType.CatmullRom)
                    .SetOptions(true)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart));
            }
            
        }
        private Vector3[] CaculatorPointMove(Vector2 startpoint )
        {
            float sideLength = _diagonal / Mathf.Sqrt(2);
            Vector3[] cornerPoints = new Vector3[4];
            Vector3[] points = new Vector3[4];
            points[0] = startpoint; 
            for (int i = 1; i < 4; i++)
            {
                if (points[i - 1].x < _center.position.x && points[i - 1].y < _center.position.y)
                {
                    points[i] = new Vector3(points[i - 1].x, points[i - 1].y + sideLength, 0);
                }
                if (points[i - 1].x < _center.position.x && points[i - 1].y > _center.position.y)
                {
                    points[i] = new Vector3(points[i - 1].x + sideLength, points[i - 1].y, 0);
                }
                if (points[i - 1].x >  _center.position.x && points[i - 1].y > _center.position.y)
                {
                    points[i] = new Vector3(points[i - 1].x , points[i - 1].y - sideLength, 0);
                }
                if (points[i - 1].x >  _center.position.x && points[i - 1].y <  _center.position.y)
                {
                    points[i] = new Vector3(points[i - 1].x - sideLength , points[i - 1].y, 0);
                }
            }

            return points;
           
        }
        Vector3[] CalculateSquareCorners(Vector2 center)
        {
            float sideLength = _diagonal / Mathf.Sqrt(2);
            Vector3[] corners = new Vector3[4];
            float halfLength = sideLength / 2f;
            corners[0] = new Vector3(center.x - halfLength, center.y - halfLength,0); 
            corners[1] = new Vector3(center.x + halfLength, center.y - halfLength,0); 
            corners[2] = new Vector3(center.x + halfLength, center.y + halfLength,0); 
            corners[3] = new Vector3(center.x - halfLength, center.y + halfLength,0); 
            return corners;
        }
        
        public void StartObs()
        {
            for (int i = 0; i < sequences.Length; i++)
            {
                sequences[i].Play();
            }
        }

        public void PauseObs()
        {
            for (int i = 0; i < sequences.Length; i++)
            {
                sequences[i].Pause();
            }
        }
    }

}
