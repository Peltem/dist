using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Dist;

public partial class AddWindow : Window
{
    private readonly Client _clients;
    public AddWindow(Client client)
    {
        _clients = client;
        InitializeComponent();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        string _connString = "server=10.10.1.24;database=pro1_8;User Id=user_01;password=user01pro";
        List<Client> _clients;
        MySqlConnection _connection;
        string sql = "INSERT Клиенты SET ФИО = @AddName, Number = @AddNumber, WHERE ID_Клиента = @Id;";
        _clients = new List<Client>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@Id", MySqlDbType.Int32);
        command.Parameters["@Id"].Value = this._clients.Id;
        command.Parameters.Add("@AddName", MySqlDbType.VarChar);
        command.Parameters["@AddName"].Value = AddName.Text;
        command.Parameters.Add("@AddNumber", MySqlDbType.Int32);
        command.Parameters["@AddNumber"].Value = AddNumber.Text;


    }
}