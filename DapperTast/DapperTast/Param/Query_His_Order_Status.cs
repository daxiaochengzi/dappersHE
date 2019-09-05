using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{/// <summary>
/// 
/// </summary>
    public class Query_His_Order_Status
    {/// <summary>
     /// 商户订单号
     /// </summary>
        [Display(Name = "商户订单号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string OrderNo { get; set; }
    }
}
