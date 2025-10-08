using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_DetectionLangue.ViewModels.Commands;

namespace TP2_DetectionLangue.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand CmdGotoConfiguration { get; private set; }
        public RelayCommand CmdGotoTokenStatus { get; private set; }
        #endregion

        private BaseViewModel _currentViewModel;
        private HomeViewModel _homeViewModel;
        private ConfigurationViewModel _configurationViewModel;
        private TokenStatusViewModel _tokenStatusViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
            }
        }

        public MainViewModel()
        {
            _homeViewModel = new HomeViewModel();
            _configurationViewModel = new ConfigurationViewModel();
            _tokenStatusViewModel = new TokenStatusViewModel();
            CurrentViewModel = _homeViewModel;

            CmdGotoConfiguration = new RelayCommand(GotoConfiguration, null);
            CmdGotoTokenStatus = new RelayCommand(GotoTokenStatus, null);
        }

        private void GotoConfiguration(object? obj)
        {
            var configurationWindow = new Views.ConfigurationView();
            configurationWindow.Show();
        }

        private void GotoTokenStatus(object? obj)
        {
            var tokenStatusWindow = new Views.TokenStatusView();
            tokenStatusWindow.Show();
        }
    }
}
