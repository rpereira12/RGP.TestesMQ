using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using (var connection = factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("fila_rgp_mq", false, false, false, null);

    string message = "Teste Rgp RabbitMQ 2!";
    
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "fila_rgp_mq", null, body);

    Console.WriteLine($"Mensagem enviada: {message}");
}