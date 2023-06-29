using SQLite;

namespace Projekt
{
    public class spodnie
    {
        [PrimaryKey, AutoIncrement]
        public int spodnie_ID { get; set; }
        public string spodnie_nazwa { get; set; }
        public string spodnie_jpg { get; set; }
        public string spodnie_plec { get; set; }
        public string spodnie_pora_roku { get; set; }
        public string spodnie_pogoda { get; set; }
        public int spodnie_waga { get; set; }
    }
}
