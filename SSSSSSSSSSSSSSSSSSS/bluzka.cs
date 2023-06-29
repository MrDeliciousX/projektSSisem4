using SQLite;

namespace Projekt
{
    public class bluzka
    {
        [PrimaryKey, AutoIncrement]
        public int bluzka_ID { get; set; }
        public string bluzka_nazwa { get; set; }
        public string bluzka_jpg { get; set; }
        public string bluzka_plec { get; set; }
        public string bluzka_pora_roku { get; set; }
        public string bluzka_pogoda { get; set; }
        public int bluzka_waga { get; set; }
    }
}
