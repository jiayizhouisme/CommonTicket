using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Application.System.Models
{
    public class AppointmentAdd
    {
        [Required(ErrorMessage = "请选择展馆")]
        public Guid exhibitionID { get; set; }
        public int dayStart { get; set; }
        public int totalDay { get; set; }
        public TimeSpan timeStart { get; set; }
        public TimeSpan timeEnd { get; set; }
    }
}
