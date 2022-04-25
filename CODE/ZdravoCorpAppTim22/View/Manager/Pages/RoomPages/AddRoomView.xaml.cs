﻿using Controller;
using Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ZdravoCorpAppTim22.View.Manager.Pages.RoomPages
{
    public partial class AddRoomView : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int level;
        private string name;
        private string type;
        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }
        public string RoomName
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("RoomName");
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public AddRoomView()
        {
            InitializeComponent();
            DataContext = this;
            TypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType));
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RoomView());
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (type == null)
            {
                return;
            }
            if (name == null || name.Equals(""))
            {
                MessageBox.Show("Name can't be empty");
                return;
            }
            if (level < 0)
            {
                MessageBox.Show("Level can't be nagative");
                return;
            }

            RoomType rt = (RoomType)Enum.Parse(typeof(RoomType), type);
            Room room = new Room(0, level, rt, name);
            RoomController.Instance.Create(room);

            this.NavigationService.Navigate(new RoomView());
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RoomView());
        }
    }
}
