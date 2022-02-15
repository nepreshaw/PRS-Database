using PRS_Library;
using PRS_Library.Controllers;
using PRS_Library.Models;
using System;
using System.Linq;

namespace PRS_Database {
    class Program {
        
        static void Print(Product product) {
            Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12} " +
                $"{product.Price,10:c} {product.Vendor.Name,-15}");
        }

        static void Main(string[] args) {

            var context = new AppDbContext();

            var userCtrl = new UsersController(context);

            var user = userCtrl.Login("sa", "sax");
            if(user is null) {
                Console.WriteLine("user not found");
            } else {
                Console.WriteLine(user.Username);
            }

            //var username = "gdoud";
            //var password = "password";
            //context.Users.SingleOrDefault(x => x.Username == "username" && x.Password == password);

            //using query syntax to authenticate username and password
            //var user = from u in context.Users
            //        where u.Username == username && u.Password == password
            //        select u;

            ////creating new controller
            //var prodCtrl = new ProductsController(context);

            //var products = prodCtrl.GetAll();

            ////calling both tables with p.Vendor.Name
            //foreach(var p in products) {
            //    Print(p);
            //}

            //var product = prodCtrl.GetByPk(2);

            //if(product is not null) {
            //    Print(product);
            //}

            //var userCtrl = new UsersController(context);

            //var newUser = new User() {
            //    Id = 0,
            //    Username = "xx",
            //    Password = "xx",
            //    Firstname = "User",
            //    Lastname = "XX",
            //    Phone = "211",
            //    Email = "xx@user.com",
            //    IsReviewer = false,
            //    IsAmin = false
            //};

            //userCtrl.Create(newUser);

            //var user3 = userCtrl.GetByPk(3);

            //if (user3 is null) {
            //    Console.WriteLine("User not found");
            //} else {
            //    Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            //}
            //user3.Lastname = "user3";
            //userCtrl.Change(user3);

            //userCtrl.Remove(4);

            ////calling method we created in controller class
            //var users = userCtrl.GetAll();

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Id} {user.Firstname} {user.Lastname}");
            //}


        }
    }
}
