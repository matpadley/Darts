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

            var dartsToThrow = throwCase!.First();
            
            Assert.That(roundTheBoardPlayer.CurrentLeg, Is.Null);
            roundTheBoardPlayer.Throw(dartsToThrow.FirstThrow.BoardScore,
                dartsToThrow.FirstThrow.Multiplier); // next score == 3
            _match.UpdatePlayer(roundTheBoardPlayer);
            
            Assert.That(roundTheBoardPlayer.CurrentLeg.NextThrow, Is.EqualTo(2));
            roundTheBoardPlayer.Throw(dartsToThrow.SecondThrow.BoardScore,
                dartsToThrow.SecondThrow.Multiplier); // next score == 7
            _match.UpdatePlayer(roundTheBoardPlayer);
            
            Assert.That(roundTheBoardPlayer?.CurrentLeg.NextThrow, Is.EqualTo(3));
            roundTheBoardPlayer.Throw(dartsToThrow.ThirdThrow.BoardScore,
                dartsToThrow.ThirdThrow.Multiplier); // next score == 8
            _match.UpdatePlayer(roundTheBoardPlayer);
            
            roundTheBoardPlayer.EndThrow();
            _match.UpdatePlayer(roundTheBoardPlayer);

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
            
            player?.Throw(boardScore1, Multiplier.Single);
            _match.UpdatePlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            player?.Throw(boardScore2, Multiplier.Single);
            _match.UpdatePlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            player?.Throw(boardScore3, Multiplier.Single);
            _match.UpdatePlayer(player);
            player = _match.CurrentPlayer as RoundTheBoardPlayer;
            
            _match.UpdatePlayer(player!);
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
        
        Assert.That(player?.CurrentLeg, Is.Null);
        player?.Throw(boardScore1, Multiplier.Treble);
        Assert.That(player?.CurrentLeg.NextThrow, Is.EqualTo(2));
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore2, Multiplier.Treble);
        Assert.That(player?.CurrentLeg.NextThrow, Is.EqualTo(3));
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore3, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
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
        player?.Throw(boardScore1, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore2, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore3, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        //second throw
        player?.Throw(BoardScore.Thirteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fourteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fifteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        // third throw
        player?.Throw(BoardScore.Sixteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Seventeen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        player?.Throw(BoardScore.Nineteen, Multiplier.Single);
        player?.Throw(BoardScore.Twenty, Multiplier.Single);
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.True);
        Assert.That(_match.Winner.Name, Is.EqualTo("new player"));
    }
    
    [Test]
    public void RoundTheBoard_Single_Player_No_Finish_With_Double_Or_treble_Twenty()
    {
        var player1 = new RoundTheBoardPlayer("new player");

        _match.AddPlayer(player1);

        _match.StartMatch();

        var player = _match.CurrentPlayer as RoundTheBoardPlayer;
        
        TryParse(player?.RequiredBoardNumber.ToString(), out BoardScore boardScore1);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore2);
        TryParse((player?.RequiredBoardNumber + 3).ToString(), out BoardScore boardScore3);
        
        //first throw
        player?.Throw(boardScore1, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore2, Multiplier.Treble);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(boardScore3, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        //second throw
        player?.Throw(BoardScore.Thirteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fourteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Fifteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        // third throw
        player?.Throw(BoardScore.Sixteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Seventeen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player = _match.CurrentPlayer as RoundTheBoardPlayer;
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        player?.Throw(BoardScore.Nineteen, Multiplier.Single);
        player?.Throw(BoardScore.Twenty, Multiplier.Double);
        player?.Throw(BoardScore.Eighteen, Multiplier.Single);
        player?.EndThrow();
        
        _match.UpdatePlayer(player!);
        
        Assert.That(_match.Players.First(f => (f as RoundTheBoardPlayer)?.Name == "new player").Finished(), Is.False);
        
        // assert that _match.Winner is null
        Assert.That(_match.Winner, Is.Null);
    }

    [Test]
    public void RoundTheBoard_MultiPlayer_Player_First_Leg()
    {
        var player1 = new RoundTheBoardPlayer("playerTwo");
        var player2 = new RoundTheBoardPlayer("playerOne");

        _match.AddPlayer(player1);
        _match.AddPlayer(player2);

        _match.StartMatch();

        Assert.That(_match.CurrentPlayer.Equals(player1));

        var player_throw_one = _match.CurrentPlayer as RoundTheBoardPlayer;
        player_throw_one.Throw(BoardScore.Six, Multiplier.Single);
        _match.UpdatePlayer(player_throw_one);
        
        Assert.That(_match.CurrentPlayer.Equals(player1));

        var player_throw_two = _match.CurrentPlayer as RoundTheBoardPlayer;
        player_throw_two.Throw(BoardScore.Five, Multiplier.Single);
        _match.UpdatePlayer(player_throw_two);
        
        Assert.That(_match.CurrentPlayer.Equals(player1));

        var player_throw_three = _match.CurrentPlayer as RoundTheBoardPlayer;
        player_throw_three.Throw(BoardScore.Five, Multiplier.Single);
        Assert.That(player_throw_three.Legs.Last().IsComplete);
        
        Assert.That(player_throw_three.Legs.Count == 1);
        Assert.That(player_throw_three.Legs.First().Throws.Count == 3);
        Assert.That(player_throw_three.Legs.First().Throws.ElementAt(0).NumberScore == 6);
        Assert.That(player_throw_three.Legs.First().Throws.ElementAt(1).NumberScore == 5);
        Assert.That(player_throw_three.Legs.First().Throws.ElementAt(2).NumberScore == 5);
        
        _match.UpdatePlayer(player_throw_three);
        
        Assert.That(_match.CurrentPlayer.Equals(player2));
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