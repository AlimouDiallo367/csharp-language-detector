using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using TP2_DetectionLangue.Models;
using TP2_DetectionLangue.ViewModels.Commands;

namespace TP2_DetectionLangue.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region RelayCommands
        public RelayCommand DetectCommand { get; private set; }
        #endregion

        #region Properties
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

        public ObservableCollection<LanguageCandidate> DetectedLanguages { get; private set; } = new ObservableCollection<LanguageCandidate>();

        private LanguageCandidate _selectedLanguage;
        public LanguageCandidate SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged();
            }
        }
        #endregion


        private readonly LanguageService _languageService;
        public HomeViewModel()
        {
            _languageService = new LanguageService();
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

            try
            {
                await _languageService.LoadSupportedLanguagesAsync(token);
                
                var results = await _languageService.DetectLanguageAsync(TextToDetect, token);

                DetectedLanguages.Clear();
                foreach (var r in results)
                {
                    r.FullLanguageName = _languageService.GetLanguageName(r.Language);
                    DetectedLanguages.Add(r);
                }

                if (DetectedLanguages.Count > 0)
                {
                    SelectedLanguage = DetectedLanguages[0];
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

