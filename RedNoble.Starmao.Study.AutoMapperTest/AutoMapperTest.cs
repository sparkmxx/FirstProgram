using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Mapping.Attributes;
using Framework.Mapping.Base;
using NUnit.Framework;

namespace RedNoble.Starmao.Study.AutoMapperTest
{
    public class User
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        [MapperAutoUpdateDateTime(MapperDateTimeType.Now)]
        public DateTime CreateDate { get; set; }
    }

    public class UserModel
    {
     
      
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string AliaName { get; set; }
        
        public DateTime CreateDate { get; set; }
    }

    public class AutoMapperTest
    {
        [Test]
        public void Test()
        {
            User user = new User
            {
                UserName = "冒星星",
                Id = 1,
                UserPassword = "123456",
                CreateDate = DateTime.Parse("2015-02-11 09:35:19")
            };

            //MapperBase<UserModel, User> mapper = new MapperBase<UserModel, User>();
            //UserModel userModel = mapper.GetModel(user);


            MapperBase<User, UserModel> mapper2 = new MapperBase<User, UserModel>();
            UserModel userModel2 = mapper2.GetEntity(user);

        }
    }
}
