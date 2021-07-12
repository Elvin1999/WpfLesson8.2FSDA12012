using MVVMApp.Commands;
using MVVMApp.Models;
using MVVMApp.Repository;
using MVVMApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMApp.ViewModels
{
   public class MainViewModel:BaseViewModel
    {
        public MainWindow MainWindow { get; set; }
        public FakeRepo PrinterRepository { get; set; }
        public ObservableCollection<Printer> Printers { get; set; }

        private Printer printer;

        public Printer Printer
        {
            get { return printer; }
            set { printer = value; OnPropertyChanged(); }
        }

        public RelayCommand ShowCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public EditViewModel EditViewModel { get; set; }

        public MainViewModel()
        {
            PrinterRepository = new FakeRepo();
            Printers = new ObservableCollection<Printer>(PrinterRepository.GetAll());

            Printer = new Printer
            {
                Model="Envy",
                Vendor="Hp",
                Color="AquaMari"
            };

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
              {
                  var item = SelectedItem as Printer;
                  Printer = item;
              });

            ShowCommand = new RelayCommand((e) =>
            {
                MessageBox.Show($"{Printer.Model} - {Printer.Vendor}");
            },(c)=> {
                if (Printer.Color.Length < 10)
                {
                    return true;
                }
                return false;
            });


            EditCommand = new RelayCommand((e) =>
              {

                  var view = new EditWindow();
                  EditViewModel = new EditViewModel();
                  EditViewModel.EditPrinter = Printer;
                  EditViewModel.MainWindow = MainWindow;
                  EditViewModel.EditView = view;
                  view.DataContext = EditViewModel;

                  MainWindow.Hide();
                  view.ShowDialog();

                  
              });


        }


      


     
    }
}
