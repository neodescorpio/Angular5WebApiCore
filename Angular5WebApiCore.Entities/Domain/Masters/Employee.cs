﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Models.Domain
{
	public class Employee : PersonBase
	{
		public string Department { get; set; }
		public string Description { get; set; }		
	}
}
