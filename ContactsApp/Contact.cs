﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
  
        /// <summary>
        /// Класс контакта
        /// </summary>
        public class Contact : ICloneable
        {
            /// <summary>
            /// Фамилия контакта
            /// </summary>
            private string _surname;

            /// <summary>
            /// Имя контакта
            /// </summary>
            private string _name;

            /// <summary>
            /// День рождения контакта
            /// </summary>
            private DateTime _birthday;

            /// <summary>
            /// e-mail контакта
            /// </summary>
            private string _email;

            /// <summary>
            /// ID страницы Вконтакте.
            /// </summary>
            private string _idVk;

            /// <summary>
            /// Номер телефона контакта
            /// </summary>
            public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

            /// <summary>
            /// Свойство фамилии
            /// Длина фамилии не может быть больше 50 символов, первая буква преобразовывается к верхнему регистру.
            /// </summary>
            public string Surname
            {
                get
                {
                    return _surname;
                }
                set
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentException("Please enter your surname");
                    }

                    if (value.Length <= 50)
                    {
                        _surname = char.ToUpper(value[0]).ToString() + value.Substring(1);
                    }
                    else
                    {
                        throw new ArgumentException("The surname cannot contain more than 50 letters");
                    }

                }
            }

        /// <summary>
        /// Свойство имени
        /// Длина имени не может быть больше 50 символов, первая буква преобразовывается к верхнему регистру.
        /// </summary>
        public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentException("Enter your name");
                    }

                    if (value.Length <= 50)
                    {
                        _name = char.ToUpper(value[0]).ToString() + value.Substring(1);
                    }
                    else
                    {
                        throw new ArgumentException("The name cannot contain more than 50 letters");
                    }
                }
            }

            /// <summary>
            /// Свойство E-mail
            /// E-mail не должен превышать 50 символов.
            /// </summary>
            public string Email
            {
                get
                {
                    return _email;
                }
                set
                {
                    if (value.Length <= 50)
                    {
                        _email = value;
                    }
                    else
                    {
                        throw new ArgumentException("Е-mail cannot be longer than 50 digits");
                    }
                }
            }

            /// <summary>
            /// Свойство ID Вконтакте
            /// ID Вконтакте не должно превышать 15 символов.
            /// </summary>
            public string IdVk
            {
                get
                {
                    return _idVk;
                }
                set
                {
                    if (value.Length <= 17)
                    {
                        _idVk = value;
                    }
                    else
                    {
                        throw new ArgumentException("IDvk cannot be longer than 15 digits");
                    }
                }
            }

            /// <summary>
            /// Свойство даты рождения
            /// Дата рождения не может быть менее 1900 года и больше текущей даты.
            /// </summary>
            public DateTime Birthday
            {
                get
                {
                    return _birthday;
                }
                set
                {
                    DateTime minData = new DateTime(1900, 1, 1);
                    if ((value < DateTime.Now) && (value > minData))
                    {
                        _birthday = value;
                    }
                    else
                    {
                        throw new ArgumentException("Date of birth cannot exceed the current date or subceed the year 1900");
                    }
                }
            }

            /// <summary>
            /// Метод клонирования объекта данного класса.
            /// </summary>
            /// <returns>Возвращает копию данного класса.</returns>
            public object Clone()
            {
                PhoneNumber phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };
                return new Contact
                {
                    Surname = this.Surname,
                    Name = this.Name,
                    Birthday = this.Birthday,
                    Email = this.Email,
                    IdVk = this.IdVk,
                    PhoneNumber = phoneNumber
                };
            }

        /// <summary>
        /// Метод, сравнивающий два объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Contact;
            if (toCompareWith == null)
            {
                return false;
            }

            return Name == toCompareWith.Name &&
            Surname == toCompareWith.Surname &&
            PhoneNumber.Number == toCompareWith.PhoneNumber.Number &&
            IdVk == toCompareWith.IdVk &&
            Email == toCompareWith.Email &&
            Birthday == toCompareWith.Birthday;
        }
    }
    
}
