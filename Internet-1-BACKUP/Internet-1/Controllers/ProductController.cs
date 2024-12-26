using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Internet_1.Models;
using Internet_1.Repositories;
using Internet_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_1.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        public ProductController(ProductRepository productRepository, CategoryRepository categoryRepository, IMapper mapper, INotyfService notyf)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var productModels = _mapper.Map<List<ProductModel>>(products);
            return View(productModels);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesSelectList = categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Categories = categoriesSelectList;

            // Türkiye'nin tüm şehirleri
            ViewBag.Cities = new List<SelectListItem>
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model, IFormFile PhotoUrl)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAllAsync();
                var categoriesSelectList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                ViewBag.Categories = categoriesSelectList;
                return View(model);
            }

            try
            {
                if (PhotoUrl != null && PhotoUrl.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userPhotos");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(PhotoUrl.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await PhotoUrl.CopyToAsync(fileStream);
                    }

                    model.PhotoUrl = "/userPhotos/" + uniqueFileName;
                }

                var productEntity = _mapper.Map<Product>(model);
                productEntity.City = model.City;
                await _productRepository.AddAsync(productEntity);
                _notyf.Success("İlan başarıyla eklendi.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hata: {ex.Message}");
                var categories = await _categoryRepository.GetAllAsync();
                var categoriesSelectList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                ViewBag.Categories = categoriesSelectList;
                return View(model);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesSelectList = categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            // Türkiye'nin tüm şehirleri
            ViewBag.Cities = new List<SelectListItem>
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
            ViewBag.Categories = categoriesSelectList;
            var product = await _productRepository.GetByIdAsync(id);
            var productModel = _mapper.Map<ProductModel>(product);
            return View(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel model, IFormFile PhotoUrl)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAllAsync();
                var categoriesSelectList = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                ViewBag.Categories = categoriesSelectList;
                return View(model);
            }

            var product = await _productRepository.GetByIdAsync(model.Id);
            if (product == null)
            {
                _notyf.Error("İlan bulunamadı.");
                return RedirectToAction("Index");
            }

            if (PhotoUrl != null && PhotoUrl.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userPhotos");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(PhotoUrl.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoUrl.CopyToAsync(fileStream);
                }

                product.PhotoUrl = "/userPhotos/" + uniqueFileName;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.IsActive = model.IsActive;
            product.CategoryId = model.CategoryId;
            product.City = model.City;
            product.Updated = DateTime.Now;

            await _productRepository.UpdateAsync(product);
            _notyf.Success("İlan başarıyla güncellendi.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                _notyf.Error("İlan bulunamadı.");
                return RedirectToAction("Index");
            }
            var productModel = _mapper.Map<ProductModel>(product);
            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    _notyf.Error("İlan bulunamadı.");
                    return RedirectToAction("Index");
                }

                await _productRepository.DeleteAsync(id);
                _notyf.Success("İlan başarıyla kaldırıldı.");
                return RedirectToAction("Add");
            }
            catch (Exception ex)
            {
                _notyf.Error($"İlan kaldırılırken bir hata oluştu: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}
