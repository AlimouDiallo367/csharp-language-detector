## 3. Bouton détection non disponible > 
## 1. 


v2
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP2_DetectionLangue.Models
{
    public class LanguageService
    {
        private readonly ApiClient _apiClient;

        public LanguageService()
        {
            // On utilise l'URL de base de l'API DetectLanguage
            _apiClient = new ApiClient("https://ws.detectlanguage.com/0.2/");
        }

        // Méthode principale pour détecter la langue
        public async Task<DetectionResult> DetectLanguageAsync(string text, string token)
        {
            // 1️⃣ Créer le JSON à envoyer
            var requestJson = JsonSerializer.Serialize(new
            {
                q = text,      // le texte à détecter
                key = token    // ton token API
            });

            // 2️⃣ Appel POST asynchrone
            var responseJson = await _apiClient.RequetePostAsync("detect", requestJson);

            // 3️⃣ Convertir le JSON reçu en objet C#
            var detectionResponse = JsonSerializer.Deserialize<DetectLanguageResponse>(responseJson);

            // 4️⃣ Extraire le premier résultat
            if (detectionResponse?.Data?.Detections?.Length > 0)
            {
                var d = detectionResponse.Data.Detections[0];
                return new DetectionResult
                {
                    Language = d.Language,
                    Confidence = d.Confidence,
                    IsReliable = d.IsReliable
                };
            }

            // 5️⃣ Si aucun résultat, renvoyer un objet vide
            return new DetectionResult
            {
                Language = "Unknown",
                Confidence = 0,
                IsReliable = false
            };
        }
    }

    // Classe pour le résultat final utilisable dans le ViewModel
    public class DetectionResult
    {
        public string Language { get; set; }
        public float Confidence { get; set; }
        public bool IsReliable { get; set; }
    }

    // Classes pour désérialiser le JSON de l'API
    public class DetectLanguageResponse
    {
        public ResponseData Data { get; set; }
    }

    public class ResponseData
    {
        public Detection[] Detections { get; set; }
    }

    public class Detection
    {
        public string Language { get; set; }
        public float Confidence { get; set; }
        public bool IsReliable { get; set; }
    }
}


<UserControl x:Class="TP2_DetectionLangue.Views.HomeView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:TP2_DetectionLangue.Views"
             mc:Ignorable="d" 
             d:DesignHeight="750" d:DesignWidth="920">
    <Grid Background="White">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <StackPanel Grid.Column="0">
            <Label Content="Entrez le texte pour lequel vous voulez détecter la langue : " Margin="10,20,0,20"/>
            <TextBox Height="330" Margin="10,0,0,0" 
                     Text="{Binding TextToDetect, UpdateSourceTrigger=PropertyChanged}"
                     AcceptsReturn="True"
                     AcceptsTab="True"
                     TextWrapping="Wrap"
            />

            <Rectangle Height="30"/>
            <Button Content="Détecter" Width="200" Padding="10,5" Command="{Binding DetectCommand}"/>
        </StackPanel>
        <StackPanel Grid.Column="1">
            <Label Content="Résultat de la détection : " Margin="0,20,0,20"/>
            <ComboBox SelectedItem="FRENCH" 
                      HorizontalAlignment="Center" 
                      Width="150"
                      Margin="0,0,0,40">
                <ComboBoxItem Content="FRENCH"/>
                <ComboBoxItem Content="ENGLISH"/>
                <ComboBoxItem Content="SPANISH"/>
            </ComboBox>

            <Grid HorizontalAlignment="Center">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>

                <Label Grid.Row="0" Grid.Column="0" Content="Langue : " Margin="0,5"/>
                <TextBlock Grid.Row="0" Grid.Column="1" Margin="10,5,0,5"/>

                <Label Grid.Row="1" Grid.Column="0" Content="Confiance : " Margin="0,5"/>
                <TextBlock Grid.Row="0" Grid.Column="1" Margin="10,5,0,5"/>

                <Label Grid.Row="2"  Grid.Column="0" Content="Est fiable : " Margin="0,5"/>
                <TextBlock Grid.Row="0" Grid.Column="1" Margin="10,5,0,5"/>
            </Grid>
        </StackPanel>
    </Grid>
</UserControl>