using DartsScorer.Tests;

namespace DartsScorer.Main.Models.Variants;

public class Killer: GameVariant
{
    public override GameType VariantType { get; set; } = GameType.Killer;

    public Killer()
    {

    }

    public override void AddPlayer(Player player)
    {
       
    }
}