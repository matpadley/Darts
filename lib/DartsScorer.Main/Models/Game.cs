using DartsScorer.Main.Models.Variants;

namespace DartsScorer.Tests;

public class Game
{
    public GameVariant GameVariant {get;}

    public Game(GameVariant gameVariant)
    {
        GameVariant = gameVariant;
    }
}
