using DreamWeddsManager.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DreamWeddsManager.Application.Interfaces.Chat;
using DreamWeddsManager.Application.Models.Chat;

namespace DreamWeddsManager.Infrastructure.Models.Identity
{
    public class BlazorHeroUser : IdentityUser<string>, IChatUser, IAuditableEntity<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CreatedBy { get; set; }

        [Column(TypeName = "text")]
        public string ProfilePictureDataUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        [NotMapped]
        public string Site { get; set; }
        [NotMapped]
        public string DisplayName { get; set; }
        public virtual ICollection<ChatHistory<BlazorHeroUser>> ChatHistoryFromUsers { get; set; }
        public virtual ICollection<ChatHistory<BlazorHeroUser>> ChatHistoryToUsers { get; set; }
        public virtual ICollection<BlazorHeroRole> UserRoles { get; set; }

        public BlazorHeroUser()
        {
            ChatHistoryFromUsers = new HashSet<ChatHistory<BlazorHeroUser>>();
            ChatHistoryToUsers = new HashSet<ChatHistory<BlazorHeroUser>>();
        }
    }
}