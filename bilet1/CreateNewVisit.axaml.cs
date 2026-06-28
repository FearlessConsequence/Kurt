using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace bilet1;

public partial class CreateNewVisit : Window
{
    public CreateNewVisit()
    {
        InitializeComponent();

    }

    private void OnSaveRecord(object? sender, RoutedEventArgs e)
    {
        try
        {
            string leaderName = LeaderTextBox.Text ?? "";
            string date = DateTextBox.Text ?? "";
            string children = ChildrenCountTextBox.Text ?? "";
            
            if (string.IsNullOrWhiteSpace(leaderName) ||
            string.IsNullOrWhiteSpace(date) ||
            string.IsNullOrWhiteSpace(children))
            {
                HeyThereTextBlock.Text = "Заполните все поля";
                return;
            }

            var leader = DatabaseHelper.GetLeaderByName(leaderName);
            if (leader == null)
            {
                HeyThereTextBlock.Text = "Руководитель не найден!";
                return;
            }

            DateTime visitDate = DateTime.Parse(date);
            int childrenCount = int.Parse(children);
            
            DatabaseHelper.InsertVisit(leader.LeaderId, visitDate, childrenCount);
            
            HeyThereTextBlock.Text = "Сохранено!";
            Close();

        }

        catch (Exception ex)
        {
            HeyThereTextBlock.Text = $"Ошибка: {ex.Message}";
        }
    }
}