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
using System.Linq;
using System.Runtime.Serialization;
using Ninject.Website.Data;
#endregion

namespace Ninject.Website.Services.Persistence
{
	public interface IRepository<T>
	{
		IQueryable<T> GetAll();
	}
}