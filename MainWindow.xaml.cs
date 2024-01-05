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

namespace CrestMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Properties

        List<string> colors = new List<string> { "Blue", "Red", "Green", "Black", "White", "Purple", "Orange", "Yellow"};

        string output;


        //Functions
        private void btnCreateCrest_Click(object sender, RoutedEventArgs e)
        {
            //picking your colors
            List<string> chooseColors = colors;
            Random rand = new Random();
            int randomInt = rand.Next(chooseColors.Count);
            string crestPrimaryColor = chooseColors[randomInt];
            chooseColors.RemoveAt(randomInt);
            randomInt = rand.Next(chooseColors.Count);
            string crestSecondaryColor = chooseColors[randomInt];
            colors.RemoveAt(randomInt);

            

            //text output
            output = "Your crest will be " + crestPrimaryColor + " and " + crestSecondaryColor +  ".";
            txtResponse.Text = output;
        }

    }
}