using FinalMediaGuide.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL
{
    public class FinalMediaGuideDataContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public FinalMediaGuideDataContext(DbContextOptions<FinalMediaGuideDataContext> options) : base(options)
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<QuizType> QuizTypes { get; set; }
    }
}
