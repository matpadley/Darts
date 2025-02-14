namespace DartsScorer.Main.Player;

public class Team(string name)
{
    public string Name { get; } = name;

    public List<Player> Players { get; } = [];

    public int Count => Players.Count;

    public void AddNewPlayer(Player player)
    {
        if (Players.Any(p => p.Name == player.Name))
        {
            return;
        }

        Players.Add(player);
    }
}