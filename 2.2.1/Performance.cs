namespace _2._2._1;

public class Performance
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int MainActor_id { get; set; }
    
    /// <summary>
    /// конструктор спекткакля
    /// </summary>
    /// <param name="title">Название спекталя</param>
    /// <param name="author">Автор</param>
    /// <param name="genre">Жанр</param>
    /// <param name="mainActorId">Id главного персонажа</param>
    public Performance(string title, string author, string genre, int mainActorId)
    {
        Title = title;
        Author = author;
        Genre = genre;
        MainActor_id = mainActorId;
    }
}