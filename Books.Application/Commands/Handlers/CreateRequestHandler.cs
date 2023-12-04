using AutoMapper;
using Books.Application.Commands.Request;
using Books.Application.DTOs;
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
    public class CreateRequestHandler : IRequestHandler<CreateRequest, int>
    {
        private readonly IGenericRepository<CreateDTO> _repository;

        private readonly IMapper _mapper;
        public CreateRequestHandler(IGenericRepository<CreateDTO> repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<Book>(request);
            FormattableString query = $"[dbo].[AddRecordsProcedure] @bookName = {dto.name}";
            var result = await _repository.Add(query);
            return result ;
        }
    }
}
