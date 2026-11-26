using cadastro_clientes.Model;
using cadastro_clientes.Services;
using Microsoft.AspNetCore.Mvc;
namespace cadastro_clientes.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly ClientesService _clientesService;
    public ClientesController(ClientesService clientesService)
    {
        _clientesService = clientesService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> Listar()
    {
        List<Cliente> produtos = await _clientesService.ListarAsync();
        return Ok(produtos);
    }
}