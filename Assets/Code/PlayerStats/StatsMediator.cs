using System;

using System.Collections.Generic;
using System.Linq;

namespace  Lagger.Code.PlayerStats
{
    public class StatsMediator
    {
        private readonly List<StatsModifier> _modifiers = new();
        public List<StatsModifier> Modifiers => _modifiers;
        public void AddModifier(StatsModifier modifier)
        {
            _modifiers.Add((modifier));
            modifier.MarkedForRemove = false;
            modifier.OnDispose += () =>
            {
                _modifiers.Remove(modifier);
            };
        }
        public void Update(float deltatime)
        {
            if(_modifiers.Count <=0) return;
            foreach (var modifier in _modifiers)
            {
                modifier.Update(deltatime);
                if (modifier.MarkedForRemove)
                {
                    modifier.DisPose();
                }
            }
        }

        public Query PerformQuery(StatsType statsType)
        {
            var statmodifi = _modifiers.FirstOrDefault(x => x.type == statsType);
            if (statmodifi == null) return new Query(statsType, 0);
            return new Query(statsType, statmodifi.operation);
        }

        public void CancleStatModifier(StatsType type)
        {
            var statmodifi = _modifiers.FirstOrDefault(x => x.type == type);
            if (statmodifi == null) return;
            statmodifi.DisPose();
        }

        public StatsModifier GetStatModifier(StatsType type)
        {
            var statmodifi = _modifiers.FirstOrDefault(x => x.type == type);
            return statmodifi;
        }
    }
    
    public class Query
    {
        public readonly StatsType StatsType;
        public int value;
        public Query(StatsType statsType, int value)
        {
            this.StatsType = statsType;
            this.value = value;
        }
    }

    


 
    
   

}




