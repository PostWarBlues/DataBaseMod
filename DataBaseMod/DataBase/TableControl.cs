using System.ComponentModel;

namespace NCE.DataBase
{
    public class TableControl : INotifyPropertyChanged
    {
        /// <summary> ID записи </summary>
        //private int id;
        /// <summary> Файл Данных  </summary>
        private byte[] dataFile;
        /// <summary> Строка таблицы дефектов </summary> 
        private string tableDefects = "";
        /// <summary> Файл настроек контроля </summary>
        private byte[] controlConfig;
        /// <summary> Файлы УЗ-настроек </summary>
        private byte[] usFiles;
        
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyValueChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary> ID записи </summary>
        public long Id { get; set; }        
        /// <summary> Файл Данных  </summary>
        public byte[] DataFile
        {
            get
            {
                return dataFile;
            }
            set
            {
                dataFile = value;
                PropertyValueChanged("DataFile");
            }
        }
        /// <summary> Файл таблицы дефектов </summary>        
        public string TableDefects
        {
            get
            {
                return tableDefects;
            }
            set
            {
                tableDefects = value;
                PropertyValueChanged("TableDefects");
            }
        }
        /// <summary> Файл настроек контроля </summary>
        public byte[] ControlConfig
        {
            get
            {
                return controlConfig;
            }
            set
            {
                controlConfig = value;
                PropertyValueChanged("ControlConfig");
            }
        }
        /// <summary> Файл настроек контроля </summary>
        public byte[] UsFiles
        {
            get
            {
                return usFiles;
            }
            set
            {
                usFiles = value;
                PropertyValueChanged("UsFiles");
            }
        }
    }
}
