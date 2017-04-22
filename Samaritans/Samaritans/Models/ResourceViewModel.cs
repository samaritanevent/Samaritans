using Samaritans.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaritans.Models
{
	public class ResourceViewModel
	{
		private Resource resource;
		public ResourceViewModel(Resource resource)
		{
			this.resource = resource;
		}

		public string Description
		{
			get { return this.resource.Description; }
		}
	}
}