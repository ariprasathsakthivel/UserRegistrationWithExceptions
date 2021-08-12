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
                Func<string, bool> nameValidation = name => Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}$");
                if (!nameValidation(name))
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
                return nameValidation(name);
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
                Func<string, bool> emailValidation = eMail => Regex.IsMatch(eMail, @"^[a-z]{2,}[-.+]?[a-z]*[0-9]*[@][a-z]*[0-9]*[.][a-z]{2,3}[.]{0,1}[a-z]{0,3}$");
                if (!emailValidation(eMail))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_EMAIL, "Invalid Email ID");
                }
                return emailValidation(eMail);
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
                Func<string, bool> numberValidation = number => Regex.IsMatch(number, @"^[9][1][ ][6-9][0-9]{9}$");
                if (!numberValidation(number))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_PHONE_NUMBER, "Invalid Phone Number");
                }
                return numberValidation(number);
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
                Func<string, bool> passwordValidation = password => Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&]).+$");
                if (!passwordValidation(password))
                {
                    throw new UserRegCustomException(UserRegCustomException.ExceptionType.INVALID_PASSWORD, "Invalid password");
                }
                return passwordValidation(password);
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