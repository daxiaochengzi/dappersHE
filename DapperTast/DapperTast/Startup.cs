using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTast.AuthHelp;
using DapperTast.ConfigModel;
using DapperTast.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web; 
using Quote.Core.Exceptions;
using Quote.Service.Interfaces;
using Quote.Service.Providers;
using Swashbuckle.AspNetCore.Swagger;

namespace DapperTast
{
    public class Startup
    {

        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            var connection = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connection))
                throw StandardException.Caused("10000", "未配置数据库连接字符串");
            //依赖注入
            services.AddScoped<IHospitalService>(sp => new HospitalService(connection));
            #region Swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "his服务接口"
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "DapperTast.xml");
                options.IncludeXmlComments(xmlPath);
                options.DescribeAllEnumsAsStrings();
                options.DocInclusionPredicate((docName, description) => true);
                //options.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            #endregion
            #region 1认证
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false; //获取或设置元数据地址或权限是否需要HTTPS。默认值为true。这应该仅在开发环境中禁用。
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = "RayPI",
            //        ValidAudiences = new[] { "yyy", "RayPI" },
            //        ValidateAudience = true,
            //        ValidateIssuer = true,//是否验证Issuer
            //        ValidateIssuerSigningKey = true,//是否验证SecurityKey
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"])),
            //        ValidateLifetime = true,//是否验证失效时间

            //    };
            //});

            #endregion
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion
            //认证

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });
            //app.UseAuthentication(); 
            app.UseMvc();
        }
    }
}
