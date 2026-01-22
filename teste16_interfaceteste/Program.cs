class Program {
    static void Main(string[] args) {
        int numero, numeroConta;
        double saldo, taxa = 0.85;
        string titular, condicao;

        List<ContaBancaria> contas = new List<ContaBancaria>();

        do {
            Console.WriteLine("Você deseja criar uma nova conta? (digite 'S' para sim, 'N' para não)");
            condicao = Console.ReadLine().ToUpper();

            if (condicao == "S") {
                Console.WriteLine("Qual o nome do titular da conta?");
                titular = Console.ReadLine().ToUpper();
                Console.WriteLine("Qual o número da conta?");
                while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0) {
                    Console.WriteLine("O número da conta inserido não é válido. Por favor, insira um número inteiro positivo.");
                }
                saldo = 0;

                Console.WriteLine("Qual tipo de conta você deseja criar? (Digite 'C' para corrente e 'P' para poupança)");
                string tipoConta = Console.ReadLine().ToUpper();
                if (tipoConta == "C") {
                    contas.Add(new ContaCorrente(numero, saldo, titular));
                }
                else if (tipoConta == "P") {
                    contas.Add(new ContaPoupanca(numero, saldo, titular));
                }
                else {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
            else if (condicao != "N") {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
        while (condicao != "N");

        do {
            Console.Write("Digite o número da conta para realizar operações: ");
            numeroConta = int.Parse(Console.ReadLine());
            ContaBancaria contaSelecionada = contas.Find(conta => conta.Numero == numeroConta);
            if (contaSelecionada != null) {
                Console.WriteLine($"Conta selecionada:\n\nTitular: {contaSelecionada.Titular}.\nNúmero: {contaSelecionada.Numero}.\nSaldo: R${contaSelecionada.Saldo}\n\n");

                Console.WriteLine($"Você deseja fazer alguma operação? \n •'D' para depósito; \n •'S' para saque; \n •'T' para transferir dinheiro; \n •'R' para checar o rendimento; \n •'O' para verificar outra conta; \n •'C' para criar outra conta \n •'X' para sair.");
                condicao = Console.ReadLine().ToUpper();
                if (condicao == "D")
                {
                    Console.WriteLine("Digite o valor do depósito:");
                    double valorDeposito;
                    while (!double.TryParse(Console.ReadLine(), out valorDeposito) || valorDeposito <= 0) {
                        Console.WriteLine("Valor inválido. O valor do depósito deve ser maior que zero.");
                    }
                    contaSelecionada.Depositar(valorDeposito);
                }
                else if (condicao == "S") {
                    Console.WriteLine("Digite o valor do saque:");
                    double valorSaque;
                    while (!double.TryParse(Console.ReadLine(), out valorSaque) || valorSaque <= 0)
                    {
                        Console.WriteLine("Valor inválido. O valor do saque deve ser maior que zero.");
                    }
                    if (contaSelecionada is ContaCorrente contaCorrente) {
                        contaCorrente.Sacar(valorSaque);
                    }
                    else if (contaSelecionada is ContaPoupanca contaPoupanca) {
                        contaPoupanca.Sacar(valorSaque);
                    }
                }
                else if (condicao == "T") {
                    Console.WriteLine("Digite o valor da transferência:");
                    double valorTransferencia;
                    while (!double.TryParse(Console.ReadLine(), out valorTransferencia) || valorTransferencia <= 0) {
                        Console.WriteLine("Valor inválido. O valor da transferência deve ser maior que zero.");
                    }
                    Console.WriteLine("Digite o número da conta destino:");
                    int numeroContaDestino;
                    while (!int.TryParse(Console.ReadLine(), out numeroContaDestino)) {
                        Console.WriteLine("Número da conta destino inválido. Digite novamente:");
                    }
                    ContaBancaria contaDestino = contas.Find(c => c.Numero == numeroContaDestino);
                    if (contaDestino != null) {
                        if (contaSelecionada is ContaCorrente contaCorrente) {
                            contaCorrente.Transferir(valorTransferencia, contaDestino);
                        }
                        if (contaSelecionada is ContaPoupanca contaPoupanca) {
                            contaPoupanca.Transferir(valorTransferencia, contaDestino);
                        }
                    }
                    else {
                        Console.WriteLine("Conta destino não encontrada.");
                    }
                }
                else if (condicao == "R" && contaSelecionada is ContaPoupanca) {
                    ContaPoupanca contaPoupanca = (ContaPoupanca)contaSelecionada;
                    contaPoupanca.CalcularRendimento(taxa);
                }

                // criar nova conta

                else if (condicao == "C") {
                    Console.WriteLine("Você deseja criar uma nova conta? (digite 'S' para sim, 'N' para não)");
                    condicao = Console.ReadLine().ToUpper();

                    if (condicao == "S") {
                        Console.WriteLine("Qual o nome do titular da conta?");
                        titular = Console.ReadLine().ToUpper();
                        Console.WriteLine("Qual o número da conta?");
                        while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0) {
                            Console.WriteLine("O número da conta inserido não é válido. Por favor, insira um número inteiro positivo.");
                        }
                        saldo = 0;

                        Console.WriteLine("Qual tipo de conta você deseja criar? (Digite 'C' para corrente e 'P' para poupança)");
                        string tipoConta = Console.ReadLine().ToUpper();
                        if (tipoConta == "C") {
                            if (contas.Any(c => c.Numero == numero)) {
                                Console.WriteLine($"Já existe uma conta com o número {numero}. Operação cancelada.");
                            }
                            else {
                                contas.Add(new ContaCorrente(numero, saldo, titular));
                                Console.WriteLine("Conta corrente criada com sucesso.");
                            }
                        }
                        else if (tipoConta == "P") {
                            if (contas.Any(c => c.Numero == numero)) {
                                Console.WriteLine($"Já existe uma conta com o número {numero}. Operação cancelada.");
                            }
                            else {
                                contas.Add(new ContaPoupanca(numero, saldo, titular));
                                Console.WriteLine("Conta poupança criada com sucesso.");
                            }
                        }
                        else {
                            Console.WriteLine("Opção inválida. Tente novamente.");
                        }
                    }
                    else if (condicao != "N") {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }

                // volta as condiçoes normais

                else if (condicao != "O") {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
                else if (condicao == "X") {
                    break;
                }
            }
            else {
                Console.WriteLine("Conta não encontrada. Verifique o número da conta e tente novamente.");
            }
        }
        while (condicao != "X");
    }
}