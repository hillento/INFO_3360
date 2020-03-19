using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
  public class Genre
  {
    public virtual int GenreId { get; set; }
    [Required]
    [StringLength(900,MinimumLength =2)]
    public virtual string Name { get; set; }

    [StringLength(900, MinimumLength = 2)]
    public virtual string Description { get; set; }
    public virtual List<Album> Albums { get; set; }
  }
}