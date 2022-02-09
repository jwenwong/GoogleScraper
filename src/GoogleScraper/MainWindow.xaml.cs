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

namespace GoogleScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchService searchService;
        public MainWindow()
        {
            InitializeComponent();
            searchService = new SearchService();
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await searchService.Search(textBox_SearchQuery.Text);
            this.Height = 150;
        }
    }
}
