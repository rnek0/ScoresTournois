using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace ScoresTournoisAzertyClub
{

    public class Tournoi :Window, INotifyPropertyChanged
    {
        // Nom Equipe 2 ------------------------------------------------------------------------------------------------
        public string equipe2
        {
            get { return (string)GetValue(equipe2Property); }
            set
            {
                SetValue(equipe2Property, value);
                OnPropertyChanged("equipe2");
            }
        }

        // Using a DependencyProperty as the backing store for equipe2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty equipe2Property =
            DependencyProperty.Register("equipe2", typeof(string), typeof(Tournoi), new UIPropertyMetadata("Equipe 2"));

        // Nom Equipe 1 ------------------------------------------------------------------------------------------------
        public string equipe1
        {
            get { return (string)GetValue(equipe1Property); }
            set { SetValue(equipe1Property, value);
            OnPropertyChanged("equipe1");
            }
        }
        // Using a DependencyProperty as the backing store for equipe1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty equipe1Property =
            DependencyProperty.Register("equipe1", typeof(string), typeof(Tournoi), new UIPropertyMetadata("Equipe 1"));

        //Nom du Tournoi ------------------------------------------------------------------------------------------------
        public string leTournoi
        {
            get 
            { 
                return (string)GetValue(leTournoiProperty); 
            }
            set 
            { 
                SetValue(leTournoiProperty, value);
                OnPropertyChanged("leTournoi");
            }
        }
        // Using a DependencyProperty as the backing store for leTournoi.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty leTournoiProperty =
            DependencyProperty.Register("leTournoi", typeof(string), typeof(Tournoi), new UIPropertyMetadata("Tournoi"));

        //Image de fond ------------------------------------------------------------------------------------------------
        public string imgBackGround
        {
            get { return (string)GetValue(imgBackGroundProperty); }
            set { SetValue(imgBackGroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for imgBackGround.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty imgBackGroundProperty =
            DependencyProperty.Register("imgBackGround", typeof(string), typeof(Tournoi), new UIPropertyMetadata(""));



        public bool couleurRB
        {
            get { return (bool)GetValue(couleurRBProperty); }
            set { SetValue(couleurRBProperty, value); }
        }

        // Using a DependencyProperty as the backing store for couleurRB.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty couleurRBProperty =
            DependencyProperty.Register("couleurRB", typeof(bool), typeof(Tournoi), new UIPropertyMetadata());

        

        //
        public Tournoi()
        {
        }

        public Tournoi(string Tournoi, string lequipe1, string lequipe2, string imgBack, bool couleur)
        {
            leTournoi = Tournoi;
            equipe1 = lequipe1;
            equipe2 = lequipe2;
            imgBackGround = imgBack;
            if (couleur == true)
            {
                couleurRB = true;
            }
            else
            {
                couleurRB = false;
            }
        }

        //
        public override string ToString()
        {
            return "Tournoi :" + leTournoi + " , equipe 1 :" + equipe1 + " , equipe 2 :" + equipe2 + " , image : " + imgBackGround;
        }

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

    }
}
