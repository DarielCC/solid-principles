using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public class Cliente {
    public int ClienteId { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string CPF { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Cliente(string nome, string email, string cpf) {
        ClienteId = Random.Next();
        Nome = nome;
        Email = email;
        CPF = cpf;
        DataCadastro = DateTime.Now();
    }

    public void Validar(){
        if(!Email.Contains("@")){
            throw new ArgumentException("O email do cliente é inválido");
        }

        if(CPF.Length != 11){
            throw new ArgumentException("O cpf do cliente é inválido");
        }
    }
}

public interface IClienteWriteRepository  {
    public void Adicionar(Cliente cliente);
}

public interface IClienteReadRepository  {
    public IEnurable<Cliente> Listar();
}

public class ClienteWriteRepository : IClienteWriteRepository {
    public void AdicionarCliente(Cliente cliente) {
        using (var cn = new SqlConnection()){
            var cmd = new SqlCommand();

            cmd.ConnectionString = "TesteConexao";
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CLIENTE (CLIENTEID, NOME, EMAIL CPF, DATACADASTRO) VALUES (@clienteId, @nome, @email, @cpf, @dataCad))";

            cmd.Parameters.AddWithValue("clienteId", cliente.ClienteId);
            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("dataCad", cliente.DataCadastro);

            nc.OpenConnection();
            cmd.ExecuteNonQuery();
        }
    }
}

public class ClienteReadRepository : IClienteReadRepository {

    public IEnumerable<Cliente> Listar() {
        return new List<Cliente>(); 
    }
}

public class ClienteService {
    private readonly IClienteWriteRepository _clienteWriteRepository;
    private readonly IClienteReadRepository _clienteReadRepository;
    private readonly IEmailService _emailService;

    public ClienteService(IEmailService emailService, IClienteWriteRepository clienteWriteRepository, IClienteReadRepository clienteReadRepository) {
        _clienteWriteRepository = clienteWriteRepository;
        _clienteReadRepository = clienteReadRepository;
        _emailService = emailService;
    }

    public void AdicionarCliente(string nome, string email, string cpf) {
        var cliente = new Cliente(nome, email, cpf);
        cliente.Validar();

        _clienteWriteRepository.AdicionarCliente(cliente);
        _emailService.EnviarEmail(cliente.Email);
    }

    public IEnumerable<Cliente> ListarCliente() {
        return _clienteReadRepository.Listar();
    }
}

public interface IEmailService {
    void EnviarEmail(string email);
}

public class EmailService : IEmailService {
    public void EnviarEmail(string email) {
        var mail = new MailMessage("teste@.com", email);
        var client = new SmptClient {
            Port = 25,
            Host = "smtp.google.com",
            DeliveryMethod = SmptDeliveryMethod.Network,
        };

        mail.Subject = "Novo usuario criado";
        mail.Body = "Parabens, bem-vindo";
        client.Send(mail);
    }
}