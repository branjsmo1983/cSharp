﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Events
{
    public interface ICallStatusObserver
    {
        void CallStatusChanged(CallStatus status);
    }
}
