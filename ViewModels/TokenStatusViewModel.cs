using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_DetectionLangue.Models;
using TP2_DetectionLangue.ViewModels.Commands;

namespace TP2_DetectionLangue.ViewModels
{
    public class TokenStatusViewModel : BaseViewModel
    {
        #region RelayCommand
        public RelayCommand CloseCommand { get; set; }
        #endregion
        #region Properties
        private string _currentDate;
        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }

        private int _todayRequests;
        public int TodayRequests
        {
            get => _todayRequests;
            set
            {
                _todayRequests = value;
                OnPropertyChanged();
            }
        }

        private int _todayBytes;
        public int TodayBytes
        {
            get => _todayBytes;
            set
            {
                _todayBytes = value;
                OnPropertyChanged();
            }
        }

        private string _currentPlan;
        public string CurrentPlan
        {
            get => _currentPlan;
            set
            {
                _currentPlan = value;
                OnPropertyChanged();
            }
        }

        private string _planExpirationDate;
        public string PlanExpirationDate
        {
            get => _planExpirationDate;
            set
            {
                _planExpirationDate = value;
                OnPropertyChanged();
            }
        }

        private int _dailyRequestsLimit;
        public int DailyRequestsLimit
        {
            get => _dailyRequestsLimit;
            set
            {
                _dailyRequestsLimit = value;
                OnPropertyChanged();
            }
        }

        private int _dailyBytesLimit;
        public int DailyBytesLimit
        {
            get => _dailyBytesLimit;
            set
            {
                _dailyBytesLimit = value;
                OnPropertyChanged();
            }
        } 
        private string _tokenStatus;
        public string TokenStatus
        {
            get => _tokenStatus;
            set
            {
                _tokenStatus = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public TokenStatusViewModel()
        {
            CloseCommand = new RelayCommand(CloseWindow, null);
            LoadTokenStatusAsync();
        }


        private async void LoadTokenStatusAsync()
        {
            try
            {
                var token = Properties.Settings.Default.ApiToken;

                if (string.IsNullOrWhiteSpace(token))
                {
                    MessageBox.Show(
                        "Jeton non valide.",
                        "Erreur",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                    return;
                }

                LanguageService service = new LanguageService();
                var status = await service.GetTokenStatusAsync(token);

                if (status != null)
                {
                    CurrentDate = status.Date;
                    TodayRequests = status.Requests;
                    TodayBytes = status.Bytes;
                    CurrentPlan = status.Plan;
                    PlanExpirationDate = status.Plan_Expires;
                    DailyRequestsLimit = status.Daily_Requests_Limit;
                    DailyBytesLimit = status.Daily_Bytes_Limit;
                    TokenStatus = status.Status;
                }
                else
                {
                    MessageBox.Show(
                        "Impossible de récupérer les informations du jeton.",
                        "Erreur",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erreur lors du chargement du statut du jeton : {ex.Message}",
                    "Erreur API",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void CloseWindow(object? obj)
        {
            if (obj is Window window)
                window.Close();
        }
    }
}
