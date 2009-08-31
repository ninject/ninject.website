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
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
#endregion

namespace Ninject.Website.Data.Collections
{
	[CollectionDataContract(Name = "products", Namespace = "", ItemName = "product")]
	public class ProductCollection : Collection<Product>
	{
	}
}