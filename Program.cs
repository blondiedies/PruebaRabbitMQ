using PruebaRabbitMQ;

Console.WriteLine("Este es un programa para demostrar la funcionalidad de RabbitMQ. Por favor, inicia el servicio antes de comenzar :-)");
//recordar que para acceder a la app web de rabbit es
// http://localhost:15672/ 

producto p = new producto();
int loop = 1;

while (loop == 1)
{
    Console.WriteLine("1: Enviar mensaje, 2: Recibir mensaje, Otro: Salir del sistema");
    int opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1: //En este caso, se envía el mensaje a la cola.
            //Primero se recopilan los datos necesarios:
            Console.WriteLine("ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Descripción:");
            string desc = Console.ReadLine();
            p.description = desc;
            p.id = id;
            p.name = name;
            //Luego se envía el producto
            p.addproduct(p);
            break;
        case 2://en este caso, se escuchan los mensajes ya existentes en la cola
            var escucha = new EscucharMensajes();
            escucha.EscucharMensaje();
            break;
        default://rompe el ciclo
            loop++;
            break;
    }
}


