using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Projekt
{
    public class DBConnection
    {
        private SQLiteConnection connection;

        public DBConnection()
        {
            string path = "H:\\SSSSSSSSSSSSSSSSSSS\\ciuchySSI.db";
            connection = new SQLiteConnection(path);
        }

        public List<Element> GetButyList()
        {
            string query = "SELECT * FROM buty";
            List<buty> list = connection.Query<buty>(query);
            List<Element> result = new List<Element>();
            foreach (buty buty in list)
            {
                Element element = new Element();
                element.Id = buty.buty_ID;
                element.Nazwa = buty.buty_nazwa;
                element.Jpg = buty.buty_jpg;
                element.Pora_roku = buty.buty_pora_roku;
                element.Pogoda = buty.buty_pogoda;
                element.Plec = buty.buty_plec;
                element.Waga = buty.buty_waga;

                result.Add(element);
            }
            return result;
        }

        public List<Element> GetDodatkiList()
        {
            string query = "SELECT * FROM dodatki";
            List<dodatki> list = connection.Query<dodatki>(query);
            List<Element> result = new List<Element>();
            foreach (dodatki dodatki in list)
            {
                Element element = new Element();
                element.Id = dodatki.dodatki_ID;
                element.Nazwa = dodatki.dodatki_nazwa;
                element.Jpg = dodatki.dodatki_jpg;
                element.Pora_roku = dodatki.dodatki_pora_roku;
                element.Pogoda = dodatki.dodatki_pogoda;
                element.Plec = dodatki.dodatki_plec;
                element.Waga = dodatki.dodatki_waga;

                result.Add(element);
            }
            return result;
        }

        public List<Element> GetBluzkaList()
        {
            string query = "SELECT * FROM bluzka";
            List<bluzka> list = connection.Query<bluzka>(query);
            List<Element> result = new List<Element>();
            foreach (bluzka bluzka in list)
            {
                Element element = new Element();
                element.Id = bluzka.bluzka_ID;
                element.Nazwa = bluzka.bluzka_nazwa;
                element.Jpg = bluzka.bluzka_jpg;
                element.Pora_roku = bluzka.bluzka_pora_roku;
                element.Pogoda = bluzka.bluzka_pogoda;
                element.Plec = bluzka.bluzka_plec;
                element.Waga = bluzka.bluzka_waga;

                result.Add(element);
            }
            return result;
        }

        public List<Element> GetNakrycieList()
        {
            string query = "SELECT * FROM nakrycie_glowy";
            List<nakrycie> list = connection.Query<nakrycie>(query);
            List<Element> result = new List<Element>();
            foreach (nakrycie nakrycie in list)
            {
                Element element = new Element();
                element.Id = nakrycie.nakrycie_ID;
                element.Nazwa = nakrycie.nakrycie_nazwa;
                element.Jpg = nakrycie.nakrycie_jpg;
                element.Pora_roku = nakrycie.nakrycie_pora_roku;
                element.Pogoda = nakrycie.nakrycie_pogoda;
                element.Plec = nakrycie.nakrycie_plec;
                element.Waga = nakrycie.nakrycie_waga;

                result.Add(element);
            }
            return result;
        }

        public List<Element> GetSpodnieList()
        {
            string query = "SELECT * FROM spodnie";
            List<spodnie> list = connection.Query<spodnie>(query);
            List<Element> result = new List<Element>();
            foreach (spodnie spodnie in list)
            {
                Element element = new Element();
                element.Id = spodnie.spodnie_ID;
                element.Nazwa = spodnie.spodnie_nazwa;
                element.Jpg = spodnie.spodnie_jpg;
                element.Pora_roku = spodnie.spodnie_pora_roku;
                element.Pogoda = spodnie.spodnie_pogoda;
                element.Plec = spodnie.spodnie_plec;
                element.Waga = spodnie.spodnie_waga;

                result.Add(element);
            }
            return result;
        }

        public spodnie GetSpodnieElement(int id)
        {
            string query = $"SELECT * FROM spodnie WHERE spodnie_ID = {id}";
            List<spodnie> result = connection.Query<spodnie>(query);

            return result[0];
        }

        public dodatki GetDodatekElement(int id)
        {
            string query = $"SELECT * FROM dodatki WHERE dadatki_id = {id}";
            List<dodatki> result = connection.Query<dodatki>(query);

            return result[0];
        }

        public bluzka GetBluzkaElement(int id)
        {
            string query = $"SELECT * FROM bluzka WHERE bluzka_ID = {id}";
            List<bluzka> result = connection.Query<bluzka>(query);

            return result[0];
        }

        public buty GetButyElement(int id)
        {
            string query = $"SELECT * FROM buty WHERE buty_ID = {id}";
            List<buty> result = connection.Query<buty>(query);

            return result[0];
        }

        public nakrycie GetNakrycieElement(int id)
        {
            string query = $"SELECT * FROM nakrycie_glowy WHERE nakrycie_ID = {id}";
            List<nakrycie> result = connection.Query<nakrycie>(query);

            return result[0];
        }

        public void ZmianaWagiButy(int id, int x)
        {
            int waga = GetButyElement(id).buty_waga;

            string query = $"UPDATE buty SET buty_waga = {waga + x} WHERE buty_ID = {id}";
            connection.Execute(query);
        }

        public void ZmianaWagiSpodnie(int id, int x)
        {
            int waga = GetSpodnieElement(id).spodnie_waga;

            string query = $"UPDATE spodnie SET spodnie_waga = {waga + x} WHERE spodnie_ID = {id}";
            connection.Execute(query);
        }

        public void ZmianaWagiDodatki(int id, int x)
        {
            int waga = GetDodatekElement(id).dodatki_waga;

            string query = $"UPDATE dodatki SET dodatki_waga = {waga + x} WHERE dadatki_id = {id}";
            connection.Execute(query);
        }

        public void ZmianaWagiBluzka(int id, int x)
        {
            int waga = GetBluzkaElement(id).bluzka_waga;

            string query = $"UPDATE bluzka SET bluzka_waga = {waga + x} WHERE bluzka_ID = {id}";
            connection.Execute(query);
        }

        public void ZmianaWagiNakrycie(int id, int x)
        {
            int waga = GetNakrycieElement(id).nakrycie_waga;

            string query = $"UPDATE nakrycie_glowy SET nakrycie_waga = {waga + x} WHERE nakrycie_ID = {id}";
            connection.Execute(query);
        }
    }
}
