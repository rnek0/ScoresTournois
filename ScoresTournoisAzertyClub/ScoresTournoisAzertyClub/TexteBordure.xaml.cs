using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Globalization;

namespace ScoresTournoisAzertyClub
{
    /// <summary>
    /// Logique d'interaction pour TexteBordure.xaml
    /// </summary>
    public partial class TexteBordure : UserControl
    {
        //String Affichée avec la mise en forme
        public string TexteAvecBordure
        {
            get { return (string)GetValue(TexteAvecBordureProperty); }
            set { 
                SetValue(TexteAvecBordureProperty, value);
                DisplayText1(value, 0.0, 50.0);
            }
        }

        // Using a DependencyProperty as the backing store for TexteAvecBordure.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TexteAvecBordureProperty =
            DependencyProperty.Register("TexteAvecBordure", typeof(string), typeof(TexteBordure), new UIPropertyMetadata());
              
        //Constructeur
        public TexteBordure()
        {
            InitializeComponent();
            TexteAvecBordure = "";
            path.Style = (Style)(this.Resources["MonStyleRouge"]);
        }

        // Affiche la string avec la mise en forme demandée
        public void DisplayText1(string textToDisplay, double largeurEcran, double hauteurEcran)
        {
            // Creation de formatted text string.
            FormattedText formattedText1 = new FormattedText(
                textToDisplay, CultureInfo.GetCultureInfo("fr-FR"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                100,
                System.Windows.Media.Brushes.AliceBlue);

            // Met sur Bold le formatted text.
            formattedText1.SetFontWeight(FontWeights.Bold);

            // Construit la geometry du contour du formatted text.
            Geometry geometry = formattedText1.BuildGeometry(new System.Windows.Point(largeurEcran, hauteurEcran));

            // Create a set of polygons by flattening the Geometry object.
            PathGeometry pathGeometry = geometry.GetFlattenedPathGeometry();

            // Supply the empty Path element in XAML with the PathGeometry in order to render the polygons.
            path.Data = pathGeometry;
        }

    }
}
