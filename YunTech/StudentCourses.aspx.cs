using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YunTech.Model;
using YunTech.Service;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace YunTech
{
    
    public partial class StudentCourses : System.Web.UI.Page
    {
        private IStudentRepository _studentRepositories;
        private IStudentCourseRepository _studentCourseRepositories;
        public StudentCourses(IStudentRepository studentRepositories, 
            IStudentCourseRepository studentCourseRepositories)
        {
            _studentRepositories = studentRepositories;
            _studentCourseRepositories = studentCourseRepositories;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentsAsync));
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            RegisterAsyncTask(new PageAsyncTask(GetStudentsAsync));
        }

        /// <summary>
        /// 模糊查詢學生資訊
        /// </summary>
        /// <returns></returns>
        private async Task GetStudentsAsync()
        {
            string searchTxt = txSearch.Text.Trim();

            try
            {
                var students = await _studentRepositories.GetStudentsAsync(searchTxt);

                var studView = from st in students
                               select new
                               {
                                   學號 = st.STUD_NO,
                                   姓名 = st.STUD_NAME,
                               };

                GvStud.DataSource = studView;

                GvStud.DataBind();


            }
            catch (Exception ex)
            {
                ResponseModel.Error(ex.Message);
            }

        }

       /// <summary>
       /// 非同步查詢學生選課列表
       /// </summary>
       /// <returns></returns>
        private async Task GetStudentCourseAsync()
        {

            try
            {
                var studNo = GvStud.SelectedRow.Cells[1].Text;

                var studentCourses = await _studentCourseRepositories.GetStudentCoursesViewAsync(studNo);

                var studentCourseView = from studentCourse in studentCourses
                                        select new
                                        {
                                            課程年度 = studentCourse.AcadYear,
                                            課程編碼 = studentCourse.CourseNo,
                                            課程 = studentCourse.SubjName,
                                            系所 = studentCourse.DeptName
                                        };

                GvStudCourse.DataSource = studentCourseView;

                GvStudCourse.DataBind();
                
            }
            catch (Exception ex)
            {
                ResponseModel.Error(ex.Message);
            }


        }

        protected void GvStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentCourseAsync));
        }
    }
}