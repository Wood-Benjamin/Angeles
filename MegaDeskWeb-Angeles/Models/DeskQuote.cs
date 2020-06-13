using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [Display(Name = "# of Drawers")]
        [Range(0, 7, ErrorMessage = "Number of drawers must be between 0 and 7.")]
        [Required(ErrorMessage = "Number of drawers is required.")]
        public int Drawers { get; set; }

        [Display(Name = "Surface Material")]
        [Required(ErrorMessage = "Please select a material.")]
        public string Material { get; set; }

        [Display(Name = "Delivery Time")]
        [Required(ErrorMessage = "Please select a deliver time.")]
        public int Rush { get; set; }
        public int SurfaceArea { get { return Width * Depth; } }

        [Display(Name = "Material Cost ")]
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal MaterialCost { get; set; }

        [Display(Name = "Additional Size Cost")]
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal SurfaceAreaCost { get; set; }

        [Display(Name = "Drawers Cost")]
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal DrawerCost { get; set; }

        [Display(Name = "Delivery Cost")]
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal RushCost { get; set; }

        [Display(Name = "Total Cost")]
        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal QuoteTotal { get; set; }


       

      
    }

}
