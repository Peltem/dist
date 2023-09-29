using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;
using MySqlConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;

namespace Dist;

public partial class MainWindow : Window
{
    private void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `groups`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Groups.Add(new Group
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        });
                    }
                }
            }

            connection.Close();
        }

        DataGrid.ItemsSource = Groups;
    }

    private List<Group> Groups { get; set; }
    private MySqlConnectionStringBuilder _connection;

    public MainWindow()
    {
        InitializeComponent();
        Groups = new List<Group>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro10",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid();

    }

    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        var a = new StudentsWindow();
        a.Show();
    }

    private void Button2_OnClick(object? sender, RoutedEventArgs e)
    {
        var g = new EditingWindow();
        g.Show();
    }
}
