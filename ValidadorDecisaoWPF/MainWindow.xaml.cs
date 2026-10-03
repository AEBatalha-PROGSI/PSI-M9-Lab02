using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValidadorDecisaoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAvaliar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validação de Entrada com TryParse
            if (!double.TryParse(txtNota.Text, out double nota) || nota < 0 || nota > 20)
            {
                MessageBox.Show("Por favor, introduza uma nota válida entre 0 e 20.",
                                "Erro de Entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Decisão com if / else if / else para Classificação
            string classificacao;
            if (nota < 9.5)
            {
                classificacao = "Reprovado (Necessita de Apoio)";
            }
            else if (nota < 13.5)
            {
                classificacao = "Suficiente";
            }
            else if (nota < 17.5)
            {
                classificacao = "Bom / Muito Bom";
            }
            else
            {
                classificacao = "Excelente (Nível Superior)";
            }

            // 3. Decisão com switch para Desconto na Propina
            string perfilSelecionado = ((ComboBoxItem)cmbPerfil.SelectedItem).Content.ToString();
            double percentagemDesconto;

            switch (perfilSelecionado)
            {
                case "Bolseiro":
                    percentagemDesconto = 50.0;
                    break;
                case "Atleta de Alta Competição":
                    percentagemDesconto = 30.0;
                    break;
                case "Mérito Académico":
                    percentagemDesconto = 40.0;
                    break;
                default:
                    percentagemDesconto = 0.0;
                    break;
            }

            // 4. Exibição Formatada do Resultado
            lblResultado.Text = $"📊 Estado do Aluno:\n"
                              + $"• Classificação: {classificacao}\n"
                              + $"• Perfil: {perfilSelecionado}\n"
                              + $"• Desconto Aplicável: {percentagemDesconto}%";
        }
    }
}