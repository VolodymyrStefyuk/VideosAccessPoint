﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace VideosAccessPoint.Domain.Entities
{
    public class VideoInfo : EntityBase
    {
        public VideoInfo()
        {
            DateAdded = DateTime.UtcNow;
        }

        public VideoInfo(string userName)
        {
            UserName = userName;
            DateAdded = DateTime.UtcNow;
        }

        [Required]
        [Url]
        [Display(Name = "Посилання на відео")]
        public string VideoLink { get; set; }

        [Required]
        [Display(Name = "Автор")] 
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Дата завантаження")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Жанр ")]
        public String Genre { get; set; }
    }
}
