using PRS_Library;
using PRS_Library.Controllers;
using System;

namespace PRS_Database {
    class Program {
        static void Main(string[] args) {

            var context = new AppDbContext();

            var userCtrl = new UsersController(context);

            //var newUser = new User() {
            //    Id = 0, Username = "xx", Password = "xx", Firstname = "User", Lastname = "XX", Phone = "211",
            //    Email = "xx@user.com", IsReviewer = false, IsAmin = false
            //};

            //userCtrl.Create(newUser);

            var user3 = userCtrl.GetByPk(3);

            if (user3 is null) {
                Console.WriteLine("User not found");
            } else {
                Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            }
            user3.Lastname = "user3";
            userCtrl.Change(user3);

            userCtrl.Remove(4);

            //calling method we created in controller class
            var users = userCtrl.GetAll();

            foreach(var user in users) {
                Console.WriteLine($"{user.Id} {user.Firstname} {user.Lastname}");
            }


        }
    }
}
