namespace cadastro_clientes.Model;

/* 
    Representa uma venda realizada pela aplicação.

    A entidade Venda concentra os dados principais
    da operação de venda e protege o estado do objeto
    por meio de propriedades com validação.

    Ela também mantém em memória a lista de itens
    associados à venda.

    Essa classe não executa comandos SQL
    e não acessa diretamente o banco de dados.
*/
public class Cliente
{
    private int _idCliente;
    private string _nomeCliente = "";
    private string _cpfCliente = "";
    private string _emailCliente = "";
    private string _telefoneCliente = "";
    private DateOnly _dataNascimentoCliente;
    private bool _ativoCliente;
    public Cliente(string nome, string cpf, string email, string telefone, DateOnly data_nascimento, bool ativo)
    {
        this.NomeCliente = nome;
        this.CpfCliente = cpf;
        this.EmailCliente = email;
        this.TelefoneCliente = telefone;
        this.DataNascimento = data_nascimento;
        this.AtivoCliente = ativo;
    }
    public Cliente(int idCliente, string nome, string cpf, string email, string telefone, DateOnly data_nascimento, bool ativo)
    {
        this.IdCliente = idCliente;
        this.NomeCliente = nome;
        this.CpfCliente = cpf;
        this.EmailCliente = email;
        this.TelefoneCliente = telefone;
        this.DataNascimento = data_nascimento;
        this.AtivoCliente = ativo;
    }

    public int IdCliente
    {
        get
        {
            return _idCliente;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "O identificador não pode ser negativo."
                );
            }
            _idCliente = value;
        }
    }


    public string NomeCliente
    {
        get { return _nomeCliente; }
        private set { _nomeCliente = value; }
    }
    public string CpfCliente
    {
        get { return _cpfCliente; }
        set { _cpfCliente = value; }
    }
    public string EmailCliente
    {
        get { return _emailCliente; }
        set { _emailCliente = value; }
    }
    public string TelefoneCliente
    {
        get { return _telefoneCliente; }
        set { _telefoneCliente = value; }
    }
    public DateOnly DataNascimento
    {
        get { return _dataNascimentoCliente; }
        set { _dataNascimentoCliente = value; }
    }
    public bool AtivoCliente
    {
        get { return _ativoCliente; }
        set { _ativoCliente = value; }
    }
}