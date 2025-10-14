using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public HomeViewModel()
        {
            DetectCommand = new RelayCommand(Detect, CanDetect);
        }

        private void Detect(object? obj)
        {
            // TODO ...
        }

        private bool CanDetect(object? obj)
        {
            return !string.IsNullOrWhiteSpace(_textToDetect);
        }
    }
}
