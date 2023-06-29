using SQLite;

namespace Projekt
{
    public class nakrycie
    {
        [PrimaryKey, AutoIncrement]
        public int nakrycie_ID { get; set; }
        public string nakrycie_nazwa { get; set; }
        public string nakrycie_jpg { get; set; }
        public string nakrycie_plec { get; set; }
        public string nakrycie_pora_roku { get; set; }
        public string nakrycie_pogoda { get; set; }
        public int nakrycie_waga { get; set; }
    }
}
