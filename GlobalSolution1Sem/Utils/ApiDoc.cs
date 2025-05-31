namespace GlobalSolution1Sem.Utils
{
    public static class ApiDoc
    {
        public const string CadastrarEnderecoSummary = "Cadastra um novo endereço";
        public const string CadastrarEnderecoDescription = "Recebe os dados de um endereço e armazena no sistema. Campos obrigatórios: CEP, logradouro, número e bairro.";

        public const string AtualizarEnderecoSummary = "Atualiza um endereço existente";
        public const string AtualizarEnderecoDescription = "Atualiza todos os campos de um endereço existente. O ID na URL deve corresponder ao ID no corpo da requisição.";

        public const string RemoverEnderecoSummary = "Remove um endereço";
        public const string RemoverEnderecoDescription = "Remove permanentemente um endereço do sistema. Requer o ID do endereço.";

        public const string BuscarEnderecoPorIdSummary = "Obtém um endereço por ID";
        public const string BuscarEnderecoPorIdDescription = "Retorna todos os detalhes de um endereço específico com base no seu ID único.";

        public const string ObterEnderecoPorCepNumeroSummary = "Obtém um endereço por CEP e número";
        public const string ObterEnderecoPorCepNumeroDescription = "Busca um endereço específico combinando CEP (8 dígitos) e número do imóvel. Ambos os parâmetros são obrigatórios.";

        public const string ListarTodosEnderecosSummary = "Lista todos os endereços";
        public const string ListarTodosEnderecosDescription = "Retorna uma lista paginada com todos os endereços cadastrados no sistema.";

        public const string CriarPostSummary = "Cria novo post";
        public const string CriarPostDescription = "Registra um novo post no sistema";

        public const string AtualizarPostSummary = "Atualiza post";
        public const string AtualizarPostDescription = "Edita um post existente";

        public const string RemoverPostSummary = "Remove post";
        public const string RemoverPostDescription = "Exclui permanentemente um post";

        public const string BuscarPorUsuarioIdSummary = "Posts por usuário";
        public const string BuscarPorUsuarioIdDescription = "Lista todos os posts de um usuário";

        public const string ListarTodosPostsSummary = "Lista posts";
        public const string ListarTodosPostsDescription = "Retorna todos os posts cadastrados";

        public const string BuscarPostPorIdSummary = "Busca post por ID";
        public const string BuscarPostPorIdDescription = "Obtém detalhes de um post específico";

        public const string CadastrarUsuarioSummary = "Cadastra usuário";
        public const string CadastrarUsuarioDescription = "Cria um novo registro de usuário";

        public const string AtualizarUsuarioSummary = "Atualiza usuário";
        public const string AtualizarUsuarioDescription = "Edita informações de um usuário existente";

        public const string RemoverUsuarioSummary = "Remove usuário";
        public const string RemoverUsuarioDescription = "Exclui um usuário do sistema";

        public const string ObterUsuarioPorCpfSummary = "Busca por CPF";
        public const string ObterUsuarioPorCpfDescription = "Obtém usuário pelo número de CPF";

        public const string ListarTodosUsuariosSummary = "Lista usuários";
        public const string ListarTodosUsuariosDescription = "Retorna todos os usuários cadastrados";

        public const string BuscarUsuarioPorIdSummary = "Busca por ID";
        public const string BuscarUsuarioPorIdDescription = "Obtém usuário pelo ID";
    }
}
