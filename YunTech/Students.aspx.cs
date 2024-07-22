using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YunTech.Model;
using YunTech.Service;

namespace YunTech
{
    public partial class Students : System.Web.UI.Page
    {
        private IStudentRepository _studentRepositories;
        private IDeptRepository _deptRepositories;

        public Students(IStudentRepository studentRepositories,IDeptRepository deptRepositories)
        {
            _studentRepositories = studentRepositories;
            _deptRepositories = deptRepositories;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentsAsync));
            RegisterAsyncTask(new PageAsyncTask(GetDeptAsync));

        }

        /// <summary>
        /// 刷新畫面
        /// </summary>
        private void ReflashView()
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentsAsync));
            RegisterAsyncTask(new PageAsyncTask(GetDeptAsync));
            TxTel.Text = "";
            TxAdd.Text = "";
            TxName.Text = "";
            TxNo.Text = "";

        }

        /// <summary>
        /// 獲取系所列表
        /// </summary>
        /// <returns></returns>
        private async Task GetDeptAsync()
        {
            try
            {
                DlDept.Items.Clear();
           
                var deps = await _deptRepositories.GetDeptsAsync();

                MappingDeptToDropList(deps);
            }
            catch (Exception ex)
            {
                ResponseModel.Error(ex.Message);

            }

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

                var studentView = from student in students
                                  select new
                                  {
                                      學號 = student.STUD_NO,
                                      姓名 = student.STUD_NAME,
                                      系所 = student.DEPT_NAME,
                                  };

                GvStud.DataSource = studentView;

                GvStud.DataBind();

            }
            catch (Exception ex)
            {
                ResponseModel.Error(ex.Message);
            }

        }

        /// <summary>
        /// 查詢詳細學籍資訊
        /// </summary>
        /// <returns></returns>
        private async Task GetStudentDetailAsync()
        {

            var studNo = GvStud.SelectedRow.Cells[1].Text;

            try
            {
                var student = await _studentRepositories.GetStudentDetailAsync(studNo);

                MappingStudentToView(student);
            }
            catch (Exception ex)
            {
                ResponseModel.Error(ex.Message);
            }


        }
           
        /// <summary>
        /// 非同步新增學籍
        /// </summary>
        /// <returns></returns>
        private async Task AddStudentAsync()
        {
            var studNo = TxNo.Text.Trim();

            var check = await _studentRepositories.CheckStudentAsync(studNo);

            if (check)
                ResponseModel.Error("新增失敗學號相同");
            else
            {
                try
                {

                    var addStudent = SetViewToStudentModel();

                    var count = await _studentRepositories.AddStudentAsync(addStudent);

                    if (count > 0)
                    {
                        ReflashView();

                        ResponseModel.Success("新增完畢");
                    }
                    else
                        ResponseModel.Error("新增失敗");
                }
                catch
                (Exception ex)
                {
                    ResponseModel.Error("新增失敗" + ex.Message);
                }
            }

            

        }

        /// <summary>
        /// 非同步修改學籍
        /// </summary>
        /// <returns></returns>
        private async Task UpdateStudentAsync()
        {
            var studNo = GvStud.SelectedRow.Cells[1].Text;

            var nStudent = SetViewToStudentModel();

            try
            {
                var count = await _studentRepositories.UpdateStudentAsync(studNo, nStudent);

                if (count > 0)
                {
                    ReflashView();

                    ResponseModel.Success("修改完畢");
                }
                else
                    ResponseModel.Error("新增失敗");

            }
            catch (Exception ex)
            {
                ResponseModel.Error("修改失敗" + ex.Message);
            }

        }

        /// <summary>
        /// 非同步刪除學籍
        /// </summary>
        /// <returns></returns>
        private async Task DelStudentAsync()
        {

            var studNo = GvStud.SelectedRow.Cells[1].Text;

            try
            {
               var count = await _studentRepositories.DelStudentAsync(studNo);
                if (count > 0)
                {
                    ReflashView();

                    ResponseModel.Success("刪除完畢");
                }
                else
                    ResponseModel.Error("新增失敗");

            }
            catch (Exception ex)
            {
                ResponseModel.Error("刪除失敗" + ex.Message);
            }

        }

        /// <summary>
        /// 學籍資訊顯示畫面
        /// </summary>
        /// <param name="student"></param>
        private void MappingStudentToView(Student student)
        {
            TxNo.Text = student.STUD_NO;
            TxName.Text = student.STUD_NAME;
            TxTel.Text = student.TEL;
            TxAdd.Text = student.ADDRESS;

            DlDept.SelectedValue = student.DEPT_CODE;

            RbSex.SelectedValue = student.SEX;
        }

        /// <summary>
        /// 畫面轉換學籍資訊
        /// </summary>
        /// <returns></returns>
        private 學生學籍資料 SetViewToStudentModel()
        {
            var student = new 學生學籍資料();
            student.STUD_NO = TxNo.Text;
            student.STUD_NAME = TxName.Text;
            student.TEL = TxTel.Text;
            student.ADDRESS = TxAdd.Text;
            student.SEX = RbSex.Text;
            student.DEPT_CODE = DlDept.SelectedValue.Trim();
            student.DEPT_CODE = LbDept.Text.Trim();

            return student;
        }

        /// <summary>
        /// 系所資訊顯示下拉
        /// </summary>
        /// <param name="deps"></param>
        private void MappingDeptToDropList(List<Dept> deps)
        {
            foreach (var dep in deps)
            {
                DlDept.Items.Add(new ListItem(dep.DEPT_NAME, dep.DEPT_CODE));
            }
        }


        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentsAsync));
        }

        protected void GvStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetStudentDetailAsync));
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AddStudentAsync));

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(UpdateStudentAsync));

        }

        protected void BtnDel_Click(object sender, EventArgs e)
        {

            RegisterAsyncTask(new PageAsyncTask(DelStudentAsync));

        }

        protected void DlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbDept.Text = DlDept.SelectedValue.Trim().ToString();
        }
    }
}