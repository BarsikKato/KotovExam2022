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
    /// Логика взаимодействия для CartList.xaml
    /// </summary>
    public partial class CartList : Page
    {
        List<Books> booksInCart;
        public CartList(List<Books> booksInCart)
        {
            InitializeComponent();
            this.booksInCart = booksInCart;
            cartList.ItemsSource = booksInCart;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoadPage.frameLoad.Navigate(new BooksList(booksInCart));
        }

        private void OrderNow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders newOrder = new Orders();
                newOrder.BooksCount = booksInCart.Count;
                float fullCost = 0;
                bool isInStore = false, onlyInStock = false;
                foreach (Books book in booksInCart)
                {
                    fullCost += (float)book.Cost;
                    if (book.CountInStore > 0)
                    {
                        isInStore = true;
                        break;
                    }
                    if (book.CountInStock > 0)
                    {
                        onlyInStock = true;
                    }
                }
                var sale = SaleLib.Sale.CalculateSale(booksInCart.Count, fullCost);
                newOrder.OrderSale = (int)sale;
                var realCost = fullCost - fullCost * sale / 100;
                newOrder.OrderCostSale = realCost;
                DateTime reserveDate = DateTime.Now + new TimeSpan(7, 0, 0, 0);
                DateTime stockGet = DateTime.Now + new TimeSpan(72, 0, 0);
                newOrder.OrderGetDate = reserveDate;
                foreach (Books book in booksInCart)
                {
                    if (book.CountInStore > 0)
                        BaseConnect.baseModel.Books.Where(x => x.Id == book.Id).First().CountInStore -= 1;
                    else
                        BaseConnect.baseModel.Books.Where(x => x.Id == book.Id).First().CountInStock -= 1;
                    BaseConnect.baseModel.SaveChanges();
                }
                var newId = BaseConnect.baseModel.Orders.Add(newOrder);
                BaseConnect.baseModel.SaveChanges();
                string message = "Заказ под номером " + newId.Id + " успешно собран!\nСтоимость заказа: " + realCost + "\nКоличество заказанных книг: " + booksInCart.Count + "\nСрок резерва: " + reserveDate;
                if (isInStore)
                    message += "\nВы можете забрать заказ из магазина уже сейчас.";
                if (onlyInStock)
                    message += "\nВы можете забрать книги со склада " + stockGet;
                MessageBox.Show(message);
                booksInCart = new List<Books>();
                LoadPage.frameLoad.Navigate(new BooksList(booksInCart));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести заказ");
            }
        }
    }
}
