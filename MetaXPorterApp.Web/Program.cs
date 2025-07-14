//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using MetaXPorterApp.Web.Brokers.Loggings;
using MetaXPorterApp.Web.Brokers.Queues;
using MetaXPorterApp.Web.Brokers.Sheets;
using MetaXPorterApp.Web.Brokers.Storages;
using MetaXPorterApp.Web.Components;
using MetaXPorterApp.Web.Services.Coordinations;
using MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets;
using MetaXPorterApp.Web.Services.Foundations.Persons;
using MetaXPorterApp.Web.Services.Foundations.Pets;
using MetaXPorterApp.Web.Services.Orchestrations.ExternalPersonPets;
using MetaXPorterApp.Web.Services.Orchestrations.PersonPets;
using MetaXPorterApp.Web.Services.Orchestrations.Persons;
using MetaXPorterApp.Web.Services.Processings.ExternalPersonPets;
using MetaXPorterApp.Web.Services.Processings.Persons;
using MetaXPorterApp.Web.Services.Processings.Pets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetaXPorterApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<HttpClient>(sp =>
            {
                var navigationManager = sp.GetRequiredService<NavigationManager>();
                return new HttpClient { BaseAddress = new Uri(navigationManager.BaseUri) };
            });

            builder.Services.AddDbContext<StorageBroker>();
            AddBrokers(builder.Services);
            AddFoundationServices(builder.Services);
            AddProcessingServices(builder.Services);
            AddOrchestrationServices(builder.Services);
            AddCoordinationServices(builder.Services);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapStaticAssets();
            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<ISheetBroker, SheetBroker>();
            services.AddTransient<IQueueBroker, QueueBroker>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetInputService, ExternalPersonPetInputService>();
            services.AddTransient<IExternalPersonPetService, ExternalPersonPetService>();
            services.AddTransient<IExternalPersonPetEventService, ExternalPersonPetEventService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonXMLService, PersonXMLService>();
            services.AddTransient<IPetService, PetService>();
        }

        private static void AddProcessingServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetInputProcessingService, ExternalPersonPetInputProcessingService>();
            services.AddTransient<IExternalPersonPetProcessingService, ExternalPersonPetProcessingService>();
            services.AddTransient<IExternalPersonPetEventProcessingService, ExternalPersonPetEventProcessingService>();
            services.AddTransient<IPersonProcessingService, PersonProcessingService>();
            services.AddTransient<IPersonXMLProcessingService, PersonXMLProcessingService>();
            services.AddTransient<IPetProcessingService, PetProcessingService>();
        }

        private static void AddOrchestrationServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetOrchestrationService, ExternalPersonPetOrchestrationService>();
            services.AddTransient<IExternalPersonPetEventOrchestrationService, ExternalPersonPetEventOrchestrationService>();
            services.AddTransient<IPersonPetOrchestrationService, PersonPetOrchestrationService>();
            services.AddTransient<IPersonOrchestrationService, PersonOrchestrationService>();
        }

        private static void AddCoordinationServices(IServiceCollection services) =>
            services.AddTransient<IPersonPetEventCoordinationService, PersonPetEventCoordinationService>();
    }
}
