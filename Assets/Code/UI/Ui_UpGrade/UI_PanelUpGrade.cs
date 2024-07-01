
using System.Collections.Generic;
using Lagger.Code.ItemHelper;
using UnityEngine;


namespace  Lagger.Code.UI
{
    public class UI_PanelUpGrade : AbsUIController
    {
        [SerializeField] private UpGradeItemBuff _upGradeItem;
        [SerializeField] private List<UI_ItemUpGrade> _listUIItemUpGrade;
        private void Start()
        {
            SetUpBegin();
        }
        private void SetUpBegin()
        {
            //Set up temporarily so that in the future, when there are more upgrades, items will be spawned based on itemUpgrade, and then set the UI
            for (int i = 0; i < _upGradeItem.ListItemUpGrade.Count; i++)
            {
                _listUIItemUpGrade[i].SetUpUI(_upGradeItem.ListItemUpGrade[i]);
            }
        }
    }
      

}

