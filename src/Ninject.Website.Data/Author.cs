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
	[DataContract(Name = "author", Namespace = "")]
	public class Author
	{
		[DataMember(Name = "name", Order = 0)]
		public string Name { get; set; }

		[DataMember(Name = "email", Order = 1)]
		public string Email { get; set; }
	}
}