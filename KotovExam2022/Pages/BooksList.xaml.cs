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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KotovExam2022
{
    /// <summary>
    /// Логика взаимодействия для BooksList.xaml
    /// </summary>
    public partial class BooksList : Page
    {
        private List<Books> booksInCart;
        public BooksList(List<Books> booksInCart)
        {
            InitializeComponent();
            this.booksInCart = booksInCart;
            bookList.ItemsSource = BaseConnect.baseModel.Books.ToList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Uid);
            var addedBook = BaseConnect.baseModel.Books.Where(x => x.Id == id).First();
            if (booksInCart.Where(x => x.Id == addedBook.Id).ToList().Count >= addedBook.FullCount)
            {
                MessageBox.Show("Такого количества книг нет!");
                return;
            }
            if (addedBook.FullCount > 0)
                booksInCart.Add(addedBook);
            UpdateOrderText();
        }

        private void UpdateOrderText()
        {
            float fullCost = 0;
            foreach(Books book in booksInCart)
            {
                fullCost += (float)book.Cost;
            }
            var sale = SaleLib.Sale.CalculateSale(booksInCart.Count, fullCost);
            if(sale == 0)
            {
                orderCost.Visibility = Visibility.Collapsed;
                orderRealCost.Text = fullCost.ToString() + " ";
            }
            else
            {
                orderCost.Visibility = Visibility.Visible;
                orderCost.Text = fullCost.ToString() + " ";
                orderRealCost.Text = (fullCost - fullCost * sale / 100).ToString();
            }

            orderBooksCount.Text = "Количество выбранных книг: " + booksInCart.Count;
            saleSize.Text = "Размер скидки: " + sale + "%";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadPage.frameLoad.Navigate(new CartList(booksInCart));
        }
    }
}
