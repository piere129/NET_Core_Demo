using LibraryData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{

    // IdentityDbContext allows you to have 1 dbcontext with 2 dbsets, one for roles & one for users
    public class LibraryContext : IdentityDbContext
    {

        // ORM, Object Relational Mapping, code first. Migrates the classes to tables in database
        // DbSets communicate with the Tables in the database. Linq can be used to query results from these sets
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Parent> parents { get; set; }

        public DbSet<Child> children { get; set; }

        public DbSet<ChildItem> childItems { get; set; }

        public DbSet<Item> items { get; set; }
    }
}
