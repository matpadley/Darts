using DartsScorer.Tests;

namespace DartsScorer.Main.Models.Variants;

public class X01Variant: GameVariant
{
    public override GameType VariantType { get; set; } = GameType.x01;

    public X01Variant()
    {

    }

    public override void AddPlayer(Player player)
    {
        _players.Add(new VariantPlayer(player));
    }
}