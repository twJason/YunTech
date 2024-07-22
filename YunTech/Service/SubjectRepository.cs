using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Model;

namespace YunTech.Service
{
    public class SubjectRepository : ISubjectRepository
    {
        private static YunTchConext db; 
        public SubjectRepository() {

            db = new YunTchConext();
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            try
            {
                var subjects = new List<Subject>();
                using (db = new YunTchConext())
                {

                    subjects =  await (from subj in db.Subjects
                                  select new Subject
                                  {
                                   SUBJ_NO = subj.SUBJ_NO,
                                   SUBJ_NAME = subj.SUBJ_NAME,
                                   SUBJ_NAME_ENG = subj.SUBJ_NAME_ENG,  
                                  }

                                    ).ToListAsync();

                };

                return subjects;    
            }
            catch
            {
                return new List<Subject>();

            }

        }
    }
}