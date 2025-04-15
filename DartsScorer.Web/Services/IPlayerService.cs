using DartsScorer.Main.Player;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DartsScorer.Web.Services.Development;

public interface IPlayerService
{
    IList<Player>? GetPlayers();
    
    void Add(string name);

    void Delete(string name);

    void Edit(string oldName, string name);
    
    IList<SelectListItem> GetPLayersForDropDown();
    bool CheckPlayerExists(string name);
}