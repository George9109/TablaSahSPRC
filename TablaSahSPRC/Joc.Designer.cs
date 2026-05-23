namespace TablaSahSPRC
{
    partial class Joc
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxTrimitMesajPrivat = new System.Windows.Forms.RichTextBox();
            this.btnTrimitMesajPrivat = new System.Windows.Forms.Button();
            this.richTextBoxChatPrivat = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxTrimiteMesajPublic = new System.Windows.Forms.RichTextBox();
            this.btnTrimiteMesajPublic = new System.Windows.Forms.Button();
            this.richTextBoxChatPublic = new System.Windows.Forms.RichTextBox();
            this.btnPararesteJoc = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(282, 669);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleName = "";
            this.tabPage1.Controls.Add(this.richTextBoxTrimitMesajPrivat);
            this.tabPage1.Controls.Add(this.btnTrimitMesajPrivat);
            this.tabPage1.Controls.Add(this.richTextBoxChatPrivat);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(274, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat Privat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxTrimitMesajPrivat
            // 
            this.richTextBoxTrimitMesajPrivat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxTrimitMesajPrivat.Location = new System.Drawing.Point(6, 481);
            this.richTextBoxTrimitMesajPrivat.Name = "richTextBoxTrimitMesajPrivat";
            this.richTextBoxTrimitMesajPrivat.Size = new System.Drawing.Size(262, 98);
            this.richTextBoxTrimitMesajPrivat.TabIndex = 3;
            this.richTextBoxTrimitMesajPrivat.Text = "";
            // 
            // btnTrimitMesajPrivat
            // 
            this.btnTrimitMesajPrivat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrimitMesajPrivat.Location = new System.Drawing.Point(6, 585);
            this.btnTrimitMesajPrivat.Name = "btnTrimitMesajPrivat";
            this.btnTrimitMesajPrivat.Size = new System.Drawing.Size(262, 49);
            this.btnTrimitMesajPrivat.TabIndex = 3;
            this.btnTrimitMesajPrivat.Text = "Trimite Mesaj";
            this.btnTrimitMesajPrivat.UseVisualStyleBackColor = true;
            this.btnTrimitMesajPrivat.Click += new System.EventHandler(this.btnTrimitMesajPrivat_Click);
            // 
            // richTextBoxChatPrivat
            // 
            this.richTextBoxChatPrivat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxChatPrivat.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxChatPrivat.Name = "richTextBoxChatPrivat";
            this.richTextBoxChatPrivat.ReadOnly = true;
            this.richTextBoxChatPrivat.Size = new System.Drawing.Size(262, 469);
            this.richTextBoxChatPrivat.TabIndex = 3;
            this.richTextBoxChatPrivat.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxTrimiteMesajPublic);
            this.tabPage2.Controls.Add(this.btnTrimiteMesajPublic);
            this.tabPage2.Controls.Add(this.richTextBoxChatPublic);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(274, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat Online";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxTrimiteMesajPublic
            // 
            this.richTextBoxTrimiteMesajPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxTrimiteMesajPublic.Location = new System.Drawing.Point(6, 481);
            this.richTextBoxTrimiteMesajPublic.Name = "richTextBoxTrimiteMesajPublic";
            this.richTextBoxTrimiteMesajPublic.Size = new System.Drawing.Size(262, 98);
            this.richTextBoxTrimiteMesajPublic.TabIndex = 4;
            this.richTextBoxTrimiteMesajPublic.Text = "";
            // 
            // btnTrimiteMesajPublic
            // 
            this.btnTrimiteMesajPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrimiteMesajPublic.Location = new System.Drawing.Point(6, 585);
            this.btnTrimiteMesajPublic.Name = "btnTrimiteMesajPublic";
            this.btnTrimiteMesajPublic.Size = new System.Drawing.Size(262, 49);
            this.btnTrimiteMesajPublic.TabIndex = 5;
            this.btnTrimiteMesajPublic.Text = "Trimite Mesaj";
            this.btnTrimiteMesajPublic.UseVisualStyleBackColor = true;
            this.btnTrimiteMesajPublic.Click += new System.EventHandler(this.btnTrimiteMesajPublic_Click);
            // 
            // richTextBoxChatPublic
            // 
            this.richTextBoxChatPublic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxChatPublic.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxChatPublic.Name = "richTextBoxChatPublic";
            this.richTextBoxChatPublic.ReadOnly = true;
            this.richTextBoxChatPublic.Size = new System.Drawing.Size(262, 469);
            this.richTextBoxChatPublic.TabIndex = 6;
            this.richTextBoxChatPublic.Text = "";
            // 
            // btnPararesteJoc
            // 
            this.btnPararesteJoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPararesteJoc.Location = new System.Drawing.Point(1767, 12);
            this.btnPararesteJoc.Name = "btnPararesteJoc";
            this.btnPararesteJoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPararesteJoc.Size = new System.Drawing.Size(145, 46);
            this.btnPararesteJoc.TabIndex = 2;
            this.btnPararesteJoc.Text = "Paraseste Joc";
            this.btnPararesteJoc.UseVisualStyleBackColor = true;
            this.btnPararesteJoc.Click += new System.EventHandler(this.btnPararesteJoc_Click);
            // 
            // Joc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 699);
            this.Controls.Add(this.btnPararesteJoc);
            this.Controls.Add(this.tabControl1);
            this.Name = "Joc";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Joc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPararesteJoc;
        private System.Windows.Forms.Button btnTrimitMesajPrivat;
        private System.Windows.Forms.RichTextBox richTextBoxChatPrivat;
        private System.Windows.Forms.RichTextBox richTextBoxTrimitMesajPrivat;
        private System.Windows.Forms.RichTextBox richTextBoxTrimiteMesajPublic;
        private System.Windows.Forms.Button btnTrimiteMesajPublic;
        private System.Windows.Forms.RichTextBox richTextBoxChatPublic;
    }
}

