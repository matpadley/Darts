using DartsScorer.Main.Models;
using DartsScorer.Main.Killer;

namespace DartsScorer.Tests.Kiiller
{
    public class KillerMatchTests
    {
        MatchBase? match;

        [SetUp]
        public void Setup()
        {
            match = new Match();
        }

        [Test]
        public void Killer_Instansitation()
        {
            Assert.That(match?.MatchType, Is.EqualTo(DartsMatchType.Killer));
        }
        [Test]
        public void Killer_Instansitation_Failure()
        {
            Assert.That(match?.MatchType, !Is.EqualTo(DartsMatchType.x01));
        }
    }
}
