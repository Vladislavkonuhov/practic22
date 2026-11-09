using System.Collections.ObjectModel;
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

namespace practic22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Product> products = new ObservableCollection<Product>();


        public MainWindow()
        {
            InitializeComponent();

            products.Add(new Product { Name = "Товар 1", Count = 1, Price = 150 });
            products.Add(new Product { Name = "Товар 2", Count = 5, Price = 2150 });
            products.Add(new Product { Name = "Товар 3", Count = 55, Price = 5150 });
            products.Add(new Product { Name = "Товар 4", Count = 95, Price = 850 });


            tableProduct.ItemsSource = products;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int price = Convert.ToInt32(txtPrice.Text);
            int count = Convert.ToInt32(txtCount.Text);

            products.Add(new Product
            {
                Name = name,
                Price = price,
                Count = count
            });

        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (tableProduct.SelectedItem is Product p)
            {
                MessageBoxResult q = MessageBox.Show("Вы точно хотите удалить?", "Удаление",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Question);

                if (q == MessageBoxResult.Yes)
                    products.Remove(p);
            }
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Product p)
            {
                MessageBox.Show($"Вы купили {p.Name}");
            }
        }

    }
}