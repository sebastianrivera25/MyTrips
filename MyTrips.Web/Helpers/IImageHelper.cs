using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Helpers
{
    interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);

    }
}
