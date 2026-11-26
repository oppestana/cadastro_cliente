using cadastro_clientes.Data;
using cadastro_clientes.Model;
using Npgsql;
namespace cadastro_clientes.Repositories;


public class ClientesRepository
{
    private readonly ConexaoBanco _conexaoBanco;
    public ClientesRepository(ConexaoBanco conexaoBanco)
    {
        _conexaoBanco = conexaoBanco;
    }
    public async Task<List<Cliente>> ListarAsync()
    {
        List<Cliente> clientes = new();
        Dictionary<int, Cliente> clientesPorId = new();
        await using NpgsqlConnection conexao =
                    await _conexaoBanco.CriarConexaoAsync();

        string sql = """
            SELECT 
                p.id_cliente,
                p.nome,
                p.cpf,
                p.email,
                p.telefone,
                p.data_nascimento,
                p.ativo
            FROM cliente AS p
            ORDER BY
                p.nome ASC;
            """;

        await using NpgsqlCommand comando =
            new NpgsqlCommand(sql, conexao);

        await using NpgsqlDataReader leitor =
            await comando.ExecuteReaderAsync();
        int colunaIdCliente = leitor.GetOrdinal("id_cliente");
        int colunaNomeCliente = leitor.GetOrdinal("nome");
        int colunaCpfCliente = leitor.GetOrdinal("cpf");
        int colunaEmailCliente = leitor.GetOrdinal("email");
        int colunaTelefoneCliente = leitor.GetOrdinal("telefone");
        int colunaDataNascimentoCliente = leitor.GetOrdinal("data_nascimento");
        int colunaAtivoCliente = leitor.GetOrdinal("ativo");
        while (await leitor.ReadAsync())
        {
            Cliente cliente = new Cliente
            (
                leitor.GetInt32(colunaIdCliente),
                leitor.GetString(colunaNomeCliente),
                leitor.GetString(colunaCpfCliente),
                leitor.GetString(colunaEmailCliente),
                leitor.GetString(colunaTelefoneCliente),
                leitor.GetFieldValue<DateOnly>(colunaDataNascimentoCliente),
                leitor.GetBoolean(colunaAtivoCliente)
            );

            clientes.Add(cliente);
        }
        return clientes;
    }
}