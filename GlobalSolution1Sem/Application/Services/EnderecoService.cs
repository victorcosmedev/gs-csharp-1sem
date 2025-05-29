using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public Task<EnderecoDto> AtualizarEnderecoAsync(EnderecoDto endereco)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDto?> BuscarEnderecoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDto> CadastrarEnderecoAsync(EnderecoDto endereco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoDto>> ListarTodosEnderecosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDto?> ObterEnderecoPorCepNumeroAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverEnderecoAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }
    }
}
