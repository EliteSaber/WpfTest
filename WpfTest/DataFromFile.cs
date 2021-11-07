using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Models;

namespace WpfTest
{
    internal class DataFromFile
    {
        public List<Table> Full { get; private set; } = new List<Table>();
        public DataFromFile(List<string> text)
        {
            foreach (string line in text)
            {
                List<string> splitted = line.Split('|').ToList();
                Table table = new Table()
                {
                    x1a = splitted[0],
                    x1b = splitted[1],
                    x1c = splitted[2],
                    x1d = splitted[3],
                    x2 = splitted[4],
                    x3 = splitted[5],
                    x4 = splitted[6],
                    x5 = splitted[7],
                    x6 = splitted[8],
                    x7 = splitted[9],
                    x8 = splitted[10],
                    x9 = splitted[11],
                    x10 = splitted[12],
                    x11 = splitted[13],
                    x12 = splitted[14],
                    x13 = splitted[15],
                    x14 = splitted[16]
                };
                Full.Add(table);
            }
        }
    }
}
