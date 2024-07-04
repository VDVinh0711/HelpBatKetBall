using System.Threading.Tasks;
using Code.Helper;
using Firebase.Database;

public class FireBaseManager
{
    private DatabaseReference _databaseReference;
    private static FireBaseManager _instance;
    public static FireBaseManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FireBaseManager();
            }

            return _instance;
        }
    }
    
    public void SaveData(string key , string data)
    {
        string keySave = Helper.GetLastPart(key);
        if (_databaseReference == null) _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        _databaseReference.Child(keySave).SetRawJsonValueAsync(data);
    }
    public  async Task<string> LoadData (string key )
    {
        if (_databaseReference == null) _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        var dataSever =  await _databaseReference.Child(key).GetValueAsync();
        string dataResult = dataSever.GetRawJsonValue();
        return dataResult;
    }

   
}



