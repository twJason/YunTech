using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunTech.Model
{
    public class 學生學籍資料
    {
        [Key]
        public string STUD_NO { get; set; }
        public string STUD_NAME { get; set; }
        public string SEX { get; set; }
        public string DEPT_CODE { get; set; }
        public string TEL { get; set; }
        public string ADDRESS { get; set; }
    }
}