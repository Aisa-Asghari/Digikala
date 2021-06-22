using System.ComponentModel.DataAnnotations;

namespace DigikalaDataAccess.Entity
{
    public class Product
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "نام محصول را وارد كنيد")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "قیمت محصول را وارد كنيد")]
        public int ProductPrice { get; set; }
        public string ProductURL { get; set; }
    }
}