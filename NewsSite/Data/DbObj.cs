using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data
{
    public class DbObj
    {
        public static void Initial(AppDbContent content)
        {
            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.News.Any())
            {
                content.AddRange(
                    new News { name = "Выборы США", AuthorName = "Пушкин А.С.", Desc = "asfasfasfasfasfasfasfasf", date = "17.11.2020", isFavourite = true, img = "/img/default.jpg", Category = Categories["Политика"] },
                    new News { name = "Кто-то вмер", AuthorName = "newnews", Desc = "asfasfasfasfasfasfasfasf", date = "13.11.2020", isFavourite = true, img = "/img/default.jpg", Category = Categories["Политика"] },
                    new News { name = "Короновирус", AuthorName = "Короновирус", Desc = "asfasfasfasfasfasfasfasf", date = "15.11.2020", isFavourite = true, img = "/img/default.jpg", Category = Categories["Политика"] },
                    new News { name = "Рубль укрепился", AuthorName = "Путин", Desc = "asfasfasfasfasfasfasfasf", date = "15.11.2021", isFavourite = true, img = "/img/default.jpg", Category = Categories["Экономика"] },
                    new News { name = "Рубль упал", AuthorName = "Путин", Desc = "asfasfasfasfasfasfasfasf", date = "15.11.2021", isFavourite = true, img = "/img/default.jpg", Category = Categories["Экономика"] }
                    );

                    }

            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category
                    {
                        CategoryName = "Экономика", desc = "Новости о экономической ситуации в мире"
                    },
                        new Category
                    {
                        CategoryName = "Политика", desc = "Новости о эполитической ситуации в мире"
                    },
                        new Category
                    {
                        CategoryName = "Общество", desc = "Общество"
                    },
                        new Category
                    {
                        CategoryName = "В мире", desc = "В мире"
                    },
                         new Category
                    {
                        CategoryName = "Спорт", desc = "Спорт"
                    },
                         new Category
                    {
                        CategoryName = "Культура", desc = "Культура"
                    }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }

        }
    }
}
