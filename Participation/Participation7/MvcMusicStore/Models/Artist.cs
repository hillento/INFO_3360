using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
  public class Artist
  {
    public virtual int ArtistId { get; set; }
    [Required]
    [StringLength(900,MinimumLength = 2)]
    public virtual string Name { get; set; }
  }
}