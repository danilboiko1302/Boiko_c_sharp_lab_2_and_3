using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using BirthdayPicker.Models;
using BirthdayPicker.Tools;
using BirthdayPicker.Tools.Managers;

namespace BirthdayPicker.ViewModels
{
    internal class BirthdayPickerViewModel : BaseViewModel, ILoaderOwner
    {
        
        private Person _person;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _date = DateTime.Today;

        private string _resultInfo = "";

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        private RelayCommand<object> _proceedCommand;
        

        
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public Person Person
        {
            get {return _person;}
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string ResultInfo
        {
            get
            {
                return _resultInfo; 

            }
            private set
            {
                _resultInfo = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility;}
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

      
        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(
                    Proceed, o => CanExecuteCommand());
            }
        }


        internal BirthdayPickerViewModel()
        {
            Date = DateTime.Today;
            LoaderManager.Instance.Initialize(this);
        }


        private async void Proceed(object obj)
        {
            ResultInfo = "";
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                 Thread.Sleep(1000);
                try
                {
                    Person = new Person(FirstName,LastName,Email,Date);
                    ResultInfo = $"Name: {_person.FirstName}\nLastName: {_person.LastName}\nEmail: {_person.Email}\n\nBirthday: {_person.Date.Day}." +
                                 $"{_person.Date.Month}.{_person.Date.Year}\n{_person.ChineseZodiac}\n{_person.WesternZodiac}\n\nIs Adult: {_person.IsAdult}\n" +
                                 $"Is Birthday: {_person.IsBirthday}";
                    if (_person.IsBirthday)
                    {
                        MessageBox.Show("HAPPY BIRTHDAY MY DEAR FRIEND!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
            LoaderManager.Instance.HideLoader();
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_email);
        }
    }
}
