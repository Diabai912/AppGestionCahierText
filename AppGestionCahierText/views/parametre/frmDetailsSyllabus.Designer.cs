namespace AppGestionCahierText.views.parametre
{
    partial class frmDetailsSyllabus
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
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgDetailsSyllabus = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.cbbSyllabus = new System.Windows.Forms.ComboBox();
            this.Syllabus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgDetailsSyllabus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Purple;
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(855, 72);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(159, 46);
            this.btnRechercher.TabIndex = 9;
            this.btnRechercher.Text = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(426, 72);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(433, 46);
            this.txtRecherche.TabIndex = 10;
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.BackColor = System.Drawing.Color.Purple;
            this.btnSelectionner.ForeColor = System.Drawing.Color.White;
            this.btnSelectionner.Location = new System.Drawing.Point(40, 57);
            this.btnSelectionner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(240, 60);
            this.btnSelectionner.TabIndex = 1;
            this.btnSelectionner.Text = "&Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = false;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contenu du cours";
            // 
            // txtSeance
            // 
            this.txtSeance.BackColor = System.Drawing.Color.Purple;
            this.txtSeance.ForeColor = System.Drawing.Color.White;
            this.txtSeance.Location = new System.Drawing.Point(29, 188);
            this.txtSeance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSeance.Name = "txtSeance";
            this.txtSeance.Size = new System.Drawing.Size(306, 26);
            this.txtSeance.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Séance";
            // 
            // DgDetailsSyllabus
            // 
            this.DgDetailsSyllabus.BackgroundColor = System.Drawing.Color.White;
            this.DgDetailsSyllabus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDetailsSyllabus.Location = new System.Drawing.Point(426, 138);
            this.DgDetailsSyllabus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgDetailsSyllabus.Name = "DgDetailsSyllabus";
            this.DgDetailsSyllabus.RowHeadersWidth = 62;
            this.DgDetailsSyllabus.RowTemplate.Height = 28;
            this.DgDetailsSyllabus.Size = new System.Drawing.Size(749, 540);
            this.DgDetailsSyllabus.TabIndex = 20;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Purple;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(227, 600);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(178, 53);
            this.btnSupprimer.TabIndex = 8;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Purple;
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(227, 527);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(178, 53);
            this.btnModifier.TabIndex = 7;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Purple;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(227, 452);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(178, 53);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // txtContenu
            // 
            this.txtContenu.BackColor = System.Drawing.Color.Purple;
            this.txtContenu.ForeColor = System.Drawing.Color.White;
            this.txtContenu.Location = new System.Drawing.Point(29, 267);
            this.txtContenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(306, 26);
            this.txtContenu.TabIndex = 5;
            // 
            // cbbSyllabus
            // 
            this.cbbSyllabus.BackColor = System.Drawing.Color.Purple;
            this.cbbSyllabus.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbSyllabus.FormattingEnabled = true;
            this.cbbSyllabus.Location = new System.Drawing.Point(30, 355);
            this.cbbSyllabus.Name = "cbbSyllabus";
            this.cbbSyllabus.Size = new System.Drawing.Size(304, 28);
            this.cbbSyllabus.TabIndex = 12;
            // 
            // Syllabus
            // 
            this.Syllabus.AutoSize = true;
            this.Syllabus.Location = new System.Drawing.Point(36, 332);
            this.Syllabus.Name = "Syllabus";
            this.Syllabus.Size = new System.Drawing.Size(68, 20);
            this.Syllabus.TabIndex = 11;
            this.Syllabus.Text = "Syllabus";
            // 
            // frmDetailsSyllabus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 734);
            this.Controls.Add(this.Syllabus);
            this.Controls.Add(this.cbbSyllabus);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSeance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgDetailsSyllabus);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmDetailsSyllabus";
            this.Text = "Details Syllabus";
            this.Load += new System.EventHandler(this.frmDetailsSyllabus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgDetailsSyllabus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgDetailsSyllabus;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.ComboBox cbbSyllabus;
        private System.Windows.Forms.Label Syllabus;
    }
}