namespace InfrastructureLayer.AzureSBSenders
{
    public class ShipmentSender(IConfiguration config) : Controller
    {
        private readonly IConfiguration _config = config;
    {
        [HttpPost("SendShipmentMessage")]
        public async Task Post(ShipmentDTO shipment, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(shipment);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}
