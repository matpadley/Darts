using DartsScorer.Main.Player;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services;

public interface IPlayerService
{
    IList<Player>? GetPlayers();
    
    void Add(String name);

    void Delete(string name);

    void Edit(string oldName, string name);
    
    IList<SelectListItem> GetPLayersForDropDown();
    bool CheckPlayerExisits(string playerName);
}

public class PlayerService: IPlayerService
{    
    private readonly IMemoryCache _cache;
    
    public PlayerService(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    public IList<Player>? GetPlayers()
    {
        var players = _cache.Get("players");
        // check if the players has anything in it
        
        return  players == null ? new List<Player>() : players as IList<Player>;
    }

    public void Add(string name)
    {
        // get the player list from the cache
        // if the players list is null create a new list
        var players = _cache.Get("players") as List<Player> ?? new List<Player>();

        if (CheckPlayerExisits(name)) return;
        var player = new Player(name);
        
        // add the player to the list
        players.Add(player);
        
        // save the player list to the cache using the player cache key
        _cache.Set("players", players);
    }

    public void Delete(string name)
    {
        // get the player list from the cache
        var players = GetPlayers();
        
        // find the player in the list
        var player = players.FirstOrDefault(p => p.Name == name);
        
        // remove the player from the list
        players.Remove(player);
        
        // save the player list to the cache
        _cache.Set("players", players);
    }

    public void Edit(string oldName, string name)
    {
        // edit the player with the new name
        // get the player list from the cache
        var players = GetPlayers();
        
        // find the player in the list
        var player = players.FirstOrDefault(p => p.Name == oldName);
        
        var newPlayer = new Player(name);
        
        players.Remove(player);
        players.Add(newPlayer);
        
        // save the player list to the cache
        _cache.Set("players", players);
    }

    public IList<SelectListItem> GetPLayersForDropDown()
    {
        // get all the players and convert them to a selectlist item
        var players = GetPlayers();
        return players.Select(p => new SelectListItem(p.Name, p.Name)).ToList();
    }

    public bool CheckPlayerExisits(string playerName)
    {
        return GetPlayers().Any(player => player.Name == playerName);
    }
}