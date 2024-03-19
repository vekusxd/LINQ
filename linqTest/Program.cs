using System.Data.SqlTypes;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using _1._6;
using _2._2._1;
using _2._2._2;
using _2._2._3;
using _2._2._4;
using Microsoft.VisualBasic.CompilerServices;

namespace linqTest;

class Program
{
    static void Main(string[] args)
    {

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

    static void task_2_2_3()
    {
                //task2_2_1();
        //task2_2_2();
        List<River> rivers = new List<River>();
        rivers.Add(new River("Енисей", 3487000, 700, 500, 1));
        rivers.Add(new River("Обь", 3650000, 12000, 161000, 2));
        rivers.Add(new River("Лена", 4400000, 2000, 176, 3));
        rivers.Add(new River("Амур", 2824000, 300, 50, 4));

        List<Sea> seas = new List<Sea>();
        seas.Add(new Sea("Средиземное море", 2500000 , 5));
        seas.Add(new Sea("Берингово море", 2260000, 6));
        seas.Add(new Sea("Жёлтое море", 416000, 7));
        seas.Add(new Sea("Азовское море", 39000, 8));
        seas.Add(new Sea("Балтийское море", 419000, 9));

        List<Ship> ships = new List<Ship>();
        ships.Add(new Ship("Корабль - 1", 2000, "Пароходная1", 1999, "речной", 4));
        ships.Add(new Ship("Корабль - 2", 1500, "Пароходная1", 2001, "речной", 1));
        ships.Add(new Ship("Корабль - 3", 5000, "Пароходная2", 2005, "морской", 9));
        ships.Add(new Ship("Корабль - 4", 1200, "Пароходная2", 1987, "морской", 7));
        ships.Add(new Ship("Корабль - 5", 500, "Пароходная1", 2003, "речной", 2));

        //Реки по длине
        var OrderedRivers = rivers.OrderBy(r => r.Length);

        foreach (var river in OrderedRivers)
        {
            Console.WriteLine($"{river.Title}, {river.Length}");
        }
        
        Console.WriteLine("\n\n---------------------------\n\n");

        //Данные сгрупированные по пароходству и году постройки
        var groupedShips = ships.GroupBy(s => new { s.Owner, s.Year });

        foreach (var ShipsKey in groupedShips)
        {
            foreach (var ship in ShipsKey)
            {
                Console.WriteLine($"{ship.Title}, {ship.Owner}, {ship.Year}");
            }
        }
        
        Console.WriteLine("\n\n---------------------------\n\n");
        
        //Число кораблей в пароходстве
        int shipsCount = ships.Count();
        
        Console.WriteLine($"Количество кораблей - {shipsCount}");
        
        Console.WriteLine("\n\n---------------------------\n\n");
        
        //Корабль и река join

        var shipWithRiver = ships.Join(rivers,
            s => s.Water_id,
            r => r.Id,
            (s, r) => new { Ship = s.Title, River = r.Title });

        foreach (var ship in shipWithRiver)
        {
            Console.WriteLine($"{ship.Ship}, {ship.River}");
        }
    }

    static void task_2_2_4()
    {
                List<Airplane> airplanes = new List<Airplane>();
        airplanes.Add(new Airplane("Самолет 1","Пассажирский", 380, 14600, 64, 2000, 1));
        airplanes.Add(new Airplane("Самолет 2","Пассажирский", 400, 16400, 65, 1900, 2));
        airplanes.Add(new Airplane("Самолет 3","Пассажирский", 450, 20000, 70, 2300, 1));
        airplanes.Add(new Airplane("Самолет 4","Пассажирский", 140, 13000, 60, 1600, 3));

        List<Helicopter> helicopters = new List<Helicopter>();
        helicopters.Add(new Helicopter("Пассажирский", 5, 5000, 10000, 2));
        helicopters.Add(new Helicopter("Пассажирский", 6,  4000, 12000, 2));
        helicopters.Add(new Helicopter("Пассажирский", 4, 3000, 6000, 3));
        helicopters.Add(new Helicopter("Пассажирский", 6, 3400, 6700, 1));

        List<Company> companies = new List<Company>();
        companies.Add(new Company("Аэрофлот", "Какой-то адресс", 1995, 1));
        companies.Add(new Company("Nordwind", "Еще один адресс", 2000, 2));
        companies.Add(new Company("Победа", "Адрес третьей компании", 1991, 3));

        //Самолет отсортиврованный по грузоподъемности
        var sortedPlanes = airplanes.OrderBy(p => p.WeightCapacity);
        foreach (var plane in sortedPlanes)
        {
            Console.WriteLine($"{plane.Type}, {plane.WeightCapacity}");
        }
        
        Console.WriteLine("\n\n---------------------------\n\n");
        
        //Вертолет групированный по высоте подъема и дальности полета
        var groupedHelicopters = helicopters.GroupBy(h => new { h.MaxLength, h.MaxHeight });
        foreach (var helicopterGroups in groupedHelicopters)
        {
            foreach (var helicopter in helicopterGroups)
            {
                Console.WriteLine($"{helicopter.Type}, {helicopter.MaxLength}, {helicopter.MaxHeight}");
            }
        }
        
        Console.WriteLine("\n\n---------------------------\n\n");

        //Самолетов в компании
        int countPlanesInCompanyOne = airplanes.Count(p => p.CompanyId == 1);
        Console.WriteLine($"Самолетов в первой компании - {countPlanesInCompanyOne}");
        
        Console.WriteLine("\n\n---------------------------\n\n");


        //Самолеты с компанией
        var planesWithCompanyFull = airplanes.Join(companies,
            p => p.CompanyId,
            c => c.Id,
            (p, c) => new { p.Name, c.Title });

        foreach (var plane in planesWithCompanyFull)
        {
            Console.WriteLine($"{plane.Name}, {plane.Title}");
        }
    }

    static void task_1_1_2()
    {
                List<_1._2.Product> products = new List<_1._2.Product>();
        products.Add((new _1._2.Product("Помидоры", 234.5, 48,
            ["2023-11-15", "2023-11-15", "2024-04-08"], "Завод 1")));
        products.Add(new _1._2.Product("Огурцы", 123.5, 45,
            ["2022-11-19", "2022-12-09", "2022-07-06"], "Завод 2"));
        products.Add(new _1._2.Product("Тапочки", 200, 56, 
            ["2023-11-15"],"Завод 3"));
        var selectAll = products.Select(p => p);

        foreach (var item in selectAll)
        {
            Console.WriteLine($"{item.Title}, {item.Manufacturer}, {item.Cost}, {item.Count}");
        }
        
        Console.WriteLine("\n----------------\n");

        //Один фильтр
        var oneFilter = products.Where(p => p.Count > 50);

        foreach (var item in oneFilter)
        {
            Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
        }
        
        Console.WriteLine("\n----------------\n");

        //несколько фильтров
        var moreFilters = products.Where(p => p.Count < 50 && p.Cost > 200);

        foreach (var item in moreFilters)
        {
            Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
        }
        
        Console.WriteLine("\n----------------\n");

        //Сортировка по одному полю
        var sortedOneField = products.OrderBy(p => p.Count);
        foreach (var item in sortedOneField)
        {
            Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
        }
        
        Console.WriteLine("\n----------------\n");
        
        //Сортировка по нескольким полям
        var sortedTwoFileds = products.OrderBy(p => p.Title).ThenByDescending(p => p.Count);
        foreach (var item in sortedTwoFileds)
        {
            Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
        }
        
        Console.WriteLine("\n----------------\n");

        //Группировка по одному полю
        var groupedByOne = products.GroupBy(p => p.Cost);
        foreach (var itemKey in groupedByOne)
        {
            foreach (var item in itemKey)
            {
                Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
            }
        }
        
        Console.WriteLine("\n----------------\n");

        var groupedByMany = products.GroupBy(p => new { p.Cost, p.Count });
        foreach (var itemKey in groupedByMany)
        {
            foreach (var item in itemKey)
            {
                Console.WriteLine($"{item.Title}, {item.Count}, {item.Manufacturer}, {item.Cost}");
            }
        }
        
        Console.WriteLine("\n----------------\n");
        
        //Проекция
        var projection = products.Select(p => new
        {
            Title = p.Title,
            TotalCost = p.Cost * p.Count
        });

        foreach (var item in projection)
        {
            Console.WriteLine($"{item.Title}, {item.TotalCost}");
        }
    }

    static void task_1_1_6()
    {
                List<Cinema> cinemas = new List<Cinema>();
        cinemas.Add(new Cinema("Киномакс", 1500, 1999, "Для просмотра видеофильмов"));
        cinemas.Add(new Cinema("Центральный", 1500, 1999, "Для просмотра широкоформатных фильмов"));
        cinemas.Add(new Cinema("Ближний", 500, 2015, "наличие стереоформатного оборудования"));
        cinemas.Add(new Cinema("Плаза", 2000, 2015, "Большая вместимость"));
        cinemas.Add(new Cinema("Восточный", 1700, 1923, "Первый кинотеатр"));

        //Простой выбор
        var allRes = cinemas.Select(s => s);
        foreach (var item in allRes)
        {
            Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
        }
        
        Console.WriteLine("\n-------------------------\n");
        
        //С одним фильтром
        var withOneFilter = cinemas.Where(s => s.Capacity > 1300);

        foreach (var item in withOneFilter)
        {
            Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
        }
        
        Console.WriteLine("\n-------------------------\n");
        
        //С несколькими фильтрами
        var withMoreFilters = cinemas.Where(s => s.Capacity < 1600 && s.Year > 1998);

        foreach (var item in withMoreFilters)
        {
            Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
        }
        
        Console.WriteLine("\n-------------------------\n");

        //Сортировка по одному полю
        var sortedWithOne = cinemas.OrderBy(s => s.Capacity);
        
        foreach (var item in sortedWithOne)
        {
            Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
        }
        
        Console.WriteLine("\n-------------------------\n");

        //Сортировка по нескольким полям
        var sortedwithMany = cinemas.OrderBy(s => s.Capacity).ThenByDescending(s => s.Year);
        foreach (var item in sortedwithMany)
        {
            Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
        }
        Console.WriteLine("\n-------------------------\n");

        //Группировка по одному полю
        var groupedByOne = cinemas.GroupBy(s => s.Capacity);
        foreach (var itemKey in groupedByOne)
        {
            foreach (var item in itemKey)
            {
                Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
            }
        }
        Console.WriteLine("\n-------------------------\n");

        //Группиврока по нескольким полям
        var groupedByMany = cinemas.GroupBy(s => new { s.Capacity, s.Year });
        foreach (var itemKey in groupedByMany)
        {
            foreach (var item in itemKey)
            {
                Console.WriteLine($"{item.Title}, {item.Year}, {item.Capacity}, {item.Special}");
            }
        }
        Console.WriteLine("\n-------------------------\n");

        //Проекция
        var projection = cinemas.Select(s => new
        {
            Title = s.Title,
            TotalYear = DateTime.Now.Year - s.Year,
            Capacity = s.Capacity
        });

        foreach (var item in projection)
        {
            Console.WriteLine($"{item.Title}, {item.TotalYear}, {item.Capacity}");
        }
    }
    
}