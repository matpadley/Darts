using DartsScorer.Main.Match.x01;
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
            _cache.Set("currentMatch", new Match(requiredScore));
        }
        
        var existingMatch = _cache.Get("currentMatch");
        
        if (existingMatch != null)
        {
            return existingMatch as Match;
        }
        
        var match = new Match();
        _cache.Set("currentMatch", match);
        return match;
    }

    public Match Get()
    {
        throw new NotImplementedException();
    }

    public void AddPlayer(string playerName)
    {
        throw new NotImplementedException();
    }

    public Match StartMatch()
    {
        throw new NotImplementedException();
    }

    public void Throw(string throwValue)
    {
        throw new NotImplementedException();
    }
}