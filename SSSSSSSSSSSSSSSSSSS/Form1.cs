using Microsoft.Scripting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;
using System.IO;
using SSSSSSSSSSSSSSSSSSS;
using System.Drawing;
using System.Net;

namespace Projekt
{
    public partial class Form1 : Form
    {
        List<int> Lbuty;
        List<int> Lspodnie;
        List<int> Lbluzka;
        List<int> Ldodatki;
        List<int> Lnakrycie;

        DBConnection connection;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Projekt SSI";

            connection = new DBConnection();


            List<string> listaPoryRoku = new List<string>
            {
                "wiosna",
                "lato",
                "jesień",
                "zima"
            };
            poraRoku.Items.AddRange(listaPoryRoku.ToArray());
            poraRoku.SelectedIndex = 0;

            List<string> listaPogoda = new List<string>
            {
                "słonecznie",
                "deszczowo",
                "zimno",
                "śnieżnie",
                "wietrznie",
                "neutralnie"
            };
            pogoda.Items.AddRange(listaPogoda.ToArray());
            pogoda.SelectedIndex = 0;

            List<string> listaPlci = new List<string>
            {
                "kobieta",
                "mężczyzna"
            };
            plec.Items.AddRange(listaPlci.ToArray());
            plec.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var klient = new List<string>();
            klient.Add(poraRoku.SelectedItem.ToString());
            klient.Add((waga1Suwak.Value).ToString());
            klient.Add(pogoda.SelectedItem.ToString());
            klient.Add((waga2Suwak.Value).ToString());
            klient.Add(plec.SelectedItem.ToString());

            string sciezkaKlient = "H:\\SSSSSSSSSSSSSSSSSSS\\klient.txt";

            using (StreamWriter writer = new StreamWriter(sciezkaKlient))
            {
                foreach (string item in klient)
                {
                    writer.WriteLine(item);
                }
            }

            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();

            scope.SetVariable("Klient", klient);

            scope.SetVariable("Buty", connection.GetButyList());
            scope.SetVariable("Bluzka", connection.GetBluzkaList());
            scope.SetVariable("Dodatki", connection.GetDodatkiList());
            scope.SetVariable("Spodnie", connection.GetSpodnieList());
            scope.SetVariable("Nakrycie", connection.GetNakrycieList());

            string scriptPath = "H:\\SSSSSSSSSSSSSSSSSSS\\ssiProjekt-1.py";
            ScriptSource script = engine.CreateScriptSourceFromFile(scriptPath);

            script.Execute(scope);

            Lbuty = new List<int>();
            Lspodnie = new List<int>();
            Lbluzka = new List<int>();
            Ldodatki = new List<int>();
            Lnakrycie = new List<int>();

            string sciezkaWyniki = "H:\\SSSSSSSSSSSSSSSSSSS\\wyniki.txt";
            using (StreamReader sr = new  StreamReader(sciezkaWyniki))
            {
                string linia;
                linia = sr.ReadLine();
                string[] wartosci = linia.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    int wartosc;
                    if (int.TryParse(wartosci[i], out wartosc))
                    {
                        Lbuty.Add(wartosc);
                    }
                }

                linia = sr.ReadLine();
                wartosci = linia.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    int wartosc;
                    if (int.TryParse(wartosci[i], out wartosc))
                    {
                        Lbluzka.Add(wartosc);
                    }
                }

                linia = sr.ReadLine();
                wartosci = linia.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    int wartosc;
                    if (int.TryParse(wartosci[i], out wartosc))
                    {
                        Ldodatki.Add(wartosc);
                    }
                }

                linia = sr.ReadLine();
                wartosci = linia.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    int wartosc;
                    if (int.TryParse(wartosci[i], out wartosc))
                    {
                        Lnakrycie.Add(wartosc);
                    }
                }

                linia = sr.ReadLine();
                wartosci = linia.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    int wartosc;
                    if (int.TryParse(wartosci[i], out wartosc))
                    {
                        Lspodnie.Add(wartosc);
                    }
                }
            }

            v1.Visible = true;
            x1.Visible = true;
            v2.Visible = true;
            x2.Visible = true;
            v3.Visible = true;
            x3.Visible = true;
            v4.Visible = true;
            x4.Visible = true;

            name11.Text = connection.GetNakrycieElement(Lnakrycie[0]).nakrycie_nazwa;
            //DownloadAndSetImage(connection.GetNakrycieElement(Lnakrycie[0]).nakrycie_jpg, pic11);
            name21.Text = connection.GetNakrycieElement(Lnakrycie[1]).nakrycie_nazwa;
            //DownloadAndSetImage(connection.GetNakrycieElement(Lnakrycie[1]).nakrycie_jpg, pic21);
            name31.Text = connection.GetNakrycieElement(Lnakrycie[2]).nakrycie_nazwa;
            //DownloadAndSetImage(connection.GetNakrycieElement(Lnakrycie[2]).nakrycie_jpg, pic31);
            name41.Text = connection.GetNakrycieElement(Lnakrycie[3]).nakrycie_nazwa;
            //DownloadAndSetImage(connection.GetNakrycieElement(Lnakrycie[3]).nakrycie_jpg, pic41);

            name12.Text = connection.GetBluzkaElement(Lbluzka[0]).bluzka_nazwa;
            //DownloadAndSetImage(connection.GetBluzkaElement(Lbluzka[0]).bluzka_jpg, pic12);
            name22.Text = connection.GetBluzkaElement(Lbluzka[1]).bluzka_nazwa;
            //DownloadAndSetImage(connection.GetBluzkaElement(Lbluzka[1]).bluzka_jpg, pic22);
            name32.Text = connection.GetBluzkaElement(Lbluzka[2]).bluzka_nazwa;
            ///DownloadAndSetImage(connection.GetBluzkaElement(Lbluzka[2]).bluzka_jpg, pic32);
            name42.Text = connection.GetBluzkaElement(Lbluzka[3]).bluzka_nazwa;
            //DownloadAndSetImage(connection.GetBluzkaElement(Lbluzka[3]).bluzka_jpg, pic42);

            name13.Text = connection.GetSpodnieElement(Lspodnie[0]).spodnie_nazwa;
            //DownloadAndSetImage(connection.GetSpodnieElement(Lspodnie[0]).spodnie_jpg, pic13);
            name23.Text = connection.GetSpodnieElement(Lspodnie[1]).spodnie_nazwa;
            //DownloadAndSetImage(connection.GetSpodnieElement(Lspodnie[1]).spodnie_jpg, pic23);
            name33.Text = connection.GetSpodnieElement(Lspodnie[2]).spodnie_nazwa;
            //DownloadAndSetImage(connection.GetSpodnieElement(Lspodnie[2]).spodnie_jpg, pic33);
            name43.Text = connection.GetSpodnieElement(Lspodnie[3]).spodnie_nazwa;
            //DownloadAndSetImage(connection.GetSpodnieElement(Lspodnie[3]).spodnie_jpg, pic43);

            name14.Text = connection.GetButyElement(Lbuty[0]).buty_nazwa;
            //DownloadAndSetImage(connection.GetButyElement(Lbuty[0]).buty_jpg, pic14);
            name24.Text = connection.GetButyElement(Lbuty[1]).buty_nazwa;
            //DownloadAndSetImage(connection.GetButyElement(Lbuty[1]).buty_jpg, pic24);
            name34.Text = connection.GetButyElement(Lbuty[2]).buty_nazwa;
            //DownloadAndSetImage(connection.GetButyElement(Lbuty[2]).buty_jpg, pic34);
            name44.Text = connection.GetButyElement(Lbuty[3]).buty_nazwa;
            //DownloadAndSetImage(connection.GetButyElement(Lbuty[3]).buty_jpg, pic44);

            name15.Text = connection.GetDodatekElement(Ldodatki[0]).dodatki_nazwa;
            //DownloadAndSetImage(connection.GetDodatekElement(Ldodatki[0]).dodatki_jpg, pic15);
            name25.Text = connection.GetDodatekElement(Ldodatki[1]).dodatki_nazwa;
            //DownloadAndSetImage(connection.GetDodatekElement(Ldodatki[1]).dodatki_jpg, pic25);
            name35.Text = connection.GetDodatekElement(Ldodatki[2]).dodatki_nazwa;
            //DownloadAndSetImage(connection.GetDodatekElement(Ldodatki[2]).dodatki_jpg, pic35);
            name45.Text = connection.GetDodatekElement(Ldodatki[3]).dodatki_nazwa;
            //DownloadAndSetImage(connection.GetDodatekElement(Ldodatki[3]).dodatki_jpg, pic45);

        }

        private void waga1Suwak_Scroll(object sender, EventArgs e)
        {
            double value = waga1Suwak.Value;
            value *= 0.1;
            waga1.Text = value.ToString();
        }

        private void waga2Suwak_Scroll(object sender, EventArgs e)
        {
            double value = waga2Suwak.Value;
            value *= 0.1;
            waga2.Text = value.ToString();
        }

        private void v1_Click(object sender, EventArgs e)
        {
            v1.Visible = false;
            x1.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[0], 1);
            connection.ZmianaWagiBluzka(Lbluzka[0], 1);
            connection.ZmianaWagiSpodnie(Lspodnie[0], 1);
            connection.ZmianaWagiButy(Lbuty[0], 1);
            connection.ZmianaWagiDodatki(Ldodatki[0], 1);
        }

        private void x1_Click(object sender, EventArgs e)
        {
            v1.Visible = false;
            x1.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[0], -1);
            connection.ZmianaWagiBluzka(Lbluzka[0], -1);
            connection.ZmianaWagiSpodnie(Lspodnie[0], -1);
            connection.ZmianaWagiButy(Lbuty[0], -1);
            connection.ZmianaWagiDodatki(Ldodatki[0], -1);
        }

        private void v2_Click(object sender, EventArgs e)
        {
            v2.Visible = false;
            x2.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[1], 1);
            connection.ZmianaWagiBluzka(Lbluzka[1], 1);
            connection.ZmianaWagiSpodnie(Lspodnie[1], 1);
            connection.ZmianaWagiButy(Lbuty[1], 1);
            connection.ZmianaWagiDodatki(Ldodatki[1], 1);
        }

        private void x2_Click(object sender, EventArgs e)
        {
            v2.Visible = false;
            x2.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[1], -1);
            connection.ZmianaWagiBluzka(Lbluzka[1], -1);
            connection.ZmianaWagiSpodnie(Lspodnie[1], -1);
            connection.ZmianaWagiButy(Lbuty[1], -1);
            connection.ZmianaWagiDodatki(Ldodatki[1], -1);
        }

        private void v3_Click(object sender, EventArgs e)
        {
            v3.Visible = false;
            x3.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[2], 1);
            connection.ZmianaWagiBluzka(Lbluzka[2], 1);
            connection.ZmianaWagiSpodnie(Lspodnie[2], 1);
            connection.ZmianaWagiButy(Lbuty[2], 1);
            connection.ZmianaWagiDodatki(Ldodatki[2], 1);
        }

        private void x3_Click(object sender, EventArgs e)
        {
            v3.Visible = false;
            x3.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[2], -1);
            connection.ZmianaWagiBluzka(Lbluzka[2], -1);
            connection.ZmianaWagiSpodnie(Lspodnie[2], -1);
            connection.ZmianaWagiButy(Lbuty[2], -1);
            connection.ZmianaWagiDodatki(Ldodatki[2], -1);
        }

        private void v4_Click(object sender, EventArgs e)
        {
            v4.Visible = false;
            x4.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[3], 1);
            connection.ZmianaWagiBluzka(Lbluzka[3], 1);
            connection.ZmianaWagiSpodnie(Lspodnie[3], 1);
            connection.ZmianaWagiButy(Lbuty[3], 1);
            connection.ZmianaWagiDodatki(Ldodatki[3], 1);
        }

        private void x4_Click(object sender, EventArgs e)
        {
            v4.Visible = false;
            x4.Visible = false;
            connection.ZmianaWagiNakrycie(Lnakrycie[3], -1);
            connection.ZmianaWagiBluzka(Lbluzka[3], -1);
            connection.ZmianaWagiSpodnie(Lspodnie[3], -1);
            connection.ZmianaWagiButy(Lbuty[3], -1);
            connection.ZmianaWagiDodatki(Ldodatki[3], -1);
        }

        private void DownloadAndSetImage(string imageUrl, PictureBox pictureBox1)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(imageUrl);
                    using (MemoryStream memoryStream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(memoryStream);
                        pictureBox1.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
