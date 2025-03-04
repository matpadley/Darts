using DartsScorer.Main.Match;
using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services;

public interface IX01Service
{
    Match Create(int requiredScore, bool reset);
    Match Get();
    void AddPlayer(string playerName);
    Match StartMatch();
    void Throw(string throwValue);
}

public class X01Service : IX01Service
{
    private readonly IMemoryCache _cache;
    
    public X01Service(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    public Match Create(int requiredScore = 5, bool reset = false)
    {
        if (reset)
        {
            _cache.Remove("currentMatch");
            _cache.Set("currentMatch", new Match(new MatchConfiguration(), requiredScore));
        }
        
        var existingMatch = _cache.Get("currentMatch");
        
        if (existingMatch != null)
        {
            return existingMatch as Match;
        }
        
        var match = new Match(new MatchConfiguration());
        _cache.Set("currentMatch", match);
        return match;
    }

    public Match Get()
    {
        return _cache.Get("currentMatch") as Match;
    }

    public IEnumerable<MatchPlayer>? GetPlayers()
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
        
        match.AddPlayer(new X01Player(playerName, match.RequiredScore));
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
        var player = match.CurrentPlayer as X01Player;
        
        player.Throw(throwValue);
        
        match.UpdatePlayer(player);
        _cache.Set("currentMatch", match);
    }
}