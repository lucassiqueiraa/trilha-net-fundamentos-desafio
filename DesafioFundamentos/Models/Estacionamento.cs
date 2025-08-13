using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> _veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this._precoInicial = precoInicial;
            this._precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida");
                return;
            }

            if (_veiculos.Any(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Esse veículo já está estacionado.");
                return;
            }
            
            _veiculos.Add(placa.ToUpper());
            
            Console.WriteLine("Veiculo adicionado com sucesso!");
        }

        public void RemoverVeiculo(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) {
                Console.WriteLine("Placa inválida!");
                return;
            }

            var veiculoParaRemover = _veiculos.FirstOrDefault(ve => ve.ToUpper() == placa.ToUpper());
            
            if (veiculoParaRemover != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                string input = Console.ReadLine();

                if (int.TryParse(input, out int horas) && horas >= 0)
                {
                    decimal valorTotal = _precoInicial +  _precoPorHora * horas;
                    
                    _veiculos.Remove(veiculoParaRemover);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Valor Inválido");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
