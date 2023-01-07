using FinalMediaGuide.DAL;
using FinalMediaGuide.DAL.Repositories;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.Services;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace FinalMediaGuide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization();
            builder.Services.AddDbContext<FinalMediaGuideDataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MediaConnectionstring")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<INewsRepository, NewsRepositories>();
            builder.Services.AddScoped<IQuestionAnswerRepository, QuestionAnswerRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestonRepository>();
            builder.Services.AddScoped<IQuizTypeRepository, QuizTypeRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IQuizTypeService, QuizTypeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ITranslateRepository, TranslateRepository>();
            builder.Services.AddScoped<ITranslatorService, TranslatorService>();
            builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<FinalMediaGuideDataContext>();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var suportedCultures = new[]
                {
                    new CultureInfo("am"),
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = suportedCultures;
                options.SupportedUICultures = suportedCultures;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}