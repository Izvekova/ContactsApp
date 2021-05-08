using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactsForm : Form
    {
        /// <summary>
        /// Времененное хранение контакта
        /// </summary>
        private Contact _contact = new Contact();

        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = (Contact)value.Clone();
                SurnameBox.Text = value.Surname;
                NameBox.Text = value.Name;
                vkBox.Text = value.IdVk;
                EmailBox.Text = value.Email;
                if (value.PhoneNumber.Number != 0)
                    PhoneBox.Text = value.PhoneNumber.Number.ToString();
                BirthdayTimePicker.Value = value.Birthday;
            }
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public ContactsForm()
        {
            InitializeComponent();
            BirthdayTimePicker.MaxDate = DateTime.Now;
            BirthdayTimePicker.Value = BirthdayTimePicker.MaxDate;
        }

        /// <summary>
        /// Создание контакта для добавления или редактирования
        /// </summary>
        private void ModifyContact()
        {
            try
            {
                Contact.Surname = SurnameBox.Text;
                Contact.Name = NameBox.Text;
                Contact.IdVk = vkBox.Text;
                Contact.Email = EmailBox.Text;
                Contact.Birthday = BirthdayTimePicker.Value;
                var phoneNumber = new PhoneNumber
                {
                    Number = PhoneBox.Text != "" ? Convert.ToInt64(PhoneBox.Text) : 0
                };
                Contact.PhoneNumber = phoneNumber;
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        /// <summary>
        /// Изменение текстового поля vkBox при ошибке вводе
        /// </summary>
        private void vkBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.IdVk = vkBox.Text;
                vkBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                vkBox.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Изменение текстового поля SurnameBox при ошибке вводе
        /// </summary>
        private void SurnameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameBox.Text;
                SurnameBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SurnameBox.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Изменение текстового поля NameBox при ошибке вводе
        /// </summary>
        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameBox.Text;
                NameBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameBox.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Изменение текстового поля PhoneBox при ошибке вводе
        /// </summary>
        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneBox.Text, out number);
                _contact.PhoneNumber.Number = number;
                PhoneBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneBox.BackColor = Color.LightSalmon;
            }
        }

        /// <summary>
        /// Изменение текстового поля EmailBox при ошибке вводе
        /// </summary>
        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailBox.Text;
                EmailBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailBox.BackColor = Color.LightSalmon;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            ModifyContact();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContactsForm_Load(object sender, EventArgs e)
        {

        }
    }

}
