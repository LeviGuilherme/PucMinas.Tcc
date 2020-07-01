using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Shared.DbSimulation.DbCIP;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace CadastroIncidentesProblemas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentesController : ControllerBase
    {
        private Incidentes _incidentes = new Incidentes();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _incidentes.ListaIncidentes.Values.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _incidentes.ListaIncidentes[id];
        }

        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            var kvpValue = value.GetProperty("value");
            var newKeyValuePair = new KeyValuePair<int, string>(_incidentes.ListaIncidentes.Count + 1, kvpValue.GetRawText());
            _incidentes.ListaIncidentes.Add(newKeyValuePair.Key, newKeyValuePair.Value);

            Publish("divulgacao", newKeyValuePair.ToByteArray());
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _incidentes.ListaIncidentes[id] = value;

            Publish("divulgacao", new KeyValuePair<int, string>(id, value).ToByteArray());
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _incidentes.ListaIncidentes.Remove(id);

            Publish("divulgacao", new KeyValuePair<int, string>(id, _incidentes.ListaIncidentes[id]).ToByteArray());
        }

        private void Publish(string queue, byte[] message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var body = message;

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }

    public static class KeyValuePairExtensions
    {
        public static byte[] ToByteArray<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair)
        {
            var bf = new BinaryFormatter();

            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, keyValuePair);
                return ms.ToArray();
            }
        }
    }
}
