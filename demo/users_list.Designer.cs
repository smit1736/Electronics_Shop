
namespace demo
{
    partial class users_list
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletebuttoncolumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch_Click = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_id,
            this.user_name,
            this.mobile_no,
            this.email_id,
            this.deletebuttoncolumn});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(228, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 285);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "User Id";
            this.user_id.MinimumWidth = 6;
            this.user_id.Name = "user_id";
            this.user_id.Width = 125;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            this.user_name.HeaderText = "User name";
            this.user_name.MinimumWidth = 6;
            this.user_name.Name = "user_name";
            this.user_name.Width = 125;
            // 
            // mobile_no
            // 
            this.mobile_no.DataPropertyName = "mobile_no";
            this.mobile_no.HeaderText = "Mobile No";
            this.mobile_no.MinimumWidth = 6;
            this.mobile_no.Name = "mobile_no";
            this.mobile_no.Width = 125;
            // 
            // email_id
            // 
            this.email_id.DataPropertyName = "email_id";
            this.email_id.HeaderText = "Email Id";
            this.email_id.MinimumWidth = 6;
            this.email_id.Name = "email_id";
            this.email_id.Width = 125;
            // 
            // deletebuttoncolumn
            // 
            this.deletebuttoncolumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deletebuttoncolumn.HeaderText = "Delete";
            this.deletebuttoncolumn.MinimumWidth = 6;
            this.deletebuttoncolumn.Name = "deletebuttoncolumn";
            this.deletebuttoncolumn.Text = "Delete";
            this.deletebuttoncolumn.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // buttonSearch_Click
            // 
            this.buttonSearch_Click.Location = new System.Drawing.Point(589, 57);
            this.buttonSearch_Click.Name = "buttonSearch_Click";
            this.buttonSearch_Click.Size = new System.Drawing.Size(100, 22);
            this.buttonSearch_Click.TabIndex = 5;
            this.buttonSearch_Click.TextChanged += new System.EventHandler(this.buttonSearch_Click_TextChanged);
            // 
            // users_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 651);
            this.Controls.Add(this.buttonSearch_Click);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "users_list";
            this.Text = "users_list";
            this.Load += new System.EventHandler(this.users_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_id;
        private System.Windows.Forms.DataGridViewButtonColumn deletebuttoncolumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox buttonSearch_Click;
    }
}