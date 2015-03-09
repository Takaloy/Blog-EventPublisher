using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisher
{
    public interface IPointyStickWielder
    {
        bool ChargeAt(IMinion minion);
        void Blocks(IMinion minion);
        int HitPoints { get; }
    }

    public class Knight : IPointyStickWielder
    {
        IReportable _reporter;

        public Knight() : this(new WhistNoisePublisher()) { }

        public Knight(IReportable reporter)
        {
            if (reporter == null)
                throw new ArgumentNullException("reporter");

            _reporter = reporter;
            HitPoints = 10;
            Defence = 3;
        }

        public bool ChargeAt(IMinion minion)
        {
            _reporter.Publish("knight starts charging ...");
            
            if (new Random().Next(1,6) > minion.Defence)
            {
                _reporter.Publish("hit!");
                return true;
            }

            _reporter.Publish("ROFL MISS!");
            return false;
        }

        public void Blocks(IMinion minion)
        {
            _reporter.Publish("tries to block");

            if (minion.AttackRoll() > this.Defence)
            {
                _reporter.Publish("ouch ..");
                HitPoints -= minion.Damage;
            }            
        }

        public int HitPoints { get; private set; }
        private int Defence { get; set; }
    }
}
