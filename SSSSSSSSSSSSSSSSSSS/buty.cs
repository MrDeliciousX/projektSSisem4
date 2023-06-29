using SQLite;

namespace Projekt
{
    public class buty
    {
        [PrimaryKey, AutoIncrement]
        public int buty_ID { get; set; }
        public string buty_nazwa { get; set; }
        public string buty_jpg { get; set; }
        public string buty_plec { get; set; }
        public string buty_pora_roku { get; set; }
        public string buty_pogoda { get; set; }
        public int buty_waga { get; set; }
    }
}
