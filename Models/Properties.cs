namespace Esstate_Management_System.Models
{
    public class Properties
    {
        public int Id{ get; set; }
        public string PropertyName {get; set;}
        public double Price {get; set;}

        public Properties (int id, string propertyName, double price)
        {
            Id = id;
            PropertyName = propertyName;
            Price = price;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{PropertyName}%%%%%{Price}";
        }

        public static Properties ConvertToProperties(string propertiesAllFromText)
        {
            var propertiesConvert = propertiesAllFromText.Split("%%%%%");
            return new Properties(int.Parse(propertiesConvert[0]), propertiesConvert[1], double.Parse(propertiesConvert[2]));
        }
    }
}