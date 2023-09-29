using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace Dist;

public partial class StudentsWindow : Window
{
    private void UpdateDataGrid2()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `student`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students.Add( new Student
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            GroupId = reader.GetInt32("group_id")
                        });
                    }
                }
            }
            connection.Close();
        }

        DataGrid2.ItemsSource = Students;
    }
    private List<Student> Students { get; set; }
    private MySqlConnectionStringBuilder _connection;
    public StudentsWindow()
    {
        InitializeComponent();
        Students = new List<Student>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro10",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid2();

    }
}