using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 3.6.1 	消息通知服务
/// </summary>
    public class Message_Notice
    {/// <summary>
     /// 电子健康卡id
     /// </summary>
        [Display(Name = "电子健康卡id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string EhealthCardId { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdNo { get; set; }
        /// <summary>
        /// 居民健康卡主索引
        /// </summary>
        [Display(Name = "居民健康卡主索引")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MindexId { get; set; }
        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }
        /// <summary>
        /// 1:导诊 2:费用 3:报告
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 导诊：1：挂号 2：检查 3:检验 4:取药 5: 处置（护理）
        /// </summary>
        public int BusinessType { get; set; }
        /// <summary>
        /// 开单日期
        /// </summary>
        public string DateTime { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string ExecuteDepart { get; set; }
        /// <summary>
        /// 执行科室地址
        /// </summary>
        public string ExecuteAddress { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartAt { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndAt { get; set; }
        /// <summary>
        /// HIS门诊费用明细ID列表
        /// </summary>
        public List<string> CosDetailIds { get; set; }
        /// <summary>
        /// HIS报告ID列表
        /// </summary>
        public List<string> ReportIds { get; set; }
        
    }
}
