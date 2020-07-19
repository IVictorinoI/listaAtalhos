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
        private List<Atalho> Lista { get; set; }

        public Atalhos()
        {
            Lista = new List<Atalho>();
        }

        public void Initialize()
        {
            GetFromPath(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs");
            GetFromPath(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs");
            GetExtraFolders();
        }

        private void GetExtraFolders()
        {
            if (!File.Exists(@"./mais.txt"))
                return;

            var lines = File.ReadAllLines(@"./mais.txt").ToList();
            lines.ForEach(GetFromPath);
        }

        public void GetFromPath(string path)
        {
            if (!Directory.Exists(path))
                return;

            GetFromDirectory(new DirectoryInfo(path));
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
            //SaveFav(path);
        }

        public void SaveFav(string path)
        {
            using (var file = new StreamWriter(@"Favoritos.txt"))
            {
                file.WriteLine(path);
            };

            var fileName = "Favoritos.xml";
            XElement doc;
            if (File.Exists(fileName))
            {
                doc = XElement.Load(fileName);
            }
            else
            {
                doc = new XElement("Favoritos");
            }

            XElement favorite = new XElement("Favorito");
            favorite.Add(new XElement("Caminho", path));
            doc.Add(favorite);
            doc.Save(fileName);
        }
    }
}

