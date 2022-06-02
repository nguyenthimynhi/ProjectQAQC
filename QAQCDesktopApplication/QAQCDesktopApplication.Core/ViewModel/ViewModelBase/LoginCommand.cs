﻿
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel;

namespace QAQCDesktopApplication.Core.ViewModel.ViewModelBase
{
    class LoginCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public LoginCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}
    }
}
