using Books.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Commands.Request
{
    public class UpdateRequest : IRequest<int>
    {
        public UpdateDTO UpdateDTO { get; set; }
    }
}
