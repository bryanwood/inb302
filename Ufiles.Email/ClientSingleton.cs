using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFiles.Email
{
    public class ClientSingleton
    {
        private ClientSingleton()
        {

        }
        private static UFilesService.UFileServiceClient client;
        public static UFilesService.UFileServiceClient Client
        {
            get
            {
                if (client == null)
                    client = new UFilesService.UFileServiceClient();
                return client;
            }
        }
    }
}
