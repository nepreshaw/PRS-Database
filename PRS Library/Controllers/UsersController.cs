using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library.Controllers {
    public class UsersController {
        //can only give _context a value in the constructor, no methods can change it
        private readonly AppDbContext _context;

        //take the value of context and store it in _context
        public UsersController(AppDbContext context) {
            this._context = context;
        }

        //5 standard functions with controllers. two read options, insert, update, delete(maitenance funct.)

        //IEnumerable cantains most interface options
        //.ToList returns everything to a list
        public IEnumerable<User> GetAll() {
           return _context.Users.ToList(); 
        }

        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }

        public User Create(User user) {
            if(user is null) {
                throw new ArgumentNullException("user");
            }
            if(user.Id != 0) {
                throw new ArgumentNullException("User.Id must be zero");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Change(User user) {
            _context.SaveChanges();
        }
        
        public void Remove(int id) {
            var user = _context.Users.Find(id);
            if(user is null) {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}
