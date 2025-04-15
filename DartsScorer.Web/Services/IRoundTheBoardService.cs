using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using Microsoft.Extensions.Caching.Memory;

namespace DartsScorer.Web.Services.Development;

public interface IRoundTheBoardService
{
    Match Create(bool reset);
    Match Get();
    void AddPlayer(string playerName);
    Match StartMatch();
    void Throw(string throwValue);
}