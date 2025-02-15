﻿using Controller;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoCorpAppTim22.Controller;
using ZdravoCorpAppTim22.Model;

namespace ZdravoCorpAppTim22.View.Secretary
{
    public partial class SecretaryAccountsEdit : Window
    {
        private SecretaryAccounts callerScreen;

        /// <summary>
        /// 0. Patient, 1. Manager, 2.Secretary, 3. Doctor
        /// </summary>
        private int currentAccount;

        private Patient Patient;
        private ManagerClass Manager;
        private SecretaryClass Secretary;
        private Doctor Doctor;

        public SecretaryAccountsEdit(SecretaryAccounts callerScreen, Patient patient)
        {
            InitializeComponent();
            this.callerScreen = callerScreen;
            this.Show();
            Patient = patient;
            currentAccount = 0;
            FillData();
        }

        public SecretaryAccountsEdit(SecretaryAccounts callerScreen, ManagerClass manager)
        {
            InitializeComponent();
            this.callerScreen = callerScreen;
            this.Show();
            Manager = manager;
            currentAccount = 1;
            FillData();
        }

        public SecretaryAccountsEdit(SecretaryAccounts callerScreen, SecretaryClass secretary)
        {
            InitializeComponent();
            this.callerScreen = callerScreen;
            this.Show();
            Secretary = secretary;
            currentAccount = 2;
            FillData();
        }

        public SecretaryAccountsEdit(SecretaryAccounts callerScreen, Doctor doctor)
        {
            InitializeComponent();
            this.callerScreen = callerScreen;
            this.Show();
            Doctor = doctor;
            currentAccount = 3;
            FillData();
        }

        public void SetSpecialisationComboBox(Visibility visible)
        {
            if (SpecialisationComboBox != null && SpecialisationLbl != null)
            {
                if (visible == Visibility.Visible)
                {
                    SpecialisationComboBox.ItemsSource = DoctorSpecializationController.Instance.GetAll();
                }
                SpecialisationComboBox.Visibility = visible;
                SpecialisationLbl.Visibility = visible;

            }
        }

        public void SetMedicalReportButton(Visibility visible)
        {
            if (MedicalRecordBtn != null)
            {
                MedicalRecordBtn.Visibility = visible;
            }
        }

        public void FillData()
        {
            while (!this._contentLoaded)
            {

            }

            switch (currentAccount)
            {
                //Patient
                case 0:
                    NameTextBox.Text = Patient.Name;
                    SurnameTextBox.Text = Patient.Surname;
                    if (Patient.Address != null)
                    {
                        AddressTextBox.Text = Patient.Address.ToString();
                    }
                    PhoneTextBox.Text = Patient.Phone;
                    BirthDayPicker.SelectedDate = Patient.Birthday;
                    JMBGTextBox.Text = Patient.Jmbg;
                    EMailTextBox.Text = Patient.Email;
                    PasswordTextBox.Password = Patient.Password;
                    switch (Patient.Gender)
                    {
                        case Gender.male:
                            MaleRB.IsChecked = true;
                            break;
                        case Gender.female:
                            FemaleRB.IsChecked = true;
                            break;
                        default:
                            OtherRB.IsChecked = true;
                            break;
                    }
                    SetSpecialisationComboBox(Visibility.Hidden);
                    SetMedicalReportButton(Visibility.Visible);
                    break;
                //Manager
                case 1:
                    NameTextBox.Text = Manager.Name;
                    SurnameTextBox.Text = Manager.Surname;
                    if (Manager.Address != null)
                    {
                        AddressTextBox.Text = Manager.Address.ToString();
                    }
                    PhoneTextBox.Text = Manager.Phone;
                    BirthDayPicker.SelectedDate = Manager.Birthday;
                    JMBGTextBox.Text = Manager.Jmbg;
                    EMailTextBox.Text = Manager.Email;
                    PasswordTextBox.Password = Manager.Password;
                    switch (Manager.Gender)
                    {
                        case Gender.male:
                            MaleRB.IsChecked = true;
                            break;
                        case Gender.female:
                            FemaleRB.IsChecked = true;
                            break;
                        default:
                            OtherRB.IsChecked = true;
                            break;
                    }
                    SetSpecialisationComboBox(Visibility.Hidden);
                    SetMedicalReportButton(Visibility.Hidden);
                    break;
                //Secretary
                case 2:
                    NameTextBox.Text = Secretary.Name;
                    SurnameTextBox.Text = Secretary.Surname;
                    if (Secretary.Address != null)
                    {
                        AddressTextBox.Text = Secretary.Address.ToString();
                    }
                    PhoneTextBox.Text = Secretary.Phone;
                    BirthDayPicker.SelectedDate = Secretary.Birthday;
                    JMBGTextBox.Text = Secretary.Jmbg;
                    EMailTextBox.Text = Secretary.Email;
                    PasswordTextBox.Password = Secretary.Password;
                    switch (Secretary.Gender)
                    {
                        case Gender.male:
                            MaleRB.IsChecked = true;
                            break;
                        case Gender.female:
                            FemaleRB.IsChecked = true;
                            break;
                        default:
                            OtherRB.IsChecked = true;
                            break;
                    }
                    SetSpecialisationComboBox(Visibility.Hidden);
                    SetMedicalReportButton(Visibility.Hidden);
                    break;
                //Doctor
                case 3:
                    NameTextBox.Text = Doctor.Name;
                    SurnameTextBox.Text = Doctor.Surname;
                    if (Doctor.Address != null)
                    {
                        AddressTextBox.Text = Doctor.Address.ToString();
                    }
                    PhoneTextBox.Text = Doctor.Phone;
                    BirthDayPicker.SelectedDate = Doctor.Birthday;
                    JMBGTextBox.Text = Doctor.Jmbg;
                    EMailTextBox.Text = Doctor.Email;
                    PasswordTextBox.Password = Doctor.Password;
                    switch (Doctor.Gender)
                    {
                        case Gender.male:
                            MaleRB.IsChecked = true;
                            break;
                        case Gender.female:
                            FemaleRB.IsChecked = true;
                            break;
                        default:
                            OtherRB.IsChecked = true;
                            break;
                    }
                    SetSpecialisationComboBox(Visibility.Visible);
                    SetMedicalReportButton(Visibility.Hidden);
                    SpecialisationComboBox.SelectedItem = Doctor.DoctorSpecialization;
                    break;


                default:
                    MessageBox.Show("Something is wrong!");
                    break;
            }

        }



        private void Window_Closed_1(object sender, System.EventArgs e)
        {
            callerScreen.Show();
        }

        private void PhoneTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void JMBGTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EMailTextBox.Text == "")
            {
                MessageBox.Show("Must enter unique email");
            }
            else
            {
                ObservableCollection<Patient> patients = new ObservableCollection<Patient>(PatientController.Instance.GetAll());
                for (int i = 0; i < patients.Count; i++)
                {
                    if (EMailTextBox.Text == patients[i].Email && patients[i] != Patient)
                    {
                        MessageBox.Show("Must enter unique email");
                        return;
                    }
                }
                ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>(DoctorController.Instance.GetAll());
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (EMailTextBox.Text == doctors[i].Email && doctors[i] != Doctor)
                    {
                        MessageBox.Show("Must enter unique email");
                        return;
                    }
                }
                ObservableCollection<ManagerClass> managers = new ObservableCollection<ManagerClass>(ManagerController.Instance.GetAll());
                for (int i = 0; i < managers.Count; i++)
                {
                    if (EMailTextBox.Text == managers[i].Email && managers[i] != Manager)
                    {
                        MessageBox.Show("Must enter unique email");
                        return;
                    }
                }
                ObservableCollection<SecretaryClass> secretaries = new ObservableCollection<SecretaryClass>(SecretaryController.Instance.GetAll());
                for (int i = 0; i < secretaries.Count; i++)
                {
                    if (EMailTextBox.Text == secretaries[i].Email && secretaries[i] != Secretary)
                    {
                        MessageBox.Show("Must enter unique email");
                        return;
                    }
                }
            }

            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Must enter name!");
                return;
            }

            if (SurnameTextBox.Text == "")
            {
                MessageBox.Show("Must enter surname!");
                return;
            }

            if (JMBGTextBox.Text == "")
            {
                MessageBox.Show("Must enter JMBG!");
                return;
            }

            if (PasswordTextBox.Password == "")
            {
                MessageBox.Show("Must enter password!");
                return;
            }
            Address addressTemp = new Address();

            if (AddressTextBox.Text != "")
            {
                int counter = 0;
                for (int i = 0; i < AddressTextBox.Text.Length; i++)
                {
                    if (AddressTextBox.Text[i] == '/')
                    {
                        counter++;
                    }

                }

                if (counter == 3)
                {

                    string[] tokens = AddressTextBox.Text.Split('/');
                    addressTemp.Street = tokens[0];
                    addressTemp.Number = tokens[1];
                    addressTemp.City = tokens[2];
                    addressTemp.Country = tokens[3];

                }
                else
                {
                    MessageBox.Show("Address must be in format Street/Number/City/Country");
                    AddressTextBox.Focus();
                    return;
                }
            }

            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirm new account", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Account edited!");
                    break;
                case MessageBoxResult.No:
                    return;
            }

            AddressController.Instance.Create(addressTemp);

            switch (currentAccount)
            {
                //Patient
                case 0:
                    {
                        Patient.Name = NameTextBox.Text;
                        Patient.Surname = SurnameTextBox.Text;
                        if (AddressTextBox != null)
                        {
                            Patient.Address = addressTemp;
                        }
                        Patient.Phone = PhoneTextBox.Text;
                        Patient.Birthday = (System.DateTime)BirthDayPicker.SelectedDate;
                        Patient.Jmbg = JMBGTextBox.Text;
                        Patient.Email = EMailTextBox.Text;
                        Patient.Password = PasswordTextBox.Password;

                        if ((bool)MaleRB.IsChecked)
                        {
                            Patient.Gender = Gender.male;
                        }
                        else if ((bool)FemaleRB.IsChecked)
                        {
                            Patient.Gender = Gender.female;
                        }
                        else
                        {
                            Patient.Gender = Gender.other;
                        }
                    }
                    PatientController.Instance.Update(Patient);
                    break;

                //Manager
                case 1:
                    {
                        Manager.Name = NameTextBox.Text;
                        Manager.Surname = SurnameTextBox.Text;
                        if (AddressTextBox != null)
                        {
                            Manager.Address = addressTemp;
                        }
                        Manager.Phone = PhoneTextBox.Text;
                        Manager.Birthday = (System.DateTime)BirthDayPicker.SelectedDate;
                        Manager.Jmbg = JMBGTextBox.Text;
                        Manager.Email = EMailTextBox.Text;
                        Manager.Password = PasswordTextBox.Password;

                        if ((bool)MaleRB.IsChecked)
                        {
                            Manager.Gender = Gender.male;
                        }
                        else if ((bool)FemaleRB.IsChecked)
                        {
                            Manager.Gender = Gender.female;
                        }
                        else
                        {
                            Manager.Gender = Gender.other;
                        }
                    }
                    ManagerController.Instance.Update(Manager);
                    break;

                //Secretary
                case 2:
                    {
                        Secretary.Name = NameTextBox.Text;
                        Secretary.Surname = SurnameTextBox.Text;
                        if (AddressTextBox != null)
                        {
                            Secretary.Address = addressTemp;
                        }
                        Secretary.Phone = PhoneTextBox.Text;
                        Secretary.Birthday = (System.DateTime)BirthDayPicker.SelectedDate;
                        Secretary.Jmbg = JMBGTextBox.Text;
                        Secretary.Email = EMailTextBox.Text;
                        Secretary.Password = PasswordTextBox.Password;

                        if ((bool)MaleRB.IsChecked)
                        {
                            Secretary.Gender = Gender.male;
                        }
                        else if ((bool)FemaleRB.IsChecked)
                        {
                            Secretary.Gender = Gender.female;
                        }
                        else
                        {
                            Secretary.Gender = Gender.other;
                        }
                    }
                    SecretaryController.Instance.Update(Secretary);
                    break;

                //Doctor
                case 3:
                    {
                        Doctor.Name = NameTextBox.Text;
                        Doctor.Surname = SurnameTextBox.Text;
                        if (AddressTextBox != null)
                        {
                            Doctor.Address = addressTemp;
                        }
                        Doctor.DoctorSpecialization = (Model.DoctorSpecialization)SpecialisationComboBox.SelectedItem;
                        Doctor.Phone = PhoneTextBox.Text;
                        Doctor.Birthday = (System.DateTime)BirthDayPicker.SelectedDate;
                        Doctor.Jmbg = JMBGTextBox.Text;
                        Doctor.Email = EMailTextBox.Text;
                        Doctor.Password = PasswordTextBox.Password;

                        if ((bool)MaleRB.IsChecked)
                        {
                            Doctor.Gender = Gender.male;
                        }
                        else if ((bool)FemaleRB.IsChecked)
                        {
                            Doctor.Gender = Gender.female;
                        }
                        else
                        {
                            Doctor.Gender = Gender.other;
                        }
                    }
                    DoctorController.Instance.Update(Doctor);
                    break;

                default:
                    MessageBox.Show("Something is wrong!");
                    break;
            }

            callerScreen.Show();
            this.Close();

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Cancel new account", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    callerScreen.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {

        }

        private void DeleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Cancel new account", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    //Account deleting
                    switch (currentAccount)
                    {
                        case 0:
                            PatientController.Instance.DeleteByID(Patient.Id);
                            break;

                        case 1:
                            ManagerController.Instance.DeleteByID(Manager.Id);
                            break;

                        case 2:
                            SecretaryController.Instance.DeleteByID(Secretary.Id);
                            break;

                        case 3:
                            DoctorController.Instance.DeleteByID(Doctor.Id);
                            break;
                        default:
                            MessageBox.Show("Something is wrong!");
                            break;
                    }

                    callerScreen.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }

        private void MedicalRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<MedicalRecord> medicalRecords = new ObservableCollection<MedicalRecord>(MedicalRecordController.Instance.GetAll());
            for (int i = 0; i < medicalRecords.Count; i++)
            {
                if (medicalRecords[i].Patient == Patient)
                {
                    Patient.MedicalRecord = medicalRecords[i];
                    break;
                }
            }

            if (Patient.MedicalRecord == null)
            {
                Patient.MedicalRecord = new MedicalRecord();
                Patient.MedicalRecord.Patient = Patient;
                PatientController.Instance.Update(Patient);
            }

            SecretaryAccountsMedicalRecord secretaryAccountsMedicalRecord = new SecretaryAccountsMedicalRecord(Patient.MedicalRecord);
            secretaryAccountsMedicalRecord.ShowDialog();
        }
    }
}
