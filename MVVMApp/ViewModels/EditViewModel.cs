using MVVMApp.Commands;
using MVVMApp.Models;
using MVVMApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.ViewModels
{
   public class EditViewModel:BaseViewModel
    {


        private Printer _editPrinter;

        public Printer EditPrinter
        {
            get { return _editPrinter; }
            set { _editPrinter = value; OnPropertyChanged(); }
        }

        public RelayCommand SaveCommand { get; set; }


        public EditWindow EditView { get; set; }
        public MainWindow MainWindow { get; set; }
        public EditViewModel()
        {
            SaveCommand = new RelayCommand((e)=> {

                EditView.Close();
                MainWindow.Show();
            
            });
        }
    }
}
