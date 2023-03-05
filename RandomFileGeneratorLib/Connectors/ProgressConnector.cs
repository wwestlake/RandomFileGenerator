using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Connectors
{
    public class ProgressConnector : Connector
    {
        public ProgressConnector(Action<Message> connection) : base(connection)
        {
        }

        public override void Send(Message message)
        {
            if (IsConnected) _connection(message);
        }
    }
}
