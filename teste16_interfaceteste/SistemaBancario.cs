using System;
using System.Collections.Generic;

public abstract class ContaBancaria {
    public int Numero {get; protected set;}
    public double Saldo {get; protected set;}
    public string Titular {get; set;}

    public ContaBancaria(int numero, double saldo, string titular)
    {
        Numero = numero;
        Saldo = saldo;
        Titular = titular;
    }

    public abstract void Depositar(double valor, bool exibirMensagem = true);

    public abstract bool Sacar(double valor);

    public abstract double ExibirSaldo();

    public void Transferir(double valor, ContaBancaria contaDestino) {
        if (valor <= 0) {
            Console.WriteLine("O valor a ser transferido deve ser maior que zero.");
            return;
        }

        if (Saldo >= valor) {
            Saldo -= valor;
            Saldo = Math.Round(Saldo, 2);

            contaDestino.Depositar(valor, exibirMensagem: false);

            Console.WriteLine($"Transferência de {valor.ToString("F")} realizada para a conta destino.");
            Console.WriteLine($"Seu novo saldo é de {Saldo.ToString("F")} reais.");
        }
        else {
            Console.WriteLine("Saldo insuficiente para realizar a transferência.");
        }
    }
}