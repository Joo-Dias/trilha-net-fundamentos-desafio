namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            
            if(placa.Length > 7 || placa.Length < 7)
            {
                Console.WriteLine("Placa inválida!");
            }
            else
            {
                Console.WriteLine($"{placa} adicionada com sucesso!");
                veiculos.Add(placa);
            }
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Lista dos carros no estacionamento: ");
            int contador = 1;
            foreach(string placaV in veiculos)
            {
                Console.WriteLine($"Carro N°{contador} - {placaV}");
                contador++;
            }
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                veiculos.Remove(placa);

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                string input = Console.ReadLine();

                if(int.TryParse(input, out int horas)) 
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                } else 
                {
                    Console.WriteLine("Hora inválida!");
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
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int contador = 1;
                foreach(string placa in veiculos)
                {
                    Console.WriteLine($"Carro N°{contador} - {placa}");
                    contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
