using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace NCE.DataBase
{
    public class XmlExchanger
    {
        /// <summary> Путь к файлу lot </summary>
        public static string lot = string.Format(Application.StartupPath + "\\" + Const.LotDataFile);
        /// <summary> Путь к директории </summary>
        public static string directoryLotData = lot.Substring(0, lot.LastIndexOf("\\"));       

        private XmlDocument _doc = new XmlDocument();
        private XmlElement _root;
        private TableInfo _instTI = new TableInfo();

        /// <summary> Создаёт dafault XML-файл данных FormLot </summary>
        public void CreateDefaultXml()
        {
            if (!Directory.Exists(directoryLotData))
                Directory.CreateDirectory(directoryLotData);

            if (!File.Exists(lot))
            {
                XElement doc = new XElement("LotData",
                               new XElement("FIO", "Ivan Ivanov"),
                               new XElement("TabelNumb", "001"),
                               new XElement("Shift", "Blue Shift"),
                               new XElement("NormDoc", "ISO"),
                               new XElement("Specification", "Spec"),
                               new XElement("Drawing"),
                               new XElement("SteelType", "Type"),
                               new XElement("SopNumb", "test rail"),
                               new XElement("Lot", "Order"),
                               new XElement("LotNumb", "1"),
                               new XElement("HeatNumb", "1a"),
                               new XElement("BundleNumb", "Humble Bundle"),
                               new XElement("SerialNumb", "00001"),
                               new XElement("AddNumb1", "0"),
                               new XElement("AddNumb2", "0"),
                               new XElement("AddNumb3", "0"),
                               new XElement("AddNumb4", "0"),
                               new XElement("AddNumb5", "0"),
                               new XElement("ObjectLength", "100"),
                               new XElement("ObjectWidth", "100"),
                               new XElement("ObjectHeight", "100"),
                               new XElement("ObjectSpeed", "100"),
                               new XElement("ObjectOuterDiameter", "0"),
                               new XElement("ObjectInnerDiameter", "0"),
                               new XElement("ObjectWallThickness", "0"),
                               new XElement("ObjectA", "0"),
                               new XElement("ObjectB", "0"),
                               new XElement("ObjectC", "0"),
                               new XElement("ObjectD", "0"),
                               new XElement("ObjectE", "0"),
                               new XElement("ObjectF", "0"),
                               new XElement("ObjectG", "0"),
                               new XElement("ObjectH", "0"),
                               new XElement("ObjectI", "0"),
                               new XElement("ObjectJ", "0"),
                               new XElement("ObjectK", "0"),
                               new XElement("ObjectL", "0"),
                               new XElement("ObjectM", "0"),
                               new XElement("ObjectN", "0"),
                               new XElement("ObjectO", "0"),
                               new XElement("ObjectP", "0"),
                               new XElement("ObjectQ", "0"),
                               new XElement("ObjectR", "0"),
                               new XElement("ObjectS", "0"),
                               new XElement("ObjectT", "0"),
                               new XElement("ObjectU", "0"),
                               new XElement("ObjectV", "0"),
                               new XElement("ObjectW", "0"),
                               new XElement("ObjectX", "0"),
                               new XElement("ObjectY", "0"),
                               new XElement("ObjectZ", "0")
                 );
                doc.Save(lot);
            }
        }

        /// <summary> Возвращает объект считанный из XML-файла данных FormLot</summary>
        public TableInfo ReadXml()
        {
            _doc.Load(lot);
            _root = _doc.DocumentElement;

            _instTI.Fio = _root.GetElementsByTagName("FIO")[0].InnerText;
            _instTI.TabelNumb = _root.GetElementsByTagName("TabelNumb")[0].InnerText;
            _instTI.Shift = _root.GetElementsByTagName("Shift")[0].InnerText;
            _instTI.NormDoc = _root.GetElementsByTagName("NormDoc")[0].InnerText;
            _instTI.Specification = _root.GetElementsByTagName("Specification")[0].InnerText;
            _instTI.Drawing = _root.GetElementsByTagName("Drawing")[0].InnerText;
            _instTI.SteelType = _root.GetElementsByTagName("SteelType")[0].InnerText;
            _instTI.SopNumb = _root.GetElementsByTagName("SopNumb")[0].InnerText;
            _instTI.Lot = _root.GetElementsByTagName("Lot")[0].InnerText;
            _instTI.LotNumb = _root.GetElementsByTagName("LotNumb")[0].InnerText;
            _instTI.HeatNumb = _root.GetElementsByTagName("HeatNumb")[0].InnerText;
            _instTI.BundleNumb = _root.GetElementsByTagName("BundleNumb")[0].InnerText;            
            _instTI.SerialNumb = _root.GetElementsByTagName("SerialNumb")[0].InnerText;
            _instTI.AddNumb1 = _root.GetElementsByTagName("AddNumb1")[0].InnerText;
            _instTI.AddNumb2 = _root.GetElementsByTagName("AddNumb2")[0].InnerText;
            _instTI.AddNumb3 = _root.GetElementsByTagName("AddNumb3")[0].InnerText;
            _instTI.AddNumb4 = _root.GetElementsByTagName("AddNumb4")[0].InnerText;
            _instTI.AddNumb5 = _root.GetElementsByTagName("AddNumb5")[0].InnerText;
            _instTI.ObjectLength = Convert.ToDouble(_root.GetElementsByTagName("ObjectLength")[0].InnerText);
            _instTI.ObjectWidth = Convert.ToDouble(_root.GetElementsByTagName("ObjectWidth")[0].InnerText);
            _instTI.ObjectHeight = Convert.ToDouble(_root.GetElementsByTagName("ObjectHeight")[0].InnerText);
            _instTI.ObjectSpeed = Convert.ToDouble(_root.GetElementsByTagName("ObjectSpeed")[0].InnerText);
            _instTI.ObjectOuterDiameter = Convert.ToDouble(_root.GetElementsByTagName("ObjectOuterDiameter")[0].InnerText);
            _instTI.ObjectInnerDiameter = Convert.ToDouble(_root.GetElementsByTagName("ObjectInnerDiameter")[0].InnerText);
            _instTI.ObjectWallThickness = Convert.ToDouble(_root.GetElementsByTagName("ObjectWallThickness")[0].InnerText);
            _instTI.ObjectA = Convert.ToDouble(_root.GetElementsByTagName("ObjectA")[0].InnerText);
            _instTI.ObjectB = Convert.ToDouble(_root.GetElementsByTagName("ObjectB")[0].InnerText);
            _instTI.ObjectC = Convert.ToDouble(_root.GetElementsByTagName("ObjectC")[0].InnerText);
            _instTI.ObjectD = Convert.ToDouble(_root.GetElementsByTagName("ObjectD")[0].InnerText);
            _instTI.ObjectE = Convert.ToDouble(_root.GetElementsByTagName("ObjectE")[0].InnerText);
            _instTI.ObjectF = Convert.ToDouble(_root.GetElementsByTagName("ObjectF")[0].InnerText);
            _instTI.ObjectG = Convert.ToDouble(_root.GetElementsByTagName("ObjectG")[0].InnerText);
            _instTI.ObjectH = Convert.ToDouble(_root.GetElementsByTagName("ObjectH")[0].InnerText);
            _instTI.ObjectI = Convert.ToDouble(_root.GetElementsByTagName("ObjectI")[0].InnerText);
            _instTI.ObjectJ = Convert.ToDouble(_root.GetElementsByTagName("ObjectJ")[0].InnerText);
            _instTI.ObjectK = Convert.ToDouble(_root.GetElementsByTagName("ObjectK")[0].InnerText);
            _instTI.ObjectL = Convert.ToDouble(_root.GetElementsByTagName("ObjectL")[0].InnerText);
            _instTI.ObjectM = Convert.ToDouble(_root.GetElementsByTagName("ObjectM")[0].InnerText);
            _instTI.ObjectN = Convert.ToDouble(_root.GetElementsByTagName("ObjectN")[0].InnerText);
            _instTI.ObjectO = Convert.ToDouble(_root.GetElementsByTagName("ObjectO")[0].InnerText);
            _instTI.ObjectP = Convert.ToDouble(_root.GetElementsByTagName("ObjectP")[0].InnerText);
            _instTI.ObjectQ = Convert.ToDouble(_root.GetElementsByTagName("ObjectQ")[0].InnerText);
            _instTI.ObjectR = Convert.ToDouble(_root.GetElementsByTagName("ObjectR")[0].InnerText);
            _instTI.ObjectS = Convert.ToDouble(_root.GetElementsByTagName("ObjectS")[0].InnerText);
            _instTI.ObjectT = Convert.ToDouble(_root.GetElementsByTagName("ObjectT")[0].InnerText);
            _instTI.ObjectU = Convert.ToDouble(_root.GetElementsByTagName("ObjectU")[0].InnerText);
            _instTI.ObjectV = Convert.ToDouble(_root.GetElementsByTagName("ObjectV")[0].InnerText);
            _instTI.ObjectW = Convert.ToDouble(_root.GetElementsByTagName("ObjectW")[0].InnerText);
            _instTI.ObjectX = Convert.ToDouble(_root.GetElementsByTagName("ObjectX")[0].InnerText);
            _instTI.ObjectY = Convert.ToDouble(_root.GetElementsByTagName("ObjectY")[0].InnerText);
            _instTI.ObjectZ = Convert.ToDouble(_root.GetElementsByTagName("ObjectZ")[0].InnerText);

            return _instTI;
        }

        /// <summary> Заполняет XML-файл данных FormLot </summary>
        public void FillXml(TableInfo tableInfo)
        {
            XElement doc = new XElement("LotData",

                           new XElement("FIO", tableInfo.Fio),
                           new XElement("TabelNumb", tableInfo.TabelNumb),
                           new XElement("Shift", tableInfo.Shift),
                           new XElement("NormDoc", tableInfo.NormDoc),
                           new XElement("Specification", tableInfo.Specification),
                           new XElement("Drawing", tableInfo.Drawing),
                           new XElement("SteelType", tableInfo.SteelType),
                           new XElement("SopNumb", tableInfo.SopNumb),
                           new XElement("Lot", tableInfo.Lot),
                           new XElement("LotNumb", tableInfo.LotNumb),
                           new XElement("HeatNumb", tableInfo.HeatNumb),
                           new XElement("BundleNumb", tableInfo.BundleNumb),
                           new XElement("SerialNumb", tableInfo.SerialNumb),
                           new XElement("AddNumb1", tableInfo.AddNumb1),
                           new XElement("AddNumb2", tableInfo.AddNumb2),
                           new XElement("AddNumb3", tableInfo.AddNumb3),
                           new XElement("AddNumb4", tableInfo.AddNumb4),
                           new XElement("AddNumb5", tableInfo.AddNumb5),
                           new XElement("ObjectLength", tableInfo.ObjectLength),
                           new XElement("ObjectWidth", tableInfo.ObjectWidth),
                           new XElement("ObjectHeight", tableInfo.ObjectHeight),
                           new XElement("ObjectSpeed", tableInfo.ObjectSpeed),
                           new XElement("ObjectOuterDiameter", tableInfo.ObjectOuterDiameter),
                           new XElement("ObjectInnerDiameter", tableInfo.ObjectInnerDiameter),
                           new XElement("ObjectWallThickness", tableInfo.ObjectWallThickness),
                           new XElement("ObjectA", tableInfo.ObjectA),
                           new XElement("ObjectB", tableInfo.ObjectB),
                           new XElement("ObjectC", tableInfo.ObjectC),
                           new XElement("ObjectD", tableInfo.ObjectD),
                           new XElement("ObjectE", tableInfo.ObjectE),
                           new XElement("ObjectF", tableInfo.ObjectF),
                           new XElement("ObjectG", tableInfo.ObjectG),
                           new XElement("ObjectH", tableInfo.ObjectH),
                           new XElement("ObjectI", tableInfo.ObjectI),
                           new XElement("ObjectJ", tableInfo.ObjectJ),
                           new XElement("ObjectK", tableInfo.ObjectK),
                           new XElement("ObjectL", tableInfo.ObjectL),
                           new XElement("ObjectM", tableInfo.ObjectM),
                           new XElement("ObjectN", tableInfo.ObjectN),
                           new XElement("ObjectO", tableInfo.ObjectO),
                           new XElement("ObjectP", tableInfo.ObjectP),
                           new XElement("ObjectQ", tableInfo.ObjectQ),
                           new XElement("ObjectR", tableInfo.ObjectR),
                           new XElement("ObjectS", tableInfo.ObjectS),
                           new XElement("ObjectT", tableInfo.ObjectT),
                           new XElement("ObjectU", tableInfo.ObjectU),
                           new XElement("ObjectV", tableInfo.ObjectV),
                           new XElement("ObjectW", tableInfo.ObjectW),
                           new XElement("ObjectX", tableInfo.ObjectX),
                           new XElement("ObjectY", tableInfo.ObjectY),
                           new XElement("ObjectZ", tableInfo.ObjectZ)
                );
            doc.Save(lot);
        }
    }
}
