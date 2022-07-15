using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public class Cliente {
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }

    public string AdicionarCliente() {
        if(!Email.Contains("@")){
            return "Cliente inválido";
        }

        if(CPF.Length != 11){
            "return Cliente com CPF inválido";
        }

        using (var cn = new SqlConnection()){
            var cmd = new SqlCommand();

            cmd.ConnectionString = "TesteConexao";
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL CPF, DATACADASTRO) VALUES (@nome, @email, @cpf, @dataCad))";

            cmd.Parameters.AddWithValue("nome", Nome);
            cmd.Parameters.AddWithValue("email", Email);
            cmd.Parameters.AddWithValue("cpf", CPF);
            cmd.Parameters.AddWithValue("dataCad", DataCadastro);

            nc.OpenConnection();
            cmd.ExecuteNonQuery();
        }

        var mail = new MailMessage("teste@.com", Email);
        var client = new SmptClient {
            Port = 25,
            Host = "smtp.google.com"
        };

        mail.Subject = "Novo usuario criado";
        mail.Body = "Parabens, bem-vindo";
        client.Send(mail);

        return "Cliente foi cadastrado com sucesso";
     }
}