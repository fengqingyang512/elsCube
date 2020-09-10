namespace elsCube
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel_game = new System.Windows.Forms.Panel();
            this.panel_show = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_score = new System.Windows.Forms.Label();
            this.label_socre = new System.Windows.Forms.Label();
            this.button_left = new System.Windows.Forms.Button();
            this.button_down = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_up = new System.Windows.Forms.Button();
            this.label_showPause = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_game
            // 
            this.panel_game.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel_game.Location = new System.Drawing.Point(11, 47);
            this.panel_game.Name = "panel_game";
            this.panel_game.Size = new System.Drawing.Size(420, 690);
            this.panel_game.TabIndex = 0;
            // 
            // panel_show
            // 
            this.panel_show.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel_show.Location = new System.Drawing.Point(460, 100);
            this.panel_show.Name = "panel_show";
            this.panel_show.Size = new System.Drawing.Size(117, 117);
            this.panel_show.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label_score);
            this.panel1.Controls.Add(this.label_socre);
            this.panel1.Location = new System.Drawing.Point(445, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 52);
            this.panel1.TabIndex = 2;
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_score.ForeColor = System.Drawing.Color.Red;
            this.label_score.Location = new System.Drawing.Point(68, 18);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(19, 20);
            this.label_score.TabIndex = 1;
            this.label_score.Text = "0";
            // 
            // label_socre
            // 
            this.label_socre.AutoSize = true;
            this.label_socre.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_socre.ForeColor = System.Drawing.Color.Red;
            this.label_socre.Location = new System.Drawing.Point(3, 18);
            this.label_socre.Name = "label_socre";
            this.label_socre.Size = new System.Drawing.Size(59, 20);
            this.label_socre.TabIndex = 0;
            this.label_socre.Text = "得分:";
            // 
            // button_left
            // 
            this.button_left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_left.BackgroundImage")));
            this.button_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_left.Enabled = false;
            this.button_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_left.Location = new System.Drawing.Point(451, 353);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(45, 45);
            this.button_left.TabIndex = 3;
            this.button_left.UseVisualStyleBackColor = true;
            // 
            // button_down
            // 
            this.button_down.BackColor = System.Drawing.Color.Yellow;
            this.button_down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_down.BackgroundImage")));
            this.button_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_down.Enabled = false;
            this.button_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_down.Location = new System.Drawing.Point(451, 455);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(45, 45);
            this.button_down.TabIndex = 4;
            this.button_down.UseVisualStyleBackColor = false;
            // 
            // button_right
            // 
            this.button_right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_right.BackgroundImage")));
            this.button_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_right.Enabled = false;
            this.button_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_right.Location = new System.Drawing.Point(451, 404);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(45, 45);
            this.button_right.TabIndex = 5;
            this.button_right.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(502, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "向左移动";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(503, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "加速移动";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(502, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "向右移动";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(446, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "空格键调整方块方向";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(474, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "下一个方块";
            // 
            // button_up
            // 
            this.button_up.BackColor = System.Drawing.Color.Yellow;
            this.button_up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_up.BackgroundImage")));
            this.button_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_up.Enabled = false;
            this.button_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_up.Location = new System.Drawing.Point(451, 506);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(45, 45);
            this.button_up.TabIndex = 10;
            this.button_up.UseVisualStyleBackColor = false;
            // 
            // label_showPause
            // 
            this.label_showPause.AutoSize = true;
            this.label_showPause.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_showPause.ForeColor = System.Drawing.Color.Black;
            this.label_showPause.Location = new System.Drawing.Point(503, 515);
            this.label_showPause.Name = "label_showPause";
            this.label_showPause.Size = new System.Drawing.Size(49, 20);
            this.label_showPause.TabIndex = 11;
            this.label_showPause.Text = "暂停";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_start});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "菜单";
            // 
            // ToolStripMenuItem_start
            // 
            this.ToolStripMenuItem_start.Name = "ToolStripMenuItem_start";
            this.ToolStripMenuItem_start.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_start.Text = "开始";
            this.ToolStripMenuItem_start.Click += new System.EventHandler(this.ToolStripMenuItem_start_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(617, 763);
            this.Controls.Add(this.label_showPause);
            this.Controls.Add(this.button_up);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_down);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_show);
            this.Controls.Add(this.panel_game);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_game;
        private System.Windows.Forms.Panel panel_show;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_socre;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.Label label_showPause;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_start;
    }
}

