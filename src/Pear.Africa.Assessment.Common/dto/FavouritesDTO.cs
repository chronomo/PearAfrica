using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using AutoMapper.Configuration.Annotations;
using System.Text;

namespace Pear.Africa.Assessment.Common.Dtos
{
    public class FavouriteDTO
    {
        public int Id { get; set; }
        public int? FaveId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Collection<FavouriteDTO> favourites { get; set; }
    }

    public class AddFavouriteDTO
    {
        public int? FaveId { get; set; }
        [StringLength(25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
    }
    public class EditFavouriteDTO
    {
        public int Id { get; set; }
        public int? FaveId { get; set; }
        [StringLength(25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
    } 
}
