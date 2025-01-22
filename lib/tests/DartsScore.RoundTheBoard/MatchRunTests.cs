using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScore.RoundTheBoard;

public class MatchRunTests
{
    private Match _match;
        
    [SetUp]
    public void Setup()
    {
        _match = new Match();
    }

    [Test]
    public void SinglePlayerRunTHrough()
    {
        var player = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player);

        _match.StartMatch();

        if (_match.Players.Count == 0)
        {
            Console.WriteLine("No players in the match.");
            return;
        }

        var firstPlayer = _match.Players[0];
        if (firstPlayer is RoundTheBoardPlayer matchCurrentPlayer)
        {
            matchCurrentPlayer.StartThrow();
            matchCurrentPlayer.Throw(BoardScore.Five, Multiplier.Single);
            matchCurrentPlayer.Throw(BoardScore.Seventeen, Multiplier.Single);
            matchCurrentPlayer.Throw(BoardScore.Eight, Multiplier.Single);
            matchCurrentPlayer.EndThrow();
            Console.WriteLine(matchCurrentPlayer.Legs.First().CurrentScore);
        }
        else
        {
            Console.WriteLine("The first player is not a RoundTheBoardPlayer.");
        }
        
    }
}