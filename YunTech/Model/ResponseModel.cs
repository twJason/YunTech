using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace YunTech.Model
{
    public static class ResponseModel
    {
        public static void Error(string errMsg)
        {
            MessageBox.Show(errMsg);
        }
        public static void Success(string secMsg) 
        {
            MessageBox.Show(secMsg);
        }

    }
}