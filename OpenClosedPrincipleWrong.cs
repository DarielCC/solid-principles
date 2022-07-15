public enum TipoConta { 
    Poupanca, Corrente, Investimento
}

public class DebitoConta {
    public void Debitar(decimal valor, string conta, TipoConta tipoConta) {
        if(tipoConta == TipoConta.Corrente) {
            //Debitar conta corrente
        }

        if (tipoConta == TipoConta.Poupanca) {
            //Validar aniversário da conta
            //Debitar conta poupança
        }

        if (tipoConta == TipoConta.Investimento) {
            //Validar aniversário da conta
            //Aplicar taxa
            //Debitar conta investimento
        }
    }
}