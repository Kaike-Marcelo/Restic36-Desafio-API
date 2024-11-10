using System.ComponentModel;

namespace ApiPedidin.Models.Enums
{
    public enum StatusRequest
    {
        [Description("Cancelado")]
        Canceled = 0,
        [Description("Em Andamento")]
        InProgress = 1,
        [Description("Concluído")]
        Done = 2
    }
}