namespace pet;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

// 
// Input InputTextBox1
// 
            this.InputTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.InputTextBox1.Location = new System.Drawing.Point(80, 15);
            this.InputTextBox1.Name = "Введите ID:";
            this.InputTextBox1.Size = new System.Drawing.Size(120, 30);
            this.InputTextBox1.ForeColor = Color.FromArgb(53, 51, 64);

// 
// Output LabelAccount
// 
            this.LabelAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.LabelAccount.Location = new System.Drawing.Point(10, 17);
            this.LabelAccount.Text = "Введите ID:";
            this.LabelAccount.AutoSize = true;
            this.LabelAccount.ForeColor = Color.White;

// 
// Button Button1 (Find)
// 
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Button1.Location = new System.Drawing.Point(220, 12);
            this.Button1.Size = new System.Drawing.Size(90, 30); 
            this.Button1.Text = "Найти";
	    this.Button1.Click += Button1_Click;
	    this.Button1.ForeColor = Color.White;

// 
// Button Button2 (Clear)
// 
            this.Button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Button2.Location = new System.Drawing.Point(320, 12);
            this.Button2.Size = new System.Drawing.Size(90, 30); 
            this.Button2.Text = "Очистить";
	    this.Button2.Click += Button2_Click;
	    this.Button2.ForeColor = Color.White;

// 
// Button Button3 (exit)
// 
            this.Button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Button3.Location = new System.Drawing.Point(420, 12);
            this.Button3.Size = new System.Drawing.Size(90, 30); 
            this.Button3.Text = "Выйти";
	    this.Button3.Click += Button3_Click;
	    this.Button3.ForeColor = Color.White;


// 
// Output MessageTextBox1
// 
Font font = new Font("Times New Roman", 14.0f, 
                               FontStyle.Bold);

            this.MessageTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.MessageTextBox1.Location = new System.Drawing.Point(10, 50);
            this.MessageTextBox1.Name = "Информация";
            this.MessageTextBox1.Size = new System.Drawing.Size(500, 400);
   	    this.MessageTextBox1.Multiline = true;
	    this.MessageTextBox1.ForeColor = Color.White;
	    this.MessageTextBox1.BackColor = Color.FromArgb(53, 51, 64);
	    this.MessageTextBox1.Font = font;


//
// Основная форма
//
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(520, 465);
        this.Text = "Информация об аккаунте";
        this.Padding = new Padding(borderSize);//Border size
        this.BackColor = Color.FromArgb(39, 37, 55);

// Информация о том, что элементы управляются основной формой
	this.Controls.Add(this.InputTextBox1);
	this.Controls.Add(this.MessageTextBox1);
	this.Controls.Add(this.LabelAccount);
	this.Controls.Add(this.Button1);
	this.Controls.Add(this.Button2);
	this.Controls.Add(this.Button3);
    }
                           

    #endregion

        private TextBox InputTextBox1;
        private TextBox MessageTextBox1;
        private Label LabelAccount;
        private Button Button1;
        private Button Button2;
        private Button Button3;

}
