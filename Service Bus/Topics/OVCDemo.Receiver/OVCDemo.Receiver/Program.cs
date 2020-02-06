using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OVEDemo.Receiver
{
    class Program
    {
        static ISubscriptionClient subscriptionClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Listner started.");
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            string ServiceBusConnectionString = "Endpoint=sb://ovc-demo-service-bus.servicebus.windows.net/;SharedAccessKeyName=Receive;SharedAccessKey=Uh8r4Dvo7nV9FCYizMmc7smiFMwCVb85+XmviumzLqE=";
            string TopicName = "ovc_demo_topic";
            string SubscriptionName = "ovc_demo_subscription2";

            subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, TopicName, SubscriptionName);

            // Register subscription message handler and receive messages in a loop.
            RegisterOnMessageHandlerAndReceiveMessages();

            Console.ReadKey();

            await subscriptionClient.CloseAsync();
        }

        static void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler);

            // Register the function that processes messages.
            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);

            var serviceBusMessage = JsonConvert.DeserializeObject<ServiceBusMessage>(messageBody);

            Console.WriteLine($"Received message: UserInfo:{Encoding.UTF8.GetString(message.Body)}");

            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var exception = exceptionReceivedEventArgs.Exception;

            return Task.CompletedTask;
        }

        public class ServiceBusMessage
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Content { get; set; }
        }
    }
}