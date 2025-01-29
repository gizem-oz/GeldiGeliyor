using GeldiGeliyor.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Business.Concrete.ResultModels
{
    public class ResponseResult:IResponseResult
    {
        public bool IsSuccessed { get; set; } = true;
        public string Error { get; set; } = null;
    }
}
