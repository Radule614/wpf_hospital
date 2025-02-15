﻿using Model;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using ZdravoCorpAppTim22.Model.Generic;
using ZdravoCorpAppTim22.Repository.FileHandlers.Serialization;

namespace ZdravoCorpAppTim22.Model
{
    public class MedicalReceipt : IHasID
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime NotifyNextDateTime { get; set; }
        public string Time { get; set; }
        public string AdditionalInstructions { get; set; }
        public string TherapyPurpose { get; set; }

        [JsonConstructor]
        public MedicalReceipt() { }

        public MedicalReceipt(DateTime endDate, string time, Medicine medicine, string additionalInstructions, string therapyPurpose, 
            MedicalRecord medicalRecord)
        {
            EndDate = endDate;
            Time = time;
            
            AdditionalInstructions = additionalInstructions;
            TherapyPurpose = therapyPurpose;
            MedicalRecord = medicalRecord;

            var parts = time.Split(':');

            NotifyNextDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(parts[0]),int.Parse(parts[1]),0);
        }

        [JsonConverter(typeof(MedicalRecordToIDConverter))]
        public MedicalRecord medicalRecord;

        [JsonConverter(typeof(MedicalRecordToIDConverter))]
        public MedicalRecord MedicalRecord
        {
            get
            {
                return medicalRecord;
            }
            set
            {
                if (this.medicalRecord == null || !this.medicalRecord.Equals(value))
                {
                    if (this.medicalRecord != null)
                    {
                        MedicalRecord oldMedicalRecord = this.medicalRecord;
                        this.medicalRecord = null;
                        oldMedicalRecord.RemoveMedicalReceipt(this);
                    }
                    if (value != null)
                    {
                        this.medicalRecord = value;
                        this.medicalRecord.AddMedicalReceipt(this);
                    }
                }
            }
        }

        [JsonIgnore]
        public ObservableCollection<Medicine> medicine;
        [JsonIgnore]
        public ObservableCollection<Medicine> Medicine
        {
            get
            {
                if (medicine == null)
                    medicine = new ObservableCollection<Medicine>();
                return medicine;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddMedicine(oMedicine);
                }
            }
        }

        public void AddMedicine(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (this.medicine == null)
                this.medicine = new ObservableCollection<Medicine>();
            if (!this.medicine.Contains(newMedicine))
            {
                this.medicine.Add(newMedicine);
                newMedicine.MedicalReceipt = this;
            }
        }
        public void RemoveMedicine(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (this.medicine != null)
                if (this.medicine.Contains(oldMedicine))
                {
                    this.medicine.Remove(oldMedicine);
                    oldMedicine.MedicalReceipt = null;
                }
        }
        public void RemoveAllMedicine()
        {
            if (medicine != null)
            {
                System.Collections.ArrayList tmpMedicine = new System.Collections.ArrayList();
                foreach (Medicine oldMedicine in medicine)
                    tmpMedicine.Add(oldMedicine);
                medicine.Clear();
                foreach (Medicine oldMedicine in tmpMedicine)
                    oldMedicine.MedicalReceipt = null;
                tmpMedicine.Clear();
            }
        }
    }
}
