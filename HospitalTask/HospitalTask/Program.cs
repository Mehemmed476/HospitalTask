using HospitalTask.Models;
using HospitalTask.Services.Concretes;
using System.ComponentModel;
namespace HospitalTask
{
    //Mehemmed Xelilzade
    public class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string patientName;
            string doctorName;
            string choice;
            int id;
            DateTime filterStartDate;
            DateTime filterEndDate;
            
            Appointment appointment = null;
            AppointmentService service = new AppointmentService();
            while (running)
            {
                Console.Clear();

                Console.WriteLine("""
                    Welcome To Hospital App!!!

                    1. Appointment yarat
                    2. Appointment-i bitir
                    3. Bütün appointment-lərə bax
                    4. Bu həftəki appointment-lərə bax
                    5. Bugünki appointment-lərə bax
                    6. Bitməmiş appointmentlərə bax
                    7. Id-ə görə appointmentə bax
                    8. Fitlerə əsasən appointmentlərə bax
                    9. Menudan çıx

                    """);

                Console.Write("Select an Option(1-9): ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Your Name: ");
                        patientName = Console.ReadLine();
                        Console.Write("Doctor Name: ");
                        doctorName = Console.ReadLine();

                        appointment = new Appointment(patientName, doctorName);

                        service.AddAppointment(appointment);
                        Console.WriteLine("Successfully Added!!!");
                        Thread.Sleep(2000);
                        break;

                    case "2":
                        if (appointment == null)
                        {
                            throw new Exception("Please create appointment first!!!");
                        }

                        Console.Write("Please send ID: ");
                        id = int.Parse(Console.ReadLine()); 

                        service.EndAppointment(id);
                        Console.WriteLine("This Appointment finish!!!");
                        Thread.Sleep(2000);
                        break;

                    case "3":
                        List<Appointment> allAppointments = service.GetAllAppointments();
                        allAppointments.ForEach(appointment => Console.WriteLine($"ID: {appointment.Id} \nPatient Name: {appointment.PatientName} \nDoctor Name: {appointment.DoctorName} \nStart Date: {appointment.StartDate} \nEnd Date: {appointment.EndDate}"));
                        Thread.Sleep(2000);
                        break;

                    case "4":
                        List<Appointment> weeklyAllAppointments = service.GetWeeklyAppointments();
                        weeklyAllAppointments.ForEach(appointment => Console.WriteLine($"ID: {appointment.Id} \nPatient Name: {appointment.PatientName} \nDoctor Name: {appointment.DoctorName} \nStart Date: {appointment.StartDate} \nEnd Date: {appointment.EndDate}"));
                        Thread.Sleep(2000);
                        break;
                    
                    case "5":
                        List<Appointment> todaysAllAppointments = service.GetTodaysAppointments();
                        todaysAllAppointments.ForEach(appointment => Console.WriteLine($"ID: {appointment.Id} \nPatient Name: {appointment.PatientName} \nDoctor Name: {appointment.DoctorName} \nStart Date: {appointment.StartDate} \nEnd Date: {appointment.EndDate}"));
                        Thread.Sleep(2000);
                        break;

                    case "6":
                        List<Appointment> openAppointments = service.GetAllContinuingAppointments();
                        openAppointments.ForEach(appointment => Console.WriteLine($"ID: {appointment.Id} \nPatient Name: {appointment.PatientName} \nDoctor Name: {appointment.DoctorName} \nStart Date: {appointment.StartDate} \nEnd Date: {appointment.EndDate}"));
                        Thread.Sleep(2000);
                        break;
                    
                    case "7":
                        Console.Write("Please send ID: ");
                        id = int.Parse(Console.ReadLine()); 
                        
                        Appointment searchingAppointment = service.GetAppointment(id);
                        Console.WriteLine(
                            $"ID: {searchingAppointment.Id} \nPatient Name: {searchingAppointment.PatientName} \nDoctor Name: {searchingAppointment.DoctorName} \nStart Date: {searchingAppointment.StartDate} \nEnd Date: {searchingAppointment.EndDate}"); 
                        Thread.Sleep(2000);
                        break;
                    
                    case "8":
                        Console.Write("Please send Start: ");
                        filterStartDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Please send End: ");
                        filterEndDate = DateTime.Parse(Console.ReadLine());

                        List<Appointment> filterAppointments = [];
                        filterAppointments = service.getAppointmentsFilter(filterStartDate, filterEndDate);
                        filterAppointments.ForEach(appointment => Console.WriteLine($"ID: {appointment.Id} \nPatient Name: {appointment.PatientName} \nDoctor Name: {appointment.DoctorName} \nStart Date: {appointment.StartDate} \nEnd Date: {appointment.EndDate}"));
                        Thread.Sleep(2000);
                        break;
                    
                    case "9":
                        running = false;
                        Console.WriteLine("Good Bye!!!");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
