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
    public class HomeViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand DetectCommand {  get; private set; }
        #endregion

        private string _textToDetect;
        public string TextToDetect
        {
            get => _textToDetect;
            set
            {
                _textToDetect = value;
                OnPropertyChanged();
            }
        }

        private string _detectedLanguage;
        public string DetectedLanguage
        {
            get => _detectedLanguage;
            set
            {
                _detectedLanguage = value;
                OnPropertyChanged();
            }
        }

        private double _detectionScore;
        public double DetectionScore
        {
            get => _detectionScore;
            set
            {
                _detectionScore = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            DetectCommand = new RelayCommand(Detect, CanDetect);
        }

        private async void Detect(object? obj)
        {
            var token = Properties.Settings.Default.ApiToken;

            if (string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show(
                    "Veuillez configurer le jeton de l'API dans la configuration avant de faire une requête.",
                    "Erreur",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return;
            }

            // TODO : Appel API detectlanguage.com et ne pas oublier async
            try
            {
                LanguageService service = new LanguageService();
                var results = await service.DetectLanguageAsync(TextToDetect, token);
                if (results != null && results.Length > 0)
                {
                    DetectedLanguage = results[0].language;
                    DetectionScore = results[0].score;
                }
                else
                {
                    DetectedLanguage = "Unknown";
                }            
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    $"Erreur lors de la détection : {ex.Message}",
                    "Erreur API",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private bool CanDetect(object? obj)
        {
            return !string.IsNullOrWhiteSpace(_textToDetect);
        }
    }
}
