using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RegRepresNew.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeeTerritoryView.xaml
    /// </summary>
    public partial class EmployeeTerritoryView : Window
    {
        public List<Employee> ListEmployee;
        public List<Territory> ListTerritory;
        DbContextOptions<ApplicationContext> options;
        public EmployeeTerritoryView()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                ListEmployee = db.Employees.ToList<Employee>();
                ListTerritory = db.Territories.ToList<Territory>();
            }
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btConcel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
