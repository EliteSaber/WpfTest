using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Models;
using System.Xml.Linq;
using WpfTest.Interfaces;

namespace WpfTest
{
    public class DataToXML
    {
        private IEnumerable<Table> _dataSource;
        public DataToXML(IEnumerable<Table> dataSource)
        {
            _dataSource = dataSource;
        }
        public bool Create()
        {
            //нулевые значения для суммирования
            Table sum = new Table()
            {
                x2 = "0",
                x3 = "0",
                x4 = "0",
                x5 = "0",
                x6 = "0",
                x7 = "0",
                x8 = "0",
                x9 = "0",
                x10 = "0",
                x11 = "0",
                x12 = "0",
                x13 = "0",
                x14 = "0"
            };

            XDocument xdoc = new XDocument();
            // <RootXml>
            XElement rootXml = new XElement("RootXml");

            // <Report Code="042" AlbumCode="МЕС_К">
            XElement report = new XElement("Report");
            XAttribute code = new XAttribute("Code", "042");
            XAttribute albumCode = new XAttribute("AlbumCode", "МЕС_К");
            report.Add(code, albumCode);

            // <FormVariant Number="1" NsiVariantCode="0000">
            XElement formVariant = new XElement("FormVariant");
            XAttribute number = new XAttribute("Number", "1");
            XAttribute nsiVariantCode = new XAttribute("NsiVariantCode", "0000");
            formVariant.Add(number, nsiVariantCode);

            // <Table Code="Строка">
            XElement table = new XElement("Table");
            XAttribute table_code = new XAttribute("Code", "Строка");
            table.Add(table_code);

            // <Data СинтСчёт="20500" КОСГУ="000" _x2="7260254869.60" _x5="1050941374.87" _x7="1863759134.36" _x9="6447437110.11" _x12="89938.89" />

            foreach (Table record in _dataSource)
            {
                //сумма всех строк
                sum.x2 = SumStringsAsDouble(sum.x2, record.x2);
                sum.x3 = SumStringsAsDouble(sum.x3, record.x3);
                sum.x4 = SumStringsAsDouble(sum.x4, record.x4);
                sum.x5 = SumStringsAsDouble(sum.x5, record.x5);
                sum.x6 = SumStringsAsDouble(sum.x6, record.x6);
                sum.x7 = SumStringsAsDouble(sum.x7, record.x7);
                sum.x8 = SumStringsAsDouble(sum.x8, record.x8);
                sum.x9 = SumStringsAsDouble(sum.x9, record.x9);
                sum.x10 = SumStringsAsDouble(sum.x10, record.x10);
                sum.x11 = SumStringsAsDouble(sum.x11, record.x11);
                sum.x12 = SumStringsAsDouble(sum.x12, record.x12);
                sum.x13 = SumStringsAsDouble(sum.x13, record.x13);
                sum.x14 = SumStringsAsDouble(sum.x14, record.x14);

                table.Add(AddData(record));
            }
            bool isSum = true;
            table.Add(AddData(sum, isSum));
            formVariant.Add(table);
            report.Add(formVariant);
            rootXml.Add(report);
            xdoc.Add(rootXml);

            IDialogService dialog = new DefaultDialogService();
            if (dialog.SaveFileDialog())
            {
                string filePath = dialog.FilePath;
                if (!filePath.Contains(".xml"))
                    filePath += ".xml";
                xdoc.Save(filePath);
                return true;
            }
            return false;
        }
        private void AddAttribute(ref XElement element, string name, string value)
        {
            if (value != "0")
                element.Add(new XAttribute(name, value));
        }
        private string SumStringsAsDouble(string s1, string s2)
        {
            double x = double.Parse(s1) - double.Parse(s2);
            return x.ToString();
        }
        private XElement AddData(Table record, bool isSum = false)
        {
            XElement data = new XElement("Data");
            string sintValue, kosguValue;
            if(isSum)
            {
                sintValue = "88888";
                kosguValue = "888";
            }
            else
            {
                sintValue = record.x1c;
                kosguValue = record.x1d;
            }
            XAttribute sint = new XAttribute("СинтСчёт", sintValue);
            XAttribute kosgu = new XAttribute("КОСГУ", kosguValue);
            data.Add(sint, kosgu);
            AddAttribute(ref data, "_x2", record.x2);
            AddAttribute(ref data, "_x3", record.x3);
            AddAttribute(ref data, "_x4", record.x4);
            AddAttribute(ref data, "_x5", record.x5);
            AddAttribute(ref data, "_x6", record.x6);
            AddAttribute(ref data, "_x7", record.x7);
            AddAttribute(ref data, "_x8", record.x8);
            AddAttribute(ref data, "_x9", record.x9);
            AddAttribute(ref data, "_x10", record.x10);
            AddAttribute(ref data, "_x11", record.x11);
            AddAttribute(ref data, "_x12", record.x12);
            AddAttribute(ref data, "_x13", record.x13);
            AddAttribute(ref data, "_x14", record.x14);
            return data;
        }
    }
}
