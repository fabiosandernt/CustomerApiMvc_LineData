using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.CrossCutting.Utils
{
    public class Notification
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public Notification()
        {
        }

        public Notification(string value)
        {
            Value = value;
        }

        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
