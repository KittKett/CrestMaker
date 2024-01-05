using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace CrestMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string newImageId;
        string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = "/CrestMaker/Outputs/Images";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateCrest_Click(object sender, RoutedEventArgs e)
        {
            ImageProcessor processor = new ImageProcessor();
            FileUtils fileUtils = new FileUtils();

            newImageId = Guid.NewGuid().ToString();

            fileUtils.SetupOutputDirectory(documentsFolderPath + path);

            processor.GenerateCrestImage(documentsFolderPath + path, newImageId);
            imgTest.Source = processor.RetrieveCrestImage(documentsFolderPath + path, newImageId);
        }

        //Properties


        //Functions
        


    }
}