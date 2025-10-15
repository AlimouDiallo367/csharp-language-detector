using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_DetectionLangue.ViewModels.Commands;

namespace TP2_DetectionLangue.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        #endregion

        private string _apiToken;
        public string ApiToken
        {
            get => _apiToken;
            set
            {
                _apiToken = value;
                OnPropertyChanged();
            }
        }

        public ConfigurationViewModel()
        {
            ApiToken = Properties.Settings.Default.ApiToken;

            SaveCommand = new RelayCommand(SaveToken, CanSaveToken);
            CancelCommand = new RelayCommand(Cancel, null);
        }


        private void SaveToken(object? obj)
        {
            Properties.Settings.Default.ApiToken = ApiToken;
            Properties.Settings.Default.Save();
            MessageBox.Show("Le jeton a été sauvegardé avec succès !");
            CloseWindow(obj);
        }
        private bool CanSaveToken(object? obj)
        {
            return !string.IsNullOrWhiteSpace(ApiToken);
        }

        private void Cancel(object? obj)
        {
            CloseWindow(obj);
        }
        private void CloseWindow(object? obj)
        {
            if (obj is Window window)
                window.Close();
        }
    }
}
