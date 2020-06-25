using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, UserContext>, IUserDal
    {
 
    }
}
