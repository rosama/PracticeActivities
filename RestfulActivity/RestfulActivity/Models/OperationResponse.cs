using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RestfulActivity.Models
{
    public class OperationResponse <T>
    {
        public bool success { get; set; }
        public T result { get; set; }
        public string message { get; set; }
    }
}
