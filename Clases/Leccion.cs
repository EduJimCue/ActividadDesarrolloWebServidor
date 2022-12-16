namespace Clases
{
    public class Leccion
{
    public string Name { get; set;}
    public User Teacher{get; set;}
    public List<User> students = new List<User>();
    public string Description { get; set; }
    public int Hour{ get; set; } 
    public int Minute{ get; set; } 
    public int Capacity{ get; set; } 
    
    //Creador con datos
    public Leccion(string Name, User Teacher, string Description,int Hour, int Minute, int Capacity)
    { 
        if (Teacher.Role==false)
        {
            Console.WriteLine("El usuario seleccionado no es un profesor");
        }else
        {
            this.Name=Name;
            this.Teacher=Teacher;
            this.Description=Description;
            this.Hour=Hour;
            this.Minute=Minute;
            this.Capacity=Capacity;
        }
    }
    //Metodos de la  clase
    public void AddStudent(User student){
        students.Add(student);
        Capacity--;
    }
}
}

