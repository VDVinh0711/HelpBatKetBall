
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
namespace Lagger.Code.Obstacles
{
    public class MoveMultiEnemyCircle : MonoBehaviour ,IObstaclesControll
    {
        public List<BaseObstacles> listEnemy = new();
        public float duration = 5f; 
        public float radius = 5f;
        public float timeDuration = 0.2f;
        public Transform center;
        private Sequence[] sequences;   
        private void Start()
        {
            SetUpBegin();
            StartCoroutine(MoveInCircle());
            StartObs();
        }
        private void SetUpBegin()
        {
            sequences = new Sequence[listEnemy.Count];
        }
        
        IEnumerator MoveInCircle()
        {
            int objectCount = listEnemy.Count;
            Vector3[] pointPath = CalculateCirclePoints(center.position, radius, Mathf.PI / 12);
          //  float step = (2 * Mathf.PI) / objectCount;
            for (int i = 0; i < objectCount; i++)
            {
                sequences[i] = DOTween.Sequence();
                Vector3 startPosition = center.position + new Vector3(0, radius, 0);
                listEnemy[i].transform.position = startPosition;
                sequences[i].Append(listEnemy[i].transform.DOPath(pointPath, duration, PathType.CatmullRom)
                    .SetOptions(true)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart));
                //pointstart += step;
                yield return new WaitForSeconds(timeDuration);
            }
            
        }
        
        Vector3[] CalculateCirclePoints(Vector3 center, float radius, float angleStep)
        {
            int pointCount = Mathf.CeilToInt(2 * Mathf.PI / angleStep); 
            Vector3[] points = new Vector3[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                float angle = i * angleStep;
                float x = center.x+ radius * Mathf.Sin(angle);
                float y = center.y+ radius * Mathf.Cos(angle);
                points[i] = new Vector3(x, y, 0);
            }
            return points;
        }
        Vector3[] CalculateCirclePoints(Vector3 center, float radius, float angleStep, float startAngle)
        {
            int pointCount = Mathf.CeilToInt(2 * Mathf.PI / angleStep); 
            Vector3[] points = new Vector3[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                float angle = startAngle + i * angleStep;
                float x = center.x + radius * Mathf.Sin(angle);
                float y = center.y + radius * Mathf.Cos(angle);
                points[i] = new Vector3(x, y, 0);
            }
            return points;
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
