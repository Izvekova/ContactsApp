using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTests
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
        /// <summary>
        /// Тест на сериализацию 
        /// </summary>
        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData";
            var actualFilename = testDataFolder + @"\ContactsApp.json";
            var expectedFilename = testDataFolder + @"\ExpectedProject.json";
            if (File.Exists(actualFilename))
            {
                File.Delete(actualFilename);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, testDataFolder);

            //Assert
            var actualFileContent = File.ReadAllText(actualFilename);
            var expectedFileContent = File.ReadAllText(expectedFilename);
            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        /// <summary>
        /// Правильная загрузка
        /// </summary>
        [Test]
        public void LoadToFile_CorrectProject_FileLoadCorrectly()
        {
            //Setup
            var expectedProject = PrepareProject();

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testDataFolder);

            //Assert
            Assert.AreEqual(expectedProject.Contacts, actualProject.Contacts);
        }

        /// <summary>
        /// Когда неправильный файл (путь), возвращаем пустой проджект
        /// </summary>
        [Test]
        public void LoadFromFile_UnCorrectFile_ReturnEmptyProject()
        {
            //Setup
            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\wrong\";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testDataFolder);

            //Assert
            Assert.IsEmpty(actualProject.Contacts);
        }
    }
}
