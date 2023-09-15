﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Helper
{
    public class ComplexTypeHelper
    {
        public static bool IsComplexType(Type type)
        {
            // Check if the type is a class and not a primitive data type
            return type != typeof(string) && type != typeof(DateTime) && !type.IsPrimitive && type != typeof(Guid); 
               
        }
    }
}
