using Ipuc.Helpers;
using Ipuc.Models;
using System;
using System.Linq;

namespace Ipuc.Services
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using Helpers;
    //using Ipuc.Models;

    public class DataService
    {
        //public bool DeleteAll()
        //{
        //    try
        //    {
        //        using (var da = new DataAccess())
        //        {
        //            var oldRecords = da.GetList();
        //            foreach (var item in oldRecords)
        //            {
        //                da.Delete(item);
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        return false;
        //    }
        //}
        public T DeleteAllAndInsert<T>(T model) where T : class
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldRecords = da.GetList();
                    foreach (var item in oldRecords)
                    {
                        da.Delete(item);
                    }
                    da.Insert(model);
                    return model;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return model;
            }
        }
        //public T InsertOrUpdate<T>(T model) where T : class
        //{
        //    try
        //    {
        //        using (var da = new DataAccess())
        //        {
        //            var oldRecord = da.Find(model.GetHashCode());
        //            if (oldRecord != null)
        //            {
        //                da.Update(model);
        //            }
        //            else
        //            {
        //                da.Insert(model);
        //            }
        //            return model;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        return model;
        //    }
        //}
        //public T Insert<T>(T model)
        //{
        //    using (var da = new DataAccess())
        //    {
        //        da.Insert(model);
        //        return model;
        //    }
        //}
        //public UserLocal Find<T>(int pk) where T : class
        //{
        //    using (var da = new DataAccess())
        //    {
        //        return da.Find(pk);
        //    }
        //}
        public UserLocal First()
        {
            using (var da = new DataAccess())
            {
                return da.GetList().FirstOrDefault();
            }
        }
        //public List<UserLocal> Get()
        //{
        //    using (var da = new DataAccess())
        //    {
        //        return da.GetList().ToList();
        //    }
        //}
        //public void Update<T>(T model)
        //{
        //    using (var da = new DataAccess())
        //    {
        //        da.Update(model);
        //    }
        //}
        //public void Delete<T>(T model)
        //{
        //    using (var da = new DataAccess())
        //    {
        //        da.Delete(model);
        //    }
        //}
        //public void Save<T>(List<T> list) where T : class
        //{
        //    using (var da = new DataAccess())
        //    {
        //        foreach (var item in list)
        //        {
        //            InsertOrUpdate(item);
        //        }
        //    }
        //}
    }
}
