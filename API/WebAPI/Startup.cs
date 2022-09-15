using Library.Application.Services;
using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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

            services.AddDbContext<PaymentServicesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionDB")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            //services.AddSingleton<DbContext, PaymentServicesContext>();
            //services.AddSingleton<PaymentServicesContext, PaymentServicesContext>();

            // Repositories
            services.AddScoped<IUserTypeRepo, UserTypeRepoImpl>();
            services.AddScoped<IUserRepo, UserRepoImpl>();
            services.AddScoped<ICompanyRepo, CompanyRepoImpl>();
            services.AddScoped<IProviderRepo, ProviderRepoImpl>();
            services.AddScoped<IProviderCompaniesRepo, ProviderCompaniesRepoImpl>();
            services.AddScoped<IOperationsAPIRepo, OperationsAPIRepoImpl>();
            services.AddScoped<ICategoryRepo, CategoryRepoImpl>();
            services.AddScoped<IServiceRepo, ServiceRepoImpl>();
            services.AddScoped<IProviderServicesRepo, ProviderServicesRepoImpl>();
            services.AddScoped<ICustomerAccountsRepo, CustomerAccountsRepoImpl>();
            services.AddScoped<IAuditRepo, AuditRepoImpl>();
            services.AddScoped<IPaymentTypeRepo, PaymentTypeRepoImpl>();
            services.AddScoped<ITransactionStatusRepo, TransactionStatusRepoImpl>();
            services.AddScoped<IRoleRepo, RoleRepoImpl>();
            services.AddScoped<IPermissionRepo, PermissionRepoImpl>();
            services.AddScoped<IPermissionRoleRepo, PermissionRoleRepoImpl>();
            services.AddScoped<IUserTypeRoleRepo, UserTypeRoleRepoImpl>();
            services.AddScoped<IUserPermissionRepo, UserPermissionRepoImpl>();
            services.AddScoped<ILogsPermissionRepo, LogsPermissionRepoImpl>();

            // Services
            services.AddScoped<IProviderService, ProviderServiceImpl>();
            services.AddScoped<ICompaniesService, CompaniesServiceImpl>();
            services.AddScoped<IProviderCompaniesService, ProviderCompaniesServiceImpl>();
            services.AddScoped<IOperationsAPIService, OperationsAPIServiceImpl>();
            services.AddScoped<IServicesService, ServicesServiceImpl>();
            services.AddScoped<IProviderServicesService, ProviderServicesServiceImpl>();
            services.AddScoped<ICustomerAccountsService, CustomerAccountsServiceImpl>();
            services.AddScoped<ITransStatusService, TransStatusServiceImpl>();
            services.AddScoped<IAuditService, AuditServiceImpl>();
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IRoleService, RoleServiceImpl>();
            services.AddScoped<IPermissionService, PermissionServiceImpl>();
            services.AddScoped<IUserTypeRoleService, UserTypeRoleServiceImpl>();
            services.AddScoped<IPermissionRoleService, PermissionRoleServiceImpl>();
            services.AddScoped<IAdminUserPermissionService, AdminUserPermissionServiceImpl>();
            services.AddScoped<IClientUserPermissionService, ClientUserPermissionServiceImpl>();
            services.AddScoped<ILogsPermissionService, LogsPermissionServiceImpl>();
            //services.AddScoped<ICompanyService, CompanyServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
