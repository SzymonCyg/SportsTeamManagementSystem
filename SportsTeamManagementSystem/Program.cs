// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

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

public interface IPlayer
{
    string Name { get; }
    string Position { get; }
    int Score { get; }
}

public class Defender : IPlayer
{
    public string Name {get;}
    public string Position { get; }
    public int Score {get;}

    public Defender(string name, int score, string position)
    {
        this.Name = name;
        this.Score = score;
        this.Position="Defender";
    }
}

public class Midfielder : IPlayer
{
    public string Name {get;}
    public string Position { get; }
    public int Score {get;}

    public Midfielder(string name, int score, string position)
    {
        this.Name = name;
        this.Score = score;
        this.Position="midfielder";
    }
}

public class Striker : IPlayer
{
    public string Name {get;}
    public string Position { get; }
    public int Score {get;}

    public Striker(string name, int score, string position)
    {
        this.Name = name;
        this.Score = score;
        this.Position="Striker";
    }
}