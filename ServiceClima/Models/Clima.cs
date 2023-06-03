using System.ComponentModel.DataAnnotations;

namespace ServiceClima.Models
{
	public class Clima
	{
		public int Id { get; set; }
		[Required]
		public string Ciudad { get; set; }
		[Required]
		public double Temperatura { get; set; }
		[Required]
		public double Humedad { get; set; }
	}

}
