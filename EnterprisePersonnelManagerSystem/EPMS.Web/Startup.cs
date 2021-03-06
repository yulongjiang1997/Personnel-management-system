﻿using System;
using System.IO;
using AutoMapper;
using EPMSEF;
using EPMS.Service.Services.AdminService;
using EPMS.Service.Services.AttendanceService;
using EPMS.Service.Services.DepartmentService;
using EPMS.Service.Services.PositionService;
using EPMS.Service.Services.SalaryService;
using EPMS.Service.Services.StaffInfoService;
using EPMS.Web.ActionFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using EPMS.Service.Services.StockService;
using EPMS.Service.Services.ProductService;
using EPMS.Service.Services.CompanyScheduleService;
using EPMS.Service.Services.PersonalScheduleService;

namespace EPMS.Web
{
    /// <summary>
    /// Startup类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("allow_all", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();//注册Automapper
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EPMS API",
                    Description = "The EPMS All Web API List",
                    TermsOfService = "None",
                });
                //Determine base path for the application.  
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "EPMS.Web.xml");
                options.IncludeXmlComments(xmlPath);
            });
            
            services.AddDbContextPool<EPMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            //services.AddMvc(options => { options.Filters.Add(typeof(PermissionActionFillter)); });
            services.AddMvc(options => { options.Filters.Add(typeof(ExceptionFiltering)); });

            #region 依赖注入添加
            services.AddTransient<IAdminService,AdminService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<ISalaryService, SalaryService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IStaffInfoService, StaffInfoService>();
            services.AddTransient<ICompanyScheduleService, CompanyScheduleService>();
            services.AddTransient<IPersonalScheduleService, PersonalScheduleService>();


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //启动跨域
            app.UseCors("allow_all");


            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("login.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MsSystem API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
