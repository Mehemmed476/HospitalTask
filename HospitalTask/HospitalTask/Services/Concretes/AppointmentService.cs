using HospitalTask.Models;
using HospitalTask.Services.Interfaces;

namespace HospitalTask.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        List<Appointment> appointments;

        public AppointmentService()
        {
            appointments = [];
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public void EndAppointment(int id)
        {
            Appointment? finishAppointment = appointments.FirstOrDefault(x => x.Id == id);
            if (finishAppointment == null)
            {
                throw new NullReferenceException();
            }

            finishAppointment.EndDate = DateTime.Now;

        }

        public List<Appointment> GetAllAppointments()
        {
            return appointments;
        }

        public List<Appointment> GetAllContinuingAppointments()
        {
            return appointments.Where(x => x.EndDate == null).ToList();
        }

        public List<Appointment> getAppointmentsFilter(DateTime start, DateTime end)
        {
            return appointments.Where(x => x.StartDate >= start && x.StartDate <= end).ToList();
        }

        public Appointment GetAppointment(int id)
        {
            Appointment? searchingAppointment = appointments.FirstOrDefault(x => x.Id == id);
            return searchingAppointment ?? throw new Exception("Appointment not found");
         }

        public List<Appointment> GetTodaysAppointments()
        {
            DateTime today = DateTime.Now.Date;
            
            return appointments.Where(x => x.StartDate >= today).ToList() ?? throw new Exception("This week we don't have any Appointments");
        }

        public List<Appointment> GetWeeklyAppointments()
        {
            DateTime endOfWeek = DateTime.Now.Date;
            DateTime startOfWeek = endOfWeek.AddDays(-7);
            return appointments.Where(x => x.StartDate >= startOfWeek && x.StartDate <= endOfWeek).ToList() ?? throw new Exception("Today we don't have any Appointments");
        }
    }
}
