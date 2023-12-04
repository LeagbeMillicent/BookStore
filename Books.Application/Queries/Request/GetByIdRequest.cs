using Books.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Queries.Request
{
    public class GetByIdRequest : IRequest<IReadOnlyList<ReadBookDTO>>
    {
        public int Id { get; set; }

    }
}
