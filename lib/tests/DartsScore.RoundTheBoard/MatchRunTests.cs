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

    [Test, TestCaseSource(nameof(throwCases))]
    public void RoundTheBoard_SinglePlayer_Run_Through_Doubles_Two_PlayerScores_Cases(object[] dartThrows)
    {
        var test = dartThrows.First() as ThrowCase[];
        var expectedScore = dartThrows[1];
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
            roundTheBoardPlayer.Throw(test.First().FirstThrow.BoardScore, test.First().FirstThrow.Multiplier); // next score == 3
            roundTheBoardPlayer.Throw(test.First().SecondThrow.BoardScore, test.First().SecondThrow.Multiplier); // next score == 7
            roundTheBoardPlayer.Throw(test.First().ThirdThrow.BoardScore, test.First().ThirdThrow.Multiplier); // next score == 8
            roundTheBoardPlayer.EndThrow();
            _match.UpdatePlayer(roundTheBoardPlayer);

            Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo(expectedScore));
            Assert.That((_match
                    .Players
                    .Where(p => p.Equals(matchPlayer)).First() as RoundTheBoardPlayer)
                .RequiredBoardNumber,
                Is.EqualTo(expectedScore));
        }
    }

    static object[] throwCases =
    {
        new object[]
        {
            new ThrowCase[]
            {
                // add three THrowCase objects
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