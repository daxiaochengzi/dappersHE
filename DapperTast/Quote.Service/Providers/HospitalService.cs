using Dapper;
using Newtonsoft.Json;
using Quote.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace Quote.Service.Providers
{
    public class HospitalService : IHospitalService
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conStr"></param> 
        public HospitalService(string conStr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(conStr) ? conStr : throw new ArgumentNullException(nameof(conStr));
            //_sqlConnection = new SqlConnection(_connectionString);
            //_sqlConnection.Open();
        }

        public async Task<dynamic> ExecutingSql(string name, string strParams)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                dynamic result = null;
                _sqlConnection.Open();
               
                var sqlData = await _sqlConnection.QueryAsync<string>("usp_webHealth_NJ_all", new { SPName = name, Params = strParams },
                    commandType: CommandType.StoredProcedure);
                string strSqlData = sqlData.FirstOrDefault();  
                _sqlConnection.Close();
                //初始化xml默认值
                string strXmlIni = null;
                if (strSqlData != null)
                {
                    XmlDocument doc = new XmlDocument();
                    if (strSqlData.Length == 4)
                    {
                        if (strSqlData == "true" || strSqlData == "false" || strSqlData == "null")
                        {
                            if (strSqlData == "true")
                                result = true;
                            if (strSqlData == "false")
                                result = false;
                            if (strSqlData == "null")
                                result = null;
                        }
                        else
                        {
                             strXmlIni = strSqlData;
                        }
                    }
                    else
                    {
                        //判断是否xml
                        if (strSqlData.Substring(0, 1) == "<")
                        {
                            strXmlIni = strSqlData;
                        }
                        else
                        {//直接返回
                            result = strSqlData;
                        }

                        
                    }
                    if (strXmlIni != null)
                    {
                        
                        doc.LoadXml(strXmlIni);
                        string strXml = null;
                        int num = 0;
                        //xml节点读取
                        foreach (XmlNode xn1 in doc.SelectNodes("Response/ResultInfo"))
                        {
                              num++;
                              XmlElement xe = (XmlElement)xn1;
                            if (strXml == null)
                            {
                                strXml = GetStrJson(JsonConvert.SerializeXmlNode(xe)) ;
                            }
                            else
                            {
                                strXml = strXml + "," + GetStrJson(JsonConvert.SerializeXmlNode(xe));
                            }
                        }

                        string strXmlResult = null;
                        if (name == "get_his_outpatient_list")
                        {
                            strXmlResult = num > 0 ? "[" + strXml + "]" : strXml;
                        }
                        else
                        {
                            strXmlResult = num > 1 ? "[" + strXml + "]" : strXml;
                        }
                        string strNew = strXmlResult.Replace("[\"\",\"\"]", "[]");
                        string strNews = strNew.Replace("},\"\"]", "}]");
                        result = JsonConvert.DeserializeObject(strNews);
                    }
                }

                return result;
            }
        }


        public async Task<string > ExecutingSqlQueryReport(string name, string strParams)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                string result = null;
                _sqlConnection.Open();

                var sqlData = await _sqlConnection.QueryAsync<string>("usp_webHealth_NJ_all", new { SPName = name, Params = strParams },
                    commandType: CommandType.StoredProcedure);
                string strSqlData = sqlData.FirstOrDefault();
                _sqlConnection.Close();
                //初始化xml默认值
                string strXmlIni = null;
                if (strSqlData != null)
                {
                    XmlDocument doc = new XmlDocument();
                    if (strSqlData.Length == 4)
                    {
                        if (strSqlData == "true" || strSqlData == "false" || strSqlData == "null")
                        {
                                result = strSqlData;
                        }
                        else
                        {
                            strXmlIni = strSqlData;
                        }
                    }
                    else
                    {
                        //判断是否xml
                        if (strSqlData.Substring(0, 1) == "<")
                        {
                            strXmlIni = strSqlData;
                        }
                        else
                        {//直接返回
                            result = strSqlData;
                        }


                    }
                    if (strXmlIni != null)
                    {

                        doc.LoadXml(strXmlIni);
                        string strXml = null;
                        int num = 0;
                        //xml节点读取
                        foreach (XmlNode xn1 in doc.SelectNodes("Response/ResultInfo"))
                        {
                            num++;
                            XmlElement xe = (XmlElement)xn1;
                            if (strXml == null)
                            {
                                strXml = GetStrJson(JsonConvert.SerializeXmlNode(xe));
                            }
                            else
                            {
                                strXml = strXml + "," + GetStrJson(JsonConvert.SerializeXmlNode(xe));
                            }
                        }

                        string strXmlResult = null;
                        if (name == "get_his_outpatient_list")
                        {
                            strXmlResult = num > 0 ? "[" + strXml + "]" : strXml;
                        }
                        else
                        {
                            strXmlResult = num > 1 ? "[" + strXml + "]" : strXml;
                        }

                        string strNew = strXmlResult.Replace("[\"\",\"\"]", "[]");
                        result = strNew;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 获取json
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        private string GetStrJson(string strXml)
        {
            var xmlData = strXml.Substring(14, strXml.Length - 14);
            return xmlData.Substring(0, xmlData.Length-1);
        }
        /// <summary>
        /// 复制源文件夹下的所有内容到新文件夹
        /// </summary>
        /// <param name="oldUrl">源文件夹路径</param>
        /// <param name="newUrl">新文件夹路径</param>
        public void CopyFolder(string oldUrl, string newUrl)
        {
            File.Copy(oldUrl, newUrl, true);//true代表可以覆盖同名文件

            //DirectoryInfo dinfo = new DirectoryInfo(oldUrl);
            ////注，这里面传的是路径，并不是文件，所以不能包含带后缀的文件
            //foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
            //{
            //    //目标路径destName = 新文件夹路径 + 源文件夹下的子文件(或文件夹)名字
            //    //Path.Combine(string a ,string b) 为合并两个字符串
            //    string destName = Path.Combine(newUrl, f.Name);
            //    if (f is FileInfo)
            //    {
            //        //如果是文件就复制
            //        File.Copy(f.FullName, destName, true);//true代表可以覆盖同名文件
            //    }
            //    else
            //    {
            //        //如果是文件夹就创建文件夹，然后递归复制
            //        Directory.CreateDirectory(destName);
            //        CopyFolder(f.FullName, destName);
            //    }
            //}
        }

        //static void Main(string[] args)
        //{
        //    string sourceFolder = @"F:\xBackup";
        //    string destFolder = @"F:\DemoFolder";

        //    CopyFolder(sourceFolder, destFolder);

        //    Console.WriteLine("Press any key to end...");
        //    Console.ReadKey();
        //}
        //public async Task<CollectionChargeBase> GetCollectionChargeBase(Guid WaterUserMeterId)
        //{
        //    using (var _sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        _sqlConnection.Open();
        //        string sql = @"SELECT [ddd].[ChargeDeadLine], [d].[RegionId],ddd.Id as TaskId, CONVERT(decimal(18, 2), [ddd].[Amount]) AS [Amount]
        //                FROM[MeiShan_Install_WaterUserMeter] AS[d]
        //                INNER JOIN[MeiShan_MeterReading_Task] AS[ddd] ON[d].[Id] = [ddd].[WaterUserMeterId]
        //                INNER JOIN[MeiShan_WaterMeterCharge_CollectionSet] AS[dddd] ON[d].[WaterPriceId] = [dddd].[WaterPriceId]
        //                WHERE d.LogicRemove = 0 and ddd.LogicRemove = 0 and dddd.LogicRemove = 0
        //                and ddd.BusinessAccounting = 3  and ddd.IsCharge = 0 and d.Id = '" + WaterUserMeterId + "'" +
        //                " and  ddd.ChargeDeadLine<GETDATE();";
        //        var result = await _sqlConnection.QueryMultipleAsync(sql);
        //        var resultData = _sqlConnection.Query<MeterReadingCycle>("select  top 1* from [dbo].[MeiShan_MeterReading_Cycle]").FirstOrDefault();
        //        var Data = (from t in result.Read<CollectionChargeBase>()
        //                    select new CollectionChargeBase
        //                    {
        //                        Amount = t.Amount,
        //                        ChargeDeadLine = t.ChargeDeadLine,
        //                        RegionId = t.RegionId,
        //                    }
        //                    ).ToList();
        //        var Datanew = new CollectionChargeBase();
        //        Datanew.Amount = Data.Select(x => x.Amount).Sum();
        //        Datanew.ChargeDeadLine = Data.Select(x => x.ChargeDeadLine).Min();
        //        Datanew.RegionId = Data.Select(x => x.RegionId).FirstOrDefault();
        //        Datanew.LateFeeAmount = GetLateFee(resultData, Datanew.Amount, Datanew.ChargeDeadLine);
        //        Datanew.Counts = Data.Count();
        //        return Datanew;
        //    }
        //}
    }
}
