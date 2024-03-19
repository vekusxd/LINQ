namespace _1._6;

public class Cinema
{
    public string Title { get; set; }
    public uint Capacity { get; set; }
    public uint Year { get; set; }
    public string Special { get; set; }

    /// <summary>
    /// Конструктор кинотеатра
    /// </summary>
    /// <param name="title">Название</param>
    /// <param name="capacity">Вместительность</param>
    /// <param name="year">Год открытия</param>
    /// <param name="special">Ранг(особенность)</param>
    public Cinema(string title, uint capacity, uint year, string special)
    {
        Title = title;
        Capacity = capacity;
        Year = year;
        Special = special;
    }
}