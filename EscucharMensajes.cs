using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PruebaRabbitMQ
{
    internal class EscucharMensajes
    {
        public void EscucharMensaje()
        {
            //se especifica el servidor rabbitmq
            var factory = new ConnectionFactory { HostName = "localhost" };

            //se crea la conexion
            var connection = factory.CreateConnection();

            //se crea el canal
            using var channel = connection.CreateModel();

            //se crea la cola
            channel.QueueDeclare("producto", exclusive: false);

            //se crea el event listener que escucha la cola y espera mensajes
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (Model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Producto: {message}");
            };

            //se lee el mensaje

            channel.BasicConsume(queue: "producto", autoAck: true, consumer: consumer);
            Console.WriteLine("Cola finalizada. Presione cualquier tecla...");
            Console.ReadKey();
        }

    }
}
