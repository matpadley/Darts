using DartsScorer.Main.Match;

namespace DartsScorer.Killer
{
    public class MatchKillerTests
    {
        CommonMatch? _match;

        [SetUp]
        public void Setup()
        {
            _match = new Main.Match.Killer.Match();
        }

        [Test]
        public void Match_Killer_Instantiation()
        {
            Assert.That(_match?.DartsMatchType, Is.EqualTo(DartsMatchType.Killer));
        }
        [Test]
        public void Match_Killer_Instantiation_Failure()
        {
            Assert.That(_match?.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        }
    }
}
