namespace DartsScorer.Main.Models.Variants;

public class KillerVarient: GameVarient
{
    public override GameType VariantType { get; set; } = GameType.Killer;
    public KillerVarient()
    {

    }
}
