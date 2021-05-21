using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Headhunter.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}