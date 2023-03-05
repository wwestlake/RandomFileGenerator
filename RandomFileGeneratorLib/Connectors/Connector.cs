using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Connectors
{
    public abstract class Connector
    {
        protected Action<Message> _connection;

        public Connector(Action<Message> connection)
        {
            _connection = connection;
        }

        public bool IsConnected { get { return _connection != null; } }

        public abstract void Send(Message message);
    }
}
