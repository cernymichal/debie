using System.Linq;
using Debie.Models.DB;
using System;
using System.Collections.Generic;
using System.IO;

namespace Debie.Services {
    public static class DebieDBInitializer {
        public static void Initialize(DebieDBContext context) {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddArticles(context);
            AddProducts(context);
            AddOrders(context);
        }

        private static void AddArticles(DebieDBContext context) {
            if (context.Articles.Any()) {
                return;
            }

            var articles = new Article[] {
                new Article {
                    Title = "Article 1",
                    Content = "My very interesting article mmm yes",
                    User = new User {
                        Name = "Admin",
                        Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8" /* "password" */ 
                    },
                    Image = new Image {
                        Title = "Article",
                        Extension = "png",
                        Data = File.ReadAllBytes("wwwroot/media/cover.png")
                    },
                    Tags = new List<Tag>() { new Tag { Label = "Test" } } },
                new Article {
                    Title = "Article 2",
                    Content = "My very interesting article mmm yes 222",
                    User = new User {
                        Name = "Autor 2",
                        Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8" /* "password" */ 
                    },
                    Image = new Image {
                        Title = "Portrait",
                        Extension = "png",
                        Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                    },
                    Tags = new List<Tag>() { new Tag { Label = "Test" } } },
            };

            foreach (var a in articles) {
                context.Articles.Add(a);
            }
            context.SaveChanges();
        }

        private static void AddProducts(DebieDBContext context) {
            if (context.Products.Any()) {
                return;
            }

            var vendor1 = new Vendor { Name = "Vendor 1" };
            var cat1 = new Category { Name = "Category 1" };
            var cat2 = new Category { Name = "Category 2" };
            var products = new Product[] {
                new Product {
                    Name = "Product1",
                    Description = "Very descriptive 1",
                    Color = "Blue",
                    Price = 99.99F,
                    Discount = 20,
                    DiscountFrom = DateTime.Now,
                    DiscountUntil = DateTime.Now.AddDays(1),
                    ReviewsCount = 4,
                    ReviewsAverage= 4F,
                    Vendor = vendor1,
                    Categories = new List<Category>() { cat1 },
                    ProductImages = new List<ProductImage>() {
                        new ProductImage {
                            Main = true,
                            Image = new Image {
                                Title = "Thumbnail",
                                Extension = "png",
                                Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                            }
                        },
                        new ProductImage {
                            Main = false,
                            Image = new Image {
                                Title = "Secondary",
                                Extension = "png",
                                Data = File.ReadAllBytes("wwwroot/media/cover.png")
                            }
                        }
                    },
                    Sizes = new List<Size>() {
                        new Size { Label = "S", Stock = 3 },
                        new Size { Label = "M", Stock = 2 }
                    }
                },
                new Product {
                    Name = "Product2",
                    Description = "Very descriptive 2",
                    Color = "Black",
                    Price = 19.99F,
                    ReviewsCount = 10000,
                    ReviewsAverage= 2.7F,
                    Vendor = vendor1,
                    Categories = new List<Category>() { cat1, cat2 },
                    ProductImages = new List<ProductImage>() {
                        new ProductImage {
                            Main = true,
                            Image = new Image {
                                Title = "Secondary",
                                Extension = "png",
                                Data = File.ReadAllBytes("wwwroot/media/cover.png")
                            }
                        }
                    },
                    Sizes = new List<Size>() {
                        new Size { Label = "L", Stock = 6 },
                        new Size { Label = "XXL", Stock = 1 }
                    }
                },
                new Product {
                    Name = "Product3",
                    Description = "Very descriptive 3",
                    Color = "Red",
                    Price = 49.99F,
                    Discount = 50,
                    DiscountFrom = DateTime.Now,
                    DiscountUntil = DateTime.Now.AddHours(3),
                    Vendor = new Vendor { Name = "Vendor 2" },
                    Categories = new List<Category>() { cat2 },
                    ProductImages = new List<ProductImage>() {
                        new ProductImage {
                            Main = true,
                            Image = new Image {
                                Title = "Thumbnail",
                                Extension = "png",
                                Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                            }
                        }
                    },
                    Sizes = new List<Size>() {
                        new Size { Label = "XS", Stock = 5 },
                        new Size { Label = "M", Stock = 2 },
                        new Size { Label = "L", Stock = 15 }
                    }
                }
            };

            foreach (var p in products) {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }

        private static void AddOrders(DebieDBContext context) {
            if (context.Orders.Any()) {
                return;
            }
            var address = new Address {
                Street = "Pepegova 12",
                Apartment = "8",
                City = "Prague",
                Country = "CZ",
                Zip = "120 00"
            };
            var orders = new Order[] {
                new Order {
                    Email = "customer@example.com",
                    Phone = "+420 123 456 789",
                    FirstName = "Petr",
                    LastName = "Novák",
                    ShippingMethod = "International Post",
                    ShippingPrice = 10F,
                    PaymentMethod = "Online card",
                    BillingAddress = address,
                    ShippingAddress = address,
                    OrderProducts = new List<OrderProduct>() {
                        new OrderProduct {
                            Product = context.Products.First(),
                            UnitPrice = context.Products.First().Price,
                            Discount = context.Products.First().Discount,
                            Count = 2
                        }
                    }
                }
            };

            foreach (var o in orders) {
                context.Orders.Add(o);
            }
            context.SaveChanges();
        }
    }
}