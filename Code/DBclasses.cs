using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFinder.Code
{
    public class DBclasses
    {

        public class KindOfAnimal {
            public int id { get; set; }
            public string name { get; set; }
            public string infoURL { get; set; }
            public string photo { get; set; }
        }

        public class Region
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class AsksCategory
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string photo { get; set; }
        }

        public class Organization
        {
            public int id { get; set; }
            public bool isDeleted { get; set; }
            public string name { get; set; }
            public string contactPerson { get; set; }
            public string[] emails { get; set; }
            public string[] phones { get; set; }
            /* Time */
            public string callTimeFrom { get; set; }
            public string callTimeTo { get; set; }
            public string[] addresses { get; set; }
            public string photo { get; set; }
            public string aboutOrg { get; set; }
            public string needHelp { get; set; }
            public string donation { get; set; }
            public string otherOrg { get; set; }
            public string linkToVK { get; set; }
            public string linkToFB { get; set; }
            public string linkToYT { get; set; }
            public string linkToTG { get; set; }
            public string linkToIG { get; set; }
            public int region { get; set; }
        }

        public class User
        {
            public long id { get; set; }
            public bool isDeleted { get; set; }
            public int rank { get; set; }
            public int organizationID { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string phone1 { get; set; }
            public string phone2 { get; set; }
            public int[] getAsksInfo { get; set; }
            public string photo { get; set; }
            public string callTimeFrom { get; set; }
            public string callTimeTo { get; set; }
            public int region { get; set; }
        }

        public class Ask
        {
            public long id { get; set; }
            public bool isDeleted { get; set; }
            public long addedByUser { get; set; }
            public string addedDateTime { get; set; } /* ToDo */
            public long lastUpdatedByUser { get; set; }
            public string lastUpdatedDateTime { get; set; } /* ToDo */
            public int[] categories { get; set; }
            public string name { get; set; }
            public string desciption { get; set; }
            public int organizationID { get; set; }
        }

        public class ArchivePet
        {
            public long id { get; set; }
            public int kindOfAnimals { get; set; }
            public long addedByUser { get; set; }
            public string addedDateTime { get; set; } /* ToDo */
            public int organizationID { get; set; }
            public string name { get; set; }
            public string[] photos { get; set; }
            public bool homeFound { get; set; }
            public string newOwnerName { get; set; }
            public string newOwnerPhone { get; set; }
            public string lastContactWithNewOwner { get; set; } /* ToDo */
        }

        public class Pet
        {
            public long id { get; set; }
            public int kindOfAnimals { get; set; }
            public long addedByUser { get; set; }
            public string addedDateTime { get; set; } /* ToDo */ 
            public long lastUpdatedByUser { get; set; }
            public string lastUpdatedDateTime { get; set; } /* ToDo */
            public string name { get; set; }
            public string[] photos { get; set; }
            public string description { get; set; }
            public string code { get; set; }
            public bool sterilised { get; set; }
            public bool pasported { get; set; }
            public bool isLosted { get; set; }
            public string birthDate { get; set; } /* ToDo */
            public bool roughlyBirth { get; set; }
            public bool roughlyDay { get; set; }
            public bool roughlyMonth { get; set; }
            public int organizationID { get; set; }
            public string address { get; set; }
            public bool isDisabled { get; set; }
            public string disableDescription { get; set; }
            public long price { get; set; }
            public string callTimeFrom { get; set; }
            public string callTimeTo { get; set; }
            public int region { get; set; }
            public string[] phones { get; set; }
            public bool vaccinated { get; set; }
            public bool sex { get; set; } /* 0 - female, 1 - male */

        }
    }
}