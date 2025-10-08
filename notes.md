<UserControl x:Class="TP2_DetectionLangue.Views.HomeView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:TP2_DetectionLangue.Views"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid Background="White" Margin="20">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>

        <StackPanel Grid.Column="0" Margin="0,0,20,0">
            <TextBlock Text="Entrez le texte pour lequel vous voulez détecter la langue :" 
                       Margin="0,0,0,10" 
                       FontWeight="SemiBold"/>
            
            <TextBox Height="200" 
                     TextWrapping="Wrap" 
                     AcceptsReturn="True" 
                     VerticalScrollBarVisibility="Auto"
                     Text="Bonjour tout le monde!&#x0a;Il était une fois dans l'Ouest..."/>
            
            <Rectangle Height="20"/>

            <Button Content="Détecter" 
                    HorizontalAlignment="Left" 
                    Padding="10,5" 
                    Width="100"/>
        </StackPanel>

        <StackPanel Grid.Column="1" Margin="20,0,0,0">
            <TextBlock Text="Résultat de la détection :" 
                       Margin="0,0,0,10" 
                       FontWeight="SemiBold"/>
            
            <ComboBox SelectedItem="FRENCH" 
                      HorizontalAlignment="Left" 
                      Width="150" 
                      Margin="0,0,0,30">
                <ComboBoxItem Content="FRENCH"/>
                <ComboBoxItem Content="ENGLISH"/>
                <ComboBoxItem Content="SPANISH"/>
            </ComboBox>
            
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>

                <TextBlock Grid.Row="0" Grid.Column="0" Text="Langue :" Margin="0,5"/>
                <TextBlock Grid.Row="0" Grid.Column="1" Text="FRENCH" FontWeight="Bold" Margin="10,5,0,5"/>

                <TextBlock Grid.Row="1" Grid.Column="0" Text="Confiance :" Margin="0,5"/>
                <TextBlock Grid.Row="1" Grid.Column="1" Text="11.94" FontWeight="Bold" Margin="10,5,0,5"/>

                <TextBlock Grid.Row="2" Grid.Column="0" Text="Est fiable :" Margin="0,5"/>
                <TextBlock Grid.Row="2" Grid.Column="1" Text="Oui" FontWeight="Bold" Margin="10,5,0,5"/>
            </Grid>
        </StackPanel>
    </Grid>
</UserControl>