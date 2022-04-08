using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    internal class MQTTService
    {

        MqttFactory mqttFactory = null;
        IMqttClient mqttClient = null;

        public MQTTService()
        {
            mqttFactory = new MqttFactory();
            mqttClient = mqttFactory.CreateMqttClient();
        }

        public async void createConnection(Config config)
        {
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(config.mqtt.server, config.mqtt.port)
                .WithCredentials(config.mqtt.username, config.mqtt.password)
                .WithClientId(config.mqtt.clientId)
                .Build();
            if (mqttClient != null)
            {
                if (!mqttClient.IsConnected)
                {
                    await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                }
            }
        }

        public async void sendMessage(Config config, Color color)
        {
            if (mqttClient.IsConnected)
            {
                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(config.mqtt.topic)
                    .WithPayload(Utils.replaceWildCards(config.mqtt.message, color))
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                Debug.WriteLine("MQTT application message is published.");
            }
        }
    }
}
