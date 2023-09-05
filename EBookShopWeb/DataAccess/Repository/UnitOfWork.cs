﻿using DataAccess.Repository.IRepository;
using EBookShopWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Product = new ProductRepository(db);
            Category = new CategoryRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
