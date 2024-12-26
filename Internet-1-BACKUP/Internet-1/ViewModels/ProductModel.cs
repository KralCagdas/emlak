using System.ComponentModel.DataAnnotations;

namespace Internet_1.ViewModels
{
    public class ProductModel : BaseModel
    {
        [Display(Name = "İlanın Adı")]
        [Required(ErrorMessage = "İlanın adını giriniz.")]
        public string Name { get; set; }

        [Display(Name = "Numara")]
        [Required(ErrorMessage = "İlana numara ekleyiniz.")]
        public string Description { get; set; }

        [Display(Name = "İlanın Fiyatı")]
        [Required(ErrorMessage = "İlanın fiyatını giriniz.")]
        public decimal Price { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori Giriniz!")]
        public int CategoryId { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Şehir Giriniz!")]
        public string City { get; set; }

        [Display(Name = "Fotoğraf")]
        public string PhotoUrl { get; set; } = "no-img.png";
    }
}
