namespace _2._2._1;

public class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }

    /// <summary>
    /// Единственный конструктор
    /// </summary>
    /// <param name="title">Название фильма</param>
    /// <param name="year">Год выпуска</param>
    /// <param name="genre">Жанр</param>
    /// <param name="director">Режиссер</param>
    public Movie(string title, int year, string genre, string director)
    {
        Title = title;
        Year = year;
        Genre = genre;
        Director = director;
    }

    public Movie()
    {
        
    }
}