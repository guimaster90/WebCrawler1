using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawler1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
           
            var url = "https://myanimelist.net/topmanga.php";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var trs = htmlDocument.DocumentNode.Descendants("tr").Where(node => node.GetAttributeValue("class", "").Equals("ranking-list")).ToList();
            var mangas = new List<Manga>();
            
            foreach (var tr in trs)
            {
                /*
                var manga = new Manga
                {

                    Rank = tr.Descendants("td").Where(node => node.GetAttributeValue("class", "").Equals("rank ac")).FirstOrDefault().InnerText.Trim(),
                    Nome = tr.Descendants("h3").Where(node => node.GetAttributeValue("class", "").Equals("manga_h3")).FirstOrDefault().InnerText,
                    Score = tr.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("js-top-ranking-score-col di-ib al")).FirstOrDefault().InnerText,
                    Link = tr.Descendants("a").FirstOrDefault().GetAttributeValue("href", " "),
                    Information = tr.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("information di-ib mt4")).FirstOrDefault().InnerText,
                    ImageUrl = tr.Descendants("img").FirstOrDefault().ChildAttributes("data-srcset").FirstOrDefault().Value
                };
                mangas.Add(manga);
                */
                Console.WriteLine("Rank: " + tr.Descendants("td").Where(node => node.GetAttributeValue("class", "").Equals("rank ac")).FirstOrDefault().InnerText.Trim()
                    );
                Console.WriteLine("Nome: " + tr.Descendants("h3").Where(node => node.GetAttributeValue("class", "").Equals("manga_h3")).FirstOrDefault().InnerText
                    );
                Console.WriteLine(tr.Descendants("a").FirstOrDefault().GetAttributeValue("href", " ")
                    );
                Console.WriteLine("Score: " + tr.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("js-top-ranking-score-col di-ib al")).FirstOrDefault().InnerText
                    );
                Console.WriteLine("Link das imagens: " + tr.Descendants("img").FirstOrDefault().ChildAttributes("data-srcset").FirstOrDefault().Value
                    );
                Console.WriteLine(tr.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("information di-ib mt4")).FirstOrDefault().InnerText
                    );
            }
            /*
            string MyConnection = "Driver={MySQL ODBC 5.2 ANSI Driver};Server=localhost;Database=test;User=root;Password=;Option=3;";
            //string MyConnection = "datasource=localhost;username=root;password=";  
            OdbcConnection con = new OdbcConnection(MyConnection);
            con.Open();
            try
            {
                int count = mangas.Count;
                foreach (var item in mangas)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string query = "insert into mangas(rank,nome,score,link,information,imageurl) value(?,?,?,?);";
                        OdbcCommand cmd = new OdbcCommand(query, con);
                        cmd.Parameters.Add("?rank", OdbcType.VarChar).Value = mangas[i].Rank;
                        cmd.Parameters.Add("?nome", OdbcType.VarChar).Value = mangas[i].Nome;
                        cmd.Parameters.Add("?score", OdbcType.VarChar).Value = mangas[i].Score;
                        cmd.Parameters.Add("?link", OdbcType.VarChar).Value = mangas[i].Link;
                        cmd.Parameters.Add("?information", OdbcType.VarChar).Value = mangas[i].Information;
                        cmd.Parameters.Add("?imageurl", OdbcType.VarChar).Value = mangas[i].ImageUrl;
                        OdbcDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                    }

                    count = 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            */
        }
    }
}
