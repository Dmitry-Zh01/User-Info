using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.DirectoryServices; 
using System.Text; 

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
	 MessageTextBox1.Text = null;

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
  
StringBuilder sb = new StringBuilder();


               foreach (String ldapField in fields.PropertyNames)  
               {  
                  // cycle through objects in each field e.g. group membership  
                  // (for many fields there will only be one object such as name)  
                  foreach (Object myCollection in fields[ldapField]) {

// тут указаны условия аттрибутов

if (ldapField == "name"){
			sb.Append($"Имя: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "mail"){

			sb.AppendFormat($"Почта: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "distinguishedname"){

			sb.AppendFormat($"distinguishedname: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "whencreated"){

			sb.AppendFormat($"Создан: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "pwdlastset"){

			sb.AppendFormat($"Пароль: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "title"){

			sb.AppendFormat($"Должность: {myCollection.ToString()} \r\n");
			}

else if (ldapField == "proxyaddresses"){

			sb.AppendFormat($"{myCollection.ToString()} \r\n");
			}

MessageTextBox1.Text = ($"{sb}");



// тут завершаются указания условий аттрибутов

}
               }  
            }  
  
            else  
            {  
               // user does not exist  
              MessageTextBox1.Text = "Пользователь не найден :(";  
            } 
         }
  
     //    catch (Exception c)  
     //   {  
     //       MessageTextBox1.Text = c.ToString();  
     //   }  

         catch (System.ArgumentException qe)  
        {  
            MessageTextBox1.Text = $"Ничего не введено. Введите ID пользователя. \r\n Ошибка: \r\n {qe}"; 

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

