using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.DirectoryServices; 
using System.Text; 
using System.Runtime.InteropServices;
using System.DirectoryServices.ActiveDirectory;

namespace pet;

// Запуск формы
public partial class Form1 : Form
{

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


private int borderSize = 2;

    public Form1()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

// text changed
        InputTextBox1.TextChanged += textBox1_TextChanged;
    }
           

 private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageTextBox1.Text = InputTextBox1.Text;
        }


// Двигаемое окно
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_NCHITTEST)
            m.Result = (IntPtr)(HT_CAPTION);
    }

    private const int WM_NCHITTEST = 0x84;
    private const int HT_CLIENT = 0x1;
    private const int HT_CAPTION = 0x2;


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

// тут указаны аттрибуты

string name = result.Properties["givenName"][0].ToString();
string surname = result.Properties["sn"][0].ToString();
string mail = result.Properties["mail"][0].ToString();
string distinguishedname = result.Properties["distinguishedname"][0].ToString();
string whencreated = result.Properties["whencreated"][0].ToString();
string title = result.Properties["title"][0].ToString();
string proxyaddresses = result.Properties["proxyaddresses"][0].ToString();
string pwdlastset = result.Properties["pwdlastset"][0].ToString();


// тут завершаются указания аттрибутов

// стринг билдер

StringBuilder sb = new StringBuilder();

sb.Append($"Имя: {username} \r\n");
sb.Append($"Имя: {name} \r\n");
sb.Append($"Фамилия: {surname} \r\n");
sb.Append($"Почта: {mail} \r\n");
sb.Append($"Контейнер: {distinguishedname} \r\n");
sb.Append($"УЗ создана: {whencreated} \r\n");
sb.Append($"Должность: {title} \r\n");
sb.Append($"Дата крайней смены пароля: {pwdlastset} \r\n");

MessageTextBox1.Text = ($"{sb}");

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
       string domainName;
       domainName = System.Environment.UserDomainName;
       DirectoryEntry ldapConnection = new DirectoryEntry($"LDAP://{domainName}");
       ldapConnection.Path               = $"LDAP://{domainName}";  
       ldapConnection.AuthenticationType = AuthenticationTypes.Secure;  
  
         return ldapConnection;  

	}

  

// тут завершаются указания условий аттрибутов



// Действие кнопки Очистить (Button2)
	private void Button2_Click(object sender, EventArgs e)
	{
   	    MessageTextBox1.Text = null;
	}

// Действие кнопки Выйти (Button3)
	private void Button3_Click(object sender, EventArgs e)
	{
   	    Close();
	}

}