using DartsScorer.Main.Match.x01;

namespace DartsScorer.Web.Services;

public interface IX01Service
{
    Match Create(int requiredScore, bool reset);
    Match Get();
    void AddPlayer(string playerName);
    Match StartMatch();
    void Throw(string throwValue);
}