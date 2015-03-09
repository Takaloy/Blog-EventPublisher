using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace EventPublisher.Unit.Tests
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void Knight_Charge_CallsIReporter()
        {
            var reporter = Substitute.For<IReportable>();
            var enemy = Substitute.For<IMinion>();
            var knight = new Knight(reporter);
            knight.ChargeAt(enemy);
            reporter.Received().Publish(Arg.Any<string>());            
        }

        [Test]
        public void Knight_Blocks_Calls_MinionAttack()
        {
            var reporter = Substitute.For<IReportable>();
            var enemy = Substitute.For<IMinion>();
            var knight = new Knight(reporter);
            knight.Blocks(enemy);
            reporter.Received().Publish(Arg.Any<string>());
            enemy.Received(1).AttackRoll();
        }
    }
}
