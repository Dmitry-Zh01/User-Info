using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.DirectoryServices;  

namespace FormApp;

// Запуск формы
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

// Действие кнопки Найти (Button1)
	private void Button1_Click(object sender, EventArgs e)
	{
   	 string username = InputTextBox1.Text;
	 InputTextBox1.Text = null;
  
         try  
         {  
            // create LDAP connection object  
  
            DirectoryEntry myLdapConnection = createDirectoryEntry();  
  
            // create search object which operates on LDAP connection object  
            // and set search object to only find the user specified  
  
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);  
            search.Filter = "(SamAccountName=" + username + ")";  
  
            // create results objects from search object  
  
            SearchResult result = search.FindOne();  
              
            if (result != null)  
            {  
               // user exists, cycle through LDAP fields 
  
               ResultPropertyCollection fields = result.Properties;  
  
               foreach (String ldapField in fields.PropertyNames)  
               {  
                  // cycle through objects in each field e.g. group membership  
                  // (for many fields there will only be one object such as name)  
                  foreach (Object myCollection in fields[ldapField]) 
                     MessageTextBox1.Text += ($"{ldapField}: \n {myCollection.ToString()}");

               }  
            }  
  
            else  
            {  
               // user does not exist  
              MessageTextBox1.Text = "Пользователь не найден :(";  
            } 
         }
  
         catch (Exception c)  
        {  
            MessageTextBox1.Text = c.ToString();  
        }  
      }  

      static DirectoryEntry createDirectoryEntry()  
      {  
         // create and return new LDAP connection with desired settings  
  
         DirectoryEntry ldapConnection     = new DirectoryEntry("cww.pep.pvt");  
         ldapConnection.Path               = "LDAP://cww.pep.pvt";  
         ldapConnection.AuthenticationType = AuthenticationTypes.Secure;  
  
         return ldapConnection;  

	}

// Действие кнопки Очистить (Button2)
	private void Button2_Click(object sender, EventArgs e)
	{
   	 MessageTextBox1.Text = null;
	}

}

