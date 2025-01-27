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
    public void SinglePlayerRunThrough()
    {
        var player = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player);

        _match.StartMatch();

        if (_match.Players.Count == 0)
        {
            Console.WriteLine("No players in the match.");
            return;
        }

        foreach (var matchPlayer in _match.Players)
        {
           var roundTheBoardPlayer = matchPlayer as RoundTheBoardPlayer;
           roundTheBoardPlayer.StartThrow();
           roundTheBoardPlayer.Throw(BoardScore.Five, Multiplier.Single);
           roundTheBoardPlayer.Throw(BoardScore.Seventeen, Multiplier.Single);
           roundTheBoardPlayer.Throw(BoardScore.Eight, Multiplier.Single);
           roundTheBoardPlayer.EndThrow();
           Console.WriteLine(roundTheBoardPlayer.Legs.Last().CurrentScore);
           _match.UpdatePlayer(roundTheBoardPlayer);
           
        }
    }
}