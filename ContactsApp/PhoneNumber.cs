using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// Свойства номера телефона
        /// Поле может быть только числовым и содержать ровно 11 цифр. Первая цифра должна быть ‘7’.
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(message: "Phone number must be 11 digits long and start with 7");
                }
            }
        }
    }
}
