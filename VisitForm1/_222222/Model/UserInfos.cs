using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitForm1._222222.Model
{
    public class UserInfos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCard { get; set; }
       
        public Appointment Appointment { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
