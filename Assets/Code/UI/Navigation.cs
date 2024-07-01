using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Lagger.Code.UI
{
    public class Navigation : MonoBehaviour
    {
        [SerializeField] private RectTransform _panel;
        [SerializeField] private List<BtnNavConfig> _btns;

        public void DeActiveButton()
        {
            _panel.gameObject.SetActive(false);
        }

        public void ActiveButton()
        {
            _panel.gameObject.SetActive(true);
        }
        
    }


    public class BtnNavConfig
    {
        public string name;
        public Button btn;
    }
}
