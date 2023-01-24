namespace Methods
{
    using Clases;
    using System.Text.Json;
    using Spectre.Console;
    public class LessonMethods
    {
        List<Leccion> AllLessons = new List<Leccion>();
        string lessonFile = "Json/DataLesson.json";
        //Metodo para iniciar la lista de lecciones
        public void LoadLessonData(){
        string lessonString = File.ReadAllText(lessonFile);
        AllLessons = JsonSerializer.Deserialize<List<Leccion>>(lessonString);
        }
        public void SearchLesson(){
                Console.WriteLine("Has elegido buscar las clases disponibles por su nombre.");
                Console.WriteLine("Introduce el nombre a buscar.");
                string texto = Console.ReadLine();
                var table = new Table();
                table.AddColumn("Numero");
                table.AddColumn("Nombre");
                table.AddColumn("Descripcion");
                table.AddColumn("Plazas disponibles");
                foreach (Leccion leccion in AllLessons)
                {
                    int index = AllLessons.IndexOf(leccion);
                    if (leccion.Name.Contains(texto))
                    {
                        table.AddRow($"{index}",$"{leccion.Name}",$"{leccion.Description}", $"{leccion.Capacity}");
                    }
                }
                AnsiConsole.Write(table);
            }
             public void MyLessons(User actual){
                Console.WriteLine("Estas apuntado a estas lecciones:");
                var table = new Table();
                table.AddColumn("Nombre");
                table.AddColumn("Descripcion");
                table.AddColumn("Horario");
                foreach (Leccion leccion in AllLessons)
                {
                    if (leccion.students.Contains(actual))
                    {
                        table.AddRow($"{leccion.Name}", $"{leccion.Description}" , $"{leccion.Hour}:{leccion.Minute}");
                    }
                }
                AnsiConsole.Write(table);
            }
            public void LessonSignUp(User actual){
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
    }
    
}