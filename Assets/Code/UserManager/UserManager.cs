
using Lagger.Code.Data;
using Lagger.Code.Model;
using Newtonsoft.Json;
using UnityEngine;


namespace  Lagger.Code.User
{
    public class UserManager : MonoBehaviour,ISaveData
    {
        [SerializeField] private UserWallet _userWallet;
        
        public string Save()
        {
             ModelUser dataAdd = new ModelUser(_userWallet.CurrentBalance, _userWallet.CurrentDimond);
             return JsonConvert.SerializeObject(dataAdd);
        }

        public void Load(string obj)
        {
            print("data User");
            var dataLoad = JsonConvert.DeserializeObject<ModelUser>(obj);
            _userWallet.LoadDataWallet(dataLoad.money, dataLoad.dimond);
        }
    }

}
