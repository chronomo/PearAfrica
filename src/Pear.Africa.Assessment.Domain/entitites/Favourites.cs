using Pear.Africa.Assessment.Common.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Pear.Africa.Assessment.Domain.Entities
{
    public class Favourites
    {
        public int Id { get; set; }

        [Required]
        [MinLength(25)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(25)]
        [MaxLength(100)]
        public string Slug { get => StringExtension.FriendlyUrl(Title); set =>  Title = value; }

        [Required]
        [MinLength(1000)]
        [MaxLength(10000)]
        public string SeriesDesc { get; set; }

        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Created { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Updated { get; set; }

    }
}
