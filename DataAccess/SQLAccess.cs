using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public static class SqlAccess
    {
        static C_ModelContainer ce1 = new C_ModelContainer();
        //public  static EntityRepository<User> dor=new EntityRepository<User>(ce1); 
        public static Repository<User, C_ModelContainer> UseRepository = new Repository<User, C_ModelContainer>(ce1);
        public static Repository<Coupon, C_ModelContainer> CouponRepository = new Repository<Coupon, C_ModelContainer>(ce1);
        public static Repository<SocialCoupon, C_ModelContainer> SocialCouponRepository = new Repository<SocialCoupon, C_ModelContainer>(ce1);
        public static Repository<Costumer, C_ModelContainer> CostumerRepository = new Repository<Costumer, C_ModelContainer>(ce1);
        public static Repository<SystemAdmin, C_ModelContainer> AdminRepository = new Repository<SystemAdmin, C_ModelContainer>(ce1);
        public static Repository<Firm, C_ModelContainer> FirmRepository = new Repository<Firm, C_ModelContainer>(ce1);
        public static Repository<FirmOwner, C_ModelContainer> FirmOwenrRepository = new Repository<FirmOwner, C_ModelContainer>(ce1);
        public static Repository<CouponOrder, C_ModelContainer> CouponOrderRepository = new Repository<CouponOrder, C_ModelContainer>(ce1);
        public static Repository<CouponAlert, C_ModelContainer> CouponAlertRepository = new Repository<CouponAlert, C_ModelContainer>(ce1); 
        public static Repository<SocialNetworkProfile,C_ModelContainer> SocialProfileRepository=new Repository<SocialNetworkProfile, C_ModelContainer>(ce1); 
        public static Repository<Categories,C_ModelContainer> CategoriesRepository=new Repository<Categories, C_ModelContainer>(ce1);
    }
}