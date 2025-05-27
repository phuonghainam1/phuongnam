namespace BT_L0_PhuongHaiNam.Model;

public class Person
{
    private static int nextId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Dob { get; set; }
    public string Address { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public Person()
    {
    }
    public Person(string name, DateTime dob, string address, double height, double weight)
    {
        // id = nextId++;
        Name = name;
        Dob = dob;
        Address = address;
        Height = height;
        Weight = weight;
    }
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Date of Birth: {Dob.ToShortDateString()}, Address: {Address}, Height: {Height}, Weight: {Weight}";
    }
    public static void SetNextId(int maxId)
    {
        nextId = maxId + 1;
    }

    public void AssignId()
    {
        this.Id = nextId++;
    }

}