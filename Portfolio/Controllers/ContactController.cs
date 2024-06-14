﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL.Context;
using Portfolio.DAL.Entities;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
		MyPortfolioContext context = new();

		public IActionResult ContactList()
		{
			var values = context.Contacts.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(Contact contact)
		{
			context.Contacts.Add(contact);
			context.SaveChanges();
			return RedirectToAction("ContactList");
		}


		public IActionResult DeleteContact(int id)
		{
			var value = context.Contacts.Find(id);
			context.Contacts.Remove(value);
			context.SaveChanges();
			return RedirectToAction("ContactList");
		}

		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			var value = context.Contacts.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateContact(Contact contact)
		{
			context.Contacts.Update(contact);
			context.SaveChanges();
			return RedirectToAction("ContactList");
		}
	}
}
