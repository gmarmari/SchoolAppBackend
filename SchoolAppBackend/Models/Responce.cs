using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAppBackend.Models
{
    public class Responce
    {

        public bool Success { get; set; } = false;

        public bool IsError => Error != null;

        public bool IsWarning => !string.IsNullOrEmpty(Warning);

        public string Warning { get; set; } = null;

        public Exception Error { get; set; } = null;

    }
}
