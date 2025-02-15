﻿using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ZdravoCorpAppTim22.Controller;
using ZdravoCorpAppTim22.View.Manager.Commands;
using ZdravoCorpAppTim22.View.Manager.Pages.WarehousePages;
using ZdravoCorpAppTim22.View.Manager.Views;

namespace ZdravoCorpAppTim22.View.Manager.ViewModels.WarehouseViewModels
{
    public class WarehouseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public RelayCommand OpenAddCommand { get; private set; }
        public RelayCommand OpenEditCommand { get; private set; }
        public RelayCommand DeleteEquipmentCommand { get; private set; }
        public RelayCommand OpenRelocationCommand { get; private set; }

        public ObservableCollection<Equipment> EquipmentCollection { get; set; }
        public ObservableCollection<Equipment> FilteredEquipment
        {
            get
            {
                List<Equipment> temp = new List<Equipment>();
                if (Filter != 0)
                {
                    if(Filter == 2)
                    {
                        temp.AddRange(EquipmentCollection.Where(x => x.EquipmentData.Type == EquipmentType.consumable));
                    }else
                    {
                        temp.AddRange(EquipmentCollection.Where(x => x.EquipmentData.Type != EquipmentType.consumable));
                    }
                }
                else
                {
                    temp = new List<Equipment>(EquipmentCollection);
                }

                List<Equipment> result = new List<Equipment>();
                if (SearchText != null && SearchText != "")
                {
                    
                    result.AddRange(temp.Where(x => x.EquipmentData.Name.ToUpper().StartsWith(SearchText.ToUpper())));
                }
                else
                {
                    result = temp;
                }
                return new ObservableCollection<Equipment>(result);
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if(searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");
                    OnPropertyChanged("FilteredEquipment");
                }
            }
        }

        private int filter;
        public int Filter
        {
            get { return filter; }
            set
            {
                if(filter != value)
                {
                    filter = value;
                    OnPropertyChanged("Filter");
                    OnPropertyChanged("FilteredEquipment");
                }
            }
        }

        public WarehouseViewModel()
        {
            OpenAddCommand = new RelayCommand(OpenAdd, null);
            OpenEditCommand = new RelayCommand(OpenEdit, IsSelected);
            DeleteEquipmentCommand = new RelayCommand(DeleteEquipment, IsSelected);
            OpenRelocationCommand = new RelayCommand(OpenRelocation, CanRelocate);

            Filter = 0;

            List<Equipment> equipment = EquipmentController.Instance.GetWarehouseEquipment();
            EquipmentCollection = new ObservableCollection<Equipment>(equipment);
            EquipmentController.Instance.DataChanged += EquipmentDataChangedHandler;
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void EquipmentDataChangedHandler(object sender, EventArgs e)
        {
            List<Equipment> equipment = EquipmentController.Instance.GetWarehouseEquipment();
            EquipmentCollection.Clear();
            foreach (Equipment eq in equipment)
            {
                EquipmentCollection.Add(eq);
            }
            OnPropertyChanged("FilteredEquipment");
        }

        public void OpenAdd(object obj)
        {
            ManagerHome.NavigationService.Navigate(new AddEquipmentView());
        }
        public void OpenEdit(object obj)
        {
            List<Equipment> selectedEquipment = ((IList)obj).Cast<Equipment>().ToList();
            Equipment equipment = selectedEquipment[0];
            EditEquipmentView editEquipment = new EditEquipmentView(equipment);
            ManagerHome.NavigationService.Navigate(editEquipment);
        }
        public void DeleteEquipment(object obj)
        {
            string msg = "Are you sure?";
            if (ManagerHome.CurrentLanguage == 1)
            {
                msg = "Da li ste sigurni?";
            }
            if (ConfirmModal.Show(msg))
            {
                List<Equipment> selectedEquipment = ((IList)obj).Cast<Equipment>().ToList();
                Equipment equipment = selectedEquipment[0];
                EquipmentCollection.Remove(equipment);

                EquipmentController.Instance.DeleteWarehouseEquipmentByID(equipment.Id);
            }
        }
        public void OpenRelocation(object obj)
        {
            List<Equipment> selectedEquipment = new List<Equipment>();
            foreach (Equipment eq in ((IList)obj).Cast<Equipment>().ToList())
            {
                if (eq.Amount > 0)
                {
                    selectedEquipment.Add(eq);
                }
            }
            ManagerHome.NavigationService.Navigate(new WarehouseRelocationView(selectedEquipment));   
        }

        private bool CanRelocate(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            List<Equipment> selectedEquipment = ((IList)obj).Cast<Equipment>().ToList();
            if (selectedEquipment.Count > 0)
            {
                return true;
            }
            return false;
        }
        private bool IsSelected(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            List<Equipment> selectedEquipment = ((IList)obj).Cast<Equipment>().ToList();
            if (selectedEquipment.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
