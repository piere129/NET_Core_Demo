using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{
    public class LibraryContext : DbContext
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
