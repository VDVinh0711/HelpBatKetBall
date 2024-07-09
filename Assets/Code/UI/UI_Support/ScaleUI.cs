
using System;
using DG.Tweening;
using UnityEngine;


namespace  Lagger.Code.UiSupport
{
    public class ScaleUI : MonoBehaviour
    {
        private void OnEnable()
        {
            ScaleSmallToBig();
        }

        private void OnDisable()
        {
            ScaleBigtoSmall();
        }
        
        private void ScaleSmallToBig()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(new Vector3(1,1,1), 1f).SetEase(Ease.OutBack);
        }
        private void ScaleBigtoSmall()
        {
            transform.DOScale(new Vector3(0,0,0), 1f).SetEase(Ease.OutBack);
        }
    }
}

