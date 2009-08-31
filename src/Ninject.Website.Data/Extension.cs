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
	[DataContract(Name = "extension", Namespace = "")]
	public class Extension
	{
		[DataMember(Name = "name", Order = 0)]
		public string Name { get; set; }

		[DataMember(Name = "website", Order = 1)]
		public string Website { get; set; }

		[DataMember(Name = "author", Order = 2)]
		public Author Author { get; set; }

		[DataMember(Name = "description", Order = 3)]
		public string Description { get; set; }
	}
}