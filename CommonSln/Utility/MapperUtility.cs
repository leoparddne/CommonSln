using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCLUtility
{
    public static class MapperUtility
    {
        public static T Map<T>(this object obj)
        {
            return Mapper.Map<T>(obj);
        }
        public static List<T>Map<T>(this List<object> obj)
        {
            return Mapper.Map<List<object>, List<T>>(obj);
        }
    }
}
