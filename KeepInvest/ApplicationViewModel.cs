using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace KeepInvest
{
    class ApplicationViewModel: INotifyPropertyChanged
    {
        ISecurities selectedSecurities;

        IFileService fileService;
        IDialogService dialogService;

        public ObservableCollection<ISecurities> Securities { get; set; }


        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var securities = fileService.Parse(dialogService.FilePath);
                              Securities.Clear();
                              foreach (var s in securities)
                                  Securities.Add(s);
                             // dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                         // dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда добавления нового объекта
        //private RelayCommand addCommand;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {
        //              Phone phone = new Phone();
        //              Securities.Insert(0, phone);
        //              SelectedPhone = phone;
        //          }));
        //    }
        //}

        //private RelayCommand removeCommand;
        //public RelayCommand RemoveCommand
        //{
        //    get
        //    {
        //        return removeCommand ??
        //          (removeCommand = new RelayCommand(obj =>
        //          {
        //              Phone phone = obj as Phone;
        //              if (phone != null)
        //              {
        //                  Securities.Remove(phone);
        //              }
        //          },
        //         (obj) => Securities.Count > 0));
        //    }
        //}
        //private RelayCommand doubleCommand;
        //public RelayCommand DoubleCommand
        //{
        //    get
        //    {
        //        return doubleCommand ??
        //          (doubleCommand = new RelayCommand(obj =>
        //          {
        //              Phone phone = obj as Phone;
        //              if (phone != null)
        //              {
        //                  Phone phoneCopy = new Phone
        //                  {
        //                      Company = phone.Company,
        //                      Price = phone.Price,
        //                      Title = phone.Title
        //                  };
        //                  Securities.Insert(0, phoneCopy);
        //              }
        //          }));
        //    }
        //}

        //public Phone SelectedPhone
        //{
        //    get { return selectedSecurities; }
        //    set
        //    {
        //        selectedSecurities = value;
        //        OnPropertyChanged("SelectedPhone");
        //    }
        //}

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            // данные по умлолчанию
            Securities = new ObservableCollection<ISecurities>
            {
                new Stock { ISIN="US0011554", CompanyName="Apple", Ticker="AAPL" },
                new Stock { ISIN="US0099129", CompanyName="Samsu", Ticker="SAMS" },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
