
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace  Lagger.Code.UI
{
    public  abstract class AbsUIController : MonoBehaviour
    {
        public virtual void Open()
        {
            transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(5000 ,0);
            transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0,0),2.0f);
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-5000,0),2.0f);
            Invoke("DeActive",2);
        }


        private void DeActive()
        {
            gameObject.SetActive(false);
        }
    }

}

