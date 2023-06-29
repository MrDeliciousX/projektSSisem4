using SQLite;

namespace Projekt
{
    public class dodatki
    {
        [PrimaryKey, AutoIncrement]
        public int dodatki_ID { get; set; }
        public string dodatki_nazwa { get; set; }
        public string dodatki_jpg { get; set; }
        public string dodatki_plec { get; set; }
        public string dodatki_pora_roku { get; set; }
        public string dodatki_pogoda { get; set; }
        public int dodatki_waga { get; set; }
    }
}
