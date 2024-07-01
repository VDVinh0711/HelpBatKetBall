



namespace  Lagger.Code.PlayerStats
{
    public class Stats
    {
        private StatsMediator _mediator;
        public StatsMediator Mediator => _mediator;
        public int Health
        {
            get
            {
               var  q = _mediator.PerformQuery(StatsType.Health);
                return q.value;
            }
        }
        public int Shield
        {
            get
            {
                var  q = _mediator.PerformQuery(StatsType.Shield);
                return q.value;
            }
            set
            {
                if(value > 0) return; 
                //Cancle
                _mediator.CancleStatModifier(StatsType.Shield);
               
            }
        }
        public Stats(StatsMediator statsMediator)
        {
            this._mediator = statsMediator;
        }
        
    }
}
public enum StatsType
{
    Health,
    Shield,
}
