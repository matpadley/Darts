namespace DartsScorer.Main.Models.Variants;

public class Killer: GameVariant
{
    public override GameType VariantType { get; set; } = GameType.Killer;
    public Killer()
    {

    }
}
