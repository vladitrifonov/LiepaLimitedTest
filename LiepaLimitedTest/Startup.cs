using AutoMapper;
using LiepaLimitedTest.Api.BackgroundJobs;
using LiepaLimitedTest.Applicaion.Mapper;
using LiepaLimitedTest.Applicaion.Mapper.Configuration;
using LiepaLimitedTest.Applicaion.Models;
using LiepaLimitedTest.Applicaion.Services;
using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using LiepaLimitedTest.Infrastructure.Dapper;
using LiepaLimitedTest.Infrastructure.Dapper.Data;
using LiepaLimitedTest.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LiepaLimitedTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiepaLimitedTest", Version = "v1" });
            });

            string connectionString = Configuration.GetConnectionString("DbContext");

            RegisterDapperDependencies(services, connectionString);

            services.AddHostedService<SyncronizeBackgroundService<UserEntity>>();

            services.AddTransient<ISyncronizeManager<UserEntity>, SyncronizeService<UserEntity>>();

            services.AddSingleton<ICacheManager<UserEntity>, UserCacheService>();

            services.AddTransient<IGenericService<UserEntity, User>, GenericService<UserEntity, User>>();

            services.AddTransient<Domain.Contracts.IMapper, SimpleMapper>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfiguration>();
            });
            services.AddTransient(x => autoMapperConfig.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiepaLimitedTest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void RegisterDapperDependencies(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<UserEntity>>(x => new DapperRepository<UserEntity>(connectionString, new DapperConfiguration("Users", new UserHelper())));         
        }
    }
}
