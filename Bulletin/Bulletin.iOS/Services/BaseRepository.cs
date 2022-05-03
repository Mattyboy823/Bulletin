using Bulletin.Services;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Bulletin.iOS.Services 
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {
        public abstract string DocumentPath { get; }
        public virtual Task<bool> Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            throw new NotImplementedException();
        }

        /*   public virtual Task<T> Get(string id)
           {
               Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection(DocumentPath).GetDocument(id).GetDocument((snapshot, error) =>
               {
                   if (error != null)
                   {

                   }
               });
           }*/

        public virtual Task<IList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}