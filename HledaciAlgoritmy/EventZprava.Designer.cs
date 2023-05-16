
namespace HledaciAlgoritmy
{
    partial class EventZprava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventZprava));
            this.lb_Uvodninapis = new System.Windows.Forms.Label();
            this.bt_no = new System.Windows.Forms.Button();
            this.bt_yes = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.pb_obrazek = new System.Windows.Forms.PictureBox();
            this.tb_telo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_obrazek)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Uvodninapis
            // 
            this.lb_Uvodninapis.AutoSize = true;
            this.lb_Uvodninapis.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Uvodninapis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(111)))));
            this.lb_Uvodninapis.Location = new System.Drawing.Point(156, 19);
            this.lb_Uvodninapis.Name = "lb_Uvodninapis";
            this.lb_Uvodninapis.Size = new System.Drawing.Size(126, 38);
            this.lb_Uvodninapis.TabIndex = 1;
            this.lb_Uvodninapis.Text = "Nadpis";
            // 
            // bt_no
            // 
            this.bt_no.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_no.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_no.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_no.Location = new System.Drawing.Point(52, 237);
            this.bt_no.Name = "bt_no";
            this.bt_no.Size = new System.Drawing.Size(155, 50);
            this.bt_no.TabIndex = 2;
            this.bt_no.Text = "Ne";
            this.bt_no.UseVisualStyleBackColor = false;
            this.bt_no.Click += new System.EventHandler(this.bt_no_Click);
            // 
            // bt_yes
            // 
            this.bt_yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_yes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_yes.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_yes.Location = new System.Drawing.Point(211, 237);
            this.bt_yes.Name = "bt_yes";
            this.bt_yes.Size = new System.Drawing.Size(155, 50);
            this.bt_yes.TabIndex = 3;
            this.bt_yes.Text = "Ano";
            this.bt_yes.UseVisualStyleBackColor = false;
            this.bt_yes.Click += new System.EventHandler(this.bt_yes_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_ok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_ok.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_ok.Location = new System.Drawing.Point(52, 237);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(314, 50);
            this.bt_ok.TabIndex = 4;
            this.bt_ok.Text = "Okay";
            this.bt_ok.UseVisualStyleBackColor = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // pb_obrazek
            // 
            this.pb_obrazek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_obrazek.ErrorImage = null;
            this.pb_obrazek.Location = new System.Drawing.Point(84, 9);
            this.pb_obrazek.Name = "pb_obrazek";
            this.pb_obrazek.Size = new System.Drawing.Size(66, 65);
            this.pb_obrazek.TabIndex = 23;
            this.pb_obrazek.TabStop = false;
            // 
            // tb_telo
            // 
            this.tb_telo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tb_telo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_telo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tb_telo.Location = new System.Drawing.Point(32, 80);
            this.tb_telo.Name = "tb_telo";
            this.tb_telo.ReadOnly = true;
            this.tb_telo.Size = new System.Drawing.Size(355, 150);
            this.tb_telo.TabIndex = 24;
            this.tb_telo.Text = "";
            // 
            // EventZprava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(425, 289);
            this.Controls.Add(this.tb_telo);
            this.Controls.Add(this.pb_obrazek);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_yes);
            this.Controls.Add(this.bt_no);
            this.Controls.Add(this.lb_Uvodninapis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EventZprava";
            this.Text = "EventZprava";
            ((System.ComponentModel.ISupportInitialize)(this.pb_obrazek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Uvodninapis;
        private System.Windows.Forms.Button bt_no;
        private System.Windows.Forms.Button bt_yes;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.PictureBox pb_obrazek;
        private System.Windows.Forms.RichTextBox tb_telo;
    }
}