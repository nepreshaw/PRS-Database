using PRS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library.Controllers {
    public class VendorsController {

        private readonly AppDbContext _context;

        public VendorsController(AppDbContext context) {
            this._context = context;
        }

        public IEnumerable<Vendor> GetAll() {
            return _context.Vendors.ToList(); 
        }

        public Vendor GetByPk(int id) {
            return _context.Vendors.Find(id);
        }

        public Vendor Create(Vendor vendor) {
            if(vendor is null) {
                throw new ArgumentNullException("vendor is null");
            }
            if(vendor.Id != 0) {
                throw new ArgumentNullException("vendor.Id must not be 0");
            }
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
            return vendor;
        }

        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if (vendor is null) {
                throw new Exception("user not found");
            }
            _context.Remove(vendor);
            _context.SaveChanges();
        }
    }
}
