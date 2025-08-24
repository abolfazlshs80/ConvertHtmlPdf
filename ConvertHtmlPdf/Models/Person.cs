namespace ConvertHtmlPdf.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int Age { get; set; }
}

public static class PersonViewModel
{



    public static List<Person> Persons { get; set; } = Persons = new List<Person>()
            {
                new Person() { Id = 1, Name = "علی", Family = "رضایی", Age = 30 },
                new Person() { Id = 2, Name = "مریم", Family = "کاظمی", Age = 25 },
                new Person() { Id = 3, Name = "حسین", Family = "محمدی", Age = 28 },
                new Person() { Id = 4, Name = "زهرا", Family = "احمدی", Age = 22 },
                new Person() { Id = 5, Name = "رضا", Family = "جعفری", Age = 35 }
            };
}
