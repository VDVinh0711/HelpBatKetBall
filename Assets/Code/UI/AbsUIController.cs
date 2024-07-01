
using DG.Tweening;
using UnityEngine;

namespace  Lagger.Code.UI
{
    public  abstract class AbsUIController : MonoBehaviour
    {
        public virtual void Open()
        {
            transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000 ,0);
            transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,0),1.0f);
            gameObject.SetActive(true);
        }
        public virtual void Close()
        {
            transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-2000,0),1.0f);
            Invoke("DeActive",1);
        }
        private void DeActive()
        {
            gameObject.SetActive(false);
        }
    }

}

