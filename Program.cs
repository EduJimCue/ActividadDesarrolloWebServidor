
namespace Prueba{ 
using Clases;
using Spectre.Console;
    class Program{ 
        List<User> AllUsers = new List<User>();
        List<Gimnasio>AllGyms = new List<Gimnasio>();
        List<Leccion>AllLessons = new List<Leccion>();
        User actual = new User();
        public void ShowMenu(){
        User profe = new User("teacher","monitor","1111",true);
        Leccion lesson= new Leccion("Karate nivel bajo",profe,"Clase de karate para principiantes",20,35,0);
        Leccion lesson1= new Leccion("Karate nivel medio",profe,"Clase de karate para gente que lleve un tiempo entrenando",20,35,30);
        Leccion lesson2= new Leccion("Karate nivel alto",profe,"Clase de karate para gente que lleve mucho tiempo y tenga buen nivel",20,35,30);
        Gimnasio gym=new Gimnasio("Sanku","Plaza de Aquimismo",45);
        AllUsers.Add(profe);
        AllGyms.Add(gym);
        AllLessons.Add(lesson);
        AllLessons.Add(lesson1);
        AllLessons.Add(lesson2);
            bool repeat= false;
            while (!repeat)
            {
                AnsiConsole.Markup("[underline red]Contenido del Menu[/]");
                Console.WriteLine("");
                if (actual.Name!="")
                {
                    AnsiConsole.Markup($"[green]Hola {actual.Name} bienvenido de vuelta[/]");
                    Console.WriteLine("");
                }
                Console.WriteLine("1-Log In");
                Console.WriteLine("2-Sign Up");
                Console.WriteLine("3-Ver gimnasios");
                Console.WriteLine("4-Buscar lecciones");
                if (actual.Name!="")
                {
                    AnsiConsole.Markup($"[blue]Zona privada del usuario[/]");
                    Console.WriteLine("");
                    Console.WriteLine("6-Mis lecciones");
                    Console.WriteLine("7-Apuntarme a una leccion");
                    Console.WriteLine("8-Mis datos");
                    Console.WriteLine("9-Cerrar sesion");
                }
                Console.WriteLine("0-Cerrar aplicacion");
                
                int valor = 0;
                bool isnum=false;
                //Menu principal
                while (!isnum)
                {
                    Console.WriteLine("Introduce el numero de la zona a la quieras entrar");
                    isnum=int.TryParse(Console.ReadLine(),out valor);
                    if (!isnum)
                    {
                        Console.WriteLine("Tienes que introducir un numero\n");
                    }
                }
                switch(valor)
                { 
                    case 0:Console.WriteLine("Hasta pronto.");
                    repeat=true;
                    break;
                    case 1: LogIn();break;
                    case 2: SignUp();break;
                    case 3: ShowGym();break;
                    case 4: SearchLesson();break;
                    case 6:if (actual.Name!="")
                    {
                        MyLessons();
                    } else
                    {
                        Console.WriteLine("No se ha encontrado la opcion pedida");
                    }
                    break;
                    case 7:if (actual.Name!="")
                    {
                        LessonSignUp();
                    } else
                    {
                        Console.WriteLine("No se ha encontrado la opcion pedida");
                    }
                    break;
                    case 8:if (actual.Name!="")
                    {
                        ShowData();
                    } else
                    {
                        Console.WriteLine("No se ha encontrado la opcion pedida");
                    }
                    break;
                    case 9:if (actual.Name!="")
                    {
                        CloseSession();
                    } else
                    {
                        Console.WriteLine("No se ha encontrado la opcion pedida");
                    }
                    break; 
                    
                    default : Console.WriteLine("No se ha encontrado la opcion pedida");
                    break; 
                } 
            }

            }
           
            //Metodos del menu
            public void LogIn(){
                Console.WriteLine("Has elegido Loguearte.");
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
                Console.WriteLine($"Hola {Name} se ha creado tu nuevo usuario con nombre de usuario {test}");

            }
            public void ShowGym(){
                Console.WriteLine("Has elegido ver la lista de gimnasios.");
                    foreach (Gimnasio gym2 in AllGyms)
                    {
                        Console.WriteLine($"Nombre:{gym2.Name} Direccion:{gym2.Adress} Mensualidad:{gym2.MonthPrice} €");
                    }

            }
            public void SearchLesson(){
                Console.WriteLine("Has elegido buscar las clases disponibles por su nombre.");
                Console.WriteLine("Introduce el nombre a buscar.");
                string texto = Console.ReadLine();
                foreach (Leccion leccion in AllLessons)
                {
                    int index = AllLessons.IndexOf(leccion);
                    if (leccion.Name.Contains(texto))
                    {
                        Console.WriteLine($"{index}-Nombre:{leccion.Name} Descripcion:{leccion.Description} Plazas disponibles:{leccion.Capacity}" );
                    }
                }
            }
            public void MyLessons(){
                Console.WriteLine("Estas apuntado a estas lecciones:");
                foreach (Leccion leccion in AllLessons)
                {
                    if (leccion.students.Contains(actual))
                    {
                        Console.WriteLine($"Nombre:{leccion.Name}, Descripcion:{leccion.Description}, Horario:{leccion.Hour}:{leccion.Minute}");
                    }
                }
            }
            public void LessonSignUp(){
                Console.WriteLine("Has elegido apuntarte a una clase.");
                foreach (Leccion leccion in AllLessons)
                {
                    int index = AllLessons.IndexOf(leccion);
                    Console.WriteLine($"{index}-Nombre:{leccion.Name}, Descripcion:{leccion.Description}, Plazas disponibles:{leccion.Capacity}");
                }
                int eleccion=0;
                bool isnum=false;
                while (!isnum)
                {
                    Console.WriteLine("Introduce el numero de la leccion a la que te quieras apuntar");
                    isnum=int.TryParse(Console.ReadLine(),out eleccion);
                    if (!isnum)
                    {
                        Console.WriteLine("Tienes que introducir un numero\n");
                    }else
                    {
                        if (eleccion >= 0 && eleccion < AllLessons.Count)
                        {   
                            Leccion selectedLesson = AllLessons[eleccion];
                            selectedLesson.AddStudent(actual);
                            }
                        else
                        {
                            Console.WriteLine("El índice seleccionado no existe.");
                            }   
                    }
                }
            }
            public void ShowData(){
                Console.WriteLine($"Tu username es: {actual.Username}, tu nombre es:{actual.Name}, tu fecha de alta es:{actual.SignUpDate}");
            }
            public void CloseSession(){
                Console.WriteLine("Se ha cerrado la sesion"); 
                actual.Name="";
            }
        }
           
    }