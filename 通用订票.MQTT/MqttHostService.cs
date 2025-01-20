using Furion.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;

namespace 通用订票.MQTT
{
    public class MqttHostService : IHostedService, IDisposable
    {
        public static MqttServer? _mqttServer = null;
        public void Dispose()
        {
            _mqttServer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            MqttServerOptionsBuilder optionsBuilder = new MqttServerOptionsBuilder();
            optionsBuilder.WithDefaultEndpointPort(56666).WithConnectionBacklog(100).WithDefaultEndpoint();
            MqttServerOptions options = optionsBuilder.Build();

            _mqttServer = new MqttFactory().CreateMqttServer(options);

            _mqttServer.ClientConnectedAsync += _mqttServer_ClientConnectedAsync;
            _mqttServer.ClientDisconnectedAsync += _mqttServer_ClientDisconnectedAsync;
            _mqttServer.ClientSubscribedTopicAsync += _mqttServer_ClienSubscribedAsync;
            _mqttServer.StartedAsync += _mqttServer_StartedAsync;
            _mqttServer.StoppedAsync += _mqttServer_StoppedAsync;
            _mqttServer.StartAsync();
            return Task.CompletedTask;
        }

        private Task _mqttServer_ClienSubscribedAsync(ClientSubscribedTopicEventArgs args)
        {
            Log.Information("客户端订阅了" + args.TopicFilter.Topic);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }

        private Task _mqttServer_ClientConnectedAsync(ClientConnectedEventArgs args)
        {
            Log.Information($"客户端ID=【{args.ClientId}】已连接");
            return Task.CompletedTask;
        }

        private Task _mqttServer_ClientDisconnectedAsync(ClientDisconnectedEventArgs args)
        {
            Log.Information($"客户端ID=【{args.ClientId}】已断开");
            return Task.CompletedTask;
        }

        private Task _mqttServer_StartedAsync(EventArgs args)
        {
            Log.Information($"mqtt服务器已启动");
            return Task.CompletedTask;
        }

        private Task _mqttServer_StoppedAsync(EventArgs args)
        {
            Log.Information($"mqtt服务器已停止");
            return Task.CompletedTask;
        }
    }
}
