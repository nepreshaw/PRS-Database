using PRS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library.Controllers {
    public class ProductsController {

        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context) {
            this._context = context;
        }

        public IEnumerable<Product> GetAll() {
            return _context.Products.ToList();
        }

        public Product GetByPk(int id) {
            return _context.Products.Find(id);
        }

        public Product Create(Product product) {
            if(product is null) {
                throw new ArgumentNullException("Product can't be null");
            }
            if( product.Id != 0) {
                throw new ArgumentNullException("Id can't be zero");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Change(Product product) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var product = _context.Products.Find(id);
            if(product is null) {
                throw new Exception("product not found");
            }
            _context.Remove(product);
            _context.SaveChanges();
        }

    }
}
