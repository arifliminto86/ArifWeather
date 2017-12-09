using ArifWeather.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArifWeather.Service.Test
{
    [TestClass]
    public class UserTest : BaseTest
    {
        private string _encryptedPassword = "tQ8w4FV3p/DDT6hw3XU5qQ==";
        [TestMethod]
        public void DecryptPasswordTest()
        {            
            var password = User.DecryptWord(_encryptedPassword);

            Assert.IsTrue(password == CurrentUser.Password);
        }

        [TestMethod]
        public void EncryptPasswordTest()
        {
            var encryptedPassword = User.EncryptedWord(CurrentUser.Password);

            Assert.IsNotNull(encryptedPassword);
            Assert.IsTrue(encryptedPassword == _encryptedPassword);
        }
    }
}
