
namespace HledaciAlgoritmy
{
    partial class Comparation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comparation));
            this.lb_Dijkstra = new System.Windows.Forms.Label();
            this.lb_astar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_bfs_krok = new System.Windows.Forms.Label();
            this.lb_dfs_krok = new System.Windows.Forms.Label();
            this.lb_dijk_krok = new System.Windows.Forms.Label();
            this.lb_astar_krok = new System.Windows.Forms.Label();
            this.lb_bfs_rozs = new System.Windows.Forms.Label();
            this.lb_dfs_rozs = new System.Windows.Forms.Label();
            this.lb_dijk_rozs = new System.Windows.Forms.Label();
            this.lb_astar_rozs = new System.Windows.Forms.Label();
            this.bt_porovnat = new System.Windows.Forms.Button();
            this.gp_loadsave = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_load = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gp_Data = new System.Windows.Forms.GroupBox();
            this.lb_astar_RVzdalenost = new System.Windows.Forms.Label();
            this.lb_dijk_RVzdalenost = new System.Windows.Forms.Label();
            this.lb_dfs_RVzdalenost = new System.Windows.Forms.Label();
            this.lb_bfs_RVzdalenost = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gp_typcesty = new System.Windows.Forms.GroupBox();
            this.rb_realistic = new System.Windows.Forms.RadioButton();
            this.rb_teoretical = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.gp_animace = new System.Windows.Forms.GroupBox();
            this.cb_animation = new System.Windows.Forms.CheckBox();
            this.lb_scroll_animace = new System.Windows.Forms.Label();
            this.tb_animace = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.background = new System.ComponentModel.BackgroundWorker();
            this.gb_parametry = new System.Windows.Forms.GroupBox();
            this.tb2 = new System.Windows.Forms.NumericUpDown();
            this.tb1 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.bt_generate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bpanel_astar = new HledaciAlgoritmy.BufferPanel();
            this.bpanel_dfs = new HledaciAlgoritmy.BufferPanel();
            this.bpanel_dijk = new HledaciAlgoritmy.BufferPanel();
            this.bpanel_bfs = new HledaciAlgoritmy.BufferPanel();
            this.gp_loadsave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gp_Data.SuspendLayout();
            this.gp_typcesty.SuspendLayout();
            this.gp_animace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_animace)).BeginInit();
            this.gb_parametry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Dijkstra
            // 
            this.lb_Dijkstra.AutoSize = true;
            this.lb_Dijkstra.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Dijkstra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_Dijkstra.Location = new System.Drawing.Point(159, 435);
            this.lb_Dijkstra.Name = "lb_Dijkstra";
            this.lb_Dijkstra.Size = new System.Drawing.Size(97, 28);
            this.lb_Dijkstra.TabIndex = 4;
            this.lb_Dijkstra.Text = "Dijkstra";
            // 
            // lb_astar
            // 
            this.lb_astar.AutoSize = true;
            this.lb_astar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_astar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_astar.Location = new System.Drawing.Point(737, 435);
            this.lb_astar.Name = "lb_astar";
            this.lb_astar.Size = new System.Drawing.Size(41, 28);
            this.lb_astar.TabIndex = 5;
            this.lb_astar.Text = "A*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(206, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "BFS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(725, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "DFS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(111)))));
            this.label3.Location = new System.Drawing.Point(1024, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 44);
            this.label3.TabIndex = 8;
            this.label3.Text = "Porovnání";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(58, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cesta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(10, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "BFS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(10, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "DFS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(12, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Dijk.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(10, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 28);
            this.label8.TabIndex = 13;
            this.label8.Text = "A*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(128, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Uzly";
            // 
            // lb_bfs_krok
            // 
            this.lb_bfs_krok.AutoSize = true;
            this.lb_bfs_krok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_bfs_krok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_bfs_krok.Location = new System.Drawing.Point(80, 61);
            this.lb_bfs_krok.Name = "lb_bfs_krok";
            this.lb_bfs_krok.Size = new System.Drawing.Size(21, 23);
            this.lb_bfs_krok.TabIndex = 15;
            this.lb_bfs_krok.Text = "0";
            // 
            // lb_dfs_krok
            // 
            this.lb_dfs_krok.AutoSize = true;
            this.lb_dfs_krok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dfs_krok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dfs_krok.Location = new System.Drawing.Point(80, 98);
            this.lb_dfs_krok.Name = "lb_dfs_krok";
            this.lb_dfs_krok.Size = new System.Drawing.Size(21, 23);
            this.lb_dfs_krok.TabIndex = 16;
            this.lb_dfs_krok.Text = "0";
            // 
            // lb_dijk_krok
            // 
            this.lb_dijk_krok.AutoSize = true;
            this.lb_dijk_krok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dijk_krok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dijk_krok.Location = new System.Drawing.Point(80, 131);
            this.lb_dijk_krok.Name = "lb_dijk_krok";
            this.lb_dijk_krok.Size = new System.Drawing.Size(21, 23);
            this.lb_dijk_krok.TabIndex = 17;
            this.lb_dijk_krok.Text = "0";
            // 
            // lb_astar_krok
            // 
            this.lb_astar_krok.AutoSize = true;
            this.lb_astar_krok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_astar_krok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_astar_krok.Location = new System.Drawing.Point(80, 166);
            this.lb_astar_krok.Name = "lb_astar_krok";
            this.lb_astar_krok.Size = new System.Drawing.Size(21, 23);
            this.lb_astar_krok.TabIndex = 18;
            this.lb_astar_krok.Text = "0";
            // 
            // lb_bfs_rozs
            // 
            this.lb_bfs_rozs.AutoSize = true;
            this.lb_bfs_rozs.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_bfs_rozs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_bfs_rozs.Location = new System.Drawing.Point(149, 61);
            this.lb_bfs_rozs.Name = "lb_bfs_rozs";
            this.lb_bfs_rozs.Size = new System.Drawing.Size(21, 23);
            this.lb_bfs_rozs.TabIndex = 19;
            this.lb_bfs_rozs.Text = "0";
            // 
            // lb_dfs_rozs
            // 
            this.lb_dfs_rozs.AutoSize = true;
            this.lb_dfs_rozs.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dfs_rozs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dfs_rozs.Location = new System.Drawing.Point(149, 98);
            this.lb_dfs_rozs.Name = "lb_dfs_rozs";
            this.lb_dfs_rozs.Size = new System.Drawing.Size(21, 23);
            this.lb_dfs_rozs.TabIndex = 20;
            this.lb_dfs_rozs.Text = "0";
            // 
            // lb_dijk_rozs
            // 
            this.lb_dijk_rozs.AutoSize = true;
            this.lb_dijk_rozs.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dijk_rozs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dijk_rozs.Location = new System.Drawing.Point(149, 131);
            this.lb_dijk_rozs.Name = "lb_dijk_rozs";
            this.lb_dijk_rozs.Size = new System.Drawing.Size(21, 23);
            this.lb_dijk_rozs.TabIndex = 21;
            this.lb_dijk_rozs.Text = "0";
            // 
            // lb_astar_rozs
            // 
            this.lb_astar_rozs.AutoSize = true;
            this.lb_astar_rozs.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_astar_rozs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_astar_rozs.Location = new System.Drawing.Point(149, 168);
            this.lb_astar_rozs.Name = "lb_astar_rozs";
            this.lb_astar_rozs.Size = new System.Drawing.Size(21, 23);
            this.lb_astar_rozs.TabIndex = 22;
            this.lb_astar_rozs.Text = "0";
            // 
            // bt_porovnat
            // 
            this.bt_porovnat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_porovnat.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_porovnat.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_porovnat.Location = new System.Drawing.Point(73, 212);
            this.bt_porovnat.Name = "bt_porovnat";
            this.bt_porovnat.Size = new System.Drawing.Size(173, 37);
            this.bt_porovnat.TabIndex = 23;
            this.bt_porovnat.Tag = "Porovnat";
            this.bt_porovnat.Text = "Porovnat";
            this.bt_porovnat.UseVisualStyleBackColor = false;
            this.bt_porovnat.Click += new System.EventHandler(this.bt_porovnat_Click);
            this.bt_porovnat.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_paint);
            // 
            // gp_loadsave
            // 
            this.gp_loadsave.BackColor = System.Drawing.Color.Transparent;
            this.gp_loadsave.Controls.Add(this.label10);
            this.gp_loadsave.Controls.Add(this.bt_save);
            this.gp_loadsave.Controls.Add(this.bt_load);
            this.gp_loadsave.Controls.Add(this.pictureBox1);
            this.gp_loadsave.Controls.Add(this.pictureBox3);
            this.gp_loadsave.Location = new System.Drawing.Point(1015, 644);
            this.gp_loadsave.Name = "gp_loadsave";
            this.gp_loadsave.Size = new System.Drawing.Size(271, 174);
            this.gp_loadsave.TabIndex = 24;
            this.gp_loadsave.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(128, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "Konfigurace";
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_save.Enabled = false;
            this.bt_save.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_save.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_save.Location = new System.Drawing.Point(129, 95);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(115, 37);
            this.bt_save.TabIndex = 12;
            this.bt_save.Tag = "Uložit";
            this.bt_save.Text = "Uložit";
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_paint);
            // 
            // bt_load
            // 
            this.bt_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_load.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_load.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_load.Location = new System.Drawing.Point(129, 52);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(115, 37);
            this.bt_load.TabIndex = 11;
            this.bt_load.Tag = "Načíst";
            this.bt_load.Text = "Načíst";
            this.bt_load.UseVisualStyleBackColor = false;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            this.bt_load.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HledaciAlgoritmy.Properties.Resources.icon31;
            this.pictureBox1.Location = new System.Drawing.Point(8, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 70);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HledaciAlgoritmy.Properties.Resources.icon30;
            this.pictureBox3.Location = new System.Drawing.Point(8, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 70);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(111)))));
            this.label11.Location = new System.Drawing.Point(1089, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 44);
            this.label11.TabIndex = 25;
            this.label11.Text = "Mapa";
            // 
            // gp_Data
            // 
            this.gp_Data.Controls.Add(this.lb_astar_RVzdalenost);
            this.gp_Data.Controls.Add(this.lb_dijk_RVzdalenost);
            this.gp_Data.Controls.Add(this.lb_dfs_RVzdalenost);
            this.gp_Data.Controls.Add(this.lb_bfs_RVzdalenost);
            this.gp_Data.Controls.Add(this.label15);
            this.gp_Data.Controls.Add(this.label12);
            this.gp_Data.Controls.Add(this.bt_porovnat);
            this.gp_Data.Controls.Add(this.label4);
            this.gp_Data.Controls.Add(this.label5);
            this.gp_Data.Controls.Add(this.label6);
            this.gp_Data.Controls.Add(this.label7);
            this.gp_Data.Controls.Add(this.lb_astar_rozs);
            this.gp_Data.Controls.Add(this.label8);
            this.gp_Data.Controls.Add(this.lb_dijk_rozs);
            this.gp_Data.Controls.Add(this.label9);
            this.gp_Data.Controls.Add(this.lb_dfs_rozs);
            this.gp_Data.Controls.Add(this.lb_bfs_krok);
            this.gp_Data.Controls.Add(this.lb_bfs_rozs);
            this.gp_Data.Controls.Add(this.lb_dfs_krok);
            this.gp_Data.Controls.Add(this.lb_astar_krok);
            this.gp_Data.Controls.Add(this.lb_dijk_krok);
            this.gp_Data.Location = new System.Drawing.Point(1000, 68);
            this.gp_Data.Name = "gp_Data";
            this.gp_Data.Size = new System.Drawing.Size(298, 255);
            this.gp_Data.TabIndex = 27;
            this.gp_Data.TabStop = false;
            // 
            // lb_astar_RVzdalenost
            // 
            this.lb_astar_RVzdalenost.AutoSize = true;
            this.lb_astar_RVzdalenost.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_astar_RVzdalenost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_astar_RVzdalenost.Location = new System.Drawing.Point(222, 166);
            this.lb_astar_RVzdalenost.Name = "lb_astar_RVzdalenost";
            this.lb_astar_RVzdalenost.Size = new System.Drawing.Size(21, 23);
            this.lb_astar_RVzdalenost.TabIndex = 29;
            this.lb_astar_RVzdalenost.Text = "0";
            // 
            // lb_dijk_RVzdalenost
            // 
            this.lb_dijk_RVzdalenost.AutoSize = true;
            this.lb_dijk_RVzdalenost.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dijk_RVzdalenost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dijk_RVzdalenost.Location = new System.Drawing.Point(222, 129);
            this.lb_dijk_RVzdalenost.Name = "lb_dijk_RVzdalenost";
            this.lb_dijk_RVzdalenost.Size = new System.Drawing.Size(21, 23);
            this.lb_dijk_RVzdalenost.TabIndex = 28;
            this.lb_dijk_RVzdalenost.Text = "0";
            // 
            // lb_dfs_RVzdalenost
            // 
            this.lb_dfs_RVzdalenost.AutoSize = true;
            this.lb_dfs_RVzdalenost.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_dfs_RVzdalenost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_dfs_RVzdalenost.Location = new System.Drawing.Point(222, 96);
            this.lb_dfs_RVzdalenost.Name = "lb_dfs_RVzdalenost";
            this.lb_dfs_RVzdalenost.Size = new System.Drawing.Size(21, 23);
            this.lb_dfs_RVzdalenost.TabIndex = 27;
            this.lb_dfs_RVzdalenost.Text = "0";
            // 
            // lb_bfs_RVzdalenost
            // 
            this.lb_bfs_RVzdalenost.AutoSize = true;
            this.lb_bfs_RVzdalenost.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_bfs_RVzdalenost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_bfs_RVzdalenost.Location = new System.Drawing.Point(222, 59);
            this.lb_bfs_RVzdalenost.Name = "lb_bfs_RVzdalenost";
            this.lb_bfs_RVzdalenost.Size = new System.Drawing.Size(21, 23);
            this.lb_bfs_RVzdalenost.TabIndex = 26;
            this.lb_bfs_RVzdalenost.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(183, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 23);
            this.label15.TabIndex = 25;
            this.label15.Text = "Vzdálenost";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(16, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 28);
            this.label12.TabIndex = 24;
            this.label12.Text = "Al";
            // 
            // gp_typcesty
            // 
            this.gp_typcesty.BackColor = System.Drawing.Color.Transparent;
            this.gp_typcesty.Controls.Add(this.rb_realistic);
            this.gp_typcesty.Controls.Add(this.rb_teoretical);
            this.gp_typcesty.Controls.Add(this.label13);
            this.gp_typcesty.Location = new System.Drawing.Point(1042, 329);
            this.gp_typcesty.Name = "gp_typcesty";
            this.gp_typcesty.Size = new System.Drawing.Size(230, 72);
            this.gp_typcesty.TabIndex = 28;
            this.gp_typcesty.TabStop = false;
            // 
            // rb_realistic
            // 
            this.rb_realistic.AutoSize = true;
            this.rb_realistic.Checked = true;
            this.rb_realistic.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_realistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rb_realistic.Location = new System.Drawing.Point(10, 41);
            this.rb_realistic.Name = "rb_realistic";
            this.rb_realistic.Size = new System.Drawing.Size(92, 22);
            this.rb_realistic.TabIndex = 16;
            this.rb_realistic.TabStop = true;
            this.rb_realistic.Text = "Standard";
            this.rb_realistic.UseVisualStyleBackColor = true;
            // 
            // rb_teoretical
            // 
            this.rb_teoretical.AutoSize = true;
            this.rb_teoretical.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_teoretical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rb_teoretical.Location = new System.Drawing.Point(104, 42);
            this.rb_teoretical.Name = "rb_teoretical";
            this.rb_teoretical.Size = new System.Drawing.Size(113, 22);
            this.rb_teoretical.TabIndex = 13;
            this.rb_teoretical.Text = "Diagonálně";
            this.rb_teoretical.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(51, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 19);
            this.label13.TabIndex = 9;
            this.label13.Text = "Hledaní cesty";
            // 
            // gp_animace
            // 
            this.gp_animace.BackColor = System.Drawing.Color.Transparent;
            this.gp_animace.Controls.Add(this.cb_animation);
            this.gp_animace.Controls.Add(this.lb_scroll_animace);
            this.gp_animace.Controls.Add(this.tb_animace);
            this.gp_animace.Controls.Add(this.label14);
            this.gp_animace.Location = new System.Drawing.Point(1051, 402);
            this.gp_animace.Name = "gp_animace";
            this.gp_animace.Size = new System.Drawing.Size(210, 82);
            this.gp_animace.TabIndex = 29;
            this.gp_animace.TabStop = false;
            // 
            // cb_animation
            // 
            this.cb_animation.AutoSize = true;
            this.cb_animation.Checked = true;
            this.cb_animation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_animation.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_animation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cb_animation.Location = new System.Drawing.Point(6, 16);
            this.cb_animation.Name = "cb_animation";
            this.cb_animation.Size = new System.Drawing.Size(95, 22);
            this.cb_animation.TabIndex = 17;
            this.cb_animation.Text = "Animace";
            this.cb_animation.UseVisualStyleBackColor = true;
            this.cb_animation.CheckedChanged += new System.EventHandler(this.cb_animation_CheckedChanged);
            // 
            // lb_scroll_animace
            // 
            this.lb_scroll_animace.AutoSize = true;
            this.lb_scroll_animace.BackColor = System.Drawing.Color.Transparent;
            this.lb_scroll_animace.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_scroll_animace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lb_scroll_animace.Location = new System.Drawing.Point(186, 16);
            this.lb_scroll_animace.Name = "lb_scroll_animace";
            this.lb_scroll_animace.Size = new System.Drawing.Size(18, 19);
            this.lb_scroll_animace.TabIndex = 10;
            this.lb_scroll_animace.Text = "8";
            // 
            // tb_animace
            // 
            this.tb_animace.AutoSize = false;
            this.tb_animace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.tb_animace.Location = new System.Drawing.Point(6, 42);
            this.tb_animace.Maximum = 20;
            this.tb_animace.Minimum = 1;
            this.tb_animace.Name = "tb_animace";
            this.tb_animace.Size = new System.Drawing.Size(198, 34);
            this.tb_animace.TabIndex = 0;
            this.tb_animace.Value = 8;
            this.tb_animace.Scroll += new System.EventHandler(this.tb_animace_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(107, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 18);
            this.label14.TabIndex = 9;
            this.label14.Text = "Rychlost";
            // 
            // background
            // 
            this.background.WorkerReportsProgress = true;
            this.background.WorkerSupportsCancellation = true;
            this.background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.background_DoWork);
            this.background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.background_ProgressChanged);
            this.background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.background_RunWorkerCompleted);
            // 
            // gb_parametry
            // 
            this.gb_parametry.BackColor = System.Drawing.Color.Transparent;
            this.gb_parametry.Controls.Add(this.tb2);
            this.gb_parametry.Controls.Add(this.tb1);
            this.gb_parametry.Controls.Add(this.label16);
            this.gb_parametry.Controls.Add(this.bt_generate);
            this.gb_parametry.Controls.Add(this.label17);
            this.gb_parametry.Controls.Add(this.label18);
            this.gb_parametry.Location = new System.Drawing.Point(1015, 533);
            this.gb_parametry.Name = "gb_parametry";
            this.gb_parametry.Size = new System.Drawing.Size(271, 105);
            this.gb_parametry.TabIndex = 30;
            this.gb_parametry.TabStop = false;
            // 
            // tb2
            // 
            this.tb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tb2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb2.Location = new System.Drawing.Point(77, 62);
            this.tb2.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.tb2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(50, 27);
            this.tb2.TabIndex = 31;
            this.tb2.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tb1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb1.Location = new System.Drawing.Point(6, 62);
            this.tb1.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.tb1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(50, 27);
            this.tb1.TabIndex = 31;
            this.tb1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(154, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 38);
            this.label16.TabIndex = 18;
            this.label16.Text = "Generace\r\nBludiště\r\n";
            // 
            // bt_generate
            // 
            this.bt_generate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_generate.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_generate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_generate.Location = new System.Drawing.Point(133, 60);
            this.bt_generate.Name = "bt_generate";
            this.bt_generate.Size = new System.Drawing.Size(126, 37);
            this.bt_generate.TabIndex = 17;
            this.bt_generate.Tag = "Náhoda";
            this.bt_generate.Text = "Náhoda";
            this.bt_generate.UseVisualStyleBackColor = false;
            this.bt_generate.Click += new System.EventHandler(this.bt_randomgenerate_Click);
            this.bt_generate.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_paint);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(57, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 21);
            this.label17.TabIndex = 11;
            this.label17.Text = "X";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(40, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 38);
            this.label18.TabIndex = 9;
            this.label18.Text = "Velikost\r\nmapy\r\n";
            // 
            // bpanel_astar
            // 
            this.bpanel_astar.BackColor = System.Drawing.Color.White;
            this.bpanel_astar.Location = new System.Drawing.Point(502, 478);
            this.bpanel_astar.Name = "bpanel_astar";
            this.bpanel_astar.Size = new System.Drawing.Size(480, 340);
            this.bpanel_astar.TabIndex = 3;
            this.bpanel_astar.Tag = "astar";
            this.bpanel_astar.Paint += new System.Windows.Forms.PaintEventHandler(this.bpanel_astar_Paint);
            // 
            // bpanel_dfs
            // 
            this.bpanel_dfs.BackColor = System.Drawing.Color.White;
            this.bpanel_dfs.Location = new System.Drawing.Point(502, 52);
            this.bpanel_dfs.Name = "bpanel_dfs";
            this.bpanel_dfs.Size = new System.Drawing.Size(480, 340);
            this.bpanel_dfs.TabIndex = 2;
            this.bpanel_dfs.Tag = "dfs";
            this.bpanel_dfs.Paint += new System.Windows.Forms.PaintEventHandler(this.bpanel_dfs_Paint);
            // 
            // bpanel_dijk
            // 
            this.bpanel_dijk.BackColor = System.Drawing.Color.White;
            this.bpanel_dijk.Location = new System.Drawing.Point(7, 478);
            this.bpanel_dijk.Name = "bpanel_dijk";
            this.bpanel_dijk.Size = new System.Drawing.Size(480, 340);
            this.bpanel_dijk.TabIndex = 1;
            this.bpanel_dijk.Tag = "dijkstra";
            this.bpanel_dijk.Paint += new System.Windows.Forms.PaintEventHandler(this.bpanel_dijk_Paint);
            // 
            // bpanel_bfs
            // 
            this.bpanel_bfs.BackColor = System.Drawing.Color.White;
            this.bpanel_bfs.Location = new System.Drawing.Point(7, 52);
            this.bpanel_bfs.Name = "bpanel_bfs";
            this.bpanel_bfs.Size = new System.Drawing.Size(480, 340);
            this.bpanel_bfs.TabIndex = 0;
            this.bpanel_bfs.Tag = "bfs";
            this.bpanel_bfs.Paint += new System.Windows.Forms.PaintEventHandler(this.bpanel_bfs_Paint);
            // 
            // Comparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1334, 831);
            this.Controls.Add(this.gb_parametry);
            this.Controls.Add(this.gp_animace);
            this.Controls.Add(this.gp_typcesty);
            this.Controls.Add(this.gp_Data);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gp_loadsave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_astar);
            this.Controls.Add(this.lb_Dijkstra);
            this.Controls.Add(this.bpanel_astar);
            this.Controls.Add(this.bpanel_dfs);
            this.Controls.Add(this.bpanel_dijk);
            this.Controls.Add(this.bpanel_bfs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Comparation";
            this.Text = "Komparace";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Comparation_FormClosed);
            this.Load += new System.EventHandler(this.Comparation_Load);
            this.Resize += new System.EventHandler(this.Comparation_Resize);
            this.gp_loadsave.ResumeLayout(false);
            this.gp_loadsave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gp_Data.ResumeLayout(false);
            this.gp_Data.PerformLayout();
            this.gp_typcesty.ResumeLayout(false);
            this.gp_typcesty.PerformLayout();
            this.gp_animace.ResumeLayout(false);
            this.gp_animace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_animace)).EndInit();
            this.gb_parametry.ResumeLayout(false);
            this.gb_parametry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferPanel bpanel_bfs;
        private BufferPanel bpanel_dijk;
        private BufferPanel bpanel_astar;
        private BufferPanel bpanel_dfs;
        private System.Windows.Forms.Label lb_Dijkstra;
        private System.Windows.Forms.Label lb_astar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_bfs_krok;
        private System.Windows.Forms.Label lb_dfs_krok;
        private System.Windows.Forms.Label lb_dijk_krok;
        private System.Windows.Forms.Label lb_astar_krok;
        private System.Windows.Forms.Label lb_bfs_rozs;
        private System.Windows.Forms.Label lb_dfs_rozs;
        private System.Windows.Forms.Label lb_dijk_rozs;
        private System.Windows.Forms.Label lb_astar_rozs;
        private System.Windows.Forms.Button bt_porovnat;
        private System.Windows.Forms.GroupBox gp_loadsave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gp_Data;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gp_typcesty;
        private System.Windows.Forms.RadioButton rb_realistic;
        private System.Windows.Forms.RadioButton rb_teoretical;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gp_animace;
        private System.Windows.Forms.CheckBox cb_animation;
        private System.Windows.Forms.Label lb_scroll_animace;
        private System.Windows.Forms.TrackBar tb_animace;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker background;
        private System.Windows.Forms.Label lb_astar_RVzdalenost;
        private System.Windows.Forms.Label lb_dijk_RVzdalenost;
        private System.Windows.Forms.Label lb_dfs_RVzdalenost;
        private System.Windows.Forms.Label lb_bfs_RVzdalenost;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gb_parametry;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bt_generate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown tb2;
        private System.Windows.Forms.NumericUpDown tb1;
    }
}