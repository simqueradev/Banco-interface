public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(int numero, double saldo, string titular) : base(numero, saldo, titular) {}

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
        Console.WriteLine($"Saldo atual da conta poupança: R${Saldo.ToString("F")}.");
        return Saldo;
    }

    public double CalcularRendimento(double taxa) {
        if (taxa < 0 || taxa > 1) {
            throw new ArgumentException("A taxa de rendimento deve estar entre 0 e 1.");
        }

        double rendimento = Saldo * taxa;
        Saldo += rendimento;
        Saldo = Math.Round(Saldo, 2);

        Console.WriteLine($"Rendimento de {rendimento} aplicado. Seu novo saldo é de {Saldo.ToString("F")} reais.");

        return rendimento;
    }
}