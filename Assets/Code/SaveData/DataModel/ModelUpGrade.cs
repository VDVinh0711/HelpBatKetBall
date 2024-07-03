
namespace  Lagger.Code.Model
{
    [System.Serializable]
    public class ModelUpGrade
    {
        public string idItemUpGrade;
        public int level;
        public int duration;
        
        public ModelUpGrade (){}
        public ModelUpGrade(string idItemUpGrade, int level, int duration)
        {
            this.idItemUpGrade = idItemUpGrade;
            this.level = level;
            this.duration = duration;
        }
    }

}
