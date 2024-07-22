using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.WebForms;
using YunTech.Service;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YunTech.App_Start.Services), nameof(YunTech.App_Start.Services.EnableServices))]

namespace YunTech.App_Start {
    public static class Services {
        public static void EnableServices() {
            ServiceHost.EnableServices(ConfigureServices);
        }

        public static void ConfigureServices(IServiceCollection services ){
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<IDeptRepository, DeptRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
        }
    }
}