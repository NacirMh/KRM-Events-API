﻿using KRM_Events_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Hashtags")]
    public class Hashtag
    {
        [Key]
        public int Id { get; set; }

     
        public string HashTagName { get; set; } = string.Empty;

        
        public string HashTagDescription { get; set; } = string.Empty;

        public virtual List<EventHashtag> EventHashtags { get; set; } = new List<EventHashtag>();


    }
}
