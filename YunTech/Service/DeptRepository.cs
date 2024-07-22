using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Model;

namespace YunTech.Service
{
    public class DeptRepository : IDeptRepository
    {
        private static YunTchConext db;
        public DeptRepository()
        {
            db = new YunTchConext();

        }

        public async Task<List<Dept>> GetDeptsAsync()
        {
            try
            {
                var depts = new List<Dept>();   
                using (db = new YunTchConext())
                {
                    var s = await db.Depts.FirstOrDefaultAsync(); ;

                    depts =  await (from dep in db.Depts
                                      select new Dept
                                      {
                                          DEPT_CODE = dep.DEPT_CODE,
                                          DEPT_NAME = dep.DEPT_NAME
                                      }

                                    ).ToListAsync();

                };

                return depts;
            }
            catch
            {
                return new List<Dept>();

            }

        }
    }
}