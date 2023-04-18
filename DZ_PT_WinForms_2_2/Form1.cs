using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ_PT_WinForms_2_2
{

    public partial class Form1 : Form
    {
        private List<User> _users;
        public Form1()
        {
            InitializeComponent();
            _users = new List<User>();
        }
        private void Open_Click(object sender, EventArgs e)
        {
            string[] strArray = File.ReadAllLines("save.txt");
            GuestionnaireBox.Items.AddRange(strArray);
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            // считываем данные из текстовых полей
            string firstName = FirstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;

            // создаем нового пользователя
            User newUser = new User(firstName, lastName, email, phone);

            // добавляем его в список пользователей
            _users.Add(newUser);

            // добавляем информацию о пользователе в ListBox
            GuestionnaireBox.Items.Add(newUser.ToString());



        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // получаем выбранный элемент в ListBox
            string selectedUser = GuestionnaireBox.SelectedItem.ToString();

            // ищем пользователя в списке по его строковому представлению
            User userToDelete = _users.FirstOrDefault(u => u.ToString() == selectedUser);

            // если пользователь найден, удаляем его из списка и ListBox
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                GuestionnaireBox.Items.Remove(selectedUser);
            }
        }



        private void addButton_Click_1(object sender, EventArgs e)
        {
            // считываем данные из текстовых полей
            string firstName = FirstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;

            // создаем нового пользователя
            User newUser = new User(firstName, lastName, email, phone);

            // добавляем его в список пользователей
            _users.Add(newUser);

            // добавляем информацию о пользователе в ListBox
            GuestionnaireBox.Items.Add(newUser.ToString());
        }

        private void CleanTextBox_Click(object sender, EventArgs e)
        {
            FirstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            phoneTextBox.Text = "";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            const string sPath = "save.txt";


            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in GuestionnaireBox.Items)
            {
                SaveFile.WriteLine(item);
            }



            SaveFile.Close();



            MessageBox.Show("Файл сохранён");
        }
        //это не работает
        private void Save_Click_xml(object sender, EventArgs e)
        {
            
            XmlDocument xmlDocument = new XmlDocument();

            
            XmlElement usersElement = xmlDocument.CreateElement("users");

            
            foreach (User user in _users)
            {                
                XmlElement userElement = xmlDocument.CreateElement("user");               
                XmlElement firstNameElement = xmlDocument.CreateElement("firstName");
                firstNameElement.InnerText = user.FirstName;
                XmlElement lastNameElement = xmlDocument.CreateElement("lastName");
                lastNameElement.InnerText = user.LastName;
                XmlElement emailElement = xmlDocument.CreateElement("email");
                emailElement.InnerText = user.Email;
                XmlElement phoneElement = xmlDocument.CreateElement("phone");
                phoneElement.InnerText = user.Phone;
                userElement.AppendChild(firstNameElement);
                userElement.AppendChild(lastNameElement);
                userElement.AppendChild(emailElement);
                userElement.AppendChild(phoneElement);
                usersElement.AppendChild(userElement);
            }
            xmlDocument.AppendChild(usersElement);

            xmlDocument.Save("save.xml");

            MessageBox.Show("Файл сохранен");
        }
        

    }
}