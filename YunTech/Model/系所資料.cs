using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace YunTech.Model
{

    public class 系所資料
    {
        [Key]
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string DEPT_NAME_ENG { get; set; }
    }
}