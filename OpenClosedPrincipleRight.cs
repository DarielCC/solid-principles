public enum TipoConta { 
    Poupanca, Corrente, Investimento
}

public abstract class DebitoConta {
    public string NumeroTransacao { get; set; }

    public abstract string Debitar(decimal valor, string conta);

    public string FormatarTransacao() {
        const string chars = "ABCasDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        NumeroTransacao = new string(Enumerable.Repeat(chars, 15)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        // Numero de transacao formatado
        return NumeroTransacao;
    } 
}

public class DebitoContaCorrente : DebitoConta {
    public override string Debitar(decimal valor, string conta) {
        //Debita Conta Corrente
        return FormatarTransacao();
    }
}

public class DebitoContaPoupanca : DebitoConta {
    public override string Debitar(decimal valor, string conta) {
        //Valida Aniversário da Conta
        //Debita Conta Poupança
        return FormatarTransacao();
    }
}

public class DebitoContaInvestimento : DebitoConta {
    public override string Debitar(decimal valor, string conta) {
        //Valida Aniversário da Conta
        //Aplica taxa
        //Debita Conta Investimento
        return FormatarTransacao();
    }
}

public class DebitoContaService {
    public string Debitar(decimal valor, string conta, TipoConta tipoConta) {
        DebitoConta debitoConta;

        switch(tipoConta) {
            case TipoConta.Corrente: {
                debitoConta = new DebitoContaCorrente();
            }
            case TipoConta.Poupanca: {
                debitoConta = new DebitoContaPoupanca();
            }
            case TipoConta.Investimento: {
                debitoConta = new DebitoContaInvestimento();
            }
        }
        
        return debitoConta.Debitar(valor, conta);
    }
}