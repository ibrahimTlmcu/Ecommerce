using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DtoLayer.MessageDtos
{
    class ResultSendBoxMessageDto
    {
        public int UserMessageId { get; set; }
        public string SendedId { get; set; }

        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }

        public bool IsRead { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
