using Microsoft.AspNetCore.Mvc;
using Internet_1.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internet_1.Controllers
{
    public class ListingsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ListingsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> All()
        {
            var products = await _productRepository.GetAllWithCategoryAsync();
            ViewBag.Cities = GetCities();

            return View(products);
        }

        public async Task<IActionResult> ForSale()
        {
            var products = await _productRepository.GetProductsByCategoryAsync("Satılık");
            ViewBag.Cities = GetCities();
            return View(products);
        }

        public async Task<IActionResult> ForRent()
        {
            var products = await _productRepository.GetProductsByCategoryAsync("Kiralık");
            ViewBag.Cities = GetCities();
            return View(products);
        }

        private List<SelectListItem> GetCities()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Adana", Value = "Adana" },
                new SelectListItem { Text = "Adıyaman", Value = "Adıyaman" },
                new SelectListItem { Text = "Afyonkarahisar", Value = "Afyonkarahisar" },
                new SelectListItem { Text = "Ağrı", Value = "Ağrı" },
                new SelectListItem { Text = "Amasya", Value = "Amasya" },
                new SelectListItem { Text = "Ankara", Value = "Ankara" },
                new SelectListItem { Text = "Antalya", Value = "Antalya" },
                new SelectListItem { Text = "Artvin", Value = "Artvin" },
                new SelectListItem { Text = "Aydın", Value = "Aydın" },
                new SelectListItem { Text = "Balıkesir", Value = "Balıkesir" },
                new SelectListItem { Text = "Bilecik", Value = "Bilecik" },
                new SelectListItem { Text = "Bingöl", Value = "Bingöl" },
                new SelectListItem { Text = "Bitlis", Value = "Bitlis" },
                new SelectListItem { Text = "Bolu", Value = "Bolu" },
                new SelectListItem { Text = "Burdur", Value = "Burdur" },
                new SelectListItem { Text = "Bursa", Value = "Bursa" },
                new SelectListItem { Text = "Çanakkale", Value = "Çanakkale" },
                new SelectListItem { Text = "Çankırı", Value = "Çankırı" },
                new SelectListItem { Text = "Çorum", Value = "Çorum" },
                new SelectListItem { Text = "Denizli", Value = "Denizli" },
                new SelectListItem { Text = "Diyarbakır", Value = "Diyarbakır" },
                new SelectListItem { Text = "Edirne", Value = "Edirne" },
                new SelectListItem { Text = "Elazığ", Value = "Elazığ" },
                new SelectListItem { Text = "Erzincan", Value = "Erzincan" },
                new SelectListItem { Text = "Erzurum", Value = "Erzurum" },
                new SelectListItem { Text = "Eskişehir", Value = "Eskişehir" },
                new SelectListItem { Text = "Gaziantep", Value = "Gaziantep" },
                new SelectListItem { Text = "Giresun", Value = "Giresun" },
                new SelectListItem { Text = "Gümüşhane", Value = "Gümüşhane" },
                new SelectListItem { Text = "Hakkâri", Value = "Hakkâri" },
                new SelectListItem { Text = "Hatay", Value = "Hatay" },
                new SelectListItem { Text = "Isparta", Value = "Isparta" },
                new SelectListItem { Text = "Mersin", Value = "Mersin" },
                new SelectListItem { Text = "İstanbul", Value = "İstanbul" },
                new SelectListItem { Text = "İzmir", Value = "İzmir" },
                new SelectListItem { Text = "Kars", Value = "Kars" },
                new SelectListItem { Text = "Kastamonu", Value = "Kastamonu" },
                new SelectListItem { Text = "Kayseri", Value = "Kayseri" },
                new SelectListItem { Text = "Kırklareli", Value = "Kırklareli" },
                new SelectListItem { Text = "Kırşehir", Value = "Kırşehir" },
                new SelectListItem { Text = "Kocaeli", Value = "Kocaeli" },
                new SelectListItem { Text = "Konya", Value = "Konya" },
                new SelectListItem { Text = "Kütahya", Value = "Kütahya" },
                new SelectListItem { Text = "Malatya", Value = "Malatya" },
                new SelectListItem { Text = "Manisa", Value = "Manisa" },
                new SelectListItem { Text = "Kahramanmaraş", Value = "Kahramanmaraş" },
                new SelectListItem { Text = "Mardin", Value = "Mardin" },
                new SelectListItem { Text = "Muğla", Value = "Muğla" },
                new SelectListItem { Text = "Muş", Value = "Muş" },
                new SelectListItem { Text = "Nevşehir", Value = "Nevşehir" },
                new SelectListItem { Text = "Niğde", Value = "Niğde" },
                new SelectListItem { Text = "Ordu", Value = "Ordu" },
                new SelectListItem { Text = "Rize", Value = "Rize" },
                new SelectListItem { Text = "Sakarya", Value = "Sakarya" },
                new SelectListItem { Text = "Samsun", Value = "Samsun" },
                new SelectListItem { Text = "Siirt", Value = "Siirt" },
                new SelectListItem { Text = "Sinop", Value = "Sinop" },
                new SelectListItem { Text = "Sivas", Value = "Sivas" },
                new SelectListItem { Text = "Tekirdağ", Value = "Tekirdağ" },
                new SelectListItem { Text = "Tokat", Value = "Tokat" },
                new SelectListItem { Text = "Trabzon", Value = "Trabzon" },
                new SelectListItem { Text = "Tunceli", Value = "Tunceli" },
                new SelectListItem { Text = "Şanlıurfa", Value = "Şanlıurfa" },
                new SelectListItem { Text = "Uşak", Value = "Uşak" },
                new SelectListItem { Text = "Van", Value = "Van" },
                new SelectListItem { Text = "Yozgat", Value = "Yozgat" },
                new SelectListItem { Text = "Zonguldak", Value = "Zonguldak" },
                new SelectListItem { Text = "Aksaray", Value = "Aksaray" },
                new SelectListItem { Text = "Bayburt", Value = "Bayburt" },
                new SelectListItem { Text = "Karaman", Value = "Karaman" },
                new SelectListItem { Text = "Kırıkkale", Value = "Kırıkkale" },
                new SelectListItem { Text = "Batman", Value = "Batman" },
                new SelectListItem { Text = "Şırnak", Value = "Şırnak" },
                new SelectListItem { Text = "Bartın", Value = "Bartın" },
                new SelectListItem { Text = "Ardahan", Value = "Ardahan" },
                new SelectListItem { Text = "Iğdır", Value = "Iğdır" },
                new SelectListItem { Text = "Yalova", Value = "Yalova" },
                new SelectListItem { Text = "Karabük", Value = "Karabük" },
                new SelectListItem { Text = "Kilis", Value = "Kilis" },
                new SelectListItem { Text = "Osmaniye", Value = "Osmaniye" },
                new SelectListItem { Text = "Düzce", Value = "Düzce" }
            };
        }



        [HttpGet]
        public async Task<IActionResult> GetListingsByCity(string city, string category)
        {
            var filteredProducts = await _productRepository.GetAllWithCategoryAsync();

            if (!string.IsNullOrEmpty(city))
            {
                filteredProducts = filteredProducts.Where(p => p.City == city);
            }

            if (!string.IsNullOrEmpty(category))
            {
                filteredProducts = filteredProducts.Where(p => p.Category != null && p.Category.Name == category);
            }

            var result = filteredProducts.Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.PhotoUrl,
                p.City,
                Category = p.Category != null ? p.Category.Name : null,
                Price = p.Price.ToString("C", new System.Globalization.CultureInfo("tr-TR"))
            });

            return Json(result);
        }



    }
}
