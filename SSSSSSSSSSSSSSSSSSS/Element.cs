namespace Projekt
{
    public class Element
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Jpg { get; set; }
        public string Plec { get; set; }
        public string Pora_roku { get; set; }
        public string Pogoda { get; set; }
        public int Waga { get; set; }

        public override string ToString()
        {
            return $"{Id} ";
        }
    }
}
