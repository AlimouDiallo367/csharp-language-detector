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
        public RelayCommand SaveCommand {  get; private set; }
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
        }


        private void SaveToken(object? obj)
        {
            Properties.Settings.Default.ApiToken = ApiToken;
            Properties.Settings.Default.Save();
        }
        private bool CanSaveToken(object? obj)
        {
            return !string.IsNullOrWhiteSpace(ApiToken);
        }
    }
}
