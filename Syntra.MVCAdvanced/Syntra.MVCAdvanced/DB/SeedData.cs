using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Syntra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.DB
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<DanceSchoolDbContext>>();
            using (var context = new DanceSchoolDbContext(dbContextOptions))
            {
                if (context.Teachers.Count() == 0)
                {
                    var teacher1 = new Teacher();
                    teacher1.FirstName = "Guy";
                    teacher1.LastName = "CryptoDev";
                    teacher1.Salary = 2000;
                    var teacher2 = new Teacher();
                    teacher2.FirstName = "Bart";
                    teacher2.LastName = "Van Gucht";
                    teacher2.Salary = 2000;
                    context.Add(teacher1);
                    context.Add(teacher2);
                    context.SaveChanges();
                }

            }
        }
    }
}
