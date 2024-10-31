using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask.Models
{
    public class Appointment
    {
        private int _id = 0; 
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        

        public Appointment(string patientName, string doctorName)
        {
            _id++;
            Id = _id;
            PatientName = patientName;
            DoctorName = doctorName;
            StartDate = DateTime.Now;
            EndDate = null;
        }

        public override string ToString()
        {
            if (EndDate == null)
            {
                return "davam edir";
            }

            return base.ToString();
        }
    }
}
