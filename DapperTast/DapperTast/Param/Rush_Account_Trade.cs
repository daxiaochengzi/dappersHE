using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 3.7.2 	冲账交易
/// </summary>
    public class Rush_Account_Trade
    {/// <summary>
     /// 对账类型(1-挂号、2-门诊、3-住院)
     /// </summary>
        public int BusinessType { get; set; }
        /// <summary>
        /// 预约挂号单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// HIS门诊挂号单号
        /// </summary>
        [Display(Name = "HIS门诊挂号单号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string RegistrationNo { get; set; }
        /// <summary>
        /// HIS门诊退号单号
        /// </summary>

        public string RefundNo { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Double Amount { get; set; }
        /// <summary>
        /// HIS门诊收费单号
        /// </summary>
        public string ChargeNo { get; set; }
        /// <summary>
        /// HIS预缴单号
        /// </summary>
        public string PreNo { get; set; }
        
    }
}
