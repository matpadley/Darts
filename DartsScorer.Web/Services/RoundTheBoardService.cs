using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services;

public interface IRoundTheBoardService
{
    Main.Match.RoundTheBoard.Match Create();
    IEnumerable<MatchPlayer> GetPlayers();
    void AddPlayer(string playerName);
    
    Main.Match.RoundTheBoard.Match StartMatch();
    void Throw(string throwValue);
}

public class RoundTheBoardService : IRoundTheBoardService
{
    private readonly IMemoryCache _cache;
    
    public RoundTheBoardService(IMemoryCache cache)
    {
        _cache = cache;
    }
    public Main.Match.RoundTheBoard.Match Create()
    {
        var existingMatch = _cache.Get("currentMatch");
        
        if (existingMatch != null)
        {
            return existingMatch  as Main.Match.RoundTheBoard.Match;
        }
        
        var match = new Main.Match.RoundTheBoard.Match();
        _cache.Set("currentMatch", match);
        return match;
    }

    public IEnumerable<MatchPlayer> GetPlayers()
    {
        var match = _cache.Get("currentMatch") as Main.Match.RoundTheBoard.Match;
        return match.Players;
    }

    public void AddPlayer(string playerName)
    {
        var match = _cache.Get("currentMatch") as Main.Match.RoundTheBoard.Match;
        match.AddPlayer(new RoundTheBoardPlayer(playerName));
        _cache.Set("currentMatch", match);
    }

    public Match StartMatch()
    {
        var match = _cache.Get("currentMatch") as Main.Match.RoundTheBoard.Match;
        match.StartMatch();
        (match.CurrentPlayer as RoundTheBoardPlayer).StartThrow();
        _cache.Set("currentMatch", match);
        return match;
    }

    public void Throw(string throwValue)
    {
        try
        {
            var match = _cache.Get("currentMatch") as Main.Match.RoundTheBoard.Match;
            (match.CurrentPlayer as RoundTheBoardPlayer).Throw(throwValue);
            _cache.Set("currentMatch", match);
        }
        catch (Exception e)
        {

        }
    }
}