using System.Diagnostics;
using DartsScore.RoundTheBoard.TestCases;
using DartsScorer.Main.Match.RoundTheBoard;
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

    [Test, TestCaseSource(nameof(_throwCases))]
    public void RoundTheBoard_SinglePlayer_Run_Through_Doubles_Two_PlayerScores_Cases(object[] dartThrows)
    {
        var throwCase = dartThrows.First() as ThrowCase[];
        var expectedScore = dartThrows[1];
        var player = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player);

        _match.StartMatch();
        
        foreach (var matchPlayer in _match.Players)
        {
            var roundTheBoardPlayer = matchPlayer as RoundTheBoardPlayer;

            Debug.Assert(roundTheBoardPlayer != null, nameof(roundTheBoardPlayer) + " != null");
            
            var dartsToThrow = throwCase!.First();
            
            roundTheBoardPlayer.StartThrow();
            roundTheBoardPlayer.Throw(dartsToThrow.FirstThrow.BoardScore,
                dartsToThrow.FirstThrow.Multiplier); // next score == 3
            roundTheBoardPlayer.Throw(dartsToThrow.SecondThrow.BoardScore,
                dartsToThrow.SecondThrow.Multiplier); // next score == 7
            roundTheBoardPlayer.Throw(dartsToThrow.ThirdThrow.BoardScore,
                dartsToThrow.ThirdThrow.Multiplier); // next score == 8
            roundTheBoardPlayer.EndThrow();
            _match.UpdatePlayer(roundTheBoardPlayer);

            Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo(expectedScore));
            Assert.That(((_match
                    .Players.First(p => p.Equals(matchPlayer)) as RoundTheBoardPlayer)!)
                .RequiredBoardNumber,
                Is.EqualTo(expectedScore));
        }
    }

    [Test]
    public void RoundTheBoard_MultiPlayer_Run_Through_To_Finish()
    {
        var player1 = new RoundTheBoardPlayer("new player");
        var player2 = new RoundTheBoardPlayer("second player");

        _match.AddPlayer(player1);
        _match.AddPlayer(player2);

        _match.StartMatch();

        while (!_match.IsMatchComplete)
        {
            var player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            Enum.TryParse(player?.RequiredBoardNumber.ToString(), out BoardScore boardScore1);
            Enum.TryParse((player?.RequiredBoardNumber + 1).ToString(), out BoardScore boardScore2);
            Enum.TryParse((player?.RequiredBoardNumber + 2).ToString(), out BoardScore boardScore3);
            
            player?.StartThrow();
            player?.Throw(boardScore1, Multiplier.Single);
            player?.Throw(boardScore2, Multiplier.Single);
            player?.Throw(boardScore3, Multiplier.Single);
            player?.EndThrow();
            
            _match.UpdatePlayer(player!);
        }
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.True);
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "second player").Finished(), Is.False);
        Assert.That(_match.Winner.Name, Is.EqualTo("new player"));
    }
    
    /// add test for bust - if the player goes over the required number[Test]

    /// <summary>
    /// Test cases for different dart throws and their expected scores.
    /// </summary>
    static object[] _throwCases =
        {
            new object[]
            {
                new ThrowCase[]
                {
                    new()
                    {
                        FirstThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.One, Multiplier.Double),
                        SecondThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Three, Multiplier.Double),
                        ThirdThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Seven, Multiplier.Single)
                    }
                },
                8
            },
            new object[]
            {
                new ThrowCase[]
                {
                    new()
                    {
                        FirstThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.One, Multiplier.Double),
                        SecondThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Three, Multiplier.Single),
                        ThirdThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Four, Multiplier.Single)
                    }
                },
                5
            },
            new object[]
            {
                new ThrowCase[]
                {
                    new()
                    {
                        FirstThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.One, Multiplier.Single),
                        SecondThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Two, Multiplier.Single),
                        ThirdThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Three, Multiplier.Single)
                    }
                },
                4
            },
            new object[]
            {
                new ThrowCase[]
                {
                    new()
                    {
                        FirstThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Five, Multiplier.Single),
                        SecondThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Seventeen, Multiplier.Single),
                        ThirdThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Three, Multiplier.Single)
                    }
                },
                1
            }
        };
}