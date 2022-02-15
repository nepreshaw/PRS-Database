using Microsoft.EntityFrameworkCore;
using PRS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library.Controllers {
    public class RequestsController {

        private readonly AppDbContext _context;

        public RequestsController(AppDbContext context) {
            this._context = context;
        }

        public IEnumerable<Request> GetAll() {
            return _context.Requests.Include(x => x.User).ToList();
        }

        public Request GetByPk(int id) {
            return _context.Requests.Include(x => x.User)
                            .SingleOrDefault(x => x.Id == id);
        }

        public Request Create(Request request) {
            if(request is null) {
                throw new ArgumentNullException("Request can't be null");
            }
            if(request.Id != 0) {
                throw new ArgumentNullException("Id");
            }
            _context.Add(request);
            _context.SaveChanges();
            return request;
        }

        public void Change(Request request) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var request = _context.Requests.Find(id);
            if(request is not null) {
                throw new Exception("request not found");
            }
            _context.Remove(request);
            _context.SaveChanges();
        }   
    }
}
