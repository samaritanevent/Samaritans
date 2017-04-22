﻿using Samaritans.Data.Entities;
using Samaritans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samaritans.Controllers
{
	public class EventController : Controller
	{
		private DoGooderDb db;

		public EventController()
		{
			db = new DoGooderDb();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details(int index)
		{
			var e = db.Events.Find(index);
			return View(new EventViewModel(e));
		}
	}
}