﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public static class DLFactory
    {
        public static IDL GetDL()
        {
            return DALObject.Instance;
        }
    }
}