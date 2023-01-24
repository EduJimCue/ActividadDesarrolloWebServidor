
namespace Prueba{ 
using Clases;
using Spectre.Console;
using Methods;
    class Program{ 
        UserMethods userMethods = new UserMethods();
        GymMethods gymMethods = new GymMethods();
        LessonMethods lessonMethods = new LessonMethods();
        User actual = new User();
        public void ShowMenu(){
        userMethods.LoadUserData();
        gymMethods.LoadGymData();
        lessonMethods.LoadLessonData();
            bool repeat= false;
            while (!repeat)
            {
                Console.WriteLine($"{System.Environment.NewLine}");
                AnsiConsole.Markup("[underline blue]Contenido del Menu[/]");
                Console.WriteLine("");
                if (actual.Name!="")
                {
                    AnsiConsole.Markup($"[green]Hola {actual.Name} bienvenido de vuelta[/]");
                    Console.WriteLine("");
                }
                Console.WriteLine("1-Iniciar Sesion");
                Console.WriteLine("2-Registrate");
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
                        Console.WriteLine("");
                        AnsiConsole.Markup("[red]TIENES QUE INTRODUCIR UN NUMERO[/]");
                        Console.WriteLine($"{System.Environment.NewLine}");
                    }
                }
                switch(valor)
                { 
                    case 0:Console.WriteLine("Hasta pronto.");
                    repeat=true;
                    break;
                    case 1: actual=userMethods.LogIn(actual);break;
                    case 2: userMethods.SignUp();break;
                    case 3: gymMethods.ShowGym();break;
                    case 4: lessonMethods.SearchLesson();break;
                    case 6:if (actual.Name!="")
                    {
                        lessonMethods.MyLessons(actual);
                    } else
                    {
                        AnsiConsole.Markup("[red]No se ha encontrado la opcion pedida");
                    }break;
                    case 7:if (actual.Name!="")
                    {
                        lessonMethods.LessonSignUp(actual);
                    } else
                    {
                        AnsiConsole.Markup("[red]No se ha encontrado la opcion pedida");
                    }break;
                    case 8:if (actual.Name!="")
                    {
                        userMethods.ShowData(actual);
                    } else
                    {
                        AnsiConsole.Markup("[red]No se ha encontrado la opcion pedida");
                    }break;
                    case 9:if (actual.Name!="")
                    {
                        actual=userMethods.CloseSession(actual);
                    } else
                    {
                        AnsiConsole.Markup("[red]No se ha encontrado la opcion pedida");
                    }break; 
                    default :AnsiConsole.Markup("[red]No se ha encontrado la opcion pedida");;break; 
                } 
            }
            }
        }
           
    }