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
    /// Lógica interna para CalculadoraWindow.xaml
    /// </summary>
    public partial class CalculadoraWindow : Window
    {
        public CalculadoraWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validação dos Números introduzidos
            if (!double.TryParse(txtNum1.Text, out double num1) || !double.TryParse(txtNum2.Text, out double num2))
            {
                MessageBox.Show("Por favor, introduza valores numéricos válidos nos dois campos.", "Erro de Entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. Obter a operação selecionada
            string operacao = ((ComboBoxItem)cmbOperacao.SelectedItem).Content.ToString();
            double resultado = 0;
            bool erroDivisao = false;

            // 3. Processamento com instrução Switch
            switch (operacao)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        erroDivisao = true;
                    }
                    else
                    {
                        resultado = num1 / num2;
                    }
                    break;
                default:
                    MessageBox.Show("Operação inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            // 4. Apresentação do Resultado ou Mensagem de Erro Preventiva
            if (erroDivisao)
            {
                MessageBox.Show("Erro: Não é possível efetuar uma divisão por zero.", "Divisão por Zero", MessageBoxButton.OK, MessageBoxImage.Error);
                lblResultado.Text = "Erro: Divisão por zero.";
            }
            else
            {
                lblResultado.Text = $"🧮 Resultado da Operação:\n• {num1} {operacao} {num2} = {resultado}";
            }
        }
    }
}
