using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasteryShop.Models
{
	public class Pie
	{
        public int PieId { get; set; }

		[Required]
        public string Name { get; set; } = String.Empty;

		public string? ShortDescription{ get; set; } 

        public string? LongDescription { get; set; }

		[Required]
		public decimal Price { get; set; }	

		public string? ImageUrl { get; set; }

		[Required]
		public bool IsPieOfTheWeek { get; set; }

		[Required]
		public bool InStock { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		public Category Category { get; set; } = default!;
	}
}
