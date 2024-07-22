using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunTech.Model
{
    public class 學期課程資料
    {
        [Key]
        public string COURSE_NO { get; set; }
        public string ACAD_YEAR { get; set; }
        public string SEME_TYPE { get; set; }
        public string DEPT_CODE { get; set; }
        public string SUBJ_NO { get; set; }
        public string CREDITS { get; set; }
        public string MAJ_OP { get; set; }
        public string TEACHER { get; set; }
    }
}