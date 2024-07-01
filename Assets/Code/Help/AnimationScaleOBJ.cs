
using DG.Tweening;
using UnityEngine;


namespace Lagger.Code.OBJHELP
{
    public class AnimationScaleOBJ : MonoBehaviour
    {
        
        [SerializeField] private float _durationScale;
        [Range(0,1)] public float scale;
        
        private void Start()
        {
            ScaleItem();
        }

        public void ScaleItem()
        {
            Vector3 originalScale = transform.localScale;
            Vector3 minScale = new Vector3(originalScale.x - scale, originalScale.y - scale, originalScale.z - scale);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(minScale, _durationScale));
            sequence.Append(transform.DOScale(originalScale, _durationScale));
            sequence.SetLoops(-1, LoopType.Restart);
        }
    }

}
