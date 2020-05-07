using System;
using System.Collections.Generic;
using System.Text;
using Transport1.client;
using Grpc;
using Grpc.Core;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace Transport1.client
{
   public class ServiceModel : TransportService.TransportServiceClient
    {
      GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
        public async Task<User> Zalupa()
        {
            var client = new TransportService.TransportServiceClient(channel);
            UserRequest request = new UserRequest
            {
                IdUser = 1
            };
            User user = client.GetOneOfUser(request);
            return await Task.FromResult(user);
        }
    }
}
