using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;
 

namespace UniversalShare.ShareApp

{
    /*

    /// <summary>
    /// Служба мониторинга очереди сообщений ServiceBroker
    /// </summary>
    public class DequeueWorker: BackgroundService
    {

        private readonly DequeueWorkerOptions _options;
        private readonly ServiceBrokerCtrl _model;
        private readonly ILogger<DequeueWorker> _logger;

        public class DequeueWorkerOptions
        {
            public int CheckTimeout { get; set; }
            public string PublicKey { get; set; }   
        }

        public DequeueWorker(
            ILogger<DequeueWorker> logger, 
            DequeueWorkerOptions options, 
            ServiceBrokerCtrl model)
        {
            _options = options;
            _model = model;
            _logger = logger;

            Clear();

            int databaseCreated =   _model.CreateServiceBrokerDatabase("dev");
            int serviceCreated =    _model.CreateMessageService("hi", "ON", "OFF");

        }
        private async Task DoCheck()
        {
            Clear();

            IEnumerable<object> readed = _model.ReadFromQueue();
            foreach (object item in readed)
                WriteLine(item);
            await Task.CompletedTask;
        }

        private async Task DoCheck(Message input)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(input));

            await Task.CompletedTask;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started");
            while (true)
            {
      
                await DoCheck();
                _logger.LogInformation("Wait "+ _options.CheckTimeout);

                await Task.Delay(_options.CheckTimeout, cancellationToken);


            }
        }

        /* public async Task StartAsync(CancellationToken cancellationToken)
         {
             
         }

         

         private IEnumerable<object> ReadFromQueue()
         {
             var messages = _model.ReadFromQueue();
             return messages;
         }

         public async Task StopAsync(CancellationToken cancellationToken)
         {
             _logger.LogInformation("Stoped()");

             while (cancellationToken.IsCancellationRequested)
             {
                 await DoCheck();
                 await Task.Delay(_options.CheckTimeout);
             }
         }
    }*/
}
