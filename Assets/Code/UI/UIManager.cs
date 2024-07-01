using Lagger.Code.UI.UICHoseLevel;
using Lagger.Code.UI.UIMainMenu;
using Lagger.Code.UI.UISetting;



using UnityEngine;


namespace  Lagger.Code.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Ui_MainMenu _uiMainMenu;
        [SerializeField] private UI_Setting _uiSetting;
        [SerializeField] private UI_ChoseLevel _uicHoseLevel;
        [SerializeField] private UI_PanelUpGrade _uiUpGrade;
        [SerializeField] private Navigation _navigation;
        private AbsUIController _currentUI;
        private void Awake()
        {
            OpenUIMainMenu();
            EventManager.RegisterEvent("CloseCurrentUI",CloseCurrentUI);
            EventManager.RegisterEvent("OpenUIMainMenu",OpenUIMainMenu);
        }
        public void OpenUIMainMenu()
        {
            HelpOpenUI(_uiMainMenu.gameObject.GetComponent<AbsUIController>());
        }
        public void OpenUISetting()
        {
            HelpOpenUI(_uiSetting.gameObject.GetComponent<AbsUIController>());
        }
        public void OpenUIUpGrade()
        {
            HelpOpenUI(_uiUpGrade.gameObject.GetComponent<AbsUIController>());
        }
        public void ChoseMap()
        {
            HelpOpenUI(_uicHoseLevel.gameObject.GetComponent<AbsUIController>());
        }
        
        
        public void CloseCurrentUI()
        {
            if (_currentUI == null) return;
            _currentUI.Close();
            _currentUI = null;
            _navigation.DeActiveButton();
        }
        private void HelpOpenUI(AbsUIController uiopen)
        {
            if(_currentUI!=null) _currentUI.Close();
            _currentUI = uiopen;
            _currentUI.Open();
            _navigation.ActiveButton();
        }

        private void OnDisable()
        {
            EventManager.RemoveListener("CloseCurrentUI",CloseCurrentUI);
            EventManager.RemoveListener("OpenUIMainMenu",OpenUIMainMenu);
        }
    }

}
