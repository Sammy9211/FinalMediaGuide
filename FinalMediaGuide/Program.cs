using FinalMediaGuide.DAL;
using FinalMediaGuide.DAL.Repositories;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.Services;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalMediaGuide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FinalMediaGuideDataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MediaConnectionstring")));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<INewsRepository,NewsRepositories>();
            builder.Services.AddScoped<IQuestionAnswerRepository,QuestionAnswerRepository>();
            builder.Services.AddScoped<IQuestionRepository,QuestonRepository>();
            builder.Services.AddScoped<IQuizTypeRepository,QuizTypeRepository>();
            builder.Services.AddScoped<ICommentRepository,CommentRepository>();
            builder.Services.AddScoped<INewsService,NewsService>();
            builder.Services.AddScoped<IQuestionAnswerService,QuestionAnswerService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IQuizTypeService,QuizTypeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ITranslateRepository, TranslateRepository>();
            builder.Services.AddScoped<ITranslatorService, TranslatorService>();
            builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<FinalMediaGuideDataContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=UserSide}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}