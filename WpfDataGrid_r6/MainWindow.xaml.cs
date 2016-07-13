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
using System.Diagnostics;
using System.ComponentModel;

namespace WpfGrid_r5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //DataGrid1.ItemsSource = Process.GetProcesses();
            /*
            //Create current process list
            Process[] processlist = Process.GetProcesses();
            //Create List of ProcessOptions
            List<ProcessOptions> items = new List<ProcessOptions>();
            foreach (Process theprocess in processlist)
            {
                items.Add(new ProcessOptions()
                {
                    ProcessName = theprocess.ProcessName,
                    Id = theprocess.Id,
                    PagedMemorySize = theprocess.PagedMemorySize
                });
            }
            DataGrid1.ItemsSource = items;
            */
            List<ProcessOptions> items = new List<ProcessOptions>();
            for (int i=0; i< 10000000; i++)
                items.Add(new ProcessOptions()
                {
                    ProcessName = "Hlam for filling" + " Number=" + i,
                    Id = Int32.Parse("1234567890"),
                    PagedMemorySize = Int32.Parse("1234567890")
                });
            DataGrid1.ItemsSource = items;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataGrid1.ItemsSource = Process.GetProcesses();
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid1.ItemsSource);
            view.Filter = UserFilter;
            CollectionViewSource.GetDefaultView(DataGrid1.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as ProcessOptions).ProcessName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


    }
    public class ProcessOptions
    {
        public string ProcessName { get; set; }

        public int Id { get; set; }

        public int PagedMemorySize { get; set; }
    }
}
