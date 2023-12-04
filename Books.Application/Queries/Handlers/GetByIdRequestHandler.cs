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
    public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, IReadOnlyList<ReadBookDTO>>
    {
        private readonly IGenericRepository<Book> _repository;

        private readonly IMapper _mapper;

        public GetByIdRequestHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ReadBookDTO>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            FormattableString response = $"[dbo].[GetByIdProcedure] @id = {request.Id}";

            var result = await _repository.GetById(response);

            return _mapper.Map<IReadOnlyList<ReadBookDTO>>(result) ;


        }
    }
}
