using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class Game
{
    public GameVarient GameVariant {get;}

    public Game(GameVarient gameVariant)
    {
        GameVariant = gameVariant;
    }
}
