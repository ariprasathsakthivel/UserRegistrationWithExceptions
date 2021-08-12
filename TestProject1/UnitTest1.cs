using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistrationRegex;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("Ariprasath")]
        [DataRow("Ramu")]
        [DataRow("Ari")]
        public void FirstName(string name)
        {
            Assert.IsTrue(Program.NameCheck(name));
        }
        [TestMethod]
        [DataRow("Sakthivel")]
        [DataRow("Kiran")]
        [DataRow("Kumar")]
        public void LastName(string name)
        {
            Assert.IsTrue(Program.NameCheck(name));
        }
        [TestMethod]
        public void Email()
        {
            string[] testMails = new string[]
                {       
                "abc@yahoo.com",
                "abc-100@yahoo.com",
                "abc.100@yahoo.com",
                "abc111@yahoo.com",
                "abc-100@yahoo.com",
                "abc.100@yahoo.com",
                "abc@1.com",
                "abc@gmail.com.com",
                "abc+100@gmail.com",
                };
            foreach (string mail in testMails)
            {
                Assert.IsTrue(Program.EmailCheck(mail));
            }
        }
        [TestMethod]
        [DataRow("91 9002446615")]
        [DataRow("91 7415874266")]
        [DataRow("91 6385426315")]
        public void PhoneNumber(string number)
        {
            Assert.IsTrue(Program.PhoneNumberCheck(number));
        }
        [TestMethod]
        [DataRow("Login@1aa@")]
        [DataRow("Login@2aa23")]
        [DataRow("Login@3a33a")]
        public void Password(string password)
        {
            Assert.IsTrue(Program.PasswordCheck(password));
        }
    }
}
