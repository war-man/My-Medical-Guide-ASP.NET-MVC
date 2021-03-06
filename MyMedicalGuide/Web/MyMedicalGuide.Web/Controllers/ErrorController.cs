﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }

        public ViewResult ServerError()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }
    }
}
