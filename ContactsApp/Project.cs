﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Project
    {
        /// <summary>
        /// Динамическая коллекция контактов проекта
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Индекс текущего контакта.
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Сортировка списка контактов по алфавиту.
        /// </summary>
        public List<Contact> SortContacts(List<Contact> contact)
        {
            return contact.OrderBy(item => item.Surname).ToList();
        }
    }
}
