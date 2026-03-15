namespace Clinic.Domain.Entities;

public class Speciality
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private Speciality() { }//for EF core
    
    public static Speciality Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Speciality name is invalid");

        return new Speciality { Name = name };
    }
}
