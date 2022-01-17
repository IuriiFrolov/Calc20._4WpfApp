using Calc20._4WpfApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calc20._4WpfApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    { // Это общие фразы для связи с xaml
        public event PropertyChangedEventHandler PropertyChanged; //Cобытие уведомляет представление что произошли изменения

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)  //принимает имя методода которое обновилось
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        //Свойство связанное с первым полем ввода, 
        private double tbt1; // Закрытое поле можно назвать tbt 
        public double Tbt1 // Открытое поле можно назвать Tbt
        {
            get => tbt1; // возвращаем значение закрытого поля
            set // установка ( присваивания значения value которое нам передали)
            {
                try
                {
                    tbt1 = value;               //  присваивания значения value которое нам передали заставляем событие сработать через ИНВОК
                    OnPropertyChanged();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        //Свойство связанное со ВТОРЫМ полем ввода,
        private double tbt2;
        public double Tbt2
        {
            get => tbt2;
            set
            {
                try
                {
                    tbt2 = value;
                    OnPropertyChanged();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        //Свойство связанное с ТРЕТЬИМ полем ввода,
        private double tbt3;
        public double Tbt3
        {
            get => tbt3;
            set
            {
                try
                {
                    tbt3 = value;
                    OnPropertyChanged();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }






        //Реализуем команду (клавишу)
        //СЛОЖЕНИЕ
        public ICommand Add1Command { get; } // свойство будет доступно только для чтения Команда сложения!
        private void OnAdd1CommandExecute(object p)
        {
            Tbt3 = Ariph.Add1(Tbt1, Tbt2); // Основной метод который выполняет действие
        }
        private bool CanAdd1CommandExecuted(object p)
        {
            if ((Tbt1 > 0 || Tbt1 <= 0) && (Tbt2 > 0 || Tbt2 <= 0)) return true;
            else return false;
        }
        //Вычетание
        public ICommand Add2Command { get; }
        private void OnAdd2CommandExecute(object p)
        {
            Tbt3 = Ariph.Add2(Tbt1, Tbt2); // Основной метод который выполняет действие
        }
        private bool CanAdd2CommandExecuted(object p)
        {
            if ((Tbt1 > 0 || Tbt1 <= 0) && (Tbt2 > 0 || Tbt2 <= 0)) return true;
            else return false;
        }
        //Умножение
        public ICommand Add3Command { get; }
        private void OnAdd3CommandExecute(object p)
        {
            Tbt3 = Ariph.Add3(Tbt1, Tbt2); // Основной метод который выполняет действие
        }
        private bool CanAdd3CommandExecuted(object p)
        {
            if ((Tbt1 > 0 || Tbt1 <= 0) && (Tbt2 > 0 || Tbt2 <= 0)) return true;
            else return false;

        }
        //Деление
        public ICommand Add4Command { get; }
        private void OnAdd4CommandExecute(object p)
        {
            Tbt3 = Ariph.Add4(Tbt1, Tbt2); // Основной метод который выполняет действие
        }
        private bool CanAdd4CommandExecuted(object p)
        {
            if ((Tbt1 > 0 || Tbt1 <= 0) && (Tbt2 > 0 || Tbt2 < 0)) return true;
            else return false;

        }

        //Очистить
        public ICommand Add5Command { get; }
        private void OnAdd5CommandExecute(object p)
        {
            Tbt1 = 0;
            Tbt2 = 0;
            Tbt3 = 0;
        }
        private bool CanAdd5CommandExecuted(object p)
        {
            return true;


        }








        //Конструктор!
        // Инициализация каждой команды в конструкторе MainWindowViewModel
        public MainWindowViewModel()
        {
            Add1Command = new RelayCommand(OnAdd1CommandExecute, CanAdd1CommandExecuted);
            Add2Command = new RelayCommand(OnAdd2CommandExecute, CanAdd2CommandExecuted);
            Add3Command = new RelayCommand(OnAdd3CommandExecute, CanAdd3CommandExecuted);
            Add4Command = new RelayCommand(OnAdd4CommandExecute, CanAdd4CommandExecuted);
            Add5Command = new RelayCommand(OnAdd5CommandExecute, CanAdd5CommandExecuted);
        }


    }
}
