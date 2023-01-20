using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Dtos.Response
{
    internal class UserSelectResponseDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
    }
}
