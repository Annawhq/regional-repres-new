using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using RegRepresNew.View;

namespace RegRepresNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbContextOptions<ApplicationContext> options;
        // Коллекции сотрудников, областей, городов и областей сотрудников
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Region> regions = new ObservableCollection<Region>();
        ObservableCollection<Territory> territories = new ObservableCollection<Territory>();
        ObservableCollection<EmployeeTerritory> employeeTerritories = new ObservableCollection<EmployeeTerritory>();
        public MainWindow()
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
        }

        private async void btLoad_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarEmployee.Visibility = Visibility.Visible;
            employees.Clear();
            Task tc = Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var query = db.Employees;
                    if (query.Count() != 0)
                    {
                        foreach (var c in query)
                            employees.Add(c);
                    }
                }
            });
            await tc;

            await Task.Run(() => Thread.Sleep(200));

            ProgressBarEmployee.Visibility = Visibility.Collapsed;
            lvEmployee.ItemsSource = employees;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee();
            EmployeeView editEmployeeView = new EmployeeView();
            editEmployeeView.Title = "Добавление нового сотрудника";
            editEmployeeView.DataContext = newEmployee;
            editEmployeeView.ShowDialog();

            if (editEmployeeView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    try
                    {
                        db.Employees.Add(newEmployee);
                        db.SaveChanges();
                        employees.Add(newEmployee);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка добавления данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            Employee editEmployee = (Employee)lvEmployee.SelectedItem;

            EmployeeView editEmployeeView = new EmployeeView();
            editEmployeeView.Title = "Редактирование данных по клиенту";
            editEmployeeView.DataContext = editEmployee;
            editEmployeeView.ShowDialog();

            if (editEmployeeView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    Employee empl = db.Employees.Find(editEmployee.Id);
                    if (empl.Lastname != editEmployee.Lastname)
                        empl.Lastname = editEmployee.Lastname.Trim();
                    if (empl.Firstname != editEmployee.Firstname)
                        empl.Firstname = editEmployee.Firstname.Trim();
                    if (empl.Secondname != editEmployee.Secondname)
                        empl.Secondname = editEmployee.Secondname.Trim();
                    if (empl.Title != editEmployee.Title)
                        empl.Title = editEmployee.Title.Trim();
                    if (empl.Birthday != editEmployee.Birthday)
                        empl.Birthday = editEmployee.Birthday;
                    if (empl.Adress != editEmployee.Adress)
                        empl.Adress = editEmployee.Adress.Trim();
                    if (empl.City != editEmployee.City)
                        empl.City = editEmployee.City.Trim();
                    if (empl.Region != editEmployee.Region)
                        empl.Region = editEmployee.Region.Trim();
                    if (empl.Phone != editEmployee.Phone)
                        empl.Phone = editEmployee.Phone.Trim();
                    if (empl.Email != editEmployee.Email)
                        empl.Email = editEmployee.Email.Trim();
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка редактирования данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee delEmployee = (Employee)lvEmployee.SelectedItem;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                // Поиск в контексте удаляемого автомобиля
                Employee delEmp = db.Employees.Find(delEmployee.Id);

                if (delEmp != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные по сотруднику: \n" + delEmp.Lastname + "  " + delEmp.Firstname,
                  "Предупреждение", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        try
                        { 
                            db.Employees.Remove(delEmp);
                            db.SaveChanges();
                            employees.Remove(delEmployee);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("\nОшибка удаления данных!\n" + ex.Message, "Предупреждение");
                        }
                    }
                }
            }
        }

        private async void btLoadRegion_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarRegion.Visibility = Visibility.Visible;
            regions.Clear();
            Task tc = Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var query = db.Regions;
                    if (query.Count() != 0)
                    {
                        foreach (var c in query)
                            regions.Add(c);
                    }
                }
            });
            await tc;

            await Task.Run(() => Thread.Sleep(200));

            ProgressBarRegion.Visibility = Visibility.Collapsed;
            lvRegion.ItemsSource = regions;
        }

        private void btAddRegion_Click(object sender, RoutedEventArgs e)
        {
            Region newRegion = new Region();
            RegionView editRegionView = new RegionView();
            editRegionView.Title = "Добавление новой области";
            editRegionView.DataContext = newRegion;
            editRegionView.ShowDialog();

            if (editRegionView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    try
                    {
                        db.Regions.Add(newRegion);
                        db.SaveChanges();
                        regions.Add(newRegion);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка добавления данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btEditRegion_Click(object sender, RoutedEventArgs e)
        {
            Region editRegion = (Region)lvRegion.SelectedItem;

            RegionView editRegionView = new RegionView();
            editRegionView.Title = "Редактирование данных по области";
            editRegionView.DataContext = editRegion;
            editRegionView.ShowDialog();

            if (editRegionView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    Region reg = db.Regions.Find(editRegion.Id);
                    if (reg.Regiondiscription != editRegion.Regiondiscription)
                        reg.Regiondiscription = editRegion.Regiondiscription.Trim();
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка редактирования данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btDeleteRegion_Click(object sender, RoutedEventArgs e)
        {
            Region delRegion = (Region)lvRegion.SelectedItem;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                // Поиск в контексте удаляемого автомобиля
                Region delReg = db.Regions.Find(delRegion.Id);

                if (delReg != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные по области: \n" + delReg.Regiondiscription,
                  "Предупреждение", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Regions.Remove(delReg);
                            db.SaveChanges();
                            regions.Remove(delRegion);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("\nОшибка удаления данных!\n" + ex.Message, "Предупреждение");
                        }
                    }
                }
            }
        }

        private async void btLoadTerritory_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarTerritory.Visibility = Visibility.Visible;

            Task tc = Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var query = db.Territories
                    .Include(c => c.Region);
                    if (query.Count() != 0)
                    {
                        foreach (var o in query)
                            territories.Add(o);
                    }
                }
            });

            await tc;

            await Task.Run(() => Thread.Sleep(200));

            ProgressBarTerritory.Visibility = Visibility.Collapsed;
            lvTerritory.ItemsSource = territories;
        }

        private void btAddTerritory_Click(object sender, RoutedEventArgs e)
        {
            Territory newTerritory = new Territory();
            TerritoryView editnewTerritoryView = new TerritoryView();
            editnewTerritoryView.Title = "Добавление нового города";
            editnewTerritoryView.DataContext = newTerritory;
            editnewTerritoryView.ShowDialog();

            if (editnewTerritoryView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    try
                    {
                        db.Territories.Add(newTerritory);
                        db.SaveChanges();
                        territories.Add(newTerritory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка добавления данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btEditTerritory_Click(object sender, RoutedEventArgs e)
        {
            Territory editTerritory = (Territory)lvTerritory.SelectedItem;

            TerritoryView editTerritoryView = new TerritoryView();
            editTerritoryView.Title = "Редактирование данных по городу";
            editTerritoryView.DataContext = editTerritory;
            editTerritoryView.ShowDialog();

            if (editTerritoryView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    Territory ter = db.Territories.Find(editTerritory.Id);
                    if (ter.RegionId != editTerritory.RegionId)
                        ter.RegionId = editTerritory.RegionId;
                    if (ter.Discription != editTerritory.Discription)
                        ter.Discription = editTerritory.Discription;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка редактирования данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btDeleteTerritory_Click(object sender, RoutedEventArgs e)
        {
            Territory delTerritory = (Territory)lvTerritory.SelectedItem;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                // Поиск в контексте удаляемого автомобиля
                Territory delTer = db.Territories.Find(delTerritory.Id);

                if (delTer != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные по городу: \n" + delTer.Discription,
                  "Предупреждение", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.Territories.Remove(delTer);
                            db.SaveChanges();
                            territories.Remove(delTerritory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("\nОшибка удаления данных!\n" + ex.Message, "Предупреждение");
                        }
                    }
                }
            }
        }

        private async void btLoadEmpTer_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarEmpTer.Visibility = Visibility.Visible;

            Task tc = Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var query = db.EmployeeTerritories
                    .Include(c => c.Employee)
                    .Include(c => c.Territory);
                    if (query.Count() != 0)
                    {
                        foreach (var o in query)
                            employeeTerritories.Add(o);
                    }
                }
            });

            await tc;

            await Task.Run(() => Thread.Sleep(200));

            ProgressBarEmpTer.Visibility = Visibility.Collapsed;
            lvEmpTer.ItemsSource = employeeTerritories;
        }

        private void btAddEmpTer_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTerritory newEmployeeTerritory = new EmployeeTerritory();
            EmployeeTerritoryView editEmpTerritoryView = new EmployeeTerritoryView();
            editEmpTerritoryView.Title = "Добавление новой области сотрудника";
            editEmpTerritoryView.DataContext = newEmployeeTerritory;
            editEmpTerritoryView.ShowDialog();

            if (editEmpTerritoryView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    try
                    {
                        db.EmployeeTerritories.Add(newEmployeeTerritory);
                        db.SaveChanges();
                        employeeTerritories.Add(newEmployeeTerritory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка добавления данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btEditEmpTer_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTerritory editEmployeeTerritory = (EmployeeTerritory)lvEmpTer.SelectedItem;

            EmployeeTerritoryView editEmpTerritoryView = new EmployeeTerritoryView();
            editEmpTerritoryView.Title = "Редактирование данных по области сотрудника";
            editEmpTerritoryView.DataContext = editEmployeeTerritory;
            editEmpTerritoryView.ShowDialog();

            if (editEmpTerritoryView.DialogResult == true)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    EmployeeTerritory empter = db.EmployeeTerritories.Find(editEmployeeTerritory.Id);
                    if (empter.EmployeeId != editEmployeeTerritory.EmployeeId)
                        empter.EmployeeId = editEmployeeTerritory.EmployeeId;
                    if (empter.TerritoryId != editEmployeeTerritory.TerritoryId)
                        empter.TerritoryId = editEmployeeTerritory.TerritoryId;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("\nОшибка редактирования данных!\n" + ex.Message, "Предупреждение");
                    }
                }
            }
        }

        private void btDeleteEmpTer_Click(object sender, RoutedEventArgs e)
        {
            EmployeeTerritory delEmpTerritory = (EmployeeTerritory)lvEmpTer.SelectedItem;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                // Поиск в контексте удаляемого автомобиля
                EmployeeTerritory delEmpTer = db.EmployeeTerritories.Find(delEmpTerritory.Id);

                if (delEmpTer != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные по области сотрдуника: \n" + delEmpTer.EmployeeId,
                  "Предупреждение", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        try
                        {
                            db.EmployeeTerritories.Remove(delEmpTer);
                            db.SaveChanges();
                            employeeTerritories.Remove(delEmpTerritory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("\nОшибка удаления данных!\n" + ex.Message, "Предупреждение");
                        }
                    }
                }
            }
        }
    }
}
