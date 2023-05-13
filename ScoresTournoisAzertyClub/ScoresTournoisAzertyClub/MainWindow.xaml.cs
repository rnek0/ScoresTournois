/* 
 * Application compteur de points pour les LANS Party de l'AzertyClub. http://www.azertyclub.com 
 * Auteur : Argo.
 * Date : 23/10/2010
 */

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
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;
using System.ComponentModel;

namespace ScoresTournoisAzertyClub
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //Construction de l'objet Tournoi avec les strings
        //*************************************************
        Tournoi ceTournoi = new Tournoi("Tournoi", "Equipe 1", "Equipe 2", "starcraft2.jpg", true);

#region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
#endregion

        public MainWindow()
        {
            InitializeComponent();

            //Set de la Source de l'image avec le nom d'image 
            //*************************************************
            this.fond.Source = ((ImageSource)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(ImageSource)).ConvertFromInvariantString(@"starcraft2.jpg")));

            //Binding du label lblTournoi sur la classe Tournoi
            //*************************************************
            Binding bdNomTournoi = new Binding("leTournoi");
            bdNomTournoi.Source = this.ceTournoi;
            lblTournoi.SetBinding(Label.ContentProperty, bdNomTournoi);
            //Appel de la prop de notre UserControl
            TexteTournoi.TexteAvecBordure = lblTournoi.Content.ToString();
            TexteTournoi.path.Style = (Style)(TexteEquipe1.Resources["MonStyleJaune"]);
            
            //Binding du label lblEquipe1 sur la classe Tournoi
            //*************************************************
            Binding bdNomEquipe1 = new Binding("equipe1");
            bdNomEquipe1.Source = this.ceTournoi;
            lblEquipe1.SetBinding(Label.ContentProperty, bdNomEquipe1);
            //Appel de la prop de notre UserControl
            TexteEquipe1.TexteAvecBordure = lblEquipe1.Content.ToString();            
            
            //Binding du label lblEquipe2 sur la classe Tournoi
            //*************************************************
            Binding bdNomEquipe2 = new Binding("equipe2");
            bdNomEquipe2.Source = this.ceTournoi;
            lblEquipe2.SetBinding(Label.ContentProperty, bdNomEquipe2);
            //Appel de la prop de notre UserControl
            TexteEquipe2.TexteAvecBordure = lblEquipe2.Content.ToString();            

            //Binding sur imgBackGround de notre classe Tournoi
            //*************************************************
            Binding bdImgFond = new Binding("imgBackGround");
            bdImgFond.Source = this.ceTournoi;
            this.ChaineImage.SetBinding(Label.ContentProperty, bdImgFond);

            //Scores
            //******
            ScoreEquipe1.TexteAvecBordure = label2.Content.ToString();            
            ScoreEquipe2.TexteAvecBordure = label1.Content.ToString();

            //Binding sur couleurRB de notre classe Tournoi
            //*************************************************
            Binding bdRB = new Binding("couleurRB");
            bdRB.Source = this.ceTournoi;
            this.ChaineRB.SetBinding(Label.ContentProperty, bdRB);

            //Couleurs au départ
            //******************
            TexteEquipe1.path.Style = (Style)(TexteEquipe1.Resources["MonStyleRouge"]);
            ScoreEquipe1.path.Style = (Style)(ScoreEquipe1.Resources["MonStyleRouge"]);
            TexteEquipe2.path.Style = (Style)(TexteEquipe2.Resources["MonStyleBleu"]);
            ScoreEquipe2.path.Style = (Style)(ScoreEquipe2.Resources["MonStyleBleu"]);        

            /* Se produit lors de la mise a jour du label Tournoi via le menu config   */
            DependencyPropertyDescriptor proplblTournoi = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            proplblTournoi.AddValueChanged(this.lblTournoi, tournoi_changed);

            /* Se produit lors de la mise a jour du label Equipe1 via le menu config   */
            DependencyPropertyDescriptor proplblEquipe1 = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            proplblTournoi.AddValueChanged(this.lblEquipe1, Equipe1_changed);

            /* Se produit lors de la mise a jour du label Equipe2 via le menu config   */
            DependencyPropertyDescriptor proplblEquipe2 = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            proplblTournoi.AddValueChanged(this.lblEquipe2, Equipe2_changed);

            /* Se produit lors de la mise a jour du label pour l'image via le menu config  */
            DependencyPropertyDescriptor proplblImgBack = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            proplblImgBack.AddValueChanged(this.ChaineImage, ImgBack_changed);

            /* Se produit lors de la mise a jour du label pour l'image via le menu config  */
            DependencyPropertyDescriptor proplblRB = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            proplblRB.AddValueChanged(this.ChaineRB, ChaineRB_changed);
            
        }

        //Au changement de string Tournoi
        //********************************
        public void tournoi_changed(object sender, EventArgs e)
        {   
            //Affiche le texte du Tournoi avec la bordure
            TexteTournoi.TexteAvecBordure = lblTournoi.Content.ToString();
        }

        //Au changement de string Equipe 1
        //********************************
        public void Equipe1_changed(object sender, EventArgs e)
        {
            //Affiche le texte de l'equipe 1 avec la bordure
            TexteEquipe1.TexteAvecBordure = lblEquipe1.Content.ToString();
        }

        //Au changement de string Equipe 2
        //********************************
        public void Equipe2_changed(object sender, EventArgs e)
        {
            //Affiche le texte de l'equipe 2 avec la bordure
            TexteEquipe2.TexteAvecBordure = lblEquipe2.Content.ToString();
        }

        //Au changement de l'image de fond
        //********************************
        public void ImgBack_changed(object sender, EventArgs e)
        {
            //Change la source de l'image
            string img = this.ChaineImage.Content.ToString();
            this.fond.Source = ((ImageSource)(System.ComponentModel.TypeDescriptor.GetConverter(typeof(ImageSource)).ConvertFromString(img)));            
        }

        //Au changement de l'image de fond
        //********************************
        public void ChaineRB_changed(object sender, EventArgs e)
        {
            //Choix des couleurs
            //******************
            if (this.ChaineRB.Content.ToString() == "True")
            {
                TexteEquipe1.path.Style = (Style)(TexteEquipe1.Resources["MonStyleRouge"]);
                ScoreEquipe1.path.Style = (Style)(ScoreEquipe1.Resources["MonStyleRouge"]);
                TexteEquipe2.path.Style = (Style)(TexteEquipe2.Resources["MonStyleBleu"]);
                ScoreEquipe2.path.Style = (Style)(ScoreEquipe2.Resources["MonStyleBleu"]);
            }
            else
            {
                TexteEquipe1.path.Style = (Style)(TexteEquipe1.Resources["MonStyleBleu"]);
                ScoreEquipe1.path.Style = (Style)(ScoreEquipe1.Resources["MonStyleBleu"]);
                TexteEquipe2.path.Style = (Style)(TexteEquipe2.Resources["MonStyleRouge"]);
                ScoreEquipe2.path.Style = (Style)(ScoreEquipe2.Resources["MonStyleRouge"]);
            }
        }

        //Recupere la touche clavier
        //**************************
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Fenetre du menu
            var menuConfig = new Menu(ceTournoi);
            switch (e.Key)
            {
                // Incremente le score du joueur a gauche
                case Key.A:
                        int nombre;
                        if (int.TryParse(label2.Content.ToString(), out nombre))
                            {
                                // code si conversion OK
                                nombre++;
                            }
                        else
                            {
                                // code si conversion KO
                            }

                        label2.Content = nombre.ToString();
                        ScoreEquipe1.TexteAvecBordure = label2.Content.ToString();
                        
                    break;
                // Décremente le score du joueur a gauche
                case Key.Q:
                        int nombreMoins;
                        if (int.TryParse(label2.Content.ToString(), out nombreMoins))
                            {
                                // code si conversion OK
                                nombreMoins--;
                            }
                        else
                            {
                                // code si conversion KO
                            }

                         label2.Content = nombreMoins.ToString();
                         ScoreEquipe1.TexteAvecBordure = label2.Content.ToString();
                         
                    break;
                /* Incremente le score du joueur a droite  */                
                case Key.P:
                    int nombre2;
                        if (int.TryParse(label1.Content.ToString(), out nombre2))
                            {
                                // code si conversion OK
                                nombre2++;
                            }
                        else
                            {
                                // code si conversion KO
                            }
                                
                        label1.Content = nombre2.ToString();
                        ScoreEquipe2.TexteAvecBordure = label1.Content.ToString();
                    break;
                // Décremente le score du joueur a droite
                case Key.M:
                        int nombre2Moins;
                        if (int.TryParse(label1.Content.ToString(), out nombre2Moins))
                            {
                                // code si conversion OK
                                nombre2Moins--;
                            }
                        else
                            {
                                // code si conversion KO
                            }

                        label1.Content = nombre2Moins.ToString();
                        ScoreEquipe2.TexteAvecBordure = label1.Content.ToString();
                    break;
                //Plein Ecran
                case Key.F:
                        if (this.WindowState == System.Windows.WindowState.Normal)
                        {
                            this.WindowState = System.Windows.WindowState.Maximized;
                        }
                    break;
                // Ouvre le Menu config
                case Key.Enter:   
                        ScoreEquipe1.TexteAvecBordure = "0";            
                        ScoreEquipe2.TexteAvecBordure = "0";
                        label1.Content = "0";
                        label2.Content = "0";
                        menuConfig.Show();
                    break;
                // Ouvre le Menu config
                case Key.Space:
                        ScoreEquipe1.TexteAvecBordure = "0";            
                        ScoreEquipe2.TexteAvecBordure = "0";
                        label1.Content = "0";
                        label2.Content = "0";
                        menuConfig.Show();
                    break;
                // Oeuf de paques ;)
                case Key.F1:
                        MessageBox.Show("Aide: voir Argo sur http://www.azertyclub.com.");
                    break;
                //Ferme l'appli
                case Key.Escape:
                        MessageBoxResult msg = MessageBox.Show(
                        "Confirmation de la fermeture ?",
                        "Confirmation",
                        MessageBoxButton.YesNo);
                        if (msg == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    break;
                default:
                    break;
            }

        }
    }
}
