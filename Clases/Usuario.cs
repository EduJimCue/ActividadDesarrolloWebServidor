namespace Clases
{
    public class User
{
    public string Name { get; set;}
    public string Username{get; set;}
    public string Password { get; set; }
    public bool Role { get; set; } 
    public DateTime SignUpDate{ get; set; } 
    public int UserNumber{ get; set; } 
    private static int Number= 12345678;
    //Creador vacio para usuario inicial
    public User()
    { 
        Name="";
        Username="";
        Password="";
    }
    //Creador con datos de usuario normal
    public User(string Username,string Name, string Password)
    { 
        this.Name=Name;
        this.Username=Username;
        this.Password=Password;
        Role=false;
        SignUpDate=DateTime.Now;
        this.UserNumber=Number;
        Number++;
    }
    //Creador de datos de profesor
    public User(string Username,string Name, string Password, bool Role)
    { 
        this.Name=Name;
        this.Username=Username;
        this.Password=Password;
        this.Role=Role;
        SignUpDate=DateTime.Now;
        this.UserNumber=Number;
        Number++;
    }
}
}