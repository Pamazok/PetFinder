using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFinder.Code
{
    public static class Constants
    {
        public static readonly string[] Ranks = {/*0*/"Посетитель", /*1*/"Посетитель с животным", /*2*/"Менеджер питомника", /*3*/"Руководитель питомника", /*4*/"Администратор", /*5*/"Я" };
        public static readonly int ResultsOnPage = 60;
        public static readonly string NpgsqlConnect = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=" + Passwords.NpgsqlPassword + ";Database=PetFinder";

        public static readonly string SiteName = "PetFinder";


        public static readonly string PetsPictures = @"C:\Users\Alex\Documents\Visual Studio 2013\Projects\PetFinder\PetFinder\Content\pictures\pets\";
        public static readonly string PetsPicturesPath = @"/Content/pictures/pets/";
    }
}