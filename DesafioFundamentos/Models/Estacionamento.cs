using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        private string placa;

        private const int CapacidadeMaxima = 50;
        private int capacidadeAtual = 0;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();

            if(ValidarPlaca(placa) && (capacidadeAtual < CapacidadeMaxima))
            {
                veiculos.Add(placa);
                capacidadeAtual++;
            }
            else
            {
            Console.WriteLine("Você precisa informar uma placa");
            }
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = "";
            placa = Console.ReadLine();

            if(ValidarPlaca(placa))
            {
               if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0; 
                if (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Valor inválido de horas");
                    return;
                }
                
                valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                capacidadeAtual--;

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                } 
            }
            else
            {
            Console.WriteLine("Você precisa informar uma placa");
            }

            
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo}");
                }
                MostrarCapacidadeAtual();
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            if (!string.IsNullOrWhiteSpace(placa))
            {
                string pattern = @"^[A-Za-z]{3}-\d{4}$";
                return Regex.IsMatch(placa, pattern);
            }
            return false;  
        }

        public void MostrarCapacidadeAtual()
    {
        Console.WriteLine($"Capacidade atual do estacionamento: {capacidadeAtual}/{CapacidadeMaxima}");
    }
    }
}
