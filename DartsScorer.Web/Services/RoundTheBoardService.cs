using DartsScorer.Main.Match;
using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace DartsScorer.Web.Services;

public interface IRoundTheBoardService
{
    Match Create(bool reset);
    Match Get();
    void AddPlayer(string playerName);
    Match StartMatch();
    void Throw(string throwValue);
}

public class RoundTheBoardService : IRoundTheBoardService
{
    private readonly MatchConfiguration _matchConfiguration;
    private readonly IMemoryCache _cache;
    
    public RoundTheBoardService(IOptions<MatchConfiguration> matchConfiguration, IMemoryCache cache)
    {
        _matchConfiguration = matchConfiguration.Value;
        _cache = cache;
    }
    public Match Create(bool reset)
    {
        if (reset)
        {
            _cache.Remove("currentMatch");
            _cache.Set("currentMatch", new Match(_matchConfiguration));
        }
        
        var existingMatch = _cache.Get("currentMatch");
        
        if (existingMatch != null)
        {
            return (existingMatch as Match)!;
        }
        
        var match = new Match(new MatchConfiguration());
        _cache.Set("currentMatch", match);
        return match;
    }

    public Match Get()
    {
        return (_cache.Get("currentMatch") as Match)!;
    }

    public IEnumerable<MatchPlayer>? GetPlayers()
    {
        var match = _cache.Get("currentMatch") as Match;
        return match?.Players;
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