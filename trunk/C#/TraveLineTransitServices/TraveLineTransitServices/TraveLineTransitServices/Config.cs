using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace TraveLineTransitServices
{
    public static class Config
    {
        private static DataSet.CurrentEmployeeRow currentEmployee = null;

        public static DataSet.CurrentEmployeeRow CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; }
        }
    }
}
