namespace _2._2._3;

public class Sea
{
    public string Title { get; set; }
    public int TotalArea { get; set; }
    public int Id { get; set; }

    /// <summary>
    /// Конструктор моря
    /// </summary>
    /// <param name="title">Название моря</param>
    /// <param name="totalArea">Площадь моря</param>
    /// <param name="id">Идентификатор моря</param>
    public Sea(string title, int totalArea, int id)
    {
        Title = title;
        TotalArea = totalArea;
        Id = id;
    }
}