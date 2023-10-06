using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;
using MySqlX.XDevAPI;
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
                command.CommandText = "SELECT*FROM `Клиенты`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clients.Add(new Client
                        {
                            Id = reader.GetInt32("ID_Клиента"),
                            Name = reader.GetString("ФИО"),
                            Number = reader.GetInt32("Number")
                        });
                    }
                }
            }

            connection.Close();
        }

        DataGrid.ItemsSource = Clients;
    }

    private List<Client> Clients { get; set; }
    private MySqlConnectionStringBuilder _connection;

    public MainWindow()
    {
        InitializeComponent();
        Clients = new List<Client>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro1_8",
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
      //  var g = new EditingWindow();
        //g.Show();
    }
}
