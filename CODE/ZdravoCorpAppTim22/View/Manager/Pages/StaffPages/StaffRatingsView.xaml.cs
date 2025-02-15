﻿using Model;
using System.Windows.Controls;
using ZdravoCorpAppTim22.View.Manager.ViewModels.StaffViewModels;
using ZdravoCorpAppTim22.View.Manager.Views;

namespace ZdravoCorpAppTim22.View.Manager.Pages.StaffPages
{
    public partial class StaffRatingsView : Page
    {
        readonly StaffRatingsViewModel ViewModel;
        public StaffRatingsView(Doctor doctor)
        {
            InitializeComponent();
            ViewModel = new StaffRatingsViewModel(doctor);
            DataContext = ViewModel;

            Kindness.Content = new GradesBlock((string)FindResource("Manager_Kindness"), ViewModel.KindnessGrades);
            Expertise.Content = new GradesBlock((string)FindResource("Manager_Expertise"), ViewModel.ExpertiseGrades);
            Discretion.Content = new GradesBlock((string)FindResource("Manager_Discretion"), ViewModel.DiscretionGrades);
            
        }
    }
}
