using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Headhunter.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Headhunter.Models
{
    // model пользователей с использованияем Identity 
    public class User : IdentityUser
    { 
        public string AvatarPath { get; set; }
        public virtual List<ChatMessage> ChatMessages { get; set; }
    }
}