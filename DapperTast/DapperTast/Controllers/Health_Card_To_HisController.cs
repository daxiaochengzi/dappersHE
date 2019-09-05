using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DapperTast.Helper;
using DapperTast.Param;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quote.AspNetCore;
using Quote.Service.Interfaces;


namespace DapperTast.Controllers
{/// <summary>
/// 
/// </summary>
    [Route("[controller]/[action]")]
    public class health_card_to_hisController : ControllerBase
    {
        private IHospitalService HospitalService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public health_card_to_hisController(IHospitalService iHospitalService)
        {
            HospitalService = iHospitalService;
        }

        #region 获取排班记录 
        /// <summary>
        /// 3.1.3 	获取排班记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> get_his_scheduling_list([FromBody]Get_His_Scheduling_List_Param param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);

              
                var data = await HospitalService.ExecutingSql("get_his_scheduling_list", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 预约挂号锁定 
        /// <summary>
        ///  	3.1.4 	预约挂号锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> his_order_lock([FromBody] His_Order_Lock param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("his_order_lock", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 查询预约挂号锁定状态 
        /// <summary>
        /// 3.1.5 	查询预约挂号锁定状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> query_his_order_status([FromQuery] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("query_his_order_status", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 确定预约挂号收费 
        /// <summary>
        ///  	3.1.6 	确定预约挂号收费
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> confirm_his_order([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("confirm_his_order", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 取消预约挂号锁定状态 
        /// <summary>
        ///  		3.1.7 	取消预约挂号锁定状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> cancel_his_order([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("cancel_his_order", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.1.8 	预约挂号退单 
        /// <summary>
        ///  3.1.8 	预约挂号退单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> refund_his_order([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("refund_his_order", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.1 	门诊费用查询
        /// <summary>
        /// 3.2.1 	门诊费用查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> get_his_outpatient_list([FromBody] Get_His_Outpatient_List param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("get_his_outpatient_list", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 门诊缴费锁定 
        /// <summary>
        ///   	3.2.2门诊缴费锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> his_outpatient_lock([FromBody] His_Outpatient_Lock param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("his_outpatient_lock", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.3 	门诊缴费查询锁定 
        /// <summary>
        ///  	3.2.3 	门诊缴费查询锁定
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> query_his_outpatient_status([FromQuery] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("query_his_outpatient_status", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.4 	门诊缴费取消锁定
        /// <summary>
        ///  3.2.4 	门诊缴费取消锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> cancel_his_outpatient([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("cancel_his_outpatient", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.5 	门诊缴费确认
        /// <summary>
        ///  3.2.5 	门诊缴费确认
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> confirm_his_outpatient([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("confirm_his_outpatient", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.6 	门诊退费锁定
        /// <summary>
        /// 3.2.6 	门诊退费锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> refund_his_outpatient_lock([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("refund_his_outpatient_lock", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.7 	门诊退费查询锁定
        /// <summary>
        ///3.2.7 	门诊退费查询锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> query_refund_his_outpatient_lock([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("query_refund_his_outpatient_lock", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.8 门诊退费取消锁定
        /// <summary>
        ///3.2.8 门诊退费取消锁定
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> refund_outpatient_cancel([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("refund_outpatient_cancel", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.2.9 	门诊退费确认
        /// <summary>
        ///3.2.9 	门诊退费确认
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> comfirm_refund_outpatient_status([FromBody] Query_His_Order_Status param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("comfirm_refund_outpatient_status", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.3.1 	住院预缴查询
        /// <summary>
        ///	3.3.1 	住院预缴查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> hospital_prepay_query([FromBody] Hospital_Prepay_Query param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("hospital_prepay_query", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.3.2 	住院预缴收费
        /// <summary>
        ///3.3.2 	住院预缴收费
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> hospital_prepay_charge([FromBody] Hospital_Prepay_Charge param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("hospital_prepay_charge", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 	3.4.1 	住院费用清单查询
        /// <summary>
        ///3.4.1 	住院费用清单查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> query_hospitalization_cost([FromBody] Query_Hospitalization_Cost param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("query_hospitalization_cost", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.5.1 	检查报告查询
        /// <summary>
        ///	3.5.1 	检查报告查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> query_report_list([FromBody] Query_Report_List param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                //192.168.101.109 D:\temp\info-2018-12-18.log
                //string currentDirectory = AppContext.BaseDirectory+ @"logs\info-2018-12-18.log";
                CopyFolder(new List<string>(){ "192.168.101.109 D:\\temp\\info-2018-12-18.log" });
                //HospitalService.CopyFolder(currentDirectory+ @"logs\info-2018-12-18.log", currentDirectory + @"pdf\info-2018-12-18.log");
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSqlQueryReport("query_report_list", paramXml);
                var  basicResultDto = JsonConvert.DeserializeObject<List<QueryReportListDto>>(data);
                var dataNew = basicResultDto.Select(c => new QueryReportListDto
                {
                    ReportDateTime = c.ReportDateTime,
                    ReportId = c.ReportId,
                    ReportName = c.ReportName,
                    ReportPdf = c.ReportPdf != null ? Convert.ToBase64String(System.IO.File.ReadAllBytes(c.ReportPdf)) : null
                });
                y.Data = dataNew;
            });
        }
        #endregion
        /// <summary>
        ///  3.6.1 	消息通知服务
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        #region 3.6.1 	消息通知服务
        [HttpPost]
        public async Task<ApiJsonResultData> message_notice([FromBody] Message_Notice param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("message_notice", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.7.1 	对账查询
        /// <summary>
        ///	3.7.1 	对账查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> query_reconciliate([FromBody] Query_Reconciliate param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("query_reconciliate", paramXml);
                y.Data = data;
            });
        }
        #endregion
        #region 3.7.2 	冲账交易
        /// <summary>
        ///	3.7.2 	冲账交易
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> rush_account_trade([FromBody] Rush_Account_Trade param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                string paramXml = XmlHelper.ToXml(param);
                var data = await HospitalService.ExecutingSql("rush_account_trade", paramXml);
                y.Data = data;
            });
        }
        #endregion
        [NonAction]
        public void CopyFolder(List<string> urlList)
        {
          
            string currentDirectory = AppContext.BaseDirectory;
            string urlFile = AppContext.BaseDirectory + @"pdf";
            string newUrl = currentDirectory + @"pdf\";

            System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.DownloadFile(@"/192.168.101.109/software/01279.lic.txt", "testdownload.txt");
            Directory.Delete(urlFile, true);
            System.IO.Directory.CreateDirectory(urlFile);
            if (urlList.Any())
            {
                foreach (var item in urlList)
                {
                    if (!System.IO.File.Exists(item))
                    {
                       throw  new  Exception(item +"   不存在请检查!!!");
                    }
                    string fileName = item.Substring(item.LastIndexOf(@"\", StringComparison.Ordinal) + 1);   
                    string newUrlItem = newUrl + fileName ;
                    System.IO.File.Copy(item, newUrlItem, true);
                }
            }

            
           
        }
    }
}