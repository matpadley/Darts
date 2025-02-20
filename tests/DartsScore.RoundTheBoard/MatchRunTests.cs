using System.Diagnostics;
using DartsScore.RoundTheBoard.TestCases;
using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Scoring;
using static System.Enum;

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
            Assert.That(roundTheBoardPlayer?.CurrentLeg.NextThrow, Is.EqualTo(1));
            roundTheBoardPlayer.Throw(dartsToThrow.FirstThrow.BoardScore,
                dartsToThrow.FirstThrow.Multiplier); // next score == 3
            _match.SetCurrentPlayer(roundTheBoardPlayer);
            
            Assert.That(roundTheBoardPlayer?.CurrentLeg.NextThrow, Is.EqualTo(2));
            roundTheBoardPlayer.Throw(dartsToThrow.SecondThrow.BoardScore,
                dartsToThrow.SecondThrow.Multiplier); // next score == 7
            _match.SetCurrentPlayer(roundTheBoardPlayer);
            
            Assert.That(roundTheBoardPlayer?.CurrentLeg.NextThrow, Is.EqualTo(3));
            roundTheBoardPlayer.Throw(dartsToThrow.ThirdThrow.BoardScore,
                dartsToThrow.ThirdThrow.Multiplier); // next score == 8
            _match.SetCurrentPlayer(roundTheBoardPlayer);
            
            roundTheBoardPlayer.EndThrow();
            _match.SetCurrentPlayer(roundTheBoardPlayer);

            Assert.That(roundTheBoardPlayer.RequiredBoardNumber, Is.EqualTo(expectedScore));
            
            Assert.That((_match
                    .Players.First(p => p.Equals(matchPlayer)) as RoundTheBoardPlayer)!
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
            
            TryParse(player?.RequiredBoardNumber.ToString(), out BoardScore boardScore1);
            TryParse((player?.RequiredBoardNumber + 1).ToString(), out BoardScore boardScore2);
            TryParse((player?.RequiredBoardNumber + 2).ToString(), out BoardScore boardScore3);
            
            player?.StartThrow();
            
            player?.Throw(boardScore1, Multiplier.Single);
            _match.SetCurrentPlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            player?.Throw(boardScore2, Multiplier.Single);
            //Assert.That(player.NextThrow, Is.EqualTo(2));
            _match.SetCurrentPlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            player?.Throw(boardScore3, Multiplier.Single);
           // Assert.That(player.NextThrow, Is.EqualTo(3));
            _match.SetCurrentPlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            player?.EndThrow();
            
            _match.SetCurrentPlayer(player!);
        }
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.True);
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "second player").Finished(), Is.False);
        Assert.That(_match.Winner.Name, Is.EqualTo("new player"));
    }

    [Test]
    public void RoundTheBoard_Single_Player_Not_Finish()
    {
        var player1 = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player1);

        _match.StartMatch();

        var player = _match.CurrentPlayer as RoundTheBoardPlayer;
        
        TryParse(player?.RequiredBoardNumber.ToString(), out BoardScore boardScore1);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore2);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore3);
        
        player?.StartThrow();
        Assert.That(player?.CurrentLeg.NextThrow, Is.EqualTo(1));
        player?.Throw(boardScore1, Multiplier.Treble);
        Assert.That(player?.CurrentLeg.NextThrow, Is.EqualTo(2));
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore2, Multiplier.Treble);
        Assert.That(player?.CurrentLeg.NextThrow, Is.EqualTo(3));
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore3, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.SetCurrentPlayer(player!);
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.False);
        Assert.That(_match.Winner, Is.Null);
    }
    
    [Test]
    public void RoundTheBoard_Single_Player_Finish()
    {
        var player1 = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player1);

        _match.StartMatch();

        var player = _match.CurrentPlayer as RoundTheBoardPlayer;
        
        TryParse(player?.RequiredBoardNumber.ToString(), out BoardScore boardScore1);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore2);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore3);
        
        //first throw
        player?.StartThrow();
        player?.Throw(boardScore1, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore2, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore3, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.SetCurrentPlayer(player!);
        
        //second throw
        player?.StartThrow();
        player?.Throw(BoardScore.Thirteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fourteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fifteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.SetCurrentPlayer(player!);
        
        // third throw
        player?.StartThrow();
        player?.Throw(BoardScore.Sixteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Seventeen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.SetCurrentPlayer(player!);
        
        player?.StartThrow();
        player?.Throw(BoardScore.Nineteen, Multiplier.Single);
        player?.Throw(BoardScore.Twenty, Multiplier.Single);
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player?.EndThrow();
        
        _match.SetCurrentPlayer(player!);
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.True);
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
            },
            new object[]
            {
                new ThrowCase[]
                {
                    new()
                    {
                        FirstThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.One, Multiplier.Treble),
                        SecondThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Four, Multiplier.Treble),
                        ThirdThrow = new ValueTuple<BoardScore, Multiplier>(BoardScore.Sixteen, Multiplier.Treble)
                    }
                },
                13
            }
        };
}