using JXK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JKX
{
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Window
    {
        private string TypeService = String.Empty;
        public Service(string Type)
        {
            InitializeComponent();
            TypeService = Type;
        }

        private void payButtonClick(object sender, RoutedEventArgs e)
        {
            string type = TypeService;
            if (String.IsNullOrWhiteSpace(iinTB.Text) || String.IsNullOrWhiteSpace(streetTB.Text) || String.IsNullOrWhiteSpace(houseNumTB.Text) || String.IsNullOrWhiteSpace(phoneNumTB.Text))
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }

            else if (String.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Выберите оплачиваемую услугу");
                return;
            }
            else if (StringToInt(flatNumTB.Text) == 0)
            {
                MessageBox.Show("Введен неверный номер квартиры (Нужно вводить только цифры)");
                return;
            }

            Bill bill = new Bill
            {
                IIN = iinTB.Text,
                Street = streetTB.Text,
                HouseNum = houseNumTB.Text,
                FlatNum = StringToInt(flatNumTB.Text),
                PhoneNum = phoneNumTB.Text,
                Sum = 200,
                Type = type
            };

            using (var context = new Context("Server=A-104-10;Database=CommunalPayment;Trusted_Connection=True;"))
            {
                context.Bills.Add(bill);
                context.SaveChanges();
            }
            MessageBox.Show("Успешно оплачено");
            this.Close();
        }

        private int StringToInt(string str)
        {
            try
            {
                int num = 0;
                Int32.TryParse(str, out num);
                return num;
            }
            catch
            {
                return 0;
            }
        }
    }
}
