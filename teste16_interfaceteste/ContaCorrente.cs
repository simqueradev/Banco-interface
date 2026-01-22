public class ContaCorrente : ContaBancaria {
    public ContaCorrente(int numero, double saldo, string titular) : base(numero, saldo, titular) { }

    public override void Depositar(double valor, bool exibirMensagem = true) {
        if (valor > 0) {
            Saldo += valor;
            Saldo = Math.Round(Saldo, 2);
            if (exibirMensagem) {
                Console.WriteLine($"Depósito de R${valor.ToString("F")} realizado. Seu novo saldo é de {Saldo.ToString("F")} reais.");
            }
        }
        else {
            Console.WriteLine("O valor do depósito deve ser maior que zero.");
        }
    }

    public override bool Sacar(double valor) {
        if (valor > 0 && Saldo >= valor) {
            Saldo -= valor;
            Saldo = Math.Round(Saldo, 2);
            Console.WriteLine($"Saque de R${valor.ToString("F")} realizado. Seu novo saldo é de {Saldo.ToString("F")} reais.");
            return true;
        }
        else {
            Console.WriteLine("Você não tem saldo suficiente para realizar esse saque.");
            return false;
        }
    }

    public override double ExibirSaldo() {
        Console.WriteLine($"Saldo atual da conta corrente: R${Saldo.ToString("F")}.");
        return Saldo;
    }
}
