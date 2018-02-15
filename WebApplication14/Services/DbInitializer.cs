using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;
using WebApplication14.Models.ViewModel;

namespace WebApplication14.Services
{
    public class DbInitializer 
    {

        public static void InitializeMigrations(IApplicationBuilder app)
        {
            using (var serviceScope =  app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                dbContext.Database.EnsureCreated();

                // TODO: Use dbContext if you want to do seeding etc.
            }
        }
    }
    }

 