using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS_Library.Models;

namespace PRS_Library.Controllers {
    public class RequestsLineController {
        private readonly AppDbContext _context;

        public RequestsLineController(AppDbContext context) {
            this._context = context;
        }

        public IEnumerable<RequestLine> GetAll() {
            return _context.RequestLines.Include(x => x.Product).Include(x => x.Request).ToList();
        }

        public RequestLine GetByPk(int id) {
            return _context.RequestLines.Include(x => x.Product).Include(x => x.Request)
                    .SingleOrDefault(x => x.Id == id);

        }

        public RequestLine Create(RequestLine requestline) {
            if (requestline is null) {
                throw new ArgumentNullException("Request can't be null");
            }
            if (requestline.Id != 0) {
                throw new ArgumentNullException("Id");
            }
            _context.Add(requestline);
            _context.SaveChanges();
            return requestline;
        }

        public void Change(RequestLine requestline) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var requestline = _context.RequestLines.Find(id);
            if (requestline is not null) {
                throw new Exception("request not found");
            }
            _context.Remove(requestline);
            _context.SaveChanges();
        }
    }
}
