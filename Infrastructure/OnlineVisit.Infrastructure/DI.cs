using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineVisit.Application.Interfaces;
using OnlineVisit.Infrastructure.DataAccessManager;
using OnlineVisit.Infrastructure.DataAccessManager.Repositories;

namespace OnlineVisit.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddIdentity(services);
            AddRepositories(services);

            return services;
        }

        private static void AddDatabase(
            IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OnlineVisitDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(
                        "DefaultConnection"));
            });
        }

        private static void AddIdentity(
            IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;

                    options.User.RequireUniqueEmail = true;

                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<OnlineVisitDbContext>()
                .AddDefaultTokenProviders();
        }


        private static void AddRepositories(
            IServiceCollection services)
        {
            services.AddScoped(
                typeof(IRepository<>),
                typeof(Repository<>));

            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<
                IAppointmentRepository,
                AppointmentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
