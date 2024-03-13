namespace _2._2._2;

public class Storage
{
    public string Title { get; set; }
    public int TotalArea { get; set; }
    public int LoadersCount { get; set; }
    public int Year { get; set; }

    /// <summary>
    /// Конструктор склада
    /// </summary>
    /// <param name="title">Название скалад</param>
    /// <param name="totalArea">Общая площадь</param>
    /// <param name="loadersCount">Количество автопогрузчиков</param>
    /// <param name="year">Год постройки</param>
    public Storage(string title, int totalArea, int loadersCount, int year)
    {
        Title = title;
        TotalArea = totalArea;
        LoadersCount = loadersCount;
        Year = year;
    }
}