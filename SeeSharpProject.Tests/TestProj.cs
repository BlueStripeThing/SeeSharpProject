using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace SeeSharpProject
{
    
    public class TestProj
    {
        [Fact]
        public void DecryptWithUpper()
        {
            //Arrange
            Encryptor enc = new Encryptor();
            string expected = "ПоздРАвляЮ, ТЫ ПолучИл исхоДНЫй теКст";
            //Act
            string generated = enc.Decrypt("БщцфАИрщрИ, БЛ ЯчъбиУъ щбюэСЯЁш гфУаа", "скорпион");

            //Assert
            Assert.Equal(expected, generated);
        }

        [Fact]
        public void DecryptWithForeighn()
        {
            //Arrange
            Encryptor enc = new Encryptor();
            string expected = "ПоздРАвWляЮD, ТЫ ПолaучИл исхdоДНЫй теTКст";
            //Act
            string generated = enc.Decrypt("БщцфАИрWщрИD, БЛ ЯчъaбиУъ щбюdэСЯЁш гфTУаа", "скорпион");

            //Assert
            Assert.Equal(expected, generated);
        }

        [Fact]
        public void EncryptWithForeighn()
        {
            //Arrange
            Encryptor enc = new Encryptor();
            string expected = "БщцфАИрWщрИD, БЛ ЯчъaбиУъ щбюdэСЯЁш гфTУаа";
            //Act
            string generated = enc.Encrypt("ПоздРАвWляЮD, ТЫ ПолaучИл исхdоДНЫй теTКст", "скорпион");

            //Assert
            Assert.Equal(expected, generated);
        }

        [Fact]
        public void EncryptWithUpper()
        {
            //Arrange
            Encryptor enc = new Encryptor();
            string expected = "БщцфАИрщрИ, БЛ ЯчъбиУъ щбюэСЯЁш гфУаа";
            //Act
            string generated = enc.Encrypt("ПоздРАвляЮ, ТЫ ПолучИл исхоДНЫй теКст", "скорпион");

            //Assert
            Assert.Equal(expected, generated);
        }

        [Fact]
        public void EncryptZeroNumbers()
        {
            //Arrange
            Encryptor enc = new Encryptor();
            string expected = "123143./''/'0977']     \\?>!@#$%^";
            //Act
            string generated = enc.Encrypt("123143./''/'0977']     \\?>!@#$%^", "скорпион");

            //Assert
            Assert.Equal(expected, generated);
        }
    }
}
