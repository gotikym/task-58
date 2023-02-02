using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        SpecialSquad specialSquad = new SpecialSquad();

        Console.WriteLine("Список солдат в спец отряде Барс, после пополнения солдатами с именем начиющимся на букву Б: ");

        specialSquad.ShowNewBars();
    }
}

class SpecialSquad
{
    private List<Soldier> _storm = new List<Soldier>();
    private List<Soldier> _bars = new List<Soldier>();

    public SpecialSquad()
    {
        RecruitInStorm();
        RecruitInBars();
    }

    public void ShowNewBars()
    {

        var newBars = _storm.OrderBy(soldier => soldier.Name).TakeWhile(soldier => soldier.Name.StartsWith("Б")).ToList();
        var newStorm = _storm.Except(newBars).ToList();
        _bars.AddRange(newBars);
        _storm = newStorm;

        foreach (var soldier in _bars)
        {
            Console.WriteLine(soldier.Name + " - " + soldier.Armament + " " + soldier.Rank + " " + soldier.SoldiersLife);
        }
    }

    private void RecruitInStorm()
    {
        _storm.Add(new Soldier("Балерон", "Ротомолотилка", "Балерон", 33));
        _storm.Add(new Soldier("Ловкач", "Снайперская винтовка", "Зверь", 20));
        _storm.Add(new Soldier("Шенген", "Слезоточивая граната", "Путешественник", 27));
        _storm.Add(new Soldier("Батон", "Расщепитель", "Злодей", 41));
        _storm.Add(new Soldier("Мека", "Разрезающий всё нож", "Факт", 10));
        _storm.Add(new Soldier("Трактор", "Газонокосилка", "Икс мен", 18));
        _storm.Add(new Soldier("Бостян", "Трёхметровый гриф", "Тухлячок", 55));
        _storm.Add(new Soldier("Бербей", "Убедительный взгляд", "Борец", 61));
    }

    private void RecruitInBars()
    {
        _bars.Add(new Soldier("Валера", "Ротомолотилка", "Е*ейший", 56));
        _bars.Add(new Soldier("Андрюха", "Снайперская винтовка", "Воин", 23));
        _bars.Add(new Soldier("Евген", "Слезоточивая граната", "Псих", 18));
        _bars.Add(new Soldier("Антон", "Расщепитель", "Кощей", 30));
        _bars.Add(new Soldier("Жека", "Разрезающий всё нож", "Ноунейм", 16));
        _bars.Add(new Soldier("Виктор", "Газонокосилка", "Чумачечий", 22));
        _bars.Add(new Soldier("Костян", "Трёхметровый гриф", "Качок", 11));
        _bars.Add(new Soldier("Сергей", "Убедительный взгляд", "Хитрец", 47));
    }
}

class Soldier
{
    public Soldier(string name, string armament, string rank, int soldiersLife)
    {
        Name = name;
        Armament = armament;
        Rank = rank;
        SoldiersLife = soldiersLife;
    }

    public string Name { get; private set; }
    public string Armament { get; private set; }
    public string Rank { get; private set; }
    public int SoldiersLife { get; private set; }
}
