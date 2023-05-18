namespace PruebaRabbitMQ
{
    public class producto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public producto() { id = 999; name = "default"; description = "default"; }

        public producto(int idd, string namee, string desc) { id = idd; name = namee; description = desc; }

        public void addproduct(producto producto)
        {

            var rabbit = new EnviarMensajes();
            rabbit.EnviarMensaje(producto); //aqui se agrega a la cola de rabbitmq

        }
    }
}
