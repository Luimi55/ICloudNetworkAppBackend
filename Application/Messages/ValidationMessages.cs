using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messages
{
    public static class ValidationMessages
    {
        public static string IsRequired(string field)
        {
            return $"{field} is required.";
        }

        public static string IsRequiredForEntity(string field, string entity)
        {
            return $"{field} is required for entity {entity}.";
        }

        public static string MaxLenght(string field, int limit)
        {
            return $"{field} must be less than {limit}.";
        }

        public static string PositiveNumber(string field)
        {
            return $"{field} must be positive.";
        }

        public static string LowerThan(string field1, string field2)
        {
            return $"{field1} must be lower than {field2}.";
        }

        public static string MustBe(string field, string whatMustBe)
        {
            return $"{field} must be {whatMustBe}.";
        }

        public static string MustNotBe(string field, string whatNotMustBe)
        {
            return $"{field} must not be {whatNotMustBe}.";
        }

        public static string Exist(string field)
        {
            return $"{field} already exist.";
        }

        public static string NotExist(string field)
        {
            return $"{field} not exist.";
        }

        public static string InvalidEmail(string field)
        {
            return $"{field} invalid email address format.";
        }

        public static string InvalidFormat(string field)
        {
            return $"{field} format is not valid.";
        }
    }
}
