using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class Shipment
  {
    public int ShipmentId { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Label Date")]
    public DateTime LabelDate { get; set; } = DateTime.Now;

    [Display(Name = "Tracking Number")]
    public string TrackingNumber { get; set; }

    [Display(Name = "Number of Shirts")]
    public int NumberOfShirts { get; set; }

    public string Notes { get; set; }

    public string Status { get; set; }
  }
}