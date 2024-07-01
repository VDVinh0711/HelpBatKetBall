using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  namespace Lagger.Code.PlayerStats
{
  public class StatsShiedModifier : StatsModifier
  {
    public StatsShiedModifier(StatsType type, float duration, int operation , Sprite icon) : base(type, duration, operation,icon)
    {
    }
    
    public override void Update(float deltatime)
    {
      base.Update(deltatime);
      Debug.Log("Shied");
    }
        
  }

}

