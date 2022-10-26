using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.CrossCutting.Utils
{
    public static class CalculaIdade
    {
        public static int CalculaAge(this DateTime dataNascimento)
        {
            var today = DateTime.Today;
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dataNascimento.Year * 100 + dataNascimento.Month) * 100 + dataNascimento.Day;
            var idade = (a - b) / 10000;
            return idade;
        }
    }
}
