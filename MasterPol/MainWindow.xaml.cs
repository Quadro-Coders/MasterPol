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
using MasterPol.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterPol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        /// <summary>
        /// Загрузка данных
        /// </summary>
        void LoadData()
        {
            try
            {
                using var context = new Wsr1DexDemoContext();

                var mapped = context.Partners
                    .Include(p => p.Histories)
                    .Select(p => new {
                        p.Id,
                        p.Type,
                        p.Name,
                        p.DirectorName,
                        p.DirectorPhone,
                        p.Rank,
                        Discount = $"{DiscountHelper.Calculate(p.Histories.Sum(p => p.Count))} %"

                    })
                    .ToArray();

                Partners.ItemsSource = mapped;
            } catch (Exception ex) {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Partners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}