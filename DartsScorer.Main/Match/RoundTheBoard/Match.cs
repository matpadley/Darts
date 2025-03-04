﻿using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.RoundTheBoard;

public sealed class Match : CommonMatch
{
    public override string Name => "Round The Board";
    public override DartsMatchType DartsMatchType => DartsMatchType.RoundTheBoard;
    
    public override void StartMatch()
    {
        if (!CanStartMatch()) return;
        SetCurrentPlayer(Players.First());
        MatchInProgress = true;
    }
}