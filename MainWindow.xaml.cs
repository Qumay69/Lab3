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

namespace Lab3
{
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fullName = FullNameTextBox.Text;
                decimal salary = decimal.Parse(SalaryTextBox.Text);
                int yearOfEmployment = int.Parse(YearOfEmploymentTextBox.Text);
                decimal bonusPercentage = decimal.Parse(BonusPercentageTextBox.Text) / 100;
                int workedDaysInMonth = int.Parse(WorkedDaysInMonthTextBox.Text);
                int workingDaysInMonth = int.Parse(WorkingDaysInMonthTextBox.Text);

                Payment payment = new Payment(fullName, salary, yearOfEmployment, bonusPercentage, workedDaysInMonth, workingDaysInMonth);

                ResultTextBlock.Text = payment.ToString();
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }

        private void WorkedDaysInMonthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Payment
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public int YearOfEmployment { get; set; }
        public decimal BonusPercentage { get; set; }
        public decimal IncomeTaxRate { get; set; } = 0.13m;
        public int WorkedDaysInMonth { get; set; }
        public int WorkingDaysInMonth { get; set; }
        public decimal AccruedAmount { get; private set; }
        public decimal WithheldAmount { get; private set; }

        public Payment(string fullName, decimal salary, int yearOfEmployment, decimal bonusPercentage, int workedDaysInMonth, int workingDaysInMonth)
        {
            FullName = fullName;
            Salary = salary;
            YearOfEmployment = yearOfEmployment;
            BonusPercentage = bonusPercentage;
            WorkedDaysInMonth = workedDaysInMonth;
            WorkingDaysInMonth = workingDaysInMonth;
            CalculateAccruedAmount();
            CalculateWithheldAmount();
        }

        public int CalculateExperience()
        {
            return DateTime.Now.Year - YearOfEmployment;
        }

        private void CalculateAccruedAmount()
        {
            decimal baseAmount = Salary * WorkedDaysInMonth / WorkingDaysInMonth;
            decimal bonusAmount = baseAmount * BonusPercentage;
            AccruedAmount = baseAmount + bonusAmount;
        }

        private void CalculateWithheldAmount()
        {
            decimal pensionFundDeduction = AccruedAmount * 0.01m;
            decimal taxableAmount = AccruedAmount - pensionFundDeduction;
            decimal incomeTax = taxableAmount * IncomeTaxRate;
            WithheldAmount = pensionFundDeduction + incomeTax;
        }

        public decimal CalculateNetAmount()
        {
            return AccruedAmount - WithheldAmount;
        }

        public override string ToString()
        {
            return $"ФИО: {FullName}\n" +
                   $"Оклад: {Salary}\n" +
                   $"Год поступления: {YearOfEmployment}\n" +
                   $"Процент надбавки: {BonusPercentage * 100}%\n" +
                   $"Отработанные дни в месяце: {WorkedDaysInMonth}\n" +
                   $"Рабочие дни в месяце: {WorkingDaysInMonth}\n" +
                   $"Начисленная сумма: {AccruedAmount}\n" +
                   $"Удержанная сумма: {WithheldAmount}\n" +
                   $"Сумма на руки: {CalculateNetAmount()}\n" +
                   $"Стаж: {CalculateExperience()} лет";
        }
    }
}