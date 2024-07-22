using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunTech.Model
{
    public class 課程資料
    {
        [Key]
        public string SUBJ_NO { get; set; }
        public string SUBJ_NAME { get; set; }
        public string SUBJ_NAME_ENG { get; set; }
    }
}