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



        //totals method joins the requestlines and products table
        //recalculates method
        //this method needs to flow into the other methods for this class
        private void RecalculateRequestTotal(int requestId) {
            var request = _context.Requests.Find(requestId);

            //new total
            request.Total = (from rl in _context.RequestLines
                             join p in _context.Products
                             //on clause shows how they are put together
                             on rl.ProductId equals p.Id
                             //dont want all lines so we use a where clause
                             where rl.RequestId == requestId
                             //select columns says what we want to output
                             //we dont want data of columns, just the data of the calculation. which is why
                             //we use new
                             select new {
                                 //linetotal is a fred variable
                                 LineTotal = rl.Quantity * p.Price
                             }).Sum(x => x.LineTotal);
            _context.SaveChanges();
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
            RecalculateRequestTotal(requestline.RequestId);
            return requestline;
        }

        public void Change(RequestLine requestline) {
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
        }

        public void Remove(int id) {
            var requestline = _context.RequestLines.Find(id);
            if (requestline is not null) {
                throw new Exception("request not found");
            }
            _context.Remove(requestline);
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
        }
    }
}
