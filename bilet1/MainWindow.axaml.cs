using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;

namespace bilet1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        try 
        {
            var circles = DatabaseHelper.GetCircles();
            CircleListBox.ItemsSource = circles;

            var leaders = DatabaseHelper.GetLeaders();
            LeadersListBox.ItemsSource = leaders;
        }
        catch (Exception ex)
        {
            HeyThereTextBlock.Text = $"Ошибка БД: {ex.Message}";
            Debug.WriteLine(ex.ToString());
        }
    }

    private void OnCreateNewVisit(object? sender, RoutedEventArgs e)
    {
        var createNewVisit = new CreateNewVisit();
        createNewVisit.Show();
        this.Close();
    }
}