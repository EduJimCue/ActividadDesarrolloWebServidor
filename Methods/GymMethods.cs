namespace Methods
{
    using Clases;
    using System.Text.Json;
    using Spectre.Console;
    public class GymMethods{
         List<Gimnasio> AllGyms = new List<Gimnasio>();
        string gymFile = "Json/DataGym.json";
        //Metodo para iniciar la lista de los gimnasios
        public void LoadGymData(){
        string gymString = File.ReadAllText(gymFile);
        AllGyms = JsonSerializer.Deserialize<List<Gimnasio>>(gymString);
        }
        //Metodo para mostrar todos los gimnasios
        public void ShowGym(){
                Console.WriteLine("Has elegido ver la lista de gimnasios.");
                var table = new Table();
                table.AddColumn("Nombre");
                table.AddColumn("Direccion");
                table.AddColumn("Precio");
                    foreach (Gimnasio gym2 in AllGyms)
                    {
                        table.AddRow($"{gym2.Name}",$"{gym2.Adress}",$"{gym2.MonthPrice} €");
                    }
                    AnsiConsole.Write(table);
            }
        
    }    
}