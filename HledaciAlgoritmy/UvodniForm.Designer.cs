
namespace HledaciAlgoritmy
{
    partial class UvodniForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UvodniForm));
            this.lb_Uvodninapis = new System.Windows.Forms.Label();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_information = new System.Windows.Forms.Button();
            this.bt_option = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_comparation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.background = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Uvodninapis
            // 
            this.lb_Uvodninapis.AutoSize = true;
            this.lb_Uvodninapis.BackColor = System.Drawing.Color.Transparent;
            this.lb_Uvodninapis.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Uvodninapis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(111)))));
            this.lb_Uvodninapis.Location = new System.Drawing.Point(377, 9);
            this.lb_Uvodninapis.Name = "lb_Uvodninapis";
            this.lb_Uvodninapis.Size = new System.Drawing.Size(376, 77);
            this.lb_Uvodninapis.TabIndex = 0;
            this.lb_Uvodninapis.Text = "Pathfinding";
            // 
            // bt_start
            // 
            this.bt_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_start.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_start.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_start.Location = new System.Drawing.Point(540, 99);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(167, 100);
            this.bt_start.TabIndex = 1;
            this.bt_start.Text = "Návrhář";
            this.bt_start.UseVisualStyleBackColor = false;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_information
            // 
            this.bt_information.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_information.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_information.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_information.Location = new System.Drawing.Point(540, 205);
            this.bt_information.Name = "bt_information";
            this.bt_information.Size = new System.Drawing.Size(167, 100);
            this.bt_information.TabIndex = 12;
            this.bt_information.Text = "Výuka";
            this.bt_information.UseVisualStyleBackColor = false;
            this.bt_information.Click += new System.EventHandler(this.bt_information_Click);
            // 
            // bt_option
            // 
            this.bt_option.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_option.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_option.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_option.Location = new System.Drawing.Point(541, 417);
            this.bt_option.Name = "bt_option";
            this.bt_option.Size = new System.Drawing.Size(167, 100);
            this.bt_option.TabIndex = 14;
            this.bt_option.Text = "Nastavení";
            this.bt_option.UseVisualStyleBackColor = false;
            this.bt_option.Click += new System.EventHandler(this.bt_option_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_exit.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_exit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_exit.Location = new System.Drawing.Point(541, 523);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(167, 100);
            this.bt_exit.TabIndex = 17;
            this.bt_exit.Text = "Konec";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_comparation
            // 
            this.bt_comparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_comparation.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_comparation.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_comparation.Location = new System.Drawing.Point(540, 311);
            this.bt_comparation.Name = "bt_comparation";
            this.bt_comparation.Size = new System.Drawing.Size(167, 100);
            this.bt_comparation.TabIndex = 18;
            this.bt_comparation.Text = "Porovnání";
            this.bt_comparation.UseVisualStyleBackColor = false;
            this.bt_comparation.Click += new System.EventHandler(this.bt_comparation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(449, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "By: Jakub Novák © 2023";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::HledaciAlgoritmy.Properties.Resources.maze;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(430, 99);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(100, 100);
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HledaciAlgoritmy.Properties.Resources.info;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(430, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HledaciAlgoritmy.Properties.Resources.injustice;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(430, 311);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::HledaciAlgoritmy.Properties.Resources.settings_knobs;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(430, 417);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 100);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::HledaciAlgoritmy.Properties.Resources.exit_door;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(430, 523);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // background
            // 
            this.background.WorkerReportsProgress = true;
            this.background.WorkerSupportsCancellation = true;
            this.background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.background_DoWork);
            this.background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.background_ProgressChanged);
            this.background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.background_RunWorkerCompleted);
            // 
            // UvodniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1172, 695);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_comparation);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_option);
            this.Controls.Add(this.bt_information);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.lb_Uvodninapis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UvodniForm";
            this.Text = "Pathfinding";
            this.Load += new System.EventHandler(this.UvodniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Uvodninapis;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button bt_information;
        private System.Windows.Forms.Button bt_option;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_comparation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.ComponentModel.BackgroundWorker background;
    }
}

