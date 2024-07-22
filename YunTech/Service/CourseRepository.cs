using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Model;

namespace YunTech.Service
{
    public class CourseRepository : ICourseRepository
    {
        private static YunTchConext db;
        public CourseRepository()
        {
            db = new YunTchConext();

        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            try
            {
                var courses = new List<Course>();
                using (db = new YunTchConext())
                {
                    var s = await db.Courses.FirstOrDefaultAsync(); ;

                    courses =  await (from course in db.Courses
                                      select new Course
                                      {
                                          ACAD_YEAR = course.ACAD_YEAR, 
                                          SEME_TYPE = course.SEME_TYPE, 
                                          COURSE_NO = course.COURSE_NO,
                                          DEPT_CODE = course.DEPT_CODE, 
                                          SUBJ_NO = course.SUBJ_NO, 
                                          CREDITS = course.CREDITS,
                                          MAJ_OP = course.MAJ_OP,   
                                          TEACHER = course. TEACHER,    
                                      }

                                    ).ToListAsync();

                };

                return courses;
            }
            catch
            {
                return new List<Course>();

            }

        }
    }
}