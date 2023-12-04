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
    public class UpdateRequestHandler : IRequestHandler<UpdateRequest, int>
    {
        private readonly IGenericRepository<Book> _repository;

        private readonly IMapper _mapper;

        public UpdateRequestHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Book>(_repository);
            FormattableString query = $"[dbo].[UpdateRecordsProcedure]@id = {map.bookId}, @bookName = {map.name}, @bookCategory = {map.category}, @bookPrice = {request.UpdateDTO.price}, @bookDescription = {request.UpdateDTO.description}";

            var result = await _repository.Update(query);

            if (result == 0)
            {
                return 0;
            }
            return result;
        }
    }
}
