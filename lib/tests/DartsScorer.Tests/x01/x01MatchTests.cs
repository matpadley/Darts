using DartsScorer.Main.Models;
using DartsScorer.Main.x01;


namespace DartsScorer.Tests.x01
{
    public class x01MatchTests
    {
        MatchBase? match;

        [SetUp]
        public void Setup()
        {
            match = new Match();
        }

        [Test]
        public void x01_Instansitation()
        {

            Assert.That(match?.MatchType, Is.EqualTo(DartsMatchType.x01));
        }

        [Test]
        public void x01_Instansitation_Failre()
        {
            Assert.That(match?.MatchType, !Is.EqualTo(DartsMatchType.Killer));
        }

        [Test]
        public void Add_Single_Player_Success()
        {
            var player = new  Player("Fancy New Team");
            match?.AddPlayer(player);
            Assert.That(match?.Players.Count, Is.EqualTo(1));
        }
    }
}
