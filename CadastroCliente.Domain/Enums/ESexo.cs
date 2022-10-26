using System.ComponentModel;

namespace CadastroCliente.Domain.Enums
{
    public enum ESexo
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2,

        [Description("Outros")]
        Outros = 3
    }
}
