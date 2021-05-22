using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Name_CorrectName_ReturnsSameName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "Contact1";
            var expectedName = sourceName;

            //Act
            contact.Name = sourceName;
            var actualName = contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_LowCaseName_ReturnsUpperCaseName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "имя";
            var expectedName = "Имя";

            //Act
            contact.Name = sourceName;
            var actualName = contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_EmptyName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "";

            //Assert
            Assert.Throws<ArgumentException>
                (
                () =>

                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Name_TooLongName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "Contact Contact Contact Contact Contact Contact Contact Contact";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Surname_CorrectSurname_ReturnsSameSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "Contact1";
            var expectedSurname = sourceSurname;

            //Act
            contact.Surname = sourceSurname;
            var actualSurname = contact.Surname;

            //Assert
            Assert.AreEqual(expectedSurname, actualSurname);
        }

        [Test]
        public void Surname_LowCaseName_ReturnsUpperCaseSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "фамилия";
            var expectedSurname = "Фамилия";

            //Act
            contact.Surname = sourceSurname;
            var actualName = contact.Surname;

            //Assert
            Assert.AreEqual(expectedSurname, actualName);
        }

        [Test]
        public void Surname_EmprtyName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Surname_TooLongSurname_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "Contact Contact Contact Contact Contact Contact Contact Contact";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Email_CorrectEmail_ReturnSameEmail()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "email@mail.com";
            var expectedEmail = sourceEmail;

            //Act
            contact.Email = sourceEmail;
            var actualEmail = contact.Email;

            //Assert
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void Email_TooLongEmail_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "Email Email Email Email Email Email Email Email Email Email Email Email";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Email = sourceEmail;
                }
            );
        }

        [Test]
        public void IdVk_CorrectIdVk_ReturnSameIdVk()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "email@mail.com";
            var expectedIdVk = sourceIdVk;

            //Act
            contact.IdVk = sourceIdVk;
            var actualIdVk = contact.IdVk;

            //Assert
            Assert.AreEqual(expectedIdVk, actualIdVk);
        }

        [Test]
        public void IdVk_TooLongIdVk_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "IdVk IdVk IdVk IdVk IdVk IdVk IdVk";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.IdVk = sourceIdVk;
                }
            );
        }

        [Test]
        public void Birthday_CorrectBirthday_ReturnSameBirthday()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthday = new DateTime(2000, 1, 1);
            var expectedBirthday = sourceBirthday;

            //Act
            contact.Birthday = sourceBirthday;
            var actualBirthday = contact.Birthday;

            //Assert
            Assert.AreEqual(expectedBirthday, actualBirthday);
        }

        [Test]
        public void Birthday_TooSmallBirthday_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthday = new DateTime(1800, 1, 1);

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Birthday = sourceBirthday;
                }
            );
        }
        [Test]
        public void CloneContact_Correctly()
        {
            //Setup
            var sourceContact = new Contact
            {
                PhoneNumber = { Number = 71122334455 },
                Birthday = new DateTime(2020, 12, 8),
                Email = "123@gmail.com",
                IdVk = "qwerty",
                Name = "Вася",
                Surname = "Пупкин"
            };

            //Act
            var actualContact = (Contact)sourceContact.Clone();

            //Assert
            Assert.AreEqual(sourceContact, actualContact);
        }
    }
}
