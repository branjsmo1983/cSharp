using Interfaces.Writers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    //enum LanguageEnum { Ita, Eng }
 
    //class Test
    //{
    //    void TestHelloIta()
    //    {
    //        IAnnouncer ann = null;
    //        string hello = ann.Hello(LanguageEnum.Ita);
    //        Debug.Assert(hello == "ciao");
    //    }

    //    void TestHelloEng()
    //    {
    //        IAnnouncer ann = null;
    //        string hello = ann.Hello(LanguageEnum.Eng);
    //        Debug.Assert(hello == "hello");
    //    }
    //}

    interface IAnnouncer
    {
        //string Hello(LanguageEnum lang);

        void AddWriter(IWriter writer);

        void Write();

        //void Write(IWriter writer);

        void Write(TextWriter writer);
    }
}
