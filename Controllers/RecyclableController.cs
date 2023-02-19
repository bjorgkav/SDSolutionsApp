using SDSolutionsApp.Data_Access_Layer__DAL_;
using SDSolutionsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDSolutionsApp.Controllers
{
    public class RecyclableController : Controller
    {
        // GET: Recyclable
        
        //accessing the DbContext for our database
        private RecyclableContext context;

        public RecyclableController()
        {
            this.context = new RecyclableContext(); //initializing context
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
        }
        //end of Entity Framework Context code


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListItems()
        {
            List<RecyclableItem> items = context.RecyclableItems.ToList();

            return View("ListItems", items);
        }

        public ActionResult ListTypes()
        {
            List<RecyclableType> types = context.RecyclableTypes.ToList();
            
            return View("ListTypes", types);
        }

        public ActionResult AddItem() //(RecyclableItem item)
        {
            return View("AddItem", new RecyclableItem());
        }

        public ActionResult ProcessAddItem(RecyclableItem recItem) 
        {
            //saving to the db assuming edit item

            RecyclableItem item = context.RecyclableItems.SingleOrDefault(x => x.Id == recItem.Id);

            //edit if it already exists
            if (item != null)
            {
                item.Id = recItem.Id;
                item.ComputedRate = recItem.ComputedRate;
                item.Weight = recItem.Weight;
                item.ItemDescription = recItem.ItemDescription;
            }
            else {
                //create new item if it doesn't exist yet
                context.RecyclableItems.Add(recItem);
            }

            context.SaveChanges();

            return View("DetailsItem", recItem); 
        }

        public ActionResult EditItem(int id)
        {
            RecyclableItem item = context.RecyclableItems.SingleOrDefault(x => x.Id == id);

            return View("EditItem", item);
        }

        public ActionResult DeleteItem(int id)
        {
            RecyclableItem item = context.RecyclableItems.SingleOrDefault(x => x.Id == id);

            return View("DeleteItem", item);
        }

        public ActionResult ProcessDeleteItem(int id)
        {
            RecyclableItem item = context.RecyclableItems.SingleOrDefault(x => x.Id == id);

            context.Entry(item).State = EntityState.Deleted;

            context.SaveChanges();

            return Redirect("/Recyclable/ListItems");
        }

        public ActionResult DetailsItem(int id)
        {
            RecyclableItem item = context.RecyclableItems.SingleOrDefault(x => x.Id == id);

            return View("DetailsItem", item); 
        }

        public ActionResult AddType(){
            return View("AddType", new RecyclableType());
        }
    
        public ActionResult EditType(int id)
        {
            RecyclableType type = context.RecyclableTypes.SingleOrDefault(x => x.Id == id);

            return View("EditType", type);
        }

        public ActionResult ProcessAddType(RecyclableType rectype) {
            RecyclableType type = context.RecyclableTypes.SingleOrDefault(x=> x.Id == rectype.Id);

            if(type != null)
            {
                type.Type = rectype.Type;
                type.Rate = rectype.Rate;
                type.MinKg = rectype.MinKg;
                type.MaxKg = rectype.MaxKg;
                type.Items = rectype.Items;
            }
            else
            {
                context.RecyclableTypes.Add(rectype);
            }

            context.SaveChanges();
            
            return View("DetailsType", rectype);
        }

        public ActionResult DeleteType(int id) { 
            RecyclableType t = context.RecyclableTypes.SingleOrDefault(x => (x.Id == id));

            return View("DeleteType", t);
        }

        public ActionResult ProcessDeleteType(int id)
        {
            RecyclableType t = context.RecyclableTypes.SingleOrDefault(x => x.Id == id);
            context.Entry(t).State = EntityState.Deleted;
            context.SaveChanges();
            return Redirect("/Recyclable/ListTypes");
        }

        public ActionResult DetailsType(int id) {
            RecyclableType t = context.RecyclableTypes.SingleOrDefault(x => (x.Id == id));

            return View("DetailsType", t);
        }
    }
}