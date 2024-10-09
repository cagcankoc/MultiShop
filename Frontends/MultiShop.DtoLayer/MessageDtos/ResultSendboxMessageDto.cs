﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.MessageDtos
{
    public class ResultSendboxMessageDto
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
    }
}
