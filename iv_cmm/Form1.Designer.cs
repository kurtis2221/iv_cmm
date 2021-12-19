namespace iv_cmm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_mod = new System.Windows.Forms.ListBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_mod
            // 
            this.lb_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_mod.FormattingEnabled = true;
            this.lb_mod.ItemHeight = 29;
            this.lb_mod.Location = new System.Drawing.Point(12, 12);
            this.lb_mod.Name = "lb_mod";
            this.lb_mod.Size = new System.Drawing.Size(330, 178);
            this.lb_mod.TabIndex = 0;
            this.lb_mod.SelectedIndexChanged += new System.EventHandler(this.lb_mod_SelectedIndexChanged);
            // 
            // bt_start
            // 
            this.bt_start.Enabled = false;
            this.bt_start.Location = new System.Drawing.Point(12, 196);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(128, 24);
            this.bt_start.TabIndex = 1;
            this.bt_start.Text = "Start Mod";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_info
            // 
            this.bt_info.Enabled = false;
            this.bt_info.Location = new System.Drawing.Point(214, 196);
            this.bt_info.Name = "bt_info";
            this.bt_info.Size = new System.Drawing.Size(128, 24);
            this.bt_info.TabIndex = 1;
            this.bt_info.Text = "Mod Info";
            this.bt_info.UseVisualStyleBackColor = true;
            this.bt_info.Click += new System.EventHandler(this.bt_info_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 232);
            this.Controls.Add(this.bt_info);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.lb_mod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA IV Custom Mod Manager 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_mod;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_info;
    }
}

