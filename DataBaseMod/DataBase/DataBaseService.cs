using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;


namespace NCE.DataBase
{
    public class DataBaseService // : StringBuilderForDB, IDataBaseInterface
    {
        /// <summary> Путь к файлу БД </summary>
        public static string _filePathDB = string.Format(Application.StartupPath + "\\Data\\" + Const.FileNameDB);
        /// <summary> Путь директории БД </summary>
        public static string _directoryDB = _filePathDB.Substring(0, _filePathDB.LastIndexOf("\\"));
        /// <summary> Подключение БД </summary>
        public static SQLiteConnection connectionDB = new SQLiteConnection(string.Format("Data Source={0};Version=3;", _filePathDB));

        public TableControl _tableControl = new TableControl();

        /// <summary>
        /// Создание новой БД
        /// </summary>        
        public bool CreateNewDB()
        {
            try
            {
                if (!Directory.Exists(_directoryDB))
                    Directory.CreateDirectory(_directoryDB);

                if (!File.Exists(_filePathDB))
                    SQLiteConnection.CreateFile(_filePathDB);

                OpenConnection();
                CreateTableInfo();
                CreateTableControl();                
                return true;
            }

            catch (Exception ex)
            {
                string error = string.Format(ex.Message + "\nCan't create data base directory '{0}'!", _directoryDB);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Открывает соединение с БД
        /// </summary>        
        private bool OpenConnection()
        {
            try
            {
                connectionDB.Open();
                return true;
            }
            catch (Exception ex)
            {
                string error = string.Format(ex.Message + "\nCan't connect to data base!");
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }
        }
        
        /// <summary>
        /// Закрывает соединение с БД
        /// </summary>  
        private bool CloseConnection()
        {
            try
            {
                connectionDB.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        /// <summary>
        /// Создает таблицу Info
        /// </summary> 
        private bool CreateTableInfo()
        {
            using (SQLiteCommand commandDB = new SQLiteCommand(connectionDB))
            {
                commandDB.CommandText =
                "CREATE TABLE IF NOT EXISTS "
                + "info "
                + "("
                + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                + "fio TEXT NOT NULL, "
                + "tabelNumb TEXT NOT NULL, "
                + "shift TEXT NOT NULL, "
                + "normDoc TEXT NOT NULL, "
                + "specification TEXT NOT NULL, "
                + "drawing TEXT NOT NULL, "
                + "steelType TEXT NOT NULL, "
                + "sopNumb TEXT NOT NULL, "
                + "lot TEXT NOT NULL, "
                + "lotNumb TEXT NOT NULL, "
                + "heatNumb TEXT NOT NULL, "
                + "bundleNumb TEXT NOT NULL, "
                + "serialNumb TEXT NOT NULL, "
                + "addNumb1 TEXT NOT NULL, "
                + "addNumb2 TEXT NOT NULL, "
                + "addNumb3 TEXT NOT NULL, "
                + "addNumb4 TEXT NOT NULL, "
                + "addNumb5 TEXT NOT NULL, "
                + "objectLength REAL NOT NULL, "
                + "objectWidth REAL NOT NULL, "
                + "objectHeight REAL NOT NULL, "
                + "objectSpeed REAL NOT NULL, "
                + "objectOuterDiameter REAL NOT NULL, "
                + "objectInnerDiameter REAL NOT NULL, "
                + "objectWallThickness REAL NOT NULL, "
                + "objectA REAL NOT NULL, "
                + "objectB REAL NOT NULL, "
                + "objectC REAL NOT NULL, "
                + "objectD REAL NOT NULL, "
                + "objectE REAL NOT NULL, "
                + "objectF REAL NOT NULL, "
                + "objectG REAL NOT NULL, "
                + "objectH REAL NOT NULL, "
                + "objectI REAL NOT NULL, "
                + "objectJ REAL NOT NULL, "
                + "objectK REAL NOT NULL, "
                + "objectL REAL NOT NULL, "
                + "objectM REAL NOT NULL, "
                + "objectN REAL NOT NULL, "
                + "objectO REAL NOT NULL, "
                + "objectP REAL NOT NULL, "
                + "objectQ REAL NOT NULL, "
                + "objectR REAL NOT NULL, "
                + "objectS REAL NOT NULL, "
                + "objectT REAL NOT NULL, "
                + "objectU REAL NOT NULL, "
                + "objectV REAL NOT NULL, "
                + "objectW REAL NOT NULL, "
                + "objectX REAL NOT NULL, "
                + "objectY REAL NOT NULL, "
                + "objectZ REAL NOT NULL, "
                + "usFilesPath TEXT NOT NULL, "
                + "controlResult INT NOT NULL, "
                + "dateTime TEXT NOT NULL"                
                + ")";
                try
                {                    
                    commandDB.CommandType = CommandType.Text;
                    commandDB.ExecuteNonQuery();                    
                    return true;
                }
                catch (Exception ex)
                {                    
                    return false;
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Создает таблицу Control
        /// </summary> 
        private bool CreateTableControl()
        {
            using (SQLiteCommand commandDB = new SQLiteCommand(connectionDB))
             {
                    commandDB.CommandText =
                       "CREATE TABLE IF NOT EXISTS "
                       + "control "
                       + "("
                       + "id INTEGER PRIMARY KEY AUTOINCREMENT, "                       
                       + "dataFile BLOB NOT NULL, "
                       + "tableDefects BLOB NOT NULL, "
                       + "controlConfig BLOB NOT NULL, "
                       + "usFiles BLOB NOT NULL"
                       //+ "id_control INT NOT NULL"
                       //+ "FOREIGN KEY (id_control) REFERENCES info(id)"
                       + ")";
                    try
                    {                        
                        commandDB.CommandType = CommandType.Text;
                        commandDB.ExecuteNonQuery();                        
                        return true;
                    }
                    catch (Exception)
                    {                        
                        return false;
                        throw;
                    }
            }
        }
        
        /// <summary>
        /// INSERT в таблицу Info
        /// </summary>
        /// <param name="info">Экземпляр TableInfo</param>
        private bool InsertIntoTableInfo(TableInfo info)
        {
            using (SQLiteCommand commandDB = new SQLiteCommand(connectionDB))
            {
                commandDB.CommandText =
                    "INSERT INTO info ("
                    + "fio, "
                    + "tabelNumb, "
                    + "shift, "
                    + "normDoc, "
                    + "specification, "
                    + "steelType, "
                    + "drawing, "
                    + "sopNumb, "
                    + "lot, "
                    + "lotNumb, "
                    + "heatNumb, "
                    + "bundleNumb, "
                    + "serialNumb, "
                    + "addNumb1, "
                    + "addNumb2, "
                    + "addNumb3, "
                    + "addNumb4, "
                    + "addNumb5, "
                    + "objectLength, "
                    + "objectWidth, "
                    + "objectHeight, "
                    + "objectSpeed, "
                    + "objectOuterDiameter, "
                    + "objectInnerDiameter, "
                    + "objectWallThickness, "
                    + "objectA, "
                    + "objectB, "
                    + "objectC, "
                    + "objectD, "
                    + "objectE, "
                    + "objectF, "
                    + "objectG, "
                    + "objectH, "
                    + "objectI, "
                    + "objectJ, "
                    + "objectK, "
                    + "objectL, "
                    + "objectM, "
                    + "objectN, "
                    + "objectO, "
                    + "objectP, "
                    + "objectQ, "
                    + "objectR, "
                    + "objectS, "
                    + "objectT, "
                    + "objectU, "
                    + "objectV, "
                    + "objectW, "
                    + "objectX, "
                    + "objectY, "
                    + "objectZ, "
                    + "usFilesPath, "
                    + "controlResult, "
                    + "dateTime"
                    + ")"
                + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                SQLiteParameter fioParam = new SQLiteParameter
                {
                    Value = info.Fio,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(fioParam);

                SQLiteParameter tabelNumbParam = new SQLiteParameter
                {
                    Value = info.TabelNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(tabelNumbParam);

                SQLiteParameter shiftParam = new SQLiteParameter
                {
                    Value = info.Shift,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(shiftParam);

                SQLiteParameter normDocParam = new SQLiteParameter
                {
                    Value = info.NormDoc,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(normDocParam);

                SQLiteParameter specificationParam = new SQLiteParameter
                {
                    Value = info.Specification,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(specificationParam);

                SQLiteParameter drawingParam = new SQLiteParameter
                {
                    Value = info.Drawing,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(drawingParam);

                SQLiteParameter steelTypeParam = new SQLiteParameter
                {
                    Value = info.SteelType,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(steelTypeParam);

                SQLiteParameter sopNumbParam = new SQLiteParameter
                {
                    Value = info.SopNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(sopNumbParam);

                SQLiteParameter lotParam = new SQLiteParameter
                {
                    Value = info.Lot,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(lotParam);

                SQLiteParameter lotNumbParam = new SQLiteParameter
                {
                    Value = info.LotNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(lotNumbParam);

                SQLiteParameter heatNumbParam = new SQLiteParameter
                {
                    Value = info.HeatNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(heatNumbParam);

                SQLiteParameter bundleNumbParam = new SQLiteParameter
                {
                    Value = info.BundleNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(bundleNumbParam);

                SQLiteParameter serialNumbParam = new SQLiteParameter
                {
                    Value = info.SerialNumb,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(serialNumbParam);
                
                SQLiteParameter addNumb1Param = new SQLiteParameter
                {
                    Value = info.AddNumb1,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(addNumb1Param);

                SQLiteParameter addNumb2Param = new SQLiteParameter
                {
                    Value = info.AddNumb1,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(addNumb2Param);

                SQLiteParameter addNumb3Param = new SQLiteParameter
                {
                    Value = info.AddNumb1,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(addNumb3Param);

                SQLiteParameter addNumb4Param = new SQLiteParameter
                {
                    Value = info.AddNumb1,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(addNumb4Param);

                SQLiteParameter addNumb5Param = new SQLiteParameter
                {
                    Value = info.AddNumb1,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(addNumb5Param);
                
                SQLiteParameter objectLengthParam = new SQLiteParameter
                {
                    Value = info.ObjectLength,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectLengthParam);

                SQLiteParameter objectWidthParam = new SQLiteParameter
                {
                    Value = info.ObjectWidth,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectWidthParam);

                SQLiteParameter objectHeightParam = new SQLiteParameter
                {
                    Value = info.ObjectHeight,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectHeightParam);

                SQLiteParameter objectSpeedParam = new SQLiteParameter
                {
                    Value = info.ObjectSpeed,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectSpeedParam);
                
                SQLiteParameter objectOuterDiameterParam = new SQLiteParameter
                {
                    Value = info.ObjectOuterDiameter,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectOuterDiameterParam);

                SQLiteParameter objectInnerDiameterParam = new SQLiteParameter
                {
                    Value = info.ObjectInnerDiameter,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectInnerDiameterParam);

                SQLiteParameter objectWallThicknessParam = new SQLiteParameter
                {
                    Value = info.ObjectWallThickness,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectWallThicknessParam);
                
                SQLiteParameter objectAParam = new SQLiteParameter
                {
                    Value = info.ObjectA,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectAParam);

                SQLiteParameter objectBParam = new SQLiteParameter
                {
                    Value = info.ObjectB,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectBParam);

                SQLiteParameter objectCParam = new SQLiteParameter
                {
                    Value = info.ObjectC,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectCParam);

                SQLiteParameter objectDParam = new SQLiteParameter
                {
                    Value = info.ObjectD,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectDParam);

                SQLiteParameter objectEParam = new SQLiteParameter
                {
                    Value = info.ObjectE,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectEParam);

                SQLiteParameter objectFParam = new SQLiteParameter
                {
                    Value = info.ObjectF,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectFParam);

                SQLiteParameter objectGParam = new SQLiteParameter
                {
                    Value = info.ObjectG,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectGParam);

                SQLiteParameter objectHParam = new SQLiteParameter
                {
                    Value = info.ObjectH,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectHParam);

                SQLiteParameter objectIParam = new SQLiteParameter
                {
                    Value = info.ObjectI,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectIParam);

                SQLiteParameter objectJParam = new SQLiteParameter
                {
                    Value = info.ObjectJ,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectJParam);

                SQLiteParameter objectKParam = new SQLiteParameter
                {
                    Value = info.ObjectK,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectKParam);

                SQLiteParameter objectLParam = new SQLiteParameter
                {
                    Value = info.ObjectL,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectLParam);

                SQLiteParameter objectMParam = new SQLiteParameter
                {
                    Value = info.ObjectM,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectMParam);

                SQLiteParameter objectNParam = new SQLiteParameter
                {
                    Value = info.ObjectN,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectNParam);

                SQLiteParameter objectOParam = new SQLiteParameter
                {
                    Value = info.ObjectO,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectOParam);

                SQLiteParameter objectPParam = new SQLiteParameter
                {
                    Value = info.ObjectP,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectPParam);

                SQLiteParameter objectQParam = new SQLiteParameter
                {
                    Value = info.ObjectQ,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectQParam);

                SQLiteParameter objectRParam = new SQLiteParameter
                {
                    Value = info.ObjectR,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectRParam);

                SQLiteParameter objectSParam = new SQLiteParameter
                {
                    Value = info.ObjectS,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectSParam);

                SQLiteParameter objectTParam = new SQLiteParameter
                {
                    Value = info.ObjectT,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectTParam);

                SQLiteParameter objectUParam = new SQLiteParameter
                {
                    Value = info.ObjectU,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectUParam);

                SQLiteParameter objectVParam = new SQLiteParameter
                {
                    Value = info.ObjectV,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectVParam);

                SQLiteParameter objectWParam = new SQLiteParameter
                {
                    Value = info.ObjectW,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectWParam);

                SQLiteParameter objectXParam = new SQLiteParameter
                {
                    Value = info.ObjectX,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectXParam);

                SQLiteParameter objectYParam = new SQLiteParameter
                {
                    Value = info.ObjectY,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectYParam);

                SQLiteParameter objectZParam = new SQLiteParameter
                {
                    Value = info.ObjectZ,
                    DbType = DbType.Double
                };
                commandDB.Parameters.Add(objectZParam);
                
                SQLiteParameter usFilesPathParam = new SQLiteParameter
                {
                    Value = info.UsFilesPath,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(usFilesPathParam);

                SQLiteParameter controlResultParam = new SQLiteParameter
                {
                    Value = info.ControlResult,
                    DbType = DbType.Byte
                };
                commandDB.Parameters.Add(controlResultParam);

                SQLiteParameter dataTimeParam = new SQLiteParameter
                {
                    Value = info.DateTimeStump,
                    DbType = DbType.DateTime
                };
                commandDB.Parameters.Add(dataTimeParam);

                try
                {                    
                    commandDB.CommandType = CommandType.Text;
                    commandDB.ExecuteNonQuery();                    
                    return true;
                }
                catch (Exception ex)
                {                    
                    return false;
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// INSERT таблицу Control
        /// </summary>
        /// <param name="control">Экземпляр TableControl</param>
        private bool InsertIntoTableControl(TableControl control)
        {
            using (SQLiteCommand commandDB = new SQLiteCommand(connectionDB))
            {
                commandDB.CommandText =
                    "INSERT INTO control ("
                    + "dataFile, "
                    + "tableDefects, "
                    + "controlConfig, "
                    + "usFiles"
                    + ")"
                + " VALUES(?,?,?,?)";

                SQLiteParameter dataFileParam = new SQLiteParameter
                {
                    Value = control.DataFile,
                    DbType = DbType.Binary
                };
                commandDB.Parameters.Add(dataFileParam);

                SQLiteParameter defectsTableParam = new SQLiteParameter
                {
                    Value = control.TableDefects,
                    DbType = DbType.String
                };
                commandDB.Parameters.Add(defectsTableParam);

                SQLiteParameter controlConfigParam = new SQLiteParameter
                {
                    Value = control.ControlConfig,
                    DbType = DbType.Binary
                };
                commandDB.Parameters.Add(controlConfigParam);

                SQLiteParameter usFilesParam = new SQLiteParameter
                {
                    Value = control.UsFiles,
                    DbType = DbType.Binary
                };
                commandDB.Parameters.Add(usFilesParam);

                try
                {                    
                    commandDB.CommandType = CommandType.Text;
                    commandDB.ExecuteNonQuery();                    
                    return true;
                }
                catch (Exception ex)
                {                    
                    return false;
                    throw new Exception(ex.Message);
                }
            }
        }
        
        /// <summary>
        /// Совершает SQL-транзакцию для двух таблиц
        /// </summary>
        /// <param name="info">Экземпляр TableInfo</param>
        /// <param name="control">Экземпляр TableControl</param>
        public bool ExecuteSqlTransaction(TableInfo info, TableControl control)
        {
            using (SQLiteCommand commandDB = new SQLiteCommand(connectionDB))
            {                
                SQLiteTransaction transaction;

                OpenConnection();

                transaction = connectionDB.BeginTransaction();                
                commandDB.Connection = connectionDB;
                commandDB.Transaction = transaction;

                try
                {                    
                    InsertIntoTableInfo(info);
                    InsertIntoTableControl(control);                    
                    transaction.Commit();                    
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();                    
                    return false;
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        /// <summary>
        /// Возвращает заполненный экземпляр TableControl
        /// </summary>
        /// <param name="pathTableDefects">Путь к файлу таблицы дефектов</param>
        /// <param name="dataFile">Путь к файлу данных контроля</param>
        /// <param name="configFile">Путь к файлу конфигурации контроля</param>
        public TableControl FillTableControl(string pathTableDefects, string dataFile, string configFile)
        {            
            byte[] dataArr;
            byte[] configArr;
            byte[] usFilesArr = { 000, 00, 000 };

            using (FileStream streamConfigFile = File.OpenRead(configFile))
            {
                configArr = new byte[streamConfigFile.Length];
                streamConfigFile.Read(configArr, 0, configArr.Length);
            }

            using (FileStream streamDataFile = new FileStream(dataFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                dataArr = new byte[streamDataFile.Length];
                streamDataFile.Read(dataArr, 0, dataArr.Length);
            }
                        
            _tableControl.DataFile = dataArr;
            _tableControl.ControlConfig = configArr;
            _tableControl.TableDefects = pathTableDefects;
            _tableControl.UsFiles = usFilesArr;

            return _tableControl;
        }    

        public List<TableInfo> SelectAllFromTableInfo()
        {
            List<TableInfo> _list = new List<TableInfo>();
            try
            {
                OpenConnection();
                using (SQLiteConnection sqlConn = new SQLiteConnection(connectionDB))
                using (SQLiteCommand cmd = new SQLiteCommand(sqlConn))
                {
                    cmd.CommandText = "SELECT * FROM info";
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                TableInfo item = new TableInfo();
                                item.ID = reader.GetInt64(0);
                                item.Fio = reader.GetString(1);
                                item.TabelNumb = reader.GetString(2);
                                item.Shift = reader.GetString(3);
                                item.NormDoc = reader.GetString(4);
                                item.Specification = reader.GetString(5);
                                item.Drawing = reader.GetString(6);
                                item.SteelType = reader.GetString(7);
                                item.SopNumb = reader.GetString(8);
                                item.Lot = reader.GetString(9);
                                item.LotNumb = reader.GetString(10);
                                item.HeatNumb = reader.GetString(11);
                                item.BundleNumb = reader.GetString(12);
                                item.SerialNumb = reader.GetString(13);
                                item.AddNumb1 = reader.GetString(14);
                                item.AddNumb2 = reader.GetString(15);
                                item.AddNumb3 = reader.GetString(16);
                                item.AddNumb4 = reader.GetString(17);
                                item.AddNumb5 = reader.GetString(18);
                                item.ObjectLength = reader.GetDouble(19);
                                item.ObjectWidth = reader.GetDouble(20);
                                item.ObjectHeight = reader.GetDouble(21);
                                item.ObjectSpeed = reader.GetDouble(22);
                                item.ObjectOuterDiameter = reader.GetDouble(23);
                                item.ObjectInnerDiameter = reader.GetDouble(24);
                                item.ObjectWallThickness = reader.GetDouble(25);
                                item.ObjectA = reader.GetDouble(26);
                                item.ObjectB = reader.GetDouble(27);
                                item.ObjectC = reader.GetDouble(28);
                                item.ObjectD = reader.GetDouble(29);
                                item.ObjectE = reader.GetDouble(30);
                                item.ObjectF = reader.GetDouble(31);
                                item.ObjectG = reader.GetDouble(32);
                                item.ObjectH = reader.GetDouble(33);
                                item.ObjectI = reader.GetDouble(34);
                                item.ObjectJ = reader.GetDouble(35);
                                item.ObjectK = reader.GetDouble(36);
                                item.ObjectL = reader.GetDouble(37);
                                item.ObjectM = reader.GetDouble(38);
                                item.ObjectN = reader.GetDouble(39);
                                item.ObjectO = reader.GetDouble(40);
                                item.ObjectP = reader.GetDouble(41);
                                item.ObjectQ = reader.GetDouble(42);
                                item.ObjectR = reader.GetDouble(43);
                                item.ObjectS = reader.GetDouble(44);
                                item.ObjectT = reader.GetDouble(45);
                                item.ObjectU = reader.GetDouble(46);
                                item.ObjectV = reader.GetDouble(47);
                                item.ObjectW = reader.GetDouble(48);
                                item.ObjectX = reader.GetDouble(49);
                                item.ObjectY = reader.GetDouble(50);
                                item.ObjectZ = reader.GetDouble(51);
                                item.UsFilesPath = reader.GetString(52);
                                item.ControlResult = reader.GetByte(53);
                                item.DateTimeStump = reader.GetDateTime(54);
                                _list.Add(item);
                            };
                    }
                }
                return _list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void SelectSingleId(long id, out MemoryStream streamDataControl, out MemoryStream streamDataConfig)
        {
            byte[] _dataControlArray;
            byte[] _dataConfigArray;
            string _tableDefects;
            try
            {
                OpenConnection();
                using (SQLiteConnection sqlConn = new SQLiteConnection(connectionDB))
                using (SQLiteCommand cmd = new SQLiteCommand(sqlConn))
                {
                    cmd.CommandText = ("SELECT * FROM control WHERE id=" + id);
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            _dataControlArray = (byte[])reader[1];
                            _tableDefects = reader.GetString(2);
                            _dataConfigArray = (byte[])reader[3];
                            streamDataControl = new MemoryStream(_dataControlArray);
                            streamDataConfig = new MemoryStream(_dataConfigArray);
                        } 
                    }                    
                }
            }
            
            catch (Exception)
            {
                throw;
            }

            finally
            {
                CloseConnection();
            }
        }
    }
}
