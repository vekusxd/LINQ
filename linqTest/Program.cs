using System.Data.SqlTypes;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using _2._2._1;
using _2._2._2;

namespace linqTest;

class Program
{
    static void Main(string[] args)
    {
        //task2_2_1();
        //task2_2_2();
    }   
    

    static void task2_2_1()
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

    static void task2_2_2()
    {
                List<Manufacturer> manufacturers = new List<Manufacturer>();
        manufacturers.Add(new Manufacturer("Саранский СКЗ", "Меркушкин Александр Николаевич", 1));
        manufacturers.Add(new Manufacturer("Обоянский консервный завод", "Мезенцева О.А.", 2));
        manufacturers.Add(new Manufacturer("Мираторг", "Никитин Александр Александрович", 3));
        manufacturers.Add(new Manufacturer("Spar russia", "Сергей Локтев", 4));
        manufacturers.Add(new Manufacturer("Вкусвилл", "Андрей Александрович Кривенко", 5));
        
        List<Product> products = new List<Product>();
        products.Add(new Product("Помидоры", 150, 30, 1));
        products.Add(new Product("Огурцы", 100, 10, 2));
        products.Add(new Product("Арахиc", 50, 20, 4));
        products.Add(new Product("Кешью", 300, 40, 5));
        products.Add(new Product("Чипсы", 90, 80, 4));
        products.Add(new Product("Фисташки", 400, 60, 1));
        products.Add(new Product("Говядина", 250, 98, 3));

        List<Storage> storages = new List<Storage>();
        storages.Add(new Storage("Склад - 1", 400, 50, 1999));
        storages.Add(new Storage("Склад - 4", 145, 30, 2017));
        storages.Add(new Storage("Склад - 5", 200, 70, 2011));
        storages.Add(new Storage("Склад - 6", 1000, 150, 1956));
        storages.Add(new Storage("Склад - 2", 250, 50, 1899));
        storages.Add(new Storage("Склад - 3", 600, 150, 2005));



        //Сортировка по стоимости
        var OrderedProducts = products.OrderBy(p => p.Price);

        foreach (var product in OrderedProducts)
        {
            Console.WriteLine($"{product.Title}, {product.Price}");
        }
        
        Console.WriteLine("\n\n--------------------------------------------\n\n");
        
        //Данные сгрупированные по автопогрузчикам и году постройки
        var GroupStorages = storages.GroupBy(storage => new { storage.LoadersCount, storage.Year });

        foreach (var storageGroup in GroupStorages )
        {
            foreach (var storage in storageGroup)
            {
                Console.WriteLine($"{storage.Title}, {storage.TotalArea}, {storage.LoadersCount}, {storage.Year}");
            }
        }
        
        Console.WriteLine("\n\n--------------------------------------------\n\n");
        
        //Количество погрузчиков
        int LoadersCount = storages.Sum(s => s.LoadersCount);

        Console.WriteLine($"Количество погрузчиков - {LoadersCount}");
        
        Console.WriteLine("\n\n--------------------------------------------\n\n");
        
        //Товар с производителем
        var productsWithManufacturers = products.Join(manufacturers,
            p => p.Manufacturer_id,
            m => m.Id,
            (p, m) => new { Product = p.Title, Manufacturer = m.Title });

        foreach (var product in productsWithManufacturers)
        {  
            Console.WriteLine($"{product.Product}, {product.Manufacturer}");
        }
    }
    
}