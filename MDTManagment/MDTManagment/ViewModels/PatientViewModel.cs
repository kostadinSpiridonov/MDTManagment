﻿using MDTManagment.Models;
using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }

        private PatientService patientService;

        public PatientViewModel(int patientId)
        {
            this.patientService = new PatientService();
            var databasePatient = patientService.GetPatient(patientId);
            this.Patient = databasePatient;
        }
    }
}
