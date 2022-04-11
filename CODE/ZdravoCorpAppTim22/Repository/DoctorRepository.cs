using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class DoctorRepository
   {
        public static MedicalAppointmentRepository medicalAppointmentRepository;

        List<Doctor> doctors = new List<Doctor>
        {
            new Doctor("Stefan", "Apostolovic", "stefan@gmail.com", "123123123", "stefan123", DateTime.Now, "123321123", Gender.male, 123, null, DoctorSpecialisationType.regular, 
                new List<MedicalAppointment> {medicalAppointmentRepository.GetByID(123) , medicalAppointmentRepository.GetByID(1231), medicalAppointmentRepository.GetByID(1232)}),
            new Doctor("Petar", "Apostolovic1", "stefan1@gmail.com", "223123123", "stefan124", DateTime.Now, "223321123", Gender.male, 124, null, DoctorSpecialisationType.regular,
                new List<MedicalAppointment> {medicalAppointmentRepository.GetByID(124) , medicalAppointmentRepository.GetByID(1241), medicalAppointmentRepository.GetByID(1242)}),
            new Doctor("Marija", "Apostolovic2", "stefan2@gmail.com", "323123123", "stefan125", DateTime.Now, "323321123", Gender.male, 125, null, DoctorSpecialisationType.regular,
                new List<MedicalAppointment> {medicalAppointmentRepository.GetByID(125) , medicalAppointmentRepository.GetByID(1251), medicalAppointmentRepository.GetByID(1252)}),
        };

        public List<Doctor> GetAll()
      {
            return doctors;
      }
      
      public Model.Doctor GetByID(int id)
      {
            int index = doctors.FindIndex(r => r.ID == id);
            return doctors[index];
        }
      
      public void DeleteByID(int id)
      {
            int index = doctors.FindIndex(r => r.ID == id);
            doctors.RemoveAt(index);
        }
      
      public void Create(Model.Doctor doctor)
      {
            this.doctors.Add(doctor);
        }
      
      public void Update(Model.Doctor doctor)
      {
            int index = doctors.FindIndex(r => r.ID == doctor.ID);
            doctors[index] = doctor;
        }
      
      public String path;
   
   }
}