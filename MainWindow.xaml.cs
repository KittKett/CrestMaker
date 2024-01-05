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

        private void btnCreateCrest_Click(object sender, RoutedEventArgs e)
        {
            //make temp lists to choose from
            List<string> chooseYourColors = colors;
            List<string> chooseYourSymbol = symbols;
            List<string> chooseYourPattern = patterns;

            //make your selections
            string crestPrimaryColor = giveMeSomethingToWorkWith(chooseYourColors);
            chooseYourColors.Remove(crestPrimaryColor);
            string crestSecondaryColor = giveMeSomethingToWorkWith(chooseYourColors);
            string crestSymbol = giveMeSomethingToWorkWith(chooseYourSymbol);
            string crestPattern = giveMeSomethingToWorkWith(chooseYourPattern);


            //text output
            output = "Your crest will be mostly " + crestPrimaryColor + " with accents of " + crestSecondaryColor +
                ".  It will proudly feature the symbol of the " + crestSymbol + " and be surrounded by " +
                "a background of " + crestPattern + ".";

            txtResponse.Text = output;
        }


        /// <summary>
        /// Returns a random list item as a string using provided list "choices"
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        private string giveMeSomethingToWorkWith(List<string> choices)
        {
            Random rand = new Random();
            int randomInt = rand.Next(choices.Count);

            return choices[randomInt];
        }



        #region PROPERTIES

        string output;
        
        List<string> colors = new List<string>
        {
            "Blue",
            "Red",
            "Green",
            "Black",
            "White",
            "Purple",
            "Orange",
            "Yellow",
            "Gold",
            "Silver",
            "Mauve",
            "Grey",
            "Maroon",
            "Navy",
            "Mustard"
        };

        List<string> symbols = new List<string>
        {
            "Lion",
            "Bear",
            "Snake",
            "Squirrel",
            "Griffin",
            "Dragon",
            "Rose",
            "Crown",
            "Cross",
            "Bumblebee",
            "Warthog",
            "Maiden",
            "Sword",
            "Stars",
            "Sun",
            "Waves",
            "Wings"
        };


        List<string> patterns = new List<string>
        {
            "Stars",
            "Fluer-des-lis",
            "Sunrays",
            "Waterdrops",
            "Diagonal Stripes",
            "Stitching",
            "Dots",
            "Horizontal Stripes",
            "Vertical Stripes",
            "Hatchwork"
        };

        #endregion

    }
}