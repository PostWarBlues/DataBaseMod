using System;
using System.ComponentModel;

namespace NCE.DataBase
{
    public class TableInfo : INotifyPropertyChanged
    {
        public const byte Accepted = 0;
        public const byte Rejected = 1;

        private long id;
        /// <summary> ФИО </summary>
        private string fio = "";
        /// <summary> Табельный номер </summary>
        private string tabelNumb = "";
        /// <summary> Смена </summary>
        private string shift = "";
        /// <summary> Нормативный документ </summary>
        private string normDoc;
        /// <summary> Спецификация </summary>
        private string specification;
        /// <summary> Чертёж </summary>
        private string drawing;
        /// <summary> Тип стали </summary>
        private string steelType;
        /// <summary> Номер СОПА </summary>
        private string sopNumb = "";
        /// <summary> Заказ </summary>
        private string lot = "";
        /// <summary> Номер заказа </summary>
        private string lotNumb = "";
        /// <summary> Номер плавки </summary>
        private string heatNumb = "";
        /// <summary> Номер пакета </summary>
        private string bundleNumb = "";
        /// <summary> Номер изделия </summary>
        private string serialNumb = "";

        #region Дополнительные string поля
        private string addNumb1 = "";
        private string addNumb2 = "";
        private string addNumb3 = "";
        private string addNumb4 = "";
        private string addNumb5 = "";
        #endregion

        /// <summary> Длинна изделия </summary> 
        private double objectLength;
        /// <summary> Ширина изделия </summary> 
        private double objectWidth;
        /// <summary> Высота изделия </summary>
        private double objectHeight;
        /// <summary> Скорость контроля </summary>
        private double objectSpeed;
        /// <summary> Внешний диаметр </summary>
        private double objectOuterDiameter;
        /// <summary> Внутренний диаметр </summary>
        private double objectInnerDiameter;
        /// <summary> Толщина стенок </summary>
        private double objectWallThickness;

        #region Дополнительные double поля

        private double objectA;
        private double objectB;
        private double objectC;
        private double objectD;
        private double objectE;
        private double objectF;
        private double objectG;
        private double objectH;
        private double objectI;
        private double objectJ;
        private double objectK;
        private double objectL;
        private double objectM;
        private double objectN;
        private double objectO;
        private double objectP;
        private double objectQ;
        private double objectR;
        private double objectS;
        private double objectT;
        private double objectU;
        private double objectV;
        private double objectW;
        private double objectX;
        private double objectY;
        private double objectZ;
        #endregion

        /// <summary> Путь к файлам УЗ настроек </summary>
        private string usFilesPath = "empty";
        /// <summary> Результат контроля </summary>
        private byte controlResult;
        /// <summary> Дата и время </summary>
        private DateTime dateTimeStump;

        public TableInfo()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyValueChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary> Идентификатор</summary>
        public long ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                PropertyValueChanged("ID");
            }
        }

        /// <summary> ФИО </summary>
        public string Fio
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
                PropertyValueChanged("Fio");
            }
        }

        /// <summary> Табельный номер </summary>
        public string TabelNumb
        {
            get
            {
                return tabelNumb;
            }
            set
            {
                tabelNumb = value;
                PropertyValueChanged("TabelNumb");
            }
        }

        /// <summary> Смена </summary>
        public string Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
                PropertyValueChanged("Shift");
            }
        }

        /// <summary> Нормативный документ </summary>
        public string NormDoc
        {
            get
            {
                return normDoc;
            }
            set
            {
                normDoc = value;
                PropertyValueChanged("NormDoc");
            }
        }

        /// <summary> Спецификация </summary>
        public string Specification
        {
            get
            {
                return specification;
            }
            set
            {
                specification = value;
                PropertyValueChanged("Specification");
            }
        }

        /// <summary> Чертёж </summary>
        public string Drawing
        {
            get
            {
                return drawing;
            }
            set
            {
                drawing = value;
                PropertyValueChanged("Drawing");
            }
        }

        /// <summary> Проект </summary>
        public string SteelType
        {
            get
            {
                return steelType;
            }
            set
            {
                steelType = value;
                PropertyValueChanged("SteelType");
            }
        }

        /// <summary> Номер СОПА </summary>
        public string SopNumb
        {
            get
            {
                return sopNumb;
            }
            set
            {
                sopNumb = value;
                PropertyValueChanged("SopNumb");
            }
        }

        /// <summary> Заказ </summary>
        public string Lot
        {
            get
            {
                return lot;
            }
            set
            {
                lot = value;
                PropertyValueChanged("Lot");
            }
        }

        /// <summary> Номер заказа </summary>
        public string LotNumb
        {
            get
            {
                return lotNumb;
            }
            set
            {
                lotNumb = value;
                PropertyValueChanged("LotNumb");
            }
        }

        /// <summary> Номер плавки </summary>
        public string HeatNumb
        {
            get
            {
                return heatNumb;
            }
            set
            {
                heatNumb = value;
                PropertyValueChanged("HeatNumb");
            }
        }

        /// <summary> Номер пакета </summary>
        public string BundleNumb
        {
            get
            {
                return bundleNumb;
            }
            set
            {
                bundleNumb = value;
                PropertyValueChanged("BundleNumb");

            }
        }

        /// <summary> Номер изделия </summary>
        public string SerialNumb
        {
            get
            {
                return serialNumb;
            }
            set
            {
                serialNumb = value;
                PropertyValueChanged("SerialNumb");
            }
        }
        
        public string AddNumb1
        {
            get
            {
                return addNumb1;
            }
            set
            {
                addNumb1 = value;
                PropertyValueChanged("SerialNumb");
            }
        }
        
        public string AddNumb2
        {
            get
            {
                return addNumb2;
            }
            set
            {
                addNumb2 = value;
                PropertyValueChanged("SerialNumb");
            }
        }
        
        public string AddNumb3
        {
            get
            {
                return addNumb3;
            }
            set
            {
                addNumb3 = value;
                PropertyValueChanged("SerialNumb");
            }
        }
        
        public string AddNumb4
        {
            get
            {
                return addNumb4;
            }
            set
            {
                addNumb4 = value;
                PropertyValueChanged("SerialNumb");
            }
        }
        
        public string AddNumb5
        {
            get
            {
                return addNumb5;
            }
            set
            {
                addNumb5 = value;
                PropertyValueChanged("SerialNumb");
            }
        }

        /// <summary> Длинна изделия </summary> 
        public double ObjectLength
        {
            get
            {
                return objectLength;
            }
            set
            {
                objectLength = value;
                PropertyValueChanged("ObjectLength");
            }
        }

        /// <summary> Ширина изделия </summary> 
        public double ObjectWidth
        {
            get
            {
                return objectWidth;
            }
            set
            {
                objectWidth = value;
                PropertyValueChanged("ObjectWidth");
            }
        }

        /// <summary> Высота изделия </summary>
        public double ObjectHeight
        {
            get
            {
                return objectHeight;
            }
            set
            {
                objectHeight = value;
                PropertyValueChanged("ObjectHeight");
            }
        }

        /// <summary> Скорость контроля</summary>
        public double ObjectSpeed
        {
            get
            {
                return objectSpeed;
            }
            set
            {
                objectSpeed = value;
                PropertyValueChanged("ObjectSpeed");
            }
        }

        /// <summary> Внешний диаметр </summary>
        public double ObjectOuterDiameter
        {
            get
            {
                return objectOuterDiameter;
            }
            set
            {
                objectOuterDiameter = value;
                PropertyValueChanged("ObjectSpeed");
            }
        }

        /// <summary> Внутренний диаметр </summary>
        public double ObjectInnerDiameter
        {
            get
            {
                return objectInnerDiameter;
            }
            set
            {
                objectInnerDiameter = value;
                PropertyValueChanged("ObjectSpeed");
            }
        }

        /// <summary> Толщина стенок </summary>
        public double ObjectWallThickness
        {
            get
            {
                return objectWallThickness;
            }
            set
            {
                objectWallThickness = value;
                PropertyValueChanged("ObjectSpeed");
            }
        }

        /// <summary> Файл УЗ настроек </summary>
        public string UsFilesPath
        {
            get
            {
                return usFilesPath;
            }
            set
            {
                usFilesPath = value;
                PropertyValueChanged("UsFilesPath");
            }
        }

        /// <summary> Результат контроля </summary>
        public byte ControlResult
        {
            get
            {
                return controlResult;
            }
            set
            {
                controlResult = value;
                PropertyValueChanged("ControlResult");
            }
        }

        /// <summary> Дата и время </summary>
        public DateTime DateTimeStump
        {
            get
            {
                return dateTimeStump;
            }
            set
            {
                dateTimeStump = value;
            }
        }

        public double ObjectA
        {
            get
            {
                return objectA;
            }
            set
            {
                objectA = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectB
        {
            get
            {
                return objectB;
            }
            set
            {
                objectB = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectC
        {
            get
            {
                return objectC;
            }
            set
            {
                objectC = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectD
        {
            get
            {
                return objectD;
            }
            set
            {
                objectD = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectE
        {
            get
            {
                return objectE;
            }
            set
            {
                objectE = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectF
        {
            get
            {
                return objectF;
            }
            set
            {
                objectF = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectG
        {
            get
            {
                return objectG;
            }
            set
            {
                objectG = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectH
        {
            get
            {
                return objectH;
            }
            set
            {
                objectH = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectI
        {
            get
            {
                return objectI;
            }
            set
            {
                objectI = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectJ
        {
            get
            {
                return objectJ;
            }
            set
            {
                objectJ = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectK
        {
            get
            {
                return objectK;
            }
            set
            {
                objectK = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectL
        {
            get
            {
                return objectL;
            }
            set
            {
                objectL = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectM
        {
            get
            {
                return objectM;
            }
            set
            {
                objectM = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectN
        {
            get
            {
                return objectN;
            }
            set
            {
                objectN = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectO
        {
            get
            {
                return objectO;
            }
            set
            {
                objectO = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectP
        {
            get
            {
                return objectP;
            }
            set
            {
                objectP = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectQ
        {
            get
            {
                return objectQ;
            }
            set
            {
                objectQ = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectR
        {
            get
            {
                return objectR;
            }
            set
            {
                objectR = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectS
        {
            get
            {
                return objectS;
            }
            set
            {
                objectS = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectT
        {
            get
            {
                return objectT;
            }
            set
            {
                objectT = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectU
        {
            get
            {
                return objectU;
            }
            set
            {
                objectU = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectV
        {
            get
            {
                return objectV;
            }
            set
            {
                objectV = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectW
        {
            get
            {
                return objectW;
            }
            set
            {
                objectW = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectX
        {
            get
            {
                return objectX;
            }
            set
            {
                objectX = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectY
        {
            get
            {
                return objectY;
            }
            set
            {
                objectY = value;
                PropertyValueChanged("ControlResult");
            }
        }

        public double ObjectZ
        {
            get
            {
                return objectZ;
            }
            set
            {
                objectZ = value;
                PropertyValueChanged("ControlResult");
            }
        }
    }
}
