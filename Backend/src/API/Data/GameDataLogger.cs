using API.Models;

namespace API.Data;

public class GameDataLogger(GameStoreData data, ILogger<GameStoreData> logger)
{
    public void PrintGames()
    {
        logger.LogInformation("Printing games");
        foreach (var game in data.GetGames())
        {
            logger.LogInformation("Game Id: {GameId}, Name: {GameName}", game.Id, game.Name);
        }
    }
}