using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Lists
    {
        public static string BrandList =
            "Marka Id\t\t" +
            "Marka Adı\n" +
            "-----------------------------------";

    public static string CarList =
            "Araba Id\t" +
            "Marka Id\t " +
            "Renk Id\t" +
            "Model Yılı\t" +
            "Günlük Ücret\t" +
            "Açıklama\n" +
            "-----------------------------------" +
            "-----------------------------------";

        public static string ColorList = 
            "Renk Id\t\t" +
            "Renk Adı\n" +
            "-----------------------------------";

        public static string CustomerList = 
            "Müşteri Id\t\t" +
            "Kullanıcı Id\t\t" +
            "Şirket Adı\n" +
            "--------------------------------------------";

        public static string RentalList = 
            "Kiralama Id\t\t" +
            "Araba Id\t\t " +
            "Müşteri Id\t\t" +
            "Kiralama Tarihi\t\t" +
            "Teslim Tarihi\n" +
            "-----------------------------------" +
            "-----------------------------------" +
            "-----------------------------------";

        public static string UserList =
            "Kullanıcı Id\t\t" +
            "Adı\t\t " +
            "Soyadı\t\t" +
            "Email\t\t" +
            "Şifre\n" +
            "-----------------------------------" +
            "-----------------------------------";
    }
}
