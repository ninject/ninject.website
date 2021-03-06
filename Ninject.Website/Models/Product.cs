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



#endregion

namespace Ninject.Website.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}