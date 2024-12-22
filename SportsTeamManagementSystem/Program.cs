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
    
    public List<Player> FindPlayersByPosition(string position)
    {
        return players.Where(p => p.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void RemovePlayer(string name)
    {
        {
            var player = players.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                players.Remove(player);
                Console.WriteLine($"Usunięto zawodnika: {player.Name}");
            }
            else
            {
                Console.WriteLine($"Nie znaleziono zawodnika o imieniu: {name}");
            }
        }
    }

    public void DisplayPlayersStatistics()
    {
        throw new NotImplementedException();
    }

    public string CalculateAverageScore()
    {
        throw new NotImplementedException();
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
        this.Score = 0;
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
        this.Score = 0;
        this.Position="Midfielder";
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
        this.Score = 0;
        this.Position="Striker";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team();
        int i = 0;
        while (i == 0)
        {

            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Dodaj zawodnika");
            Console.WriteLine("2. Usuń zawodnika");
            Console.WriteLine("3. Wyświetl statystyki drużyny");
            Console.WriteLine("4. Oblicz średni wynik drużyny");
            Console.WriteLine("5. Wyszukaj zawodnika po pozycji");
            Console.WriteLine("6. Wyszukaj zawodnika po punktach");
            Console.WriteLine("7. Wyjście");
            Console.Write("Wybierz opcję: ");
            int choice = 0;
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddPlayer(team);
                    break;
                case 2:
                    RemovePlayer(team);
                    break;
                case 3:
                    team.DisplayPlayersStatistics();
                    break;
                case 4:
                    Console.WriteLine($"Średni wynik drużyny: {team.CalculateAverageScore()}");
                    break;
                case 5:
                    FindPlayerByPosition(team);
                    break;
                case 6:
                    FindPlayerByScore(team);
                    break;
                case 7:
                    Console.WriteLine("Zakończono działanie programu.");
                    i = 1;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                    break;
            }
        }
    }

    private static void FindPlayerByScore(Team team)
    {
        throw new NotImplementedException();
    }

    private static void FindPlayerByPosition(Team team)
    {
        throw new NotImplementedException();
    }

    private static void AddPlayer(Team team)
    {
        Console.WriteLine("Podaj imię zawodnika: ");
        string name = Console.ReadLine();
        Console.Write("Podaj pozycję zawodnika (np. Defender, Midfielder, Striker): ");
        string position = Console.ReadLine();
        
    }
    private static void RemovePlayer(Team team)
    {
        Console.Write("Podaj imię zawodnika do usunięcia: ");
        string name = Console.ReadLine();
        team.RemovePlayer(name);
    }
}

