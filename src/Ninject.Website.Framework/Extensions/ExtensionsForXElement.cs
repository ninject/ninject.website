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
using System.Configuration;
using System.Xml.Linq;
#endregion

namespace Ninject.Website.Framework.Extensions
{
	public static class ExtensionsForXElement
	{
		public static XAttribute RequiredAttribute(this XElement element, XName name)
		{
			XAttribute attribute = element.Attribute(name);

			if (attribute == null)
				throw new ConfigurationErrorsException(String.Format("The <{0}> element is missing the required attribute '{1}'", element.Name, name));

			return attribute;
		}
	}
}