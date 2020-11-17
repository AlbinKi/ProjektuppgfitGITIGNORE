using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public string UserName { get; set; }
        

        public IncorrectPasswordException() { }
        public IncorrectPasswordException(string message) : base(message) { }

        public IncorrectPasswordException(string message, Exception inner)
        : base(message, inner) { }

        public IncorrectPasswordException(string message, string userName)
        : this(message)
        {
            UserName = userName;
        }

    }
}
