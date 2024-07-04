
namespace  Lagger.Code.Model
{
    
    [System.Serializable]
    public class ModelLevel 
    {
        public int idLevel;
        public int starOfLevel;
        
        
        public ModelLevel(){}
        public ModelLevel(int idLevel, int starOfLevel)
        {
            this.idLevel = idLevel;
            this.starOfLevel = starOfLevel;
        }
    }
 
}
