using System.ComponentModel;

namespace PrimeiraApi.Enum
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Em Andamento")]
        Concluido = 3
    }
}
