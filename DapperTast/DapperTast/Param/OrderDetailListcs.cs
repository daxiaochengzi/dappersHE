using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{
    public class OrderDetailListcs
    {/// <summary>
     /// 电子健康卡id
     /// </summary>
        [Display(Name = "电子健康卡id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string ehealthCardId { get; set; }

        /// <summary>
        /// 居民健康卡主索引id
        /// </summary>
        [Display(Name = "居民健康卡主索引id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MindexId { get; set; }
        /// <summary>
        /// 证件类别
        /// </summary>
        [Display(Name = "证件类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdNo { get; set; }
        /// <summary>
        /// 预约挂号单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// HIS门诊就诊号
        /// </summary>
        public string ClinicNo { get; set; }
        /// <summary>
        /// HIS门诊挂号单号(预约挂号)
        /// </summary>
        public string RegistrationNo { get; set; }
       
        /// <summary>
        /// HIS门诊收费单号(门诊收费)
        /// </summary>
        public string ChargeNo { get; set; }
        /// <summary>
        /// HIS预缴单号(住院预缴收费)
        /// </summary>
        public string PreNo { get; set; }
        /// <summary>
        /// HIS门诊退号单号
        /// </summary>
        public string RefundNo { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
    }
}
