using AutoMapper;
using Books.Application.Commands.Request;
using Books.Application.Repository;
using Books.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Commands.Handlers
{
    public class DeleteRequestHandler : IRequestHandler<DeleteRequest, int>
    {
        private readonly IGenericRepository<Book> _repository;

        private readonly IMapper _mapper;

        public DeleteRequestHandler(IGenericRepository<Book> repository, IMapper mapper) 
        {
            _repository = repository;
                _mapper = mapper;
        }
        public async Task<int> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            FormattableString query = $"[dbo].[DeleteRecordsProcedure] @id ={request.Id}";

            var response = await _repository.Delete(query);

            if (response == null)
                return 0;
            return 1;
        }
    }
}
