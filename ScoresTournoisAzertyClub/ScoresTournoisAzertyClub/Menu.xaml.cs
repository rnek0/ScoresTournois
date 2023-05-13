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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace ScoresTournoisAzertyClub
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Tournoi leTournoi;
        //public Label score1;
        //public Label score2;
        private string fichierBackGround = string.Empty;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Tournoi leTournoiParam)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.leTournoi = leTournoiParam;

            //
            tbNomTournoi.Text   = leTournoi.leTournoi;
            tbNomEquipe1.Text   = leTournoi.equipe1;
            tbNomEquipe2.Text   = leTournoi.equipe2;
            label5.Content      = leTournoi.imgBackGround;
            if (leTournoiParam.couleurRB == true)
            {
                radioButton2.IsChecked = true;
            }
            else
            {
                radioButton1.IsChecked = true;
            }
        }

        private void valideConfig(object sender, RoutedEventArgs e)
        {
            leTournoi.leTournoi     = tbNomTournoi.Text;
            leTournoi.equipe1       = tbNomEquipe1.Text;
            leTournoi.equipe2       = tbNomEquipe2.Text;
            leTournoi.imgBackGround = label5.Content.ToString();
            //Si choix rouge / bleu
            if (radioButton2.IsChecked == true)
            {
                leTournoi.couleurRB = true;
            }
            else
            {
                leTournoi.couleurRB = false;
            }

            this.Close();
        }
        //Choisit l'image de fond
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            { 
                fichierBackGround = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\"));
                fichierBackGround = fichierBackGround.Replace("\\","");
                //MessageBox.Show("fichier :" + fichierBackGround);
                label5.Content = fichierBackGround;
            }
        }
    }
}
