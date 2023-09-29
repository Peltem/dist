using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Dist;

public partial class EditingWindow : Window
{
    private readonly Group _group;
    public EditingWindow(Group group)
    {

        _group = group;
        InitializeComponent();
    }

    private void EditBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        string _connString = "server=10.10.1.24;database=pro1_23;User Id=user_01;password=user01pro";
        List<Group> _group;
        MySqlConnection _connection;
        string sql="UPDATE groups SET name = @namebox, WHERE id = @Id";
        _group = new List<Group>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@Id", MySqlDbType.Int32);
        command.Parameters["@Id"].Value = this._group.Id;
        command.Parameters.Add("@namebox", MySqlDbType.VarChar);
        command.Parameters["@namebox"].Value = namebox.Text;
    }
}