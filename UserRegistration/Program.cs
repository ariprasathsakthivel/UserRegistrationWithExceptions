using System;
using System.Text.RegularExpressions;

namespace UserRegistrationRegex
{
    public class Program : Exception
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to User registration validator program");
        }
        public static bool NameCheck(string name)
        {
            try
            {
                string pattern = "^[A-Z]{1}[a-z]{2,}$";
                if (!Regex.IsMatch(name, pattern))
                {
                    if (!char.IsUpper(name[0]))
                    {
                        throw new UserRegCustomException(UserRegCustomException.ExceptionType.FIRST_CAPITAL, "First Letter must be in upper case");
                    }
                    else if (name.Length < 4)
                    {
                        throw new UserRegCustomException(UserRegCustomException.ExceptionType.MIN_THREE, "Name must contain minimum three letters");
                    }
                }
                return Regex.IsMatch(name, pattern);
            }
            catch (UserRegCustomException ex)
            {
                Console.WriteLine(ex.message);
                return false;
            }
            catch (ArgumentNullException)
            {
                throw new UserRegCustomException(UserRegCustomException.ExceptionType.ENTERED_NULL, "name cannot have null in it");
            }
            catch (IndexOutOfRangeException)
            {
                throw new UserRegCustomException(UserRegCustomException.ExceptionType.EMPTY, "Name cannot be empty");
            }
        }
        public static bool EmailCheck(string eMail)
        {
            try
            {
                string pattern = "^[a-z]{2,}[-.+]?[a-z]*[0-9]*[@][a-z]*[0-9]*[.][a-z]{2,3}[.]{0,1}[a-z]{0,3}$";
                if (!Regex.IsMatch(eMail, pattern))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_EMAIL, "Invalid Email ID");
                }
                return Regex.IsMatch(eMail, pattern);
            }
            catch (UserRegCustomException ex)
            {
                Console.WriteLine(ex.message);
                return false;
            }
            catch (NullReferenceException)
            {
                throw new UserRegCustomException(UserRegCustomException.ExceptionType.ENTERED_NULL, "Email cannot have null in it");
            }
        }
        public static bool PhoneNumberCheck(string number)
        {
            try
            {
                string pattern = "^[9][1][ ][6-9][0-9]{9}$";
                if (!Regex.IsMatch(number,pattern))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_PHONE_NUMBER, "Invalid Phone Number");
                }
                return Regex.IsMatch(number, pattern);
            }
            catch (UserRegCustomException ex)
            {
                Console.WriteLine(ex.message);
                return false;
            }
            catch (NullReferenceException)
            {
                throw new UserRegCustomException(UserRegCustomException.ExceptionType.ENTERED_NULL, "Phone number cannot have null in it");
            }
        }
        public static bool PasswordCheck(string password)
        {
            try
            {
                string pattern = "^.*[!@#$%^&*,.-_][0-9]*.*$";
                if (!Regex.IsMatch(password,pattern))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_PASSWORD, "Invalid password");
                }
                return Regex.IsMatch(password, pattern);
            }
            catch (UserRegCustomException ex)
            {
                Console.WriteLine(ex.message);
                return false;
            }
            catch (NullReferenceException)
            {
                throw new UserRegCustomException(UserRegCustomException.ExceptionType.ENTERED_NULL, "Password cannot have null in it");
            }
        }
    }
}
