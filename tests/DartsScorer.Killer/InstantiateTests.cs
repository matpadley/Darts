using DartsScorer.Main.Match;
using DartsScorer.Main.Match.Killer;

namespace DartsScorer.Killer
{
    public class InstantiateTests
    {
        CommonMatch? _match;

        [SetUp]
        public void Setup()
        {
            _match = new Match();
        }

        [Test]
        public void Match_Killer_Instantiation()
        {
            Assert.That(_match?.DartsMatchType, Is.EqualTo(DartsMatchType.Killer));
            Assert.That(_match?.Name, Is.EqualTo("Killer"));
        }
        [Test]
        public void Match_Killer_Instantiation_Failure()
        {
            Assert.That(_match?.DartsMatchType, !Is.EqualTo(DartsMatchType.X01));
        }
    }
}
