using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Connectors
{
    public class ProgressMessage : Message
    {
        public float Progress { get; }

        public ProgressMessage(float progress)
        {
            Progress = progress;
        }
    }
}
