using System.ComponentModel;

namespace biblioteca_fc_api.Enums
{
    public enum LoanStatus
    {
        [Description("Em Aberto")]
        EmAberto = 1,
        
        [Description("Fechado")]
        Fechado = 2
    }
}