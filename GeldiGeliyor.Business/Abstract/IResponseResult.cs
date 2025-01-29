using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Business.Abstract
{
    public interface IResponseResult
    {
        bool IsSuccessed { get; set; }
        string Error { get; set; }
    }
}
