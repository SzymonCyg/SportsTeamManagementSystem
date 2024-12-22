// See https://aka.ms/new-console-template for more information

public class Player
{
    public string Name {get; set;}
    public string Position {get; set;}
    public int Score {get; set;}

    public void updateScore(int newScore)
    {
        Score = newScore;
    }
}

public class Team
{
    public List<Player> players = new List<Player>();

    public void addPlayer(Player player)
    {
        players.Add(player);
    }
    
    public void removePlayer(Player player)
    {
        players.Remove(player);
    }

    public void displayPlayersStatistics()
    {
        foreach (var player in players)
        {
            Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    }

    public double Avg()
    {
        return players.Average(player => player.Score);
    }
    
}
