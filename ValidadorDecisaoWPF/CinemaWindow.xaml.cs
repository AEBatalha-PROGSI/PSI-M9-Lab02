using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ValidadorDecisaoWPF
{
    /// <summary>
    /// Lógica interna para CinemaWindow.xaml
    /// </summary>
    public partial class CinemaWindow : Window
    {
        public CinemaWindow()
        {
            InitializeComponent();
        }

        private void btnCalcularBilhete_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validação de Entrada da Idade
            if (!int.TryParse(txtIdadeCinema.Text, out int idade) || idade <= 0)
            {
                MessageBox.Show("Por favor, introduza uma idade válida.", "Erro de Entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Definição do Preço Base e Descontos
            double precoBase = 7.50;
            double descontoDia = 0.00;
            double descontoIdade = 0.00;

            string diaSemana = ((ComboBoxItem)cmbDiaSemana.SelectedItem).Content.ToString();

            // 3. Switch para o desconto fixo de Terça-feira (Dia do Espetador)
            switch (diaSemana)
            {
                case "Terça-feira":
                    descontoDia = 2.00;
                    break;
                default:
                    descontoDia = 0.00;
                    break;
            }

            // 4. Estrutura If para verificar o desconto de Estudante/Sénior
            if (idade <= 18 || idade >= 65)
            {
                descontoIdade = 1.50;
            }

            // 5. Cálculo do Preço Final
            double precoFinal = precoBase - descontoDia - descontoIdade;

            // Garantir que o bilhete nunca fica com preço negativo caso existam mais regras futuramente
            if (precoFinal < 0) precoFinal = 0;

            // 6. Exibição do resumo detalhado
            lblResultado.Text = $"🎬 Resumo do Bilhete:\n"
                             + $"• Preço Base: {precoBase:F2} €\n"
                             + $"• Dia Selecionado: {diaSemana} (Desconto: -{descontoDia:F2} €)\n"
                             + $"• Idade do Cliente: {idade} anos (Desconto Adicional: -{descontoIdade:F2} €)\n"
                             + $"• Preço Final a Pagar: {precoFinal:F2} €";
        }
    }
}
