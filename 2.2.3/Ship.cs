namespace _2._2._3;

public class Ship
{
    public string Title { get; set; }
    public int PassengersCount { get; set; }
    public string Owner { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    public int Water_id { get; set; }

    /// <summary>
    /// Консртуктор корабля
    /// </summary>
    /// <param name="title">Название</param>
    /// <param name="passengersCount">Количество пассажиров</param>
    /// <param name="owner">Владеющая компания</param>
    /// <param name="year">Год создания</param>
    /// <param name="type">тип</param>
    /// <param name="waterId">Id водоема</param>
    public Ship(string title, int passengersCount, string owner, int year, string type, int waterId)
    {
        Title = title;
        PassengersCount = passengersCount;
        Owner = owner;
        Year = year;
        Type = type;
        Water_id = waterId;
    }
}