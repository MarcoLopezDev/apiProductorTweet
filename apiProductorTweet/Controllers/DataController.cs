using apiProductorTweet.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProductorTweet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {

            //queue1 -> Shared access policies -> enviar -> Primary Connection String -> copiar 
            string connectionString = "Endpoint=sb://tweetbus.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=Dh3kkn8tmhT+4vtXosXn0DYZbAEYKxKQAyNfpfmuiUk=;EntityPath=data";
            string queueName = "data";
            //Instalar paquetes newton (JsonConvert)
            string mensaje = JsonConvert.SerializeObject(data);

            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // Create a sender for the queue
                ServiceBusSender sender = client.CreateSender(queueName);

                // Create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // Send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");

            }


            return true;
        }
    }
}
