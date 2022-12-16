namespace Clases
{
    public class Gimnasio
{
    public string Name { get; set;}
    public string Adress{get; set;}
    public int MonthPrice { get; set; }
    public DateTime SignUpDate{ get; set; } 
    public int GymNumber{ get; set; } 
    public List<Leccion> lessons=new List<Leccion>();
    private static int Number= 12345678;
    //Creador con datos
    public Gimnasio(string Name, string Adress, int MonthPrice)
    { 
        this.Name=Name;
        this.Adress=Adress;
        this.MonthPrice=MonthPrice;
        SignUpDate=DateTime.Now;
        this.GymNumber=Number;
        Number++;
    }
}
}