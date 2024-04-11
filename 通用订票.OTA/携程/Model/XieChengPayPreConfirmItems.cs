using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengPayPreConfirmItems
    {
        public string itemId { get; set; }
        public int isCredentialVouchers { get; set; }
        public List<PassengerVouchers> passengerVouchers { get; set; }
        public List<Inventorys[]> inventorys { get; set; }
        public XieChengPayPreConfirmItems()
        {
            passengerVouchers = new List<PassengerVouchers>();
            inventorys = new List<Inventorys[]>();
        }

    }
    public struct PassengerVouchers
    {
        public string passengerId { get; set; }
        public string voucherId { get; set; }
    }

    public struct Inventorys
    {
        public string useDate { get; set; }
        public int quantity { get; set; }
    }
}
