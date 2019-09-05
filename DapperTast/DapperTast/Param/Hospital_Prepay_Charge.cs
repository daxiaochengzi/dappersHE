using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 3.3.2 	住院预缴收费
/// </summary>
    public class Hospital_Prepay_Charge
    {/// <summary>
        /// 电子健康卡id
        /// </summary>

        public string EhealthCardId { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 居民健康卡主索引
        /// </summary>
        public string MindexId { get; set; }
        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        [Display(Name = "患者姓名")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Name { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        [Display(Name = "住院号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string HosNo { get; set; }
        /// <summary>
        /// 缴费金额
        /// </summary>
        public double PrepayMoney { get; set; }
        /// <summary>
        /// 预缴单号
        /// </summary>
        [Display(Name = "预缴单号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string OrderNo { get; set; }
    }
}
