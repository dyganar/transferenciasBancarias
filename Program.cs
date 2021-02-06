

using System;
using System.Collections.Generic;

namespace projeto01
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferirPontos();
                        break;
                    case "4":
                        UtilizarPontos();
                        break;
                    case "5":
                        InserirPontos();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Insira dados válidos\nAperte Enter para prosseguir");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
        }
        private static void InserirPontos(){
            try{
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite a quantidade de pontos a serem depositados: ");
                double valorDepositado = double.Parse(Console.ReadLine());

                listContas[indiceConta].InserirPontos(valorDepositado);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        private static void UtilizarPontos(){
            try{
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser sacado: ");
                double valorSaque = double.Parse(Console.ReadLine());

                listContas[indiceConta].UtilizarPontos(valorSaque);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        private static void TransferirPontos(){
            try{
                Console.Write("Digite o número da conta de origem: ");
                int indiceContaOrigem = int.Parse(Console.ReadLine());

                Console.Write("Digite o número da conta de destino: ");
                int indiceContaDestino = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser transferido: ");
                double valorATransferir = double.Parse(Console.ReadLine());

                listContas[indiceContaOrigem].TransferirPontos(valorATransferir, listContas[indiceContaDestino]);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        private static void InserirConta(){
            try{
                Console.WriteLine("Inserir nova conta");
                Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
                //int.TryParse(Console.ReadLine(), out int entradaTipoConta);
                int entradaTipoConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do cliente: ");
                string entradaNome = Console.ReadLine();

                if(VerificarNome(entradaNome)){
                    Console.Write("Cliente já se encontra na base de dados: ");
                    Console.Write("Deseja tentar novamente? Digite 1 para sim e 0 para não: ");
                    string valor = Console.ReadLine();
                    switch(valor){
                        case "1":
                            InserirConta();
                            return;
                        case "0":
                            ObterOpcaoUsuario();
                            return;
                        default:
                            break;
                    }
                }

                Console.Write("Digite o saldo de pontos inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.Write("Digite o crédito: ");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
                listContas.Add(novaConta);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        private static void ListarContas(){
            Console.WriteLine("Listar contas");
            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine("Aperte Enter para prosseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta.FormatarSaida());
            }
        }

        private static bool VerificarNome(string nome){
            bool retorno = false;
            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                if(conta.GetNome() == nome){
                    retorno = true;
                }
            }
            return retorno;
        }
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Localiza Pontos a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir Pontos");
            Console.WriteLine("4- Utilizar Pontos");
            Console.WriteLine("5- Inserir Pontos");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
