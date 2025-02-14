using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services;

public interface IPLayerService
{
    IList<Player>? GetPLayers();
    
    void AddP(String name);

    void Delete(string name);

    void Edit(string name);
}

public class PlayerService: IPLayerService
{    
    private readonly IMemoryCache _cache;
    
    public PlayerService(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    public IList<Player>? GetPLayers()
    {
        var players = _cache.Get("players");
        // check if the players has anything in it
        
        return  players == null ? new List<Player>() : players as IList<Player>;
    }

    public void AddP(string name)
    {
        // get the player list from the cache
        // if the players list is null create a new list
        var players = _cache.Get("players") as List<Player> ?? new List<Player>();

        // create a new player using the name from AddPlayer
        var player = new Player(name);
        
        // add the player to the list
        players.Add(player);
        
        // save the player list to the cache using the player cache key
        _cache.Set("players", players);
    }

    public void Delete(string name)
    {
        // get the player list from the cache
        var players = GetPLayers();
        
        // find the player in the list
        var player = players.FirstOrDefault(p => p.Name == name);
        
        // remove the player from the list
        players.Remove(player);
        
        // save the player list to the cache
        _cache.Set("players", players);
    }

    public void Edit(string name)
    {
        // edit the player with the new name
        // get the player list from the cache
        var players = GetPLayers();
        
        // find the player in the list
        var player = players.FirstOrDefault(p => p.Name == name);
        
        players.Remove(player);
        players.Add(player);
        
        // save the player list to the cache
        _cache.Set("players", players);
    }
}