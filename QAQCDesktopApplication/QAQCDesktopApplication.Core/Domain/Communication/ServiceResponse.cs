﻿using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Communication
{
    public class ServiceResponse
    {
        public bool Success { get; protected set; }
        public Error Error { get; protected set; }

        protected ServiceResponse()
        {
        }

        public ServiceResponse(bool success, Error error)
        {
            Success = success;
            Error = error;
        }

        public static ServiceResponse Failed(Error error)
        {
            return new ServiceResponse(false, error);
        }

        public static ServiceResponse Successful()
        {
            return new ServiceResponse(true, null);
        }
    }

}
