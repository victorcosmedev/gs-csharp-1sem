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
    }
}
