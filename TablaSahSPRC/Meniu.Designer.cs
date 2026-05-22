namespace TablaSahSPRC
{
    partial class Meniu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meniu));
            this.btnJoaca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCod = new System.Windows.Forms.TextBox();
            this.labelIntroduNumeUtilizator = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.CreareIntroduUrmareste = new System.Windows.Forms.Label();
            this.btnInchideLobby = new System.Windows.Forms.Button();
            this.btnGenerareCod = new System.Windows.Forms.Button();
            this.btnSchimbaActiune = new System.Windows.Forms.Button();
            this.labelUrmaresteMeci = new System.Windows.Forms.Label();
            this.labelIntroduCod = new System.Windows.Forms.Label();
            this.labelCreareJoc = new System.Windows.Forms.Label();
            this.btnIesiDinJoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJoaca
            // 
            this.btnJoaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoaca.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnJoaca.Location = new System.Drawing.Point(632, 204);
            this.btnJoaca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnJoaca.Name = "btnJoaca";
            this.btnJoaca.Size = new System.Drawing.Size(247, 92);
            this.btnJoaca.TabIndex = 6;
            this.btnJoaca.Text = "Joaca";
            this.btnJoaca.UseVisualStyleBackColor = true;
            this.btnJoaca.Click += new System.EventHandler(this.btnJoaca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(364, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1086, 81);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bine ai venit, succes la meciul de SAH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxCod
            // 
            this.textBoxCod.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCod.Location = new System.Drawing.Point(1052, 204);
            this.textBoxCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCod.MaxLength = 10;
            this.textBoxCod.Name = "textBoxCod";
            this.textBoxCod.Size = new System.Drawing.Size(453, 41);
            this.textBoxCod.TabIndex = 2;
            this.textBoxCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCod.TextChanged += new System.EventHandler(this.textBoxCod_TextChanged);
            // 
            // labelIntroduNumeUtilizator
            // 
            this.labelIntroduNumeUtilizator.AutoSize = true;
            this.labelIntroduNumeUtilizator.BackColor = System.Drawing.Color.Transparent;
            this.labelIntroduNumeUtilizator.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroduNumeUtilizator.ForeColor = System.Drawing.Color.White;
            this.labelIntroduNumeUtilizator.Location = new System.Drawing.Point(97, 153);
            this.labelIntroduNumeUtilizator.Name = "labelIntroduNumeUtilizator";
            this.labelIntroduNumeUtilizator.Size = new System.Drawing.Size(350, 35);
            this.labelIntroduNumeUtilizator.TabIndex = 12;
            this.labelIntroduNumeUtilizator.Text = "Introdu numele de utilizator :";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUser.Location = new System.Drawing.Point(103, 200);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(306, 41);
            this.textBoxUser.TabIndex = 0;
            // 
            // CreareIntroduUrmareste
            // 
            this.CreareIntroduUrmareste.AutoSize = true;
            this.CreareIntroduUrmareste.BackColor = System.Drawing.Color.Transparent;
            this.CreareIntroduUrmareste.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreareIntroduUrmareste.ForeColor = System.Drawing.Color.White;
            this.CreareIntroduUrmareste.Location = new System.Drawing.Point(1104, 153);
            this.CreareIntroduUrmareste.Name = "CreareIntroduUrmareste";
            this.CreareIntroduUrmareste.Size = new System.Drawing.Size(363, 35);
            this.CreareIntroduUrmareste.TabIndex = 17;
            this.CreareIntroduUrmareste.Text = "Creare/Introdu Cod/Urmareste";
            this.CreareIntroduUrmareste.Click += new System.EventHandler(this.CreareIntroduUrmareste_Click);
            // 
            // btnInchideLobby
            // 
            this.btnInchideLobby.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnInchideLobby.Location = new System.Drawing.Point(1218, 373);
            this.btnInchideLobby.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInchideLobby.Name = "btnInchideLobby";
            this.btnInchideLobby.Size = new System.Drawing.Size(148, 37);
            this.btnInchideLobby.TabIndex = 5;
            this.btnInchideLobby.Text = "Inchide Lobby";
            this.btnInchideLobby.UseVisualStyleBackColor = true;
            this.btnInchideLobby.Click += new System.EventHandler(this.btnInchideLobby_Click);
            // 
            // btnGenerareCod
            // 
            this.btnGenerareCod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerareCod.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGenerareCod.Location = new System.Drawing.Point(1302, 275);
            this.btnGenerareCod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerareCod.Name = "btnGenerareCod";
            this.btnGenerareCod.Size = new System.Drawing.Size(203, 85);
            this.btnGenerareCod.TabIndex = 4;
            this.btnGenerareCod.Text = "Genenare Cod";
            this.btnGenerareCod.UseVisualStyleBackColor = true;
            this.btnGenerareCod.Click += new System.EventHandler(this.btnGenerareCod_Click);
            // 
            // btnSchimbaActiune
            // 
            this.btnSchimbaActiune.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchimbaActiune.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSchimbaActiune.Location = new System.Drawing.Point(1052, 275);
            this.btnSchimbaActiune.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSchimbaActiune.Name = "btnSchimbaActiune";
            this.btnSchimbaActiune.Size = new System.Drawing.Size(224, 85);
            this.btnSchimbaActiune.TabIndex = 3;
            this.btnSchimbaActiune.Text = "Schimba Actiune";
            this.btnSchimbaActiune.UseVisualStyleBackColor = true;
            this.btnSchimbaActiune.Click += new System.EventHandler(this.btnSchimbaActiune_Click);
            // 
            // labelUrmaresteMeci
            // 
            this.labelUrmaresteMeci.AutoSize = true;
            this.labelUrmaresteMeci.BackColor = System.Drawing.Color.Transparent;
            this.labelUrmaresteMeci.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUrmaresteMeci.ForeColor = System.Drawing.Color.White;
            this.labelUrmaresteMeci.Location = new System.Drawing.Point(1394, 426);
            this.labelUrmaresteMeci.Name = "labelUrmaresteMeci";
            this.labelUrmaresteMeci.Size = new System.Drawing.Size(152, 25);
            this.labelUrmaresteMeci.TabIndex = 2;
            this.labelUrmaresteMeci.Text = "Urmareste meci";
            // 
            // labelIntroduCod
            // 
            this.labelIntroduCod.AutoSize = true;
            this.labelIntroduCod.BackColor = System.Drawing.Color.Transparent;
            this.labelIntroduCod.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIntroduCod.ForeColor = System.Drawing.Color.White;
            this.labelIntroduCod.Location = new System.Drawing.Point(1047, 426);
            this.labelIntroduCod.Name = "labelIntroduCod";
            this.labelIntroduCod.Size = new System.Drawing.Size(113, 25);
            this.labelIntroduCod.TabIndex = 1;
            this.labelIntroduCod.Text = "Introdu cod";
            this.labelIntroduCod.Click += new System.EventHandler(this.labelIntroduCod_Click);
            // 
            // labelCreareJoc
            // 
            this.labelCreareJoc.AutoSize = true;
            this.labelCreareJoc.BackColor = System.Drawing.Color.Transparent;
            this.labelCreareJoc.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCreareJoc.ForeColor = System.Drawing.Color.White;
            this.labelCreareJoc.Location = new System.Drawing.Point(1237, 426);
            this.labelCreareJoc.Name = "labelCreareJoc";
            this.labelCreareJoc.Size = new System.Drawing.Size(101, 25);
            this.labelCreareJoc.TabIndex = 0;
            this.labelCreareJoc.Text = "Creare joc";
            // 
            // btnIesiDinJoc
            // 
            this.btnIesiDinJoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIesiDinJoc.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIesiDinJoc.Location = new System.Drawing.Point(632, 410);
            this.btnIesiDinJoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIesiDinJoc.Name = "btnIesiDinJoc";
            this.btnIesiDinJoc.Size = new System.Drawing.Size(247, 92);
            this.btnIesiDinJoc.TabIndex = 7;
            this.btnIesiDinJoc.Text = "Iesi din joc";
            this.btnIesiDinJoc.UseVisualStyleBackColor = true;
            this.btnIesiDinJoc.Click += new System.EventHandler(this.btnIesiDinJoc_Click);
            // 
            // Meniu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::TablaSahSPRC.Properties.Resources.poza_de_fundal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1708, 775);
            this.Controls.Add(this.btnIesiDinJoc);
            this.Controls.Add(this.labelCreareJoc);
            this.Controls.Add(this.labelIntroduCod);
            this.Controls.Add(this.labelUrmaresteMeci);
            this.Controls.Add(this.btnInchideLobby);
            this.Controls.Add(this.btnGenerareCod);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSchimbaActiune);
            this.Controls.Add(this.textBoxCod);
            this.Controls.Add(this.labelIntroduNumeUtilizator);
            this.Controls.Add(this.btnJoaca);
            this.Controls.Add(this.CreareIntroduUrmareste);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Meniu";
            this.Text = "Joaca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Meniu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJoaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCod;
        private System.Windows.Forms.Label labelIntroduNumeUtilizator;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label CreareIntroduUrmareste;
        private System.Windows.Forms.Button btnGenerareCod;
        private System.Windows.Forms.Button btnSchimbaActiune;
        private System.Windows.Forms.Label labelUrmaresteMeci;
        private System.Windows.Forms.Label labelIntroduCod;
        private System.Windows.Forms.Label labelCreareJoc;
        private System.Windows.Forms.Button btnInchideLobby;
        private System.Windows.Forms.Button btnIesiDinJoc;
    }
}