using System.Security.AccessControl;

namespace _2._2._1;

public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Birthdate { get; set; }
        public string Role { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="birthdate">Год рождения</param>
        /// <param name="role">Амплуа</param>
        /// <param name="id">Идентификатор</param>
        public Actor(string firstName, string lastName, string patronymic, int birthdate, string role, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Birthdate = birthdate;
            Role = role;
            Id = id;
        }
    }
