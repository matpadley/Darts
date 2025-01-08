namespace DartsScorer.Main.Models.Variants;

public class KillerVarient: GameVariant
{
    public override GameType VariantType { get; set; } = GameType.Killer;
    public KillerVarient()
    {

    }
}
