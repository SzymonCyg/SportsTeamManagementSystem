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
    public List<Player> players = new List<Player>
    {
        new Player { Name = "Dudek", Position = "Goalkeeper", Score = 4 },
        new Player { Name = "Piszczek", Position = "Defender", Score = 14 },
        new Player { Name = "Pazdan", Position = "Defender", Score = 16 },
        new Player { Name = "Żmuda", Position = "Defender", Score = 11 },
        new Player { Name = "Szymanowski", Position = "Defender", Score = 17},
        new Player { Name = "Boniek", Position = "Midfielder", Score = 16 },
        new Player { Name = "Krychowiak", Position = "Midfielder", Score = 15 },
        new Player { Name = "Zielinski", Position = "Midfielder", Score = 19 },
        new Player { Name = "Piątek", Position = "Striker", Score = 22 },
        new Player { Name = "Lewandowski", Position = "Striker", Score = 19 },
        new Player { Name = "Milik", Position = "Striker", Score = 18 }
    };
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
        if (players.Count == 0)
        {
            Console.WriteLine("Brak zawodników w drużynie.");
            return;
        }

        Console.WriteLine("Statystyki zawodników:");
        foreach (var player in players)
        {
            Console.WriteLine($"Imię: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    }

    public string CalculateAverageScore()
    {
        if (players.Count == 0) return "Brak zawodników w drużynie.";
        double average = players.Average(player => player.Score);
        return $"Średni wynik drużyny wynosi: {average:F2}";
    }
}

public interface IPlayer
{
    string Name { get; }
    string Position { get; }
    int Score { get; }
}
public class Goalkeeper : IPlayer
{
    public string Name { get; }
    public string Position { get; }
    public int Score { get; }

    public Goalkeeper(string name, int score)
    {
        this.Name = name;
        this.Score = score;
        this.Position = "Goalkeeper";
    }
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
        this.Score = score;
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
        Console.Write("Podaj minimalną liczbę punktów: ");
        int minScore = Convert.ToInt32(Console.ReadLine());

        var players = team.players.Where(p => p.Score >= minScore).ToList();

        if (players is null)
        {
            Console.WriteLine($"Brak zawodników z wynikiem co najmniej {minScore}.");
        }
        else
        {
            Console.WriteLine($"Zawodnicy z wynikiem co najmniej {minScore}:");
            foreach (var player in players)
            {
                Console.WriteLine($"Imię: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
            }
        }
    }

    private static void FindPlayerByPosition(Team team)
    {
        Console.Write("Podaj pozycję zawodnika (np. Goalkeeper, Defender, Midfielder, Striker): ");
        string position = Console.ReadLine();

        var playersByPosition = team.FindPlayersByPosition(position);

        if (playersByPosition is null)
        {
            Console.WriteLine($"Brak zawodników na pozycji: {position}");
        }
        else
        {
            Console.WriteLine("Znalezieni zawodnicy:");
            foreach (var player in playersByPosition)
            {
                Console.WriteLine($"Nazwa: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
            }
        }
    }
    
    private static void AddPlayer(Team team)
    {
        Console.WriteLine("Podaj imię zawodnika: ");
        string name = Console.ReadLine();
        Console.Write("Podaj pozycję zawodnika (np. Goalkeeper, Defender, Midfielder, Striker): ");
        string position = Console.ReadLine();
        Console.WriteLine("Podaj ilosc punktów zawodnika: ");
        int score = int.Parse(Console.ReadLine());

        Player newPlayer;
        switch (position)
        {
            case "Goalkeeper":
                newPlayer = new Player { Name = name, Position = "Goalkeeper", Score = score };
                break;
            case "Defender":
                newPlayer = new Player { Name = name, Position = "Defender", Score = score };
                break;
            case "Midfielder":
                newPlayer = new Player { Name = name, Position = "Midfielder", Score = score };
                break;
            case "Striker":
                newPlayer = new Player { Name = name, Position = "Striker", Score = score };
                break;
            default:
                Console.WriteLine("Nieprawidłowa pozycja, spróbuj ponownie.");
                return;
        }

        team.addPlayer(newPlayer);
        Console.WriteLine($"Dodano zawodnika: {newPlayer.Name}, Pozycja: {newPlayer.Position}");
    }
    private static void RemovePlayer(Team team)
    {
        Console.Write("Podaj imię zawodnika do usunięcia: ");
        string name = Console.ReadLine();
        team.RemovePlayer(name);
    }
}

