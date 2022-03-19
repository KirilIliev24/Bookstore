using Bookstore.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBookCollection();
        IMongoCollection<User> GetUserCollection();
    }
}
