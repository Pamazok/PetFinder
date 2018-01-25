using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Npgsql;

namespace PetFinder.Code
{
    public static class DBfunctions
    {
        public static DBclasses.KindOfAnimal getKindOfAnimalsById(int id)
        {
            DBclasses.KindOfAnimal result = new DBclasses.KindOfAnimal();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from kindofanimals where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.name = reader["name"].ToString();
                    result.photo = reader["photo"].ToString();
                    result.infoURL = reader["infoURL"].ToString();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return null;
                }
            }

            return result;
        }

        public static DBclasses.AsksCategory getAsksCategoriesById(int id)
        {
            DBclasses.AsksCategory result = new DBclasses.AsksCategory();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from askscategories where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.name = reader["name"].ToString();
                    result.photo = reader["photo"].ToString();
                    result.description = reader["description"].ToString();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return null;
                }
            }

            return result;
        }

        public static DBclasses.Organization getOrganizationById(int id)
        {
            DBclasses.Organization result = new DBclasses.Organization();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from organizations where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.isDeleted = (bool)reader["isDeleted"];
                    result.name = reader["name"].ToString();
                    result.contactPerson = reader["contactPerson"].ToString();

                    result.emails = reader["emails"] as string[];
                    result.phones = reader["phones"] as string[];

                    /* TODO */
                    result.callTimeFrom = reader["callTimeFrom"].ToString(); ;
                    result.callTimeTo = reader["callTimeTo"].ToString(); ;

                    result.addresses = reader["addresses"] as string[];
                    result.photo = reader["photo"].ToString();

                    result.aboutOrg = reader["aboutOrg"].ToString();
                    result.needHelp = reader["needHelp"].ToString();
                    result.donation = reader["donation"].ToString();
                    result.otherOrg = reader["otherOrg"].ToString();
                    result.linkToVK = reader["linkToVK"].ToString();
                    result.linkToFB = reader["linkToFB"].ToString();
                    result.linkToYT = reader["linkToYT"].ToString();
                    result.linkToTG = reader["linkToTG"].ToString();
                    result.linkToIG = reader["linkToIG"].ToString();

                    result.region = (int)reader["region"];
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    result.name = ex.StackTrace + ex.Message;
                    return result;
                }
            }

            return result;
        }

        public static DBclasses.Region getRegionById(int id)
        {
            DBclasses.Region result = new DBclasses.Region();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from regions where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.name = reader["name"].ToString();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return null;
                }
            }

            return result;
        }

        public static DBclasses.User getUserById(long id)
        {
            DBclasses.User result = new DBclasses.User();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from users where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.isDeleted = (bool)reader["isDeleted"];
                    result.rank = (int)reader["rank"];
                    result.organizationID = (int)reader["organizationID"];
                    result.name = reader["name"].ToString();
                    result.email = reader["email"].ToString();
                    result.phone1 = reader["phone1"].ToString();
                    result.phone2 = reader["phone2"].ToString();
                    result.getAsksInfo = reader["getAsksInfo"] as int[];
                    result.photo = reader["photo"].ToString();
                    /* TODO */
                    result.callTimeFrom = reader["callTimeFrom"].ToString(); ;
                    result.callTimeTo = reader["callTimeTo"].ToString(); ;
                    result.region = (int)reader["region"];
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    result.name = ex.StackTrace + ex.Message;
                    return result;
                }
            }

            return result;
        }

        public static DBclasses.Ask getAskById(int id)
        {
            DBclasses.Ask result = new DBclasses.Ask();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from asks where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.isDeleted = (bool)reader["isDeleted"];
                    result.addedByUser = (long)reader["addedByUser"];
                    result.addedDateTime = reader["addedDateTime"].ToString();
                    result.lastUpdatedByUser = (long)reader["lastUpdatedByUser"];
                    result.lastUpdatedDateTime = reader["lastUpdatedDateTime"].ToString();
                    result.categories = reader["categories"] as int[];
                    result.name = reader["name"].ToString();
                    result.desciption = reader["desciption"].ToString();
                    result.organizationID = (int)reader["organizationID"];
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    result.name = ex.StackTrace + ex.Message;
                    return result;
                }
            }

            return result;
        }

        public static DBclasses.ArchivePet getArchivePetById(int id)
        {
            DBclasses.ArchivePet result = new DBclasses.ArchivePet();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from archivepets where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.kindOfAnimals = (int)reader["kindOfAnimals"];
                    result.addedByUser = (long)reader["addedByUser"];
                    result.addedDateTime = reader["addedDateTime"].ToString();
                    result.organizationID = (int)reader["organizationID"];
                    result.name = reader["name"].ToString();
                    result.photos = reader["photos"] as string[];
                    result.homeFound = (bool)reader["homeFound"];
                    result.newOwnerName = reader["newOwnerName"].ToString();
                    result.newOwnerPhone = reader["newOwnerPhone"].ToString();
                    result.lastContactWithNewOwner = reader["lastContactWithNewOwner"].ToString();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    result.name = ex.StackTrace + ex.Message;
                    return result;
                }
            }

            return result;
        }

        public static DBclasses.Pet getPetById(long id)
        {
            DBclasses.Pet result = new DBclasses.Pet();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from pets where \"id\"=" + id.ToString();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    result.id = id;
                    result.kindOfAnimals = (int)reader["kindOfAnimals"];
                    result.addedByUser = (long)reader["addedByUser"];
                    result.addedDateTime = reader["addedDateTime"].ToString();
                    result.lastUpdatedByUser = (long)reader["lastUpdatedByUser"];
                    result.lastUpdatedDateTime = reader["lastUpdatedDateTime"].ToString();
                    result.name = reader["name"].ToString();
                    result.photos = reader["photos"] as string[];
                    result.code = reader["code"].ToString();
                    result.sterilised = (bool)reader["sterilised"];
                    result.pasported = (bool)reader["pasported"];
                    result.isLosted = (bool)reader["isLosted"];
                    result.birthDate = reader["birthDate"].ToString();
                    result.roughlyBirth = (bool)reader["roughlyBirth"];
                    result.roughlyDay = (bool)reader["roughlyDay"];
                    result.roughlyMonth = (bool)reader["roughlyMonth"];
                    result.organizationID = (int)reader["organizationID"];
                    result.address = reader["address"].ToString();
                    result.isDisabled = (bool)reader["isDisabled"];
                    result.disableDescription = reader["disableDescription"].ToString();
                    result.price = (long)reader["price"];
                    result.callTimeFrom = reader["_callTimeFrom"].ToString();
                    result.callTimeTo = reader["_callTimeTo"].ToString();
                    result.region = (int)reader["region"];
                    result.phones = reader["phones"] as string[];
                    result.vaccinated = (bool)reader["vaccinated"];
                    result.sex = (bool)reader["sex"];

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return null;
                }
            }

            return result;
        }

        public static List<DBclasses.Pet> getAllPets()
        {
            List<DBclasses.Pet> result = new List<DBclasses.Pet>();

            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(PetFinder.Code.Constants.NpgsqlConnect);
            string queue = "select * from pets order by id";
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(queue, connection);
            connection.Open();
            Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    DBclasses.Pet row = new DBclasses.Pet();

                    row.id = (long)reader["id"];
                    row.kindOfAnimals = (int)reader["kindOfAnimals"];
                    row.addedByUser = (long)reader["addedByUser"];
                    row.addedDateTime = reader["addedDateTime"].ToString();
                    row.lastUpdatedByUser = (long)reader["lastUpdatedByUser"];
                    row.lastUpdatedDateTime = reader["lastUpdatedDateTime"].ToString();
                    row.name = reader["name"].ToString();
                    row.photos = reader["photos"] as string[];
                    row.code = reader["code"].ToString();
                    row.sterilised = (bool)reader["sterilised"];
                    row.pasported = (bool)reader["pasported"];
                    row.isLosted = (bool)reader["isLosted"];
                    row.birthDate = reader["birthDate"].ToString();
                    row.roughlyBirth = (bool)reader["roughlyBirth"];
                    row.roughlyDay = (bool)reader["roughlyDay"];
                    row.roughlyMonth = (bool)reader["roughlyMonth"];
                    row.organizationID = (int)reader["organizationID"];
                    row.address = reader["address"].ToString();
                    row.isDisabled = (bool)reader["isDisabled"];
                    row.disableDescription = reader["disableDescription"].ToString();
                    row.price = (long)reader["price"];
                    row.callTimeFrom = reader["_callTimeFrom"].ToString();
                    row.callTimeTo = reader["_callTimeTo"].ToString();
                    row.region = (int)reader["region"];
                    row.phones = reader["phones"] as string[];
                    row.vaccinated = (bool)reader["vaccinated"];
                    row.sex = (bool)reader["sex"];

                    result.Add(row);

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return null;
                }
            }

            return result;
        }
    }
}