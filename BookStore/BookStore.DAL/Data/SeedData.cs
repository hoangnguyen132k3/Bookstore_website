using BookStore.DAL.Models;
using BookStore.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace BookStore.DAL.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(BookDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                    new Category
                    {
                        Name = "Kinh dị",
                        ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg"
                    },

                    new Category
                    {
                        Name = "Nấu Ăn",
                        ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg"
                    }
                    );
                    for (int i = 1; i <= 20; i++)
                    {
                        context.Categories.Add(new Category
                        {
                            Name = $"Category {i}",
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg"
                        });
                    }
                    await context.SaveChangesAsync(); 
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "Địa Ngục Tầng Thứ 18",
                            Description = "Hay",
                            Price = 200000,
                            OldPrice = 250000,
                            StockQuantity = 30,
                            CategoryId = 1,
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg",
                            Author = "Haong",
                            Discount = 10,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        },
                        new Book
                        {
                            Name = "Địa Ngục Tầng Thứ 19",
                            Description = "Hay",
                            Price = 200000,
                            OldPrice = 250000,
                            StockQuantity = 30,
                            CategoryId = 2,
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg",
                            Author = "Haong",
                            Discount = 10,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        },
                        new Book
                        {
                            Name = "Địa Ngục Tầng Thứ 14",
                            Description = "Hay",
                            Price = 200000,
                            OldPrice = 250000,
                            StockQuantity = 30,
                            CategoryId = 1,
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg",
                            Author = "Haong",
                            Discount = 10,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        },
                        new Book
                        {
                            Name = "Địa Ngục Tầng Thứ 17",
                            Description = "Hay",
                            Price = 200000,
                            OldPrice = 250000,
                            StockQuantity = 30,
                            CategoryId = 1,
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg",
                            Author = "Haong",
                            Discount = 10,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        }
                    );
                    Random random = new Random();
                    for (int i = 1; i <= 20; i++)
                    {
                        context.Books.Add(new Book
                        {
                            Name = $"Book {i}",
                            Description = $"Description for Book {i}",
                            Price = 10000000,
                            OldPrice = 10500000,
                            StockQuantity = 50,
                            CategoryId = random.Next(1, 10),
                            ImageUrl = "https://cdn.popsww.com/blog/sites/2/2021/04/cam-tu-ky-bao.jpg",
                            Author = "Hanh",
                            Discount = 12,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.InformationTypes.Any())
                {
                    context.InformationTypes.AddRange(
                        new InformationType { Code = "39483ru394834" }
                    );
                    await context.SaveChangesAsync();
                }

                if (!context.BookInformations.Any())
                {
                    context.BookInformations.AddRange(
                        new BookInformation { BookId = 1, InformationTypeId = 1, Publish = "Kim Dong" }
                    );
                    await context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static void EnableIdentityInsert(BookDbContext context, string tableName, bool enable)
        {
            var rawSql = enable
                ? $"SET IDENTITY_INSERT {tableName} ON;"
                : $"SET IDENTITY_INSERT {tableName} OFF;";
            context.Database.ExecuteSqlRaw(rawSql);
        }
    }
}
