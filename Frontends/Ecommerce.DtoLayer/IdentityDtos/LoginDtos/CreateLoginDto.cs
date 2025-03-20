using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DtoLayer.IdentityDtos.LoginDtos
{
    public class CreateLoginDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
