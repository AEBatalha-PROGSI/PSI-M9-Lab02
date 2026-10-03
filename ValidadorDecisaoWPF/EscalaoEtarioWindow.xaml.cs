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
    /// Lógica interna para EscalaoEtarioWindow.xaml
    /// </summary>
    public partial class EscalaoEtarioWindow : Window
    {
        public EscalaoEtarioWindow()
        {
            InitializeComponent();
        }

        private void btnClassificar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validação de Entrada
            if (!int.TryParse(txtIdade.Text, out int idade) || idade <= 0)
            {
                MessageBox.Show("Por favor, introduza uma idade válida maior que 0.", "Erro de Entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
                lblResultado.Text = "Idade inválida.";
                return;
            }

            // 2. Determinação do escalão usando if / else if / else
            string escalao;
            if (idade < 12)
            {
                escalao = "Escalão Infantil";
            }
            else if (idade <= 17)
            {
                escalao = "Escalão Juvenil";
            }
            else if (idade <= 64)
            {
                escalao = "Escalão Adulto";
            }
            else
            {
                escalao = "Escalão Sénior";
            }

            // 3. Exibição do Resultado
            lblResultado.Text = $"👤 Idade: {idade} anos\n🎯 Classificação: {escalao}";

        }
    }
}
