#region License
// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 
#endregion
#region Using Directives
using System;
using System.Runtime.Serialization;
#endregion

namespace Ninject.Website.Data
{
	[DataContract(Name = "product", Namespace = "")]
	public class Product
	{
		[DataMember(Name = "id", Order = 0)]
		public string Id { get; set; }

		[DataMember(Name = "name", Order = 1)]
		public string Name { get; set; }

		[DataMember(Name = "category", Order = 2)]
		public string Category { get; set; }

		[DataMember(Name = "image", Order = 3)]
		public string Image { get; set; }
	}
}