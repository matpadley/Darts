using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services;

public interface IRoundTheBoardService
{
    Match Create();
    IEnumerable<MatchPlayer> GetPlayers();
    void AddPlayer(string playerName);
    Match StartMatch();
    void Throw(string throwValue);
}

public class RoundTheBoardService : IRoundTheBoardService
{
    private readonly IMemoryCache _cache;
    
    public RoundTheBoardService(IMemoryCache cache)
    {
        _cache = cache;
    }
    public Match Create()
    {
        var existingMatch = _cache.Get("currentMatch");
        
        if (existingMatch != null)
        {
            return existingMatch  as Match;
        }
        
        var match = new Match();
        _cache.Set("currentMatch", match);
        return match;
    }

    public IEnumerable<MatchPlayer> GetPlayers()
    {
        var match = _cache.Get("currentMatch") as Match;
        return match.Players;
    }

    public void AddPlayer(string playerName)
    {
        var match = _cache.Get("currentMatch") as Match;
        
        if (match.Players.Any(f => f.Name == playerName))
        {
            return;
        }
        
        match.AddPlayer(new RoundTheBoardPlayer(playerName));
        _cache.Set("currentMatch", match);
    }

    public Match StartMatch()
    {
        var match = _cache.Get("currentMatch") as Match;
        match.StartMatch();
        _cache.Set("currentMatch", match);
        return match;
    }

    public void Throw(string throwValue)
    {
        var match = _cache.Get("currentMatch") as Match;
        var player = match.CurrentPlayer as RoundTheBoardPlayer;
        
        player.Throw(throwValue);
        
        match.UpdatePlayer(player);
        _cache.Set("currentMatch", match);
    }
}