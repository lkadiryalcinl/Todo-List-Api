using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Business.Abstract;
using TodoList.Business.Concrete;
using TodoList.DataAccess;
using TodoList.DataAccess.Abstract;
using TodoList.DataAccess.Concrete;
using TodoList.Entities.Models;

namespace TodoList
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<TodoListAuthDbContext>();
            services.AddScoped<DbContext, TodoListAuthDbContext>();

            //addScoped, her HTTP isteği için bir örnek oluşturup, 
            //aynı istek içinde yapılan tüm çağrılarda aynı örneğin kullanılmasını sağlayan
            // kapsamlı hizmetler (scoped services) oluşturmak için kullanılır.
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoService, TodoManager>();

            string mongoConnectionString = Configuration.GetConnectionString("MongoConnectionString");

            //addTransient, her talep edildiğinde yeni bir örneği döndüren geçici hizmetler (transient services) oluşturmak için kullanılır.
            services.AddTransient<BaseMongoRepository<FavTodoMongoModel>>
                (s => new FavTodoMongoRepository(mongoConnectionString, "Todo-list", "TodoFavorited"));

            services.AddTransient<BaseMongoRepository<FinTodoMongoModel>>
                (s => new FinTodoMongoRepository(mongoConnectionString, "Todo-list", "TodoFinished"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                        ;
                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(
                options => options.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                );
            app.UseMvc();
        }
    }
}
