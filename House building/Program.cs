using System;
using System.Collections.Generic;

// Интерфейс для части дома
interface IPart
{
    void Build();
}

// Интерфейс для строителя
interface IWorker
{
    void Work(House house);
}

// Классы частей дома, реализующие интерфейс IPart
class Basement : IPart
{
    public void Build()
    {
        Console.WriteLine("Basement is built");
    }
}

class Walls : IPart
{
    public void Build()
    {
        Console.WriteLine("Walls are built");
    }
}

class Door : IPart
{
    public void Build()
    {
        Console.WriteLine("Door is installed");
    }
}

class Window : IPart
{
    public void Build()
    {
        Console.WriteLine("Window is installed");
    }
}

class Roof : IPart
{
    public void Build()
    {
        Console.WriteLine("Roof is constructed");
    }
}

// Класс строителя
class Worker : IWorker
{
    public void Work(House house)
    {
        foreach (IPart part in house.Parts)
        {
            part.Build();
        }
    }
}

// Класс бригадира
class TeamLeader : IWorker
{
    public void Work(House house)
    {
        Console.WriteLine("TeamLeader is checking the progress of the construction");
        foreach (IPart part in house.Parts)
        {
            part.Build();
        }
    }
}

// Класс дома
class House
{
    public List<IPart> Parts { get; set; } = new List<IPart>();

    public void DisplayHouse()
    {
        Console.WriteLine("Current state of the house:");
        

        Console.WriteLine("      /***\\");
        Console.WriteLine("     /     \\");
        Console.WriteLine("    |  +  + |");


        Console.WriteLine("       ___    ");       
        Console.WriteLine("    | +| |+ |");
        Console.WriteLine("     \\______/");
        Console.WriteLine();

        foreach (IPart part in Parts)
        {
            Console.Write(part.GetType().Name + " is present. ");
        }
    }
}

// Класс бригады строителей
class Team
{
    private List<IWorker> workers = new List<IWorker>();

    public void AddWorker(IWorker worker)
    {
        workers.Add(worker);
    }

    public void StartBuilding(House house)
    {
        Console.WriteLine("Construction of the house started by the team:");

        house.Parts.Add(new Basement()); // 1 фундамент

        for (int i = 0; i < 4; i++)
        {
            house.Parts.Add(new Walls()); // 4 стены
        }

        house.Parts.Add(new Door()); // 1 дверь

        for (int i = 0; i < 4; i++)
        {
            house.Parts.Add(new Window()); // 4 окна
        }

        house.Parts.Add(new Roof()); // 1 крыша

        foreach (IWorker worker in workers)
        {
            worker.Work(house);
        }

        Console.WriteLine("Construction of the house completed");
    }
}

class Program
{
    static void Main()
    {
        House house = new House();
        Team team = new Team();

        team.AddWorker(new Worker());
        team.AddWorker(new Worker());
        team.AddWorker(new TeamLeader());

        team.StartBuilding(house);

        house.DisplayHouse();

        Console.ReadLine();
    }
}
