using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 3.2.2 	门诊缴费锁定
/// </summary>
    public class His_Outpatient_Lock
    {/// <summary>
     /// HIS门诊费用ID
     /// </summary>
        [Display(Name = "HIS门诊费用ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string CosId { get; set; }
        /// <summary>
        /// 门诊收费单号
        /// </summary>
        [Display(Name = "门诊收费单号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string OrderNo { get; set; }
    }
}
