using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace launchPad.Models {

    public class LinkManager : DbContext {

        // -------------------------------------------------- get/sets
        private DbSet<Link> tblLink { get; set;}
        private DbSet<Category> tblCategory { get; set;}


        // -------------------------------------------------- public methods
        public List<Link> links {
            get {
                return tblLink.OrderBy(c => c.label).OrderByDescending(c => c.pinned).ToList();
            }
        }
        public List<Category> categories {
            get {
                return tblCategory.ToList();
            }
        }
        public Link getLinkByID(int ID){
            return tblLink.Single(item => item.linkID == ID);
        }
        public Category getCategoryByID(int ID){
            return tblCategory.Single(item => item.categoryID == ID);
        }
        // get the list of categories from the database
        public SelectList getCategoryList() {
            List<Category> listCategory = tblCategory.OrderBy(c => c.categoryName).ToList();
            return new SelectList(listCategory, "categoryID", "categoryName");
        }

        public string categoryName {get; set;}
        public int categoryID  {get; set;}
        public string linkID {get; set;}


         // -------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }









    }

}