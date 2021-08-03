using System.ComponentModel.DataAnnotations;

namespace LA.Domain
{
    public class IEntity
	{
		[ScaffoldColumn(false)]
		[Key]
		public int ID { get; set; }
	}
}
