using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunTech.Model
{
    public class 學生選課資料
    {
        [Key]
        public string STUD_NO { get; set; }
        public string ACAD_YEAR { get; set; }
        public string SEME_TYPE { get; set; }
        public string COURSE_NO { get; set; }
    }
}