using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

using Debie.Models.DB;

namespace Debie.Services {
    public static class DebieDBInitializer {
        public static void Initialize(DebieDBContext context) {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddArticles(context);
            AddProducts(context);
            AddOrders(context);
        }

        private static void AddArticles(DebieDBContext context) {
            if (context.Articles.Any()) {
                return;
            }

            byte[] passwordHash;
            using (var sha = SHA256.Create()) {
                passwordHash = sha.ComputeHash(Encoding.UTF8.GetBytes("password"));
            }

            var tag = new Tag { Label = "Test" };
            var admin = new User {
                Username = "admin",
                Password = passwordHash
            };
            var articles = new Article[] {
                new Article {
                    Title = "Article 1",
                    Content = "My very interesting article mmm yes",
                    Created = DateTime.UtcNow,
                    User = admin,
                    Image = new Image {
                        Title = "Article",
                        ContentType = "image/png",
                        Data = File.ReadAllBytes("wwwroot/media/cover.png")
                    },
                    Tags = new List<Tag>() { tag } },
                new Article {
                    Title = "Article 2",
                    Content = "My very interesting article mmm yes 222",
                    Created = DateTime.UtcNow,
                    User = admin,
                    Image = new Image {
                        Title = "Portrait",
                        ContentType = "image/png",
                        Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                    },
                    Tags = new List<Tag>() { tag, new Tag { Label = "Test2" } } },
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

            var main1 = new ProductImage {
                Image = new Image {
                    Title = "Thumbnail",
                    ContentType = "image/png",
                    Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                }
            };
            var main2 = new ProductImage {
                Image = new Image {
                    Title = "Thumbnail",
                    ContentType = "image/png",
                    Data = File.ReadAllBytes("wwwroot/media/cover.png")
                }
            };
            var main3 = new ProductImage {
                Image = new Image {
                    Title = "Thumbnail",
                    ContentType = "image/png",
                    Data = File.ReadAllBytes("wwwroot/media/about-portrait.png")
                }
            };

            var products = new Product[] {
                new Product {
                    Name = "Product1",
                    Description = "Very descriptive 1",
                    Color = "Blue",
                    Price = 99.99M,
                    Discount = .20M,
                    DiscountFrom = DateTime.Now,
                    DiscountUntil = DateTime.Now.AddDays(1),
                    ReviewsCount = 4,
                    ReviewsSum= 4 * 2.5M,
                    Vendor = vendor1,
                    Categories = new List<Category>() { cat1 },
                    ProductImages = new List<ProductImage>() {
                        new ProductImage {
                            Image = new Image {
                                Title = "Secondary",
                                ContentType = "image/png",
                                Data = File.ReadAllBytes("wwwroot/media/cover.png")
                            }
                        },
                        main1
                    },
                    MainProductImage = main1,
                    Sizes = new List<Size>() {
                        new Size { Label = "S", Stock = 3 },
                        new Size { Label = "M", Stock = 2 }
                    }
                },
                new Product {
                    Name = "Product2",
                    Description = "Very descriptive 2",
                    Color = "Black",
                    Price = 19.99M,
                    ReviewsCount = 10000,
                    ReviewsSum = 10000 * 4.5M,
                    Vendor = vendor1,
                    Categories = new List<Category>() { cat1, cat2 },
                    ProductImages = new List<ProductImage>() {
                        main2
                    },
                    MainProductImage = main2,
                    Sizes = new List<Size>() {
                        new Size { Label = "L", Stock = 6 },
                        new Size { Label = "XXL", Stock = 1 }
                    }
                },
                new Product {
                    Name = "Product3",
                    Description = "Very descriptive 3",
                    Color = "Red",
                    Price = 49.99M,
                    Discount = .50M,
                    DiscountFrom = DateTime.Now,
                    DiscountUntil = DateTime.Now.AddHours(3),
                    Vendor = new Vendor { Name = "Vendor 2" },
                    Categories = new List<Category>() { cat2 },
                    ProductImages = new List<ProductImage>() {
                        main3
                    },
                    MainProductImage = main3,
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

            var product = context.Products.First();

            var orders = new Order[] {
                new Order {
                    Email = "customer@example.com",
                    FirstName = "Petr",
                    LastName = "Novák",
                    ShippingMethod = "International Post",
                    ShippingPrice = 10M,
                    PaymentMethod = "Online card",
                    ShippingStreet = "Pepegova 12",
                    ShippingApartment = "8",
                    ShippingCity = "Prague",
                    ShippingCountry = "CZ",
                    ShippingZip = "120 00",
                    OrderProducts = new List<OrderProduct>() {
                        new OrderProduct {
                            Product = product,
                            UnitPrice = product.Price,
                            Discount = product.Discounted ? product.Discount : 0,
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