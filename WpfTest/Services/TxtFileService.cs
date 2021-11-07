using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Interfaces;

namespace WpfTest
{
    public class TxtFileService : IFileService
    {
        private readonly List<char> _bannedSymbols = new List<char>() { '*', '#', 'Т' };
        public List<string> Open(string filename)
        {
            List<string> text = new List<string>();
            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    bool isBanned = true;
                    foreach(char ban in _bannedSymbols)
                    {
                        isBanned = line[0].Equals(ban);
                        if (isBanned)
                            break;
                    }
                    if (!isBanned)
                        text.Add(line);
                }
            }
            return text;
        }
    }
}
