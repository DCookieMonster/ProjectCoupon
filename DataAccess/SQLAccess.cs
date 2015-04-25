using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public static int CreateUser(string username,string pass,string email)
        {
            try
            {
               
                  
                    var user = new User { email = email, password = pass, username = username };


                    var newUser = UseRepository.Create(user);
                    UseRepository.SaveChanges();
                return newUser.Id;

            }
            catch (Exception e)
            {
                                  return -1;
            }
        }

        public static int CreateCostumer(string username,string pass,string email, int gender, double age)
        {
            try
            {
                var costumer = new Costumer
                {
                    age = age,
                    gender = (Gender) gender,
                    username = username,
                    password = pass,
                    email = email
                };
                var newCost = CostumerRepository.Create(costumer);
                CostumerRepository.SaveChanges();
                return newCost.Id;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static int CreateAdmin(string username, string pass, string email)
        {
            try
            {
                var admin = new SystemAdmin {email = email, password = pass, username = username};
                var newAdmin = AdminRepository.Create(admin);
                AdminRepository.SaveChanges();
                return newAdmin.Id;
                //C_ModelContainer ce=new C_ModelContainer();
                //ce.Users.Add(admin);
                //ce.SaveChanges();
                return admin.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static int CreateFirmOwner(SystemAdmin sa,string username, string pass, string email)
        {
            try
            {
                var admin = new FirmOwner {email = email, password = pass, username = username, SystemAdmin = sa};
                var newAdmin = FirmOwenrRepository.Create(admin);
                FirmOwenrRepository.SaveChanges();
                return newAdmin.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static int CreateCoupon(User user,string name,double aRank,string desc,double disPrice,
            double origPrice,DateTime lastTime,int reaminQua)
        {
            try
            {
                var coupon = new Coupon
                {
                    User = user,
                    aggregatedRank = aRank,
                    description = desc,
                    discountPrice = disPrice,
                    lastDateForUse = lastTime,
                    name = name,
                    originalPrice = origPrice,
                    reaminingQuantity = reaminQua
                };
                var newCoupon = CouponRepository.Create(coupon);
                CouponRepository.SaveChanges();
                return newCoupon.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int CreateSocialCoupon(Costumer costumer, string name, double aRank, string desc, double disPrice,
            double origPrice, DateTime lastTime, int reaminQua)
        {

            try
            {
                var coupon = new SocialCoupon
                {
                    User = costumer,
                    Costumer = costumer,
                    name = name,
                    originalPrice = origPrice,
                    reaminingQuantity = reaminQua,
                    lastDateForUse = lastTime,
                    aggregatedRank = aRank,
                    description = desc,
                    discountPrice = disPrice
                };
                var newCoupon = SocialCouponRepository.Create(coupon);
                SocialCouponRepository.SaveChanges();
                return newCoupon.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int CreateFirm(SystemAdmin admin,FirmOwner owner,string name,string address,string city,string desc,
            double longitude, double latitue)
        {
            try
            {
                var firm = new Firm
                {
                    name = name,
                    address = address,
                    SystemAdmin = admin,
                    FirmOwner = owner,
                    city = city,
                    latitude = latitue,
                    longitude = longitude,
                    description = desc
                };
                var newCoupon = FirmRepository.Create(firm);
                FirmRepository.SaveChanges();
                return newCoupon.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int CreateSocialNetwork(Costumer costumer, string username, string password, string email, string rData,
            string sData, string authToken)
        {
            try
            {
                var social = new SocialNetworkProfile
                {
                    Costumer = costumer,
                    authToken = authToken,
                    email = email,
                    username = username,
                    password = password,
                    recivedDData = rData,
                    sendData = sData
                };
                var newSocail = SocialProfileRepository.Create(social);
                SocialProfileRepository.SaveChanges();
                return newSocail.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int CreateCouponAlert(int alertType,string text)
        {
            try
            {
                var couponAlert = new CouponAlert();
                couponAlert.alerType = (AlertType) alertType;
                couponAlert.text = text;
                var newCoupon = CouponAlertRepository.Create(couponAlert);
                CouponAlertRepository.SaveChanges();
                return newCoupon.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int CreateCouponOrder(Coupon coup,Costumer costumer, string QR, bool isUsed, string CreaditApproval, int quant,
         double rank, DateTime date, string recipt,string serialNumber)
        {
            try
            {
                var coupon = new CouponOrder();
                coupon.QR = QR;
                coupon.date = date;
                coupon.creditApproval = CreaditApproval;
                coupon.isUsed = isUsed;
                coupon.quantity = quant;
                coupon.rank = rank;
                coupon.recipt = recipt;
                coupon.serialKey = serialNumber;
                coupon.Costumer = costumer;
                coupon.Coupons = coup;
                var newCoupon = CouponOrderRepository.Create(coupon);
                CouponOrderRepository.SaveChanges();
                return newCoupon.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
    }
}