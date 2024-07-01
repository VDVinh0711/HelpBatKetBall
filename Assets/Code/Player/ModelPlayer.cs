using DG.Tweening;
using UnityEngine;

namespace Lagger.Code.Player
{
    public class ModelPlayer : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>(); 
        }
        public void ModelTakeDamage()
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.material.DOFade(0f, 0.2f).OnComplete(() => {
                    _spriteRenderer.material.DOFade(1f, 0.2f);
                }).SetLoops(5, LoopType.Yoyo);
            }
        }

        public void RotateModel(Vector2 dir)
        {
            if (dir.x < 0)
            {
                transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z + 180), 0.7f);
            }
            else
            {
                transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 180), 0.7f);
            }

        }
    }

}
