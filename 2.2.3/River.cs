namespace _2._2._3;

public class River
{
    public string Title { get; set; }
    public int Length { get; set; }
    public int MaxWidth { get; set; }
    public int Tributaries { get; set; }
    public int Id { get; set; }

    /// <summary>
    /// Конструктор реки
    /// </summary>
    /// <param name="title">Название реки</param>
    /// <param name="length">Длина реки</param>
    /// <param name="maxWidth">Максимальная ширина</param>
    /// <param name="tributaries">Число притоков</param>
    /// <param name="id">Идентификатор</param>
    public River(string title, int length, int maxWidth, int tributaries, int id)
    {
        Title = title;
        Length = length;
        MaxWidth = maxWidth;
        Tributaries = tributaries;
        Id = id;
    }
}