using cadastro_clientes.Model;
using cadastro_clientes.Repositories;
namespace cadastro_clientes.Services;

public class ClientesService
{

    private readonly ClientesRepository _clientesRepository;
    public ClientesService(ClientesRepository clientesRepository)
    {
        _clientesRepository = clientesRepository;
    }
    public async Task<List<Cliente>> ListarAsync()
    {
        return await _clientesRepository.ListarAsync();
    }
}