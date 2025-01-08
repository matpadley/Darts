namespace DartsScorer.Main.Models.Variants;

public abstract class GameVariant
{
    public abstract GameType VariantType { get; set; }

    // add an abstract method to allow players to be added to a player arrary
    //public abstract void AddPlayer(Player player);

    // add an abstract method to allow players to be removed from a player arrary
    //public abstract void RemovePlayer(Player player);

    // add a new array for the players
    public List<Player> Players { get; set; } = [];
}
