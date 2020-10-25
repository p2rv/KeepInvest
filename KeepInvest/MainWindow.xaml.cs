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

namespace KeepInvest
{
    public interface IDialogService
    {
        string FilePath { get; set; }   
        string Message { get; set; }
        bool OpenFileDialog();  // открытие файла
        bool SaveFileDialog();  // сохранение файла
    }

    public class DefaultDialogService : IDialogService
    {
        public DefaultDialogService()
        {
            Message = "Choose file from tinkoff";
        }

        public string FilePath { get; set; }
        public string Message { get; set; }

        public bool OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dlgOpen = new Microsoft.Win32.OpenFileDialog();
            dlgOpen.Title = Message;
            dlgOpen.DefaultExt = ".xls";
            dlgOpen.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| All files|*.*";
            if (dlgOpen.ShowDialog() == true)
            {
                FilePath = dlgOpen.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            return false;
        }
    }

        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
    {
        public string FilePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new FileService());
        }

       
    }
}
