﻿ using System;
using Newtonsoft.Json;

namespace OnionArc.Application.Exceptions
{
	public class ExceptionModel : ErrorStatusCode
    {
		public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}

