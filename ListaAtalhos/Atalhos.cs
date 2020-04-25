using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListaAtalhos
{
    public class Atalhos
    {
        public List<Atalho> Lista { get; set; }

        public Atalhos()
        {
            Lista = new List<Atalho>();
        }

        public void Initialize()
        {
            this.GetFromPath(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs");
            this.GetFromPath(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs");
        }

        public void GetFromDirectory(DirectoryInfo dir)
        {
            foreach (var file in dir.GetFiles())
            {
                if (file.Extension.Equals(".lnk"))
                {
                    Lista.Add(new Atalho
                    {
                        Caminho = file.FullName,
                        Nome = file.Name,
                        Extensao = file.Extension,
                        Icone = string.Empty,
                        VezesAberto = 0
                    });
                }
            }

            foreach (var subDir in dir.GetDirectories())
            {
                GetFromDirectory(subDir);
            }            
        }

        public void GetFromPath(string path)
        {
            GetFromDirectory(new DirectoryInfo(path));
        }

        public IEnumerable<Atalho> Search(string pesquisa)
        {
            pesquisa = pesquisa.ToUpper();

            return Lista.Where(c => c.Caminho.ToUpper().Contains(pesquisa));
        }

        public Atalho GetAtalhoFromPath(string path)
        {
            return Lista.Where(p => p.Caminho.ToUpper() == path.ToUpper()).FirstOrDefault();
        }

        public void StartProgramFromPath(string path)
        {
            Process.Start(path);
            SaveFav(path);
        }

        public void SaveFav(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Favoritos.txt"))
            {
                file.WriteLine(path);
            };

            var nomeArquivo = "Favoritos.xml";
            XElement doc;
            if (File.Exists(nomeArquivo))
            {
                doc = XElement.Load(nomeArquivo);
            }
            else
            {
                doc = new XElement("Favoritos");
            }

            XElement favorito = new XElement("Favorito");
            favorito.Add(new XElement("Caminho", path));
            doc.Add(favorito);
            doc.Save(nomeArquivo);
        }
    }
}

