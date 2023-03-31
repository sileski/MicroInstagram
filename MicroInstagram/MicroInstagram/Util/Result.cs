using System;
using System.Collections.Generic;
using System.Text;

namespace MicroInstagram
{
    public abstract class Result<T>
    {
        public T Data { get; }
        public string Error { get; }

        protected Result(T data = default(T), string error = null)
        {
            Data = data;
            Error = error;
        }

        public class Success : Result<T>
        {
            public Success(T data) : base(data: data) { }
        }

        public class Failure : Result<T>
        {
            public Failure(string error) : base(error: error) { }
        }
    }
}
