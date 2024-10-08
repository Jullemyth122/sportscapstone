using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportsCapstone.Models; // Update with your actual namespace
using SportsCapstone.Entities;

public class InventoryController : Controller
{
    // Simulate a database with a static list (replace with your actual database context)
    private static List<Product> products = new List<Product>();

    public ActionResult Index()
    {
        // Return the list of products to the view
        return View(products);
    }

    public ActionResult Create()
    {
        // Return the view for creating a new product
        return View();
    }

    [HttpPost]
    public ActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            // Add the new product to the list (replace with your database logic)
            products.Add(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public ActionResult Edit(int id)
    {
        // Find the product by id (replace with your database logic)
        var product = products.Find(p => p.Id == id);
        if (product == null)
        {
            ViewBag.ErrorMessage = "Product not found.";
            return View("Error"); // You would create an Error.cshtml view to display the message
        }
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            // Update the product in the list (replace with your database logic)
            var existingProduct = products.Find(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Brand = product.Brand;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Type = product.Type;
                existingProduct.AgeRange = product.AgeRange;
            }
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Delete(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null)
        {
            ViewBag.ErrorMessage = "Product not found.";
            return View("Error"); // You would create an Error.cshtml view to display the message
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        // Remove the product from the list (replace with your database logic)
        var product = products.Find(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }
        return RedirectToAction("Index");
    }
}
