using DartsScorer.Main.Match;

namespace DartsScorer.Tests.Match.Kiiller
{
    public class KillerMatchTests
    {
        CommonMatch? match;

        [SetUp]
        public void Setup()
        {
            match = new Main.Match.Killer.Match();
        }

        [Test]
        public void Killer_Instansitation()
        {
            Assert.That(match?.DartsMatchType, Is.EqualTo(DartsMatchType.Killer));
        }
        [Test]
        public void Killer_Instansitation_Failure()
        {
            Assert.That(match?.DartsMatchType, !Is.EqualTo(DartsMatchType.x01));
        }
    }
}
