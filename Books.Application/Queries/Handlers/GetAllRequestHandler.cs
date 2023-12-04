using AutoMapper;
using Books.Application.DTOs;
using Books.Application.Queries.Request;
using Books.Application.Repository;
using Books.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Queries.Handlers
{
    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, IReadOnlyList<ReadBookDTO>>
    {
        private readonly IGenericRepository<Book> _repository;

        private readonly IMapper _mapper;

        public GetAllRequestHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ReadBookDTO>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var response = $"[dbo].[ReadRecordsProcedure]";

            var result = await _repository.GetAllAsync(response);

            return _mapper.Map<IReadOnlyList<ReadBookDTO>>(result);
        }
    }
}
