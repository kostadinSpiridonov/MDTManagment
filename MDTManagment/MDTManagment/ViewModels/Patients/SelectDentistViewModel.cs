using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels.Patients
{
    public class SelectDentistViewModel 
    {
        private DentistService dentistService { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool isSelected { get; set; }

        //public ObservableCollection<SelectDentistViewModel> Dentists { get; set; }


     //   void Bla()
     //   { 
     //       foreach ( var item in this.Patients)
     //           {
     //               foreach (var item1 in this.Patients) //???? in this. kvo?
     //               {
     //               if (item.Name == item1)
     //                   listSysDentistsOfThePatient.Add(item);
     //               }   
     //               
     //           }
     //   }


   //     public SelectDentistViewModel()
   //     {
   //         this.dentistService = new DentistService();                                                  //ne6to ot tuka moje mi trqa
   //         this.Dentists = new ObservableCollection<SelectDentistViewModel>();                          //
   //                                                                                                      //
   //         var dentists = dentistService.GetAllDentists();                                              //
   //         var viewModelDentists = new ObservableCollection<SelectDentistViewModel>();                  //
   //         this.Dentists = viewModelDentists;                                                           //
   //
   //
   //     } 
    }
}
