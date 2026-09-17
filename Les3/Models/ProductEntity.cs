using System.ComponentModel.DataAnnotations;

namespace Les3.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва товару є обов'язковою")]
        [StringLength(100, ErrorMessage = "Назва не може бути довшою за 100 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажіть ціну")]
        [Range(0.01, 100000.00, ErrorMessage = "Ціна повинна бути більшою за 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Укажіть кількість")]
        [Range(0, 10000, ErrorMessage = "Кількість не може бути від'ємною")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Вкажіть категорію")]
        [StringLength(50, ErrorMessage = "Категорія не може бути довшою за 50 символів")]
        public string Category { get; set; }
    }
}