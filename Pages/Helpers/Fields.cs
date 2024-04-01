using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Helpers
{
    /// <summary>
    /// Промежуточный класс для хранения значений полей.
    /// </summary>
    public static class Fields
    {
        public static string _firstName;
        public static string _lastName;
        public static string _middleName;
        public static string _birthDate;
        public static string _phoneNumber;

        public static void GenerateFields()
        {
            _firstName = FieldGenerator.GenerateRandomString(10);
            _lastName = FieldGenerator.GenerateRandomString(10);
            _middleName = FieldGenerator.GenerateRandomString(10);
            _birthDate = FieldGenerator.GenerateRandomBirthDate();
            _phoneNumber = FieldGenerator.GenerateRandomPhoneNumber();
        }
    }
}
