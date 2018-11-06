using System;

namespace FirstTestApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string ExMessage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}