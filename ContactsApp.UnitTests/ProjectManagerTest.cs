using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        public Project PrepareProject()
        {
            var sourceProject = new Project();

            sourceProject.Contacts.Add(new Contact()
            {
                Surname = "Пчелкин",
                Name = "Иван",
                Birthday = new DateTime(2020, 12, 7, 23, 55, 17),
                PhoneNumber = new PhoneNumber()
                {
                    Number = 78901234567
                },
                IdVk = "qwerty",
                Email = "123@gmail.com"
            }
            );

            sourceProject.Contacts.Add(new Contact()
            {
                Surname = "Пупкин",
                Name = "Вася",
                Birthday = new DateTime(2020, 12, 7, 23, 55, 17),
                PhoneNumber = new PhoneNumber()
                {
                    Number = 78891234321
                },
                IdVk = "qwerty",
                Email = "123@gmail.com"
            }
            );
            return sourceProject;
        }


        [Test]
        public void LoadToFile_CorrectProject_FileLoadCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\";

            //Act
            var actualFilename = ProjectManager.LoadFromFile(testDataFolder);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sourceProject.Contacts.Count, actualFilename.Contacts.Count);
                for (int i = 0; i != sourceProject.Contacts.Count; i++)
                {
                    Assert.AreEqual(sourceProject.Contacts[i].Surname, actualFilename.Contacts[i].Surname);
                    Assert.AreEqual(sourceProject.Contacts[i].Name, actualFilename.Contacts[i].Name);
                    Assert.AreEqual(sourceProject.Contacts[i].Birthday, actualFilename.Contacts[i].Birthday);
                    Assert.AreEqual(sourceProject.Contacts[i].PhoneNumber.Number, actualFilename.Contacts[i].PhoneNumber.Number);
                    Assert.AreEqual(sourceProject.Contacts[i].IdVk, actualFilename.Contacts[i].IdVk);
                    Assert.AreEqual(sourceProject.Contacts[i].Email, actualFilename.Contacts[i].Email);
                }
            });
        }

        [Test]
        public void LoadToFile_ExistFile_LoadCorrectly()
        {
            //Setup

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\";
            var expectedFilename = testDataFolder + "\\ContactsApp.notes";

            //Act
            var actualFilename = ProjectManager.LoadFromFile(expectedFilename);

            //Assert
            Assert.IsNotNull(actualFilename);

        }

        [Test]
        public void LoadToFile_EmptyFile_CreateNewProject()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\EmptyFile\";
            ProjectManager.LoadFromFile(testDataFolder);
        }
    }
}
