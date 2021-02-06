using System;

namespace projeto01
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public string GetNome(){
            return this.Nome;
        }
        public bool UtilizarPontos(double quantidade){
            if(this.Saldo - quantidade < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= quantidade;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }
        public void InserirPontos(double quantidade){
            this.Saldo += quantidade;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

        }
        public void TransferirPontos(double quantidade, Conta contaDestino){
            if(this.UtilizarPontos(quantidade)){
                contaDestino.InserirPontos(quantidade);
            }

        }

        public string FormatarSaida(){
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }


    }
}