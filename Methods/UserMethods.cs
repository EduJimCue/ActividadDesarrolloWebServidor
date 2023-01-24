namespace Methods{
using Clases;
using System.Text.Json;
    public class UserMethods
    {
        List<User> AllUsers = new List<User>();
        string userFile = "Json/DataUser.json";
        public void LoadUserData(){
        string userString = File.ReadAllText(userFile);
        AllUsers = JsonSerializer.Deserialize<List<User>>(userString);
        }
        public User LogIn(User actual){
                Console.WriteLine("Has elegido Iniciar sesion.");
                    Console.WriteLine("Introduce tu nombre de usuario");
                    string UserName= Console.ReadLine();
                    Console.WriteLine("Introduce tu contraseña");
                    string Pass= Console.ReadLine();
                    foreach (User user in AllUsers)
                        {
                            if (user.Username==UserName && user.Password==Pass)
                            {
                                actual=user;
                            }
                        }
                    if (actual.Name=="")
                     {
                            Console.WriteLine("No se ha encontrado ningun usuario con esas credenciales");
                            return actual;
                        }else
                        {
                            return actual;
                        }
            }
            public void SignUp(){
                Console.WriteLine("Has elegido Registrarte.");
                bool again=true;
                bool repe=false;
                string test="";
                while (again)
                {
                    repe=false;
                    Console.WriteLine("Introduce tu nombre de usuario");
                    test= Console.ReadLine();
                    foreach (User user in AllUsers)
                    {
                        if (user.Username==test)
                        {
                            Console.WriteLine("Lo sentimos ya existe un usuario con ese nombre de usuario");
                            repe= true;
                        }
                    }
                    if (!repe)
                    {
                        again=false;
                    }
                }
                Console.WriteLine("Como quieres que te llamemos?");
                string Name= Console.ReadLine();
                Console.WriteLine("Introduce tu contraseña");
                string Password= Console.ReadLine();
                var nuevo=new User(test,Name,Password);
                AllUsers.Add(nuevo);
                string userString = JsonSerializer.Serialize(AllUsers);
                File.WriteAllText(userFile,userString);
                Console.WriteLine($"Hola {Name} se ha creado tu nuevo usuario con nombre de usuario {test}");

            }
            public void ShowData(User actual){
                Console.WriteLine($"Tu username es: {actual.Username}, tu nombre es:{actual.Name}, tu fecha de alta es:{actual.SignUpDate}");
            }
            public User CloseSession(User actual){
                User empty=new User();
                Console.WriteLine("Se ha cerrado la sesion"); 
                actual=empty;
                return actual;
            }
    }
    
}