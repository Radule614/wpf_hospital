﻿using Controller;
using Model;
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
using ZdravoCorpAppTim22.Controller;
using ZdravoCorpAppTim22.View.DoctorView;
using ZdravoCorpAppTim22.View.Manager;
using ZdravoCorpAppTim22.View.PatientView;
using ZdravoCorpAppTim22.View.Secretary;

namespace ZdravoCorpAppTim22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Doc { get; private set; }

        public MainWindow()
        {
            var ac = AddressController.Instance.GetAll();
            var rc = RoomController.Instance.GetAllRooms();
            var sc = SecretaryController.Instance.GetAll();
            var mc = ManagerController.Instance.GetAll();
            var pc = PatientController.Instance.GetAll();
            var doctor = DoctorController.Instance.GetAll();    
            var ec = EquipmentController.Instance.GetAllEquipment();
            var mm = MedicalAppointmentController.Instance.getAll();



            InitializeComponent();
        }

        private void ManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            ManagerHome managerHome = new ManagerHome();
            managerHome.Show();
            this.Close();
        }



        private void SecretaryBtn_Click(object sender, RoutedEventArgs e)
        {

            SecretaryHome secretaryHome = new SecretaryHome(this);
            secretaryHome.Show();
            this.Hide();
        }

        private void DoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            DoctorHome doctorHome = new DoctorHome();
            doctorHome.Show();
            this.Close();

        }

        private void PatientBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientSelectionForTemporaryPurpose patientSelectionForTemporaryPurpose = new PatientSelectionForTemporaryPurpose();
            patientSelectionForTemporaryPurpose.Show();
            this.Close();
        }
    }
}
