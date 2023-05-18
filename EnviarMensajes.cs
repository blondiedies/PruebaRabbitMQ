using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace PruebaRabbitMQ
{
    public class EnviarMensajes
    {
        public void EnviarMensaje<T>(T mensaje)

        //especificar el servidor de RabbitMQ (en este caso localhost)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            //se crea la cnexión con rabbitmq
            var connection = factory.CreateConnection();

            //se crea el canal con sesion y modelo

            using var channel = connection.CreateModel();

            //se declara la cola
            //producto es el nombre de la cola :-)
            //exclusive:false significa que los objetos sólo tienen un lector
            //auto-delete es que borra los archivos de la cola al ser leidos
            //hay otras caracteristicas que se le pueden dar
            //la cola se crea manualmente
            channel.QueueDeclare("producto", exclusive: false);


            //se serializa el mensaje:
            var json = JsonConvert.SerializeObject(mensaje);
            var body = Encoding.UTF8.GetBytes(json);

            //se coloca la data en la cola
            //exchange va vacio porque no se necesita para este mensaje
            channel.BasicPublish(exchange: "", routingKey: "producto", body: body);

            Console.WriteLine("Envío finalizado. Presione cualquier tecla...");
            Console.ReadKey();

        }

    }
}
