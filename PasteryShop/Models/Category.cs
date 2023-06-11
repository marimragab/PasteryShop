﻿namespace PasteryShop.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string Name { get; set; } = String.Empty;

		public string? Description { get; set; }

        public List<Pie>? Pies { get; set; }
	}
}