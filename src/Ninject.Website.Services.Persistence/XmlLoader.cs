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
using System.IO;
using System.Runtime.Serialization;
#endregion

namespace Ninject.Website.Services.Persistence
{
	public class XmlLoader
	{
		public T Load<T>(string filename)
		{
			using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				var serializer = new DataContractSerializer(typeof(T));
				return (T)serializer.ReadObject(stream);
			}
		}
	}
}