﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitForm1._222222.Model
{
    public class Appointment
    {
        
        public Guid Id { get; set; }
        
        public Guid ?ObjectId { get; set; }
        public int Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ?StockName { get; set; }
        public int? amount { get; set; }
    }
}
