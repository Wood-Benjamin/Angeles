using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MegaDeskWeb_Angeles.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        [Display(Name = "Customer Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a valid date, 'MM/DD/YYYY'.")]
        public DateTime QuoteDate { get; set; }

        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96 inches.")]
        [Required(ErrorMessage = "Width is required.")]
        public int Width { get; set; }

        [Range(12, 48, ErrorMessage = "Width must be between 12 and 48 inches.")]
        [Required(ErrorMessage = "Depth is required.")]
        public int Depth { get; set; }

        [Range(0, 7, ErrorMessage = "Number of drawers must be between 0 and 7.")]
        [Required(ErrorMessage = "Number of drawers is required.")]
        public int Drawers { get; set; }

        //[Required(ErrorMessage = "Please select a material.")]
        public string Material = "Pine";

        //[Required(ErrorMessage = "Please select a deliver time.")]
        public int Rush = 0;
        public int SurfaceArea => Width * Depth;
        public int MaterialCost = 200;
        public int SurfaceAreaCost { get; set; }
        public int DrawerCost { get; set; }
        public int RushCost { get; set; }
        public int QuoteTotal { get; set; }

        public const int BASEPRICE = 200;
        public const int BASESURFACE = 1000;
        public const int OVERSURFACE = 1;
        public const int LARGESURFACE = 2000;
        public int calDrawerCost() => Drawers * 50;
        public int calQuoteTotal() => BASEPRICE + calDrawerCost() + calSurfaceAreaCost();
        public int calSurfaceAreaCost()
        {
            if (SurfaceArea > BASESURFACE)
            {
                return (SurfaceArea - BASESURFACE) * OVERSURFACE;
            }
            else
            {
                return 0;
            }
        }
    }
}
