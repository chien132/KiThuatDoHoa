namespace KTDH.UserC
{
    partial class user_Mode2D
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user_Mode2D));
            this.btn_xe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_xe
            // 
            this.btn_xe.FlatAppearance.BorderSize = 0;
            this.btn_xe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xe.ForeColor = System.Drawing.Color.White;
            this.btn_xe.Image = ((System.Drawing.Image)(resources.GetObject("btn_xe.Image")));
            this.btn_xe.Location = new System.Drawing.Point(14, 15);
            this.btn_xe.Margin = new System.Windows.Forms.Padding(2);
            this.btn_xe.Name = "btn_xe";
            this.btn_xe.Size = new System.Drawing.Size(40, 39);
            this.btn_xe.TabIndex = 0;
            this.btn_xe.UseVisualStyleBackColor = true;
            this.btn_xe.Click += new System.EventHandler(this.btn_xe_Click);
            // 
            // user_Mode2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btn_xe);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "user_Mode2D";
            this.Size = new System.Drawing.Size(281, 292);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_xe;
    }
}
