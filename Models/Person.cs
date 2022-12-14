namespace TP3_Habib_Sellami.Models;

public class Person
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
    public string Country { get; set; }

    public Person(long Id, string FirstName, string Lastname, string Email, string image, string Country)
    {
        Id = Id;
        FirstName = FirstName;
        LastName = LastName;
        Image = image;
        Email = Email;
        Country = Country;
    }
}
