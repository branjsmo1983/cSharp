﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Events
{
     public class CallStatus
    {
        public bool Status { get; set; }
        public string Number { get; set; }

        public CallStatus(bool status, string number)
        {
            this.Status = status;
            this.Number = number;
        }
    }
}
