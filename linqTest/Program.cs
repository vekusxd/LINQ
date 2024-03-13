using System.Data.SqlTypes;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using _2._2._1;

namespace linqTest;

class Program
{
    static void Main(string[] args)
    {
        task2_2();

    }

    static void task2_2()
    {
                List<Movie> movies = new List<Movie>();
        movies.Add(new Movie("Побег из Шоушенка ", 1994, "драма", "Фрэнк Дарабонт"));
        movies.Add(new Movie("Зеленая миля", 1999, "драма", "Фрэнк Дарабонт"));
        movies.Add(new Movie("Форрест Гамп", 1994, "драма", "Роберт Земекис"));
        movies.Add(new Movie("1+1", 2011, "драма", "Оливье Накаш"));
        movies.Add(new Movie("Бойцовский клуб", 1999, "триллер", "Дэвид Финчер"));
    
        //Сортиврока по годам
        var MoviesByYear = movies.OrderBy(y => y.Year);
        foreach (var movie in MoviesByYear)
        {
            Console.WriteLine($"{movie.Title} - {movie.Year}");
        }

        List<Actor> actors = new List<Actor>();
        actors.Add(new Actor("Михал", "Казаков", "Владимирович", 1976, "герой", 1));
        actors.Add(new Actor("Иванов", "Игорь", "Юрьевич", 1954, "герой", 2));
        actors.Add(new Actor("Павел", "Лазарев", "", 1995, "затейник", 3));
        actors.Add(new Actor("Борис", "Невзоров", "", 1950, "злодей интриган", 4));
        actors.Add(new Actor("Сергей", "Маковецкий", "Васильевич", 1965, "инодушный", 5));
        
        List<Performance> performances = new List<Performance>();
        performances.Add(new Performance("Борис Годунов", "Николай Голованов", "опера", 1));
        performances.Add(new Performance("БРАТЬЯ КАРАМАЗОВЫ", "Лев Додин ", "пьеса", 2));
        performances.Add(new Performance("Ревиззор", "Александр Славутский", "комедия", 3));
        performances.Add(new Performance("ДМИТРИЙ САМОЗВАНЕЦ И ВАСИЛИЙ ШУЙСКИЙ", "А.Н. Островский", "пьеса", 4));
        performances.Add(new Performance("Евгений Онегин", "А.С. Пушкин", "опера", 5));
    
        //Группировка по амплуа и году рождения
        var GroupByYearAndRole = actors.GroupBy(filter => new { filter.Role, filter.Birthdate });
        
        Console.WriteLine("\n\n---------------------------\n\n");
        
        foreach (var item in GroupByYearAndRole)
        {
            foreach(var actor in item)
            {
                Console.WriteLine($"{actor.LastName}, {actor.Birthdate}, {actor.Role}");
            }
        }
        
        //Слияение кинофильма и спектакля
        var movieQuery = movies.Select(movie => new
        {
            Name = movie.Title,
            Genre = movie.Genre,
            Author = movie.Director
        });
        var performanceQuery = performances.Select(performance => new
        {
            Name = performance.Title,
            Genre = performance.Genre,
            Author = performance.Author
        });
        
        Console.WriteLine("\n\n---------------------------\n\n");
        
        foreach (var item in movieQuery.Concat(performanceQuery))
        {
            Console.WriteLine($"{item.Name}, {item.Genre}, {item.Author}");
        }
        
        Console.WriteLine("\n\n---------------------------\n\n");

        //Спектакль и актер join
        var performancesWithActors = performances.Join(actors,
            first => first.MainActor_id,
            second => second.Id,
            (first, second) => new
            {
                Title = first.Title, Author = first.Author, Genre = first.Genre,
                MainActorInitials = second.FirstName + " " + second.LastName, ActorRole = second.Role
            });

        foreach (var item in performancesWithActors)
        {
            Console.WriteLine($"{item.Title}, {item.Author}, {item.Genre}, {item.MainActorInitials} - {item.ActorRole}");
        }
    }
}