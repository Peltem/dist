using System.Collections.Generic;
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
                       Groups.Add( new Group
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
           Server = "localhost",
           Database = "dist",
           UserID = "root",
           Password = "1111"
        };
        UpdateDataGrid();

    }

    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        new StudentsWindow().Show(this);
    }
  //rivate void Button2_OnClick(object? sender, RoutedEventArgs e)
  //
  //   UPDataGrid();
  //
  //
  //rivate void Button3_OnClick(object? sender, RoutedEventArgs e)
  //
  //   throw new System.NotImplementedException();
  //
}
  
