using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisher
{
    public interface IMinion
    {
        int Defence { get; }
        int AttackRoll();
        int Damage { get; }
    }
}
