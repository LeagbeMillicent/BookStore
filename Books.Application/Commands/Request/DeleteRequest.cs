using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Commands.Request
{
    public class DeleteRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
