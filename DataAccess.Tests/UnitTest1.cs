using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        
        public void TestInit()
        {
            SqlAccess.CreateUser("User" + DateTime.Now.ToShortTimeString(), "pass", "email");
           int id= SqlAccess.CreateUser("User" + DateTime.Now.ToShortTimeString(), "pass", "email");

            SqlAccess.CreateAdmin("Admin" + DateTime.Now.ToShortTimeString(), "pass", "email");
            SqlAccess.CreateCostumer("Costumer" + DateTime.Now.ToShortTimeString(), "pass", "email",12,23,23.3,23.3);
            SqlAccess.CreateCoupon(SqlAccess.UseRepository.FindById(id), "Coupon" + DateTime.Now.ToShortDateString(),
                23.4, "bls", 23, 23.3, DateTime.Now, 2);
            SqlAccess.CreateCouponAlert(1, "alert"+DateTime.Now.ToShortDateString());
            SqlAccess.CreateCouponOrder(SqlAccess.CouponRepository.FindOne(null),
                SqlAccess.CostumerRepository.FindOne(null), "qr", false, "bg", 2, 3, DateTime.Now, "fads", "fdsfd");
            SqlAccess.CreateFirmOwner(SqlAccess.AdminRepository.FindOne(null),"Firm" + DateTime.Now.ToShortTimeString(), "pass", "email");
            SqlAccess.CreateFirm(SqlAccess.AdminRepository.FindOne(null), SqlAccess.FirmOwenrRepository.FindOne(null),
                "fdfd", "fdfdfd", "dfdfd", "dfdfd", 23, 34);
            SqlAccess.CreateSocialCoupon(SqlAccess.CostumerRepository.FindOne(null), "social", 23, "edf", 21, 45,
                DateTime.Now, 5);
            SqlAccess.CreateSocialNetwork(SqlAccess.CostumerRepository.FindOne(null), "socialProf", "pa", "dsf", "sdf",
                "sdfds", "sdfsd");

        }

        #region Insert Test
        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateUser()
        {
            int id = SqlAccess.CreateUser("User", "9670", "amirdor@gmail.com");
            Assert.AreNotEqual(id, -1);
        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateAdmin()
        {
            int id = SqlAccess.CreateAdmin("Admin"+DateTime.Now.ToShortDateString(), "9670", "amirdor@gmail.com");
            Assert.AreNotEqual(id, -1);
        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateFirmOwner()
        {
            SystemAdmin admin = SqlAccess.AdminRepository.FindOne(null);
            Assert.IsNotNull(admin,"there is not admin users in the DB");
            int id = SqlAccess.CreateFirmOwner(admin,"FirmOwner", "9670", "amirdor@gmail.com");
            Assert.AreNotEqual(id, -1);
        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateFirm()
        {
            SystemAdmin admin = SqlAccess.AdminRepository.FindOne(null);
            Assert.IsNotNull(admin);
            FirmOwner firmOwner = SqlAccess.FirmOwenrRepository.FindOne(null);
            Assert.IsNotNull(firmOwner);
            int FirmId = SqlAccess.CreateFirm(admin,firmOwner,"ToysRus", "beer sheva", "beer sheva","toys!",23.3,23.3);
            Assert.IsTrue(FirmId > 0, "Can't Create Firm");
        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateCostumer()
        {

            int cid = SqlAccess.CreateCostumer("Costumer", "9670", "amirdor@gmail.com",1,23,23.4,34.3);
            Assert.IsTrue(cid > 0, "you cant Costomer this user");

        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateCoupon()
        {
            var user = SqlAccess.UseRepository.FindOne(null);
            Assert.IsNotNull(user);
            int couponId = SqlAccess.CreateCoupon(user,"coupon",23.4, "bla", 23, 23.3, DateTime.Now,2);
            Assert.IsTrue(couponId > 0, "Cannot create coupon");
        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateSocialCoupon()
        {
            var user = SqlAccess.CostumerRepository.FindOne(null);
            Assert.IsNotNull(user);
            int soCouponId = SqlAccess.CreateSocialCoupon(user,"socialCop",23.3,"bla",23,25,DateTime.Now,3);
            Assert.IsTrue(soCouponId > 0, "Cannot create Social coupon");

        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateSocialNet()
        {
            var user = SqlAccess.CostumerRepository.FindOne(null);
            Assert.IsNotNull(user);
            int soCouponId = SqlAccess.CreateSocialNetwork(user, "social", "123", "bla@bla.com", "rData", "sData", "token");
            Assert.IsTrue(soCouponId > 0, "Cannot create Social Profile");

        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateCouponAlert()
        {
            int soCouponId = SqlAccess.CreateCouponAlert(1,"help!");
            Assert.IsTrue(soCouponId > 0, "Cannot create coupon Alert");

        }

        [TestCategory("Create")]
        [TestMethod]
        public void Test_CreateCouponOrder()
        {
            Coupon coupon = SqlAccess.CouponRepository.FindOne(null);
            var collCoupn = new Collection<Coupon> {coupon};
            var user = SqlAccess.CostumerRepository.FindOne(null);
            Assert.IsNotNull(user);
            int soCouponId = SqlAccess.CreateCouponOrder(coupon,user,"qr",false,"approve",3,34,DateTime.Now,"recipt","123");
            Assert.IsTrue(soCouponId > 0, "Cannot create coupon Alert");

        }
        #endregion

        #region Select Test

        [TestCategory("Select"), TestCategory("User")]
        [TestMethod]
        public void Test_SelectUser()
        {
            
            var y = SqlAccess.UseRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("User")]
        [TestMethod]
        public void Test_SelectAllUsers()
        {
            IQueryable<User> y = SqlAccess.UseRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("User")]
        [TestMethod]
        public void Test_SelectUserById()
        {
            var u = SqlAccess.UseRepository.FindOne(null).Id;
            User y = SqlAccess.UseRepository.FindById(u);
            Assert.IsNotNull(y);
        }


        [TestCategory("Select"), TestCategory("Costomer")]
        [TestMethod]
        public void Test_SelectCostmer()
        {
            //ParameterExpression param = Expression.Parameter(typeof(Costumer), "age");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "age"),
            //      Expression.Constant(18, typeof(int)));
            //Expression<Func<Costumer, bool>> filter = Expression.Lambda<Func<Costumer, bool>>(boby, param);
            Costumer y = SqlAccess.CostumerRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Costomer")]
        [TestMethod]
        public void Test_SelectAllCostomers()
        {
            IQueryable<Costumer> y = SqlAccess.CostumerRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Costomer")]
        [TestMethod]
        public void Test_SelectCostomerrById()
        {
            var u = SqlAccess.CostumerRepository.FindOne(null);
            Costumer y = SqlAccess.CostumerRepository.FindById(u.Id);
            Assert.IsNotNull(y);
        }



        [TestCategory("Select"), TestCategory("FirmOwner")]
        [TestMethod]
        public void Test_SelectFirmOwner()
        {
        
            var y = SqlAccess.FirmOwenrRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("FirmOwner")]
        [TestMethod]
        public void Test_SelectAllFirmOwners()
        {
            IQueryable<FirmOwner> y = SqlAccess.FirmOwenrRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("FirmOwner")]
        [TestMethod]
        public void Test_SelectFirmOwnerById()
        {
            var n = SqlAccess.FirmOwenrRepository.FindOne(null);
            FirmOwner y = SqlAccess.FirmOwenrRepository.FindById(n.Id);
            Assert.IsNotNull(y);
        }


        [TestCategory("Select"), TestCategory("Firm")]
        [TestMethod]
        public void Test_SelectFirm()
        {
            //ParameterExpression param = Expression.Parameter(typeof(Firm), "name");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "name"),
            //      Expression.Constant("Firm", typeof(string)));
            //Expression<Func<Firm, bool>> filter = Expression.Lambda<Func<Firm, bool>>(boby, param);
            Firm y = SqlAccess.FirmRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Firm")]
        [TestMethod]
        public void Test_SelectAllFirmrs()
        {
            IQueryable<Firm> y = SqlAccess.FirmRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Firm")]
        [TestMethod]
        public void Test_SelectFirmById()
        {
            Firm y = SqlAccess.FirmRepository.FindById(1);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Coupon")]
        [TestMethod]
        public void Test_SelectCoupon()
        {
            //ParameterExpression param = Expression.Parameter(typeof(Coupon), "name");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "name"),
            //      Expression.Constant("Coupon", typeof(string)));
            //Expression<Func<Coupon, bool>> filter = Expression.Lambda<Func<Coupon, bool>>(boby, param);
            var y = SqlAccess.CouponRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Coupon")]
        [TestMethod]
        public void Test_SelectAllCoupons()
        {
            var y = SqlAccess.CouponRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("Coupon")]
        [TestMethod]
        public void Test_SelectCouponById()
        {
            var c = SqlAccess.CouponRepository.FindOne(null).Id;
            var y = SqlAccess.CouponRepository.FindById(c);
            Assert.IsNotNull(y);
        }


        [TestCategory("Select"), TestCategory("SocialCoupon")]
        [TestMethod]
        public void Test_SelectAllSocialCoupons()
        {
            var y = SqlAccess.SocialCouponRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("SocialCoupon")]
        [TestMethod]
        public void Test_SelectSocialCouponById()
        {
            var u = SqlAccess.SocialCouponRepository.FindOne(null);
            var y = SqlAccess.SocialCouponRepository.FindById(u.Id);
            Assert.IsNotNull(y);
        }


        [TestCategory("Select"), TestCategory("CouponOrder")]
        [TestMethod]
        public void Test_SelectCouponOrder()
        {
            //ParameterExpression param = Expression.Parameter(typeof(CouponOrder), "serialKey");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "serialKey"),
            //      Expression.Constant(1, typeof(int)));
            //Expression<Func<CouponOrder, bool>> filter = Expression.Lambda<Func<CouponOrder, bool>>(boby, param);
            var y = SqlAccess.CouponOrderRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("CouponOrder")]
        [TestMethod]
        public void Test_SelectAllCouponOrders()
        {
            var y = SqlAccess.CouponOrderRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("CouponOrder")]
        [TestMethod]
        public void Test_SelectCouponOrdernById()
        {
            var x = SqlAccess.CouponOrderRepository.FindOne(null).Id;
            var y = SqlAccess.CouponOrderRepository.FindById(x);
            Assert.IsNotNull(y);
        }



        [TestCategory("Select"), TestCategory("CouponAlert")]
        [TestMethod]
        public void Test_SelectCouponAlert()
        {
            //ParameterExpression param = Expression.Parameter(typeof(CouponAlert), "alerType");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "alerType"),
            //      Expression.Constant(1, typeof(int)));
            //Expression<Func<CouponAlert, bool>> filter = Expression.Lambda<Func<CouponAlert, bool>>(boby, param);
            var y = SqlAccess.CouponAlertRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("CouponAlert")]
        [TestMethod]
        public void Test_SelectAlCouponAlerts()
        {
            var y = SqlAccess.CouponAlertRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("CouponAlert")]
        [TestMethod]
        public void Test_SelectCouponAlertnById()
        {
            var a = SqlAccess.CouponAlertRepository.FindOne(null).Id;
            var y = SqlAccess.CouponAlertRepository.FindById(a);
            Assert.IsNotNull(y);
        }


        [TestCategory("Select"), TestCategory("SocialNetworkProfile")]
        [TestMethod]
        public void Test_SelectSocialNetworkProfile()
        {
            //ParameterExpression param = Expression.Parameter(typeof(SocialNetworkProfile), "username");
            //Expression boby = Expression.Equal(Expression.PropertyOrField(param, "username"),
            //      Expression.Constant("Dor", typeof(string)));
            //Expression<Func<SocialNetworkProfile, bool>> filter = Expression.Lambda<Func<SocialNetworkProfile, bool>>(boby, param);
            var y = SqlAccess.SocialProfileRepository.FindOne(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("SocialNetworkProfile")]
        [TestMethod]
        public void Test_SelectAlSocialNetworkProfile()
        {
            var y = SqlAccess.SocialProfileRepository.FindAll(null);
            Assert.IsNotNull(y);
        }

        [TestCategory("Select"), TestCategory("SocialNetworkProfile")]
        [TestMethod]
        public void Test_SelectSocialNetworkProfileById()
        {
            var u = SqlAccess.SocialProfileRepository.FindOne(null).Id;
            var y = SqlAccess.SocialProfileRepository.FindById(u);
            Assert.IsNotNull(y);
        }

        #endregion

        #region Update Test

        [TestCategory("Update"), TestCategory("User")]
        [TestMethod]
        public void Test_UpdateUser()
        {

            User user = SqlAccess.UseRepository.FindOne(null);
            user.username = "UserName_new";
            User update = SqlAccess.UseRepository.Update(user);
            SqlAccess.UseRepository.SaveChanges();
            Assert.AreEqual(update.username, "UserName_new");
        }

        [TestCategory("Update"), TestCategory("Costomer")]
        [TestMethod]
        public void Test_UpdateCostumer()
        {
            var user = SqlAccess.CostumerRepository.FindOne(null);
            user.age = 23;
            var update = SqlAccess.CostumerRepository.Update(user);
            SqlAccess.CostumerRepository.SaveChanges();
            Assert.AreEqual(update.age, 23);
        }

        [TestCategory("Update"), TestCategory("Firm")]
        [TestMethod]
        public void Test_UpdateFirm()
        {
            var user = SqlAccess.FirmRepository.FindOne(null);
            user.city = "Tel-Aviv";
            var update = SqlAccess.FirmRepository.Update(user);
            SqlAccess.FirmRepository.SaveChanges();
            Assert.AreEqual(update.city, "Tel-Aviv");
        }

        [TestCategory("Update"), TestCategory("Coupon")]
        [TestMethod]
        public void Test_UpdateCoupon()
        {
            var user = SqlAccess.CouponRepository.FindOne(null);
            user.name = "Tel-Aviv";
            var update = SqlAccess.CouponRepository.Update(user);
            SqlAccess.CouponRepository.SaveChanges();
            Assert.AreEqual(update.name, "Tel-Aviv");
        }

        [TestCategory("Update"), TestCategory("SocialCoupon")]
        [TestMethod]
        public void Test_UpdateSocialCoupon()
        {
            var user = SqlAccess.SocialCouponRepository.FindOne(null);
            user.name = "Tel-Aviv";
            var update = SqlAccess.SocialCouponRepository.Update(user);
            SqlAccess.SocialCouponRepository.SaveChanges();
            Assert.AreEqual(update.name, "Tel-Aviv");
        }
        [TestCategory("Update"), TestCategory("CouponOrder")]
        [TestMethod]
        public void Test_UpdateCouponOrder()
        {
            DateTime n = DateTime.Now;
            var user = SqlAccess.CouponOrderRepository.FindOne(null);
            user.date = n;
            var update = SqlAccess.CouponOrderRepository.Update(user);
            SqlAccess.CouponOrderRepository.SaveChanges();
            Assert.AreEqual(update.date.ToShortDateString(), n.ToShortDateString());
        }

        [TestCategory("Update"), TestCategory("CouponAlert")]
        [TestMethod]
        public void Test_UpdateCouponAlert()
        {
            var user = SqlAccess.CouponAlertRepository.FindOne(null);
            user.text = "Test";
            var update = SqlAccess.CouponAlertRepository.Update(user);
            SqlAccess.CouponAlertRepository.SaveChanges();
            Assert.AreEqual(update.text, "Test");
        }

        [TestCategory("Update"), TestCategory("SocialNetworkProfile")]
        [TestMethod]
        public void Test_UpdateSocialNetworkProfile()
        {
            var user = SqlAccess.SocialProfileRepository.FindOne(null);
            user.username = "TestUsername";
            var update = SqlAccess.SocialProfileRepository.Update(user);
            SqlAccess.SocialProfileRepository.SaveChanges();
            Assert.AreEqual(update.username, "TestUsername");
        }

        #endregion

        #region Delete Test
        [TestCategory("Delete"), TestCategory("User")]
        [TestMethod]
        public void Test_DeleteUser()
        {
            int id = SqlAccess.CreateUser("dor", "9670", "email@rmail.com");
            SqlAccess.UseRepository.Delete(id);
            SqlAccess.UseRepository.SaveChanges();
            var item = SqlAccess.UseRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("Costomer")]
        [TestMethod]
        public void Test_DeleteCostumer()
        {

            int id = SqlAccess.CreateCostumer("cost", "dfds", "sdfsd", 2, 23,45,34.5);
            SqlAccess.CostumerRepository.Delete(id);
            SqlAccess.CostumerRepository.SaveChanges();

            var item = SqlAccess.CostumerRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("Admin")]
        [TestMethod]
        public void Test_DeleteAdmin()
        {
            int id = SqlAccess.CreateAdmin("Admin", "sdfds", "sdfdsf");
            SqlAccess.AdminRepository.Delete(id);
            SqlAccess.AdminRepository.SaveChanges();
            var item = SqlAccess.AdminRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("FirmOwner")]
        [TestMethod]
        public void Test_DeleteFirmOwner()
        {


            int id = SqlAccess.CreateFirmOwner(SqlAccess.AdminRepository.FindOne(null),
                "Firm" + DateTime.Now.ToShortTimeString(), "pass", "email");
            SqlAccess.FirmOwenrRepository.Delete(id);
            SqlAccess.FirmOwenrRepository.SaveChanges();
            var item = SqlAccess.FirmOwenrRepository.FindById(id);
            Assert.IsNull(item);
        }


        [TestCategory("Delete"), TestCategory("Firm")]
        [TestMethod]
        public void Test_DeleteFirm()
        {

            int idf = SqlAccess.CreateFirm(SqlAccess.AdminRepository.FindOne(null), SqlAccess.FirmOwenrRepository.FindOne(null),
                "fdfd", "fdfdfd", "dfdfd", "dfdfd", 23, 34);
            SqlAccess.FirmRepository.Delete(idf);
            SqlAccess.FirmRepository.SaveChanges();
            var item = SqlAccess.FirmRepository.FindById(idf);
            Assert.IsNull(item);
        }


        [TestCategory("Delete"), TestCategory("Coupon")]
        [TestMethod]
        public void Test_DeleteCoupon()
        {

            int idf = SqlAccess.CreateCoupon(SqlAccess.UseRepository.FindOne(null),
                "Coupon" + DateTime.Now.ToShortDateString(),
                23.4, "bls", 23, 23.3, DateTime.Now, 2);
            SqlAccess.CouponRepository.Delete(idf);
            SqlAccess.CouponRepository.SaveChanges();
            var item = SqlAccess.CouponRepository.FindById(idf);
            Assert.IsNull(item);
        }


        [TestCategory("Delete"), TestCategory("SocialCoupon")]
        [TestMethod]
        public void Test_DeleteSocialCoupon()
        {

            int id = SqlAccess.CreateSocialCoupon(SqlAccess.CostumerRepository.FindOne(null), "social", 23, "edf", 21, 45,
                DateTime.Now, 5);
            SqlAccess.SocialCouponRepository.Delete(id);
            SqlAccess.SocialCouponRepository.SaveChanges();
            var item = SqlAccess.SocialCouponRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("CouponAlert")]
        [TestMethod]
        public void Test_DeleteCouponAlert()
        {

            int id = SqlAccess.CouponAlertRepository.FindOne(null).Id;
            SqlAccess.CouponAlertRepository.Delete(id);
            SqlAccess.CouponAlertRepository.SaveChanges();
            var item = SqlAccess.CouponAlertRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("CouponOrder")]
        [TestMethod]
        public void Test_DeleteCouponOrder()
        {

            int id = SqlAccess.CreateCouponOrder(SqlAccess.CouponRepository.FindOne(null),
                SqlAccess.CostumerRepository.FindOne(null), "qr", false, "bg", 2, 5, DateTime.Now, "fads", "fdsfd");
            SqlAccess.CouponOrderRepository.Delete(id);
            SqlAccess.CouponOrderRepository.SaveChanges();
            var item = SqlAccess.CouponOrderRepository.FindById(id);
            Assert.IsNull(item);
        }

        [TestCategory("Delete"), TestCategory("SocialNetworkProfile")]
        [TestMethod]
        public void Test_DeleteSocialNetworkProfile()
        {

            int id = SqlAccess.CreateSocialNetwork(SqlAccess.CostumerRepository.FindOne(null), "socialProf", "pa", "dsf", "sdf",
                "sdfds", "sdfsd");
            SqlAccess.SocialProfileRepository.Delete(id);
            SqlAccess.SocialProfileRepository.SaveChanges();
            var item = SqlAccess.SocialProfileRepository.FindById(id);
            Assert.IsNull(item);
        }
        #endregion

    }
}
