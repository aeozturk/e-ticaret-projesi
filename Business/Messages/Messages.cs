using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Messages
{
    public static class Messages
    {
        public static string ProductExists = "Ürün zaten mevcut";
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductNotFound = "Ürün bulunamadı.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";
        public static string ProductDeleted = "Ürün başarıyla pasifleştirildi.";
        public static string ProductBarkodAlreadyExist = "Bu barkod başka bir ürüne kayıtlıdır.";

        public static string TradeMarkHaveNotProduct = "Bu markaya ait bir ürün bulunmamaktadır.";
        public static string ViskoziteNotFound = "Bu viskoziteli bir ürün bulunamadı.";

        public static string OrderAdded = "Sipariş başarıyla eklendi.";
        public static string OrderNotFound = "Sipariş bulunamadı.";
        public static string OrderUpdated = "Sipariş başarıyla güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string LoginPasswordNotMatch = "Girdiğiniz şifre hatalıdır.";
        public static string UserLoginSucceed = "Kullanıcı girişi başarılı.";
        public static string UserAlreadyExist = "Kullanıcı zaten kayıtlı.";
        public static string UserRegisterSucceed = "Kullanıcı kaydı başarılı.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserStatusChanged = "Kullanıcı durumu değiştirildi.";

    }
}
