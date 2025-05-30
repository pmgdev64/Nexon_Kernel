using System;
using System.Text;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;

namespace NexonKernel.Network
{
    public class HttpClient
    {
        public static string SendGetRequest(string host, string path = "/", int port = 80)
        {
            try
            {
                Address ipAddress = Dns.Resolve(host);
                var endpoint = new RemoteEndPoint(ipAddress, (ushort)port);

                using (TcpClient client = new TcpClient())
                {
                    client.Connect(endpoint);

                    if (!client.Connected)
                        return "Failed to connect to server.";

                    var stream = client.GetStream();

                    string request = $"GET {path} HTTP/1.1\r\nHost: {host}\r\nConnection: close\r\n\r\n";
                    byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                    stream.Write(requestBytes, 0, requestBytes.Length);

                    byte[] buffer = new byte[4096];
                    int read;
                    StringBuilder response = new StringBuilder();

                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        response.Append(Encoding.ASCII.GetString(buffer, 0, read));
                    }

                    return response.ToString();
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
