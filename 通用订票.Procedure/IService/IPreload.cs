using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;

namespace 通用订票.Procedure.IService
{
    public interface IPreload
    {
        Task PreloadAsync(PreloadEntity param);
        Task OnExcepton(Exception e);
    }
}
