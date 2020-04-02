﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Covid_Alert.CovidApi;
using Covid_Stats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Covid_Alert.Alerting
{
    public class Alerting : BackgroundService, IHostedService
    {
        
        StateData stateData = new StateData();

        public IList<CustomerInfo> CustomerList { get; set; }
        public IServiceProvider Services { get; }

        public Alerting(IServiceProvider services)
        {
            Services = services;
        }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            using (var scope = Services.CreateScope())
            {
                var dbContext =
                    scope.ServiceProvider
                        .GetRequiredService<CustomerInfoDbContext>();

                CustomerList = await dbContext.CustomerInfo.ToListAsync();
                IEnumerable<StateStats> statesInfo = stateData.GetStateStats().Result;

                foreach (var recipient in CustomerList)
                {
                    StateStats stateOfInterest = statesInfo.First(x => x.provincestate == recipient.State);
                    Execute(recipient.Email, recipient.Name, recipient.State, stateOfInterest).Wait();
                }
                await Task.CompletedTask;
            }
        }

        static async Task Execute(string recepiantEmail, string recepiantName, string location, StateStats stateOfInterest)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient("s");
            var from = new EmailAddress("sumaiya.aa@gmail.com", "Queen Sumaiya");
            var subject = "COVID-19 Case Number Update";
            var to = new EmailAddress(recepiantEmail, recepiantName);
            var plainTextContent = location + " :  and easy to do anywhere, even with C#";
            var htmlContent = "<strong>" + location + "</strong><p>confirmed:" + stateOfInterest.confirmed + "</p><p> deaths: " + stateOfInterest.deaths + "</p><p> recovered: " + stateOfInterest.recovered + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await OnGetAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
                }

            }


        }
    }
}