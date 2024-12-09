namespace TravelApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.txtViaCity = new System.Windows.Forms.TextBox();
            this.rbDirect = new System.Windows.Forms.RadioButton();
            this.rbTransit = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // comboBoxFrom
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(50, 30);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(150, 21);
            this.comboBoxFrom.TabIndex = 0;

            // comboBoxTo
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(250, 30);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(150, 21);
            this.comboBoxTo.TabIndex = 1;

            // txtViaCity
            this.txtViaCity.Location = new System.Drawing.Point(450, 30);
            this.txtViaCity.Name = "txtViaCity";
            this.txtViaCity.Size = new System.Drawing.Size(150, 20);
            this.txtViaCity.TabIndex = 2;

            // rbDirect
            this.rbDirect.AutoSize = true;
            this.rbDirect.Location = new System.Drawing.Point(50, 70);
            this.rbDirect.Name = "rbDirect";
            this.rbDirect.Size = new System.Drawing.Size(108, 17);
            this.rbDirect.TabIndex = 3;
            this.rbDirect.TabStop = true;
            this.rbDirect.Text = "Прямой маршрут";
            this.rbDirect.UseVisualStyleBackColor = true;

            // rbTransit
            this.rbTransit.AutoSize = true;
            this.rbTransit.Location = new System.Drawing.Point(250, 70);
            this.rbTransit.Name = "rbTransit";
            this.rbTransit.Size = new System.Drawing.Size(143, 17);
            this.rbTransit.TabIndex = 4;
            this.rbTransit.TabStop = true;
            this.rbTransit.Text = "Маршрут с пересадкой";
            this.rbTransit.UseVisualStyleBackColor = true;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(450, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Найти маршрут";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // txtResult
            this.txtResult.Location = new System.Drawing.Point(50, 120);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(550, 200);
            this.txtResult.TabIndex = 6;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 351);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rbTransit);
            this.Controls.Add(this.rbDirect);
            this.Controls.Add(this.txtViaCity);
            this.Controls.Add(this.comboBoxTo);
            this.Controls.Add(this.comboBoxFrom);
            this.Name = "MainForm";
            this.Text = "TravelApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.TextBox txtViaCity;
        private System.Windows.Forms.RadioButton rbDirect;
        private System.Windows.Forms.RadioButton rbTransit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtResult;
    }
}
