namespace CalculatriceApp
{
    partial class Calculatrice
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculatrice));
            this.txtAffichage = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnPct = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnPrd = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNeg = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnvgl = new System.Windows.Forms.Button();
            this.btnRst = new System.Windows.Forms.Button();
            this.btnDif = new System.Windows.Forms.Button();
            this.btnRcn = new System.Windows.Forms.Button();
            this.btnCbe = new System.Windows.Forms.Button();
            this.btnCre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAffichage
            // 
            this.txtAffichage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAffichage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAffichage.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAffichage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtAffichage.Location = new System.Drawing.Point(1, 88);
            this.txtAffichage.Name = "txtAffichage";
            this.txtAffichage.ReadOnly = true;
            this.txtAffichage.Size = new System.Drawing.Size(437, 67);
            this.txtAffichage.TabIndex = 0;
            this.txtAffichage.Text = "0";
            this.txtAffichage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDel.Location = new System.Drawing.Point(333, 167);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(89, 62);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "←";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnClr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClr.FlatAppearance.BorderSize = 0;
            this.btnClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClr.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnClr.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClr.Location = new System.Drawing.Point(226, 167);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(89, 62);
            this.btnClr.TabIndex = 2;
            this.btnClr.Text = "C";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnPct
            // 
            this.btnPct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnPct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct.FlatAppearance.BorderSize = 0;
            this.btnPct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnPct.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPct.Location = new System.Drawing.Point(119, 167);
            this.btnPct.Name = "btnPct";
            this.btnPct.Size = new System.Drawing.Size(89, 62);
            this.btnPct.TabIndex = 3;
            this.btnPct.Text = "%";
            this.btnPct.UseVisualStyleBackColor = false;
            this.btnPct.Click += new System.EventHandler(this.btnPct_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.BackColor = System.Drawing.Color.BlueViolet;
            this.btnDiv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiv.FlatAppearance.BorderSize = 0;
            this.btnDiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiv.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnDiv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiv.Location = new System.Drawing.Point(333, 250);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(89, 62);
            this.btnDiv.TabIndex = 4;
            this.btnDiv.Text = "÷";
            this.btnDiv.UseVisualStyleBackColor = false;
            this.btnDiv.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn9.Location = new System.Drawing.Point(226, 333);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(89, 62);
            this.btn9.TabIndex = 5;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn8.Location = new System.Drawing.Point(119, 333);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(89, 62);
            this.btn8.TabIndex = 6;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn7.Location = new System.Drawing.Point(12, 333);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(89, 62);
            this.btn7.TabIndex = 7;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExp.FlatAppearance.BorderSize = 0;
            this.btnExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnExp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExp.Location = new System.Drawing.Point(12, 167);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(89, 62);
            this.btnExp.TabIndex = 8;
            this.btnExp.Text = "xʸ";
            this.btnExp.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn4.Location = new System.Drawing.Point(12, 416);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(89, 62);
            this.btn4.TabIndex = 12;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn5.Location = new System.Drawing.Point(119, 416);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(89, 62);
            this.btn5.TabIndex = 11;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn6.Location = new System.Drawing.Point(226, 416);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(89, 62);
            this.btn6.TabIndex = 10;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btnPrd
            // 
            this.btnPrd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrd.FlatAppearance.BorderSize = 0;
            this.btnPrd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrd.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnPrd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrd.Location = new System.Drawing.Point(333, 333);
            this.btnPrd.Name = "btnPrd";
            this.btnPrd.Size = new System.Drawing.Size(89, 62);
            this.btnPrd.TabIndex = 9;
            this.btnPrd.Text = "×";
            this.btnPrd.UseVisualStyleBackColor = false;
            this.btnPrd.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn1.Location = new System.Drawing.Point(12, 499);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(89, 62);
            this.btn1.TabIndex = 16;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn2.Location = new System.Drawing.Point(119, 499);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(89, 62);
            this.btn2.TabIndex = 15;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn3.Location = new System.Drawing.Point(226, 499);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(89, 62);
            this.btn3.TabIndex = 14;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Location = new System.Drawing.Point(333, 499);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 62);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btnNeg
            // 
            this.btnNeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnNeg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNeg.FlatAppearance.BorderSize = 0;
            this.btnNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeg.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnNeg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNeg.Location = new System.Drawing.Point(12, 582);
            this.btnNeg.Name = "btnNeg";
            this.btnNeg.Size = new System.Drawing.Size(89, 62);
            this.btnNeg.TabIndex = 20;
            this.btnNeg.Text = "+/-";
            this.btnNeg.UseVisualStyleBackColor = false;
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btn0.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn0.Location = new System.Drawing.Point(119, 582);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(89, 62);
            this.btn0.TabIndex = 19;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btnChiffre_click);
            // 
            // btnvgl
            // 
            this.btnvgl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnvgl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvgl.FlatAppearance.BorderSize = 0;
            this.btnvgl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvgl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnvgl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnvgl.Location = new System.Drawing.Point(226, 582);
            this.btnvgl.Name = "btnvgl";
            this.btnvgl.Size = new System.Drawing.Size(89, 62);
            this.btnvgl.TabIndex = 18;
            this.btnvgl.Text = ".";
            this.btnvgl.UseVisualStyleBackColor = false;
            this.btnvgl.Click += new System.EventHandler(this.btnFlt);
            // 
            // btnRst
            // 
            this.btnRst.BackColor = System.Drawing.Color.Turquoise;
            this.btnRst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRst.FlatAppearance.BorderSize = 0;
            this.btnRst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRst.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnRst.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRst.Location = new System.Drawing.Point(333, 582);
            this.btnRst.Name = "btnRst";
            this.btnRst.Size = new System.Drawing.Size(89, 62);
            this.btnRst.TabIndex = 17;
            this.btnRst.Text = "=";
            this.btnRst.UseVisualStyleBackColor = false;
            this.btnRst.Click += new System.EventHandler(this.btnRst_Click);
            // 
            // btnDif
            // 
            this.btnDif.BackColor = System.Drawing.Color.Orange;
            this.btnDif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDif.FlatAppearance.BorderSize = 0;
            this.btnDif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDif.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnDif.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDif.Location = new System.Drawing.Point(333, 416);
            this.btnDif.Name = "btnDif";
            this.btnDif.Size = new System.Drawing.Size(89, 62);
            this.btnDif.TabIndex = 21;
            this.btnDif.Text = "−";
            this.btnDif.UseVisualStyleBackColor = false;
            this.btnDif.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btnRcn
            // 
            this.btnRcn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnRcn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRcn.FlatAppearance.BorderSize = 0;
            this.btnRcn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRcn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnRcn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRcn.Location = new System.Drawing.Point(226, 250);
            this.btnRcn.Name = "btnRcn";
            this.btnRcn.Size = new System.Drawing.Size(89, 62);
            this.btnRcn.TabIndex = 22;
            this.btnRcn.Text = "√";
            this.btnRcn.UseVisualStyleBackColor = false;
            this.btnRcn.Click += new System.EventHandler(this.btnRcn_Click);
            // 
            // btnCbe
            // 
            this.btnCbe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnCbe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCbe.FlatAppearance.BorderSize = 0;
            this.btnCbe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCbe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnCbe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCbe.Location = new System.Drawing.Point(119, 250);
            this.btnCbe.Name = "btnCbe";
            this.btnCbe.Size = new System.Drawing.Size(89, 62);
            this.btnCbe.TabIndex = 23;
            this.btnCbe.Text = "x³";
            this.btnCbe.UseVisualStyleBackColor = false;
            this.btnCbe.Click += new System.EventHandler(this.btnCbe_Click);
            // 
            // btnCre
            // 
            this.btnCre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnCre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCre.FlatAppearance.BorderSize = 0;
            this.btnCre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnCre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCre.Location = new System.Drawing.Point(12, 250);
            this.btnCre.Name = "btnCre";
            this.btnCre.Size = new System.Drawing.Size(89, 62);
            this.btnCre.TabIndex = 24;
            this.btnCre.Text = "x²";
            this.btnCre.UseVisualStyleBackColor = false;
            this.btnCre.Click += new System.EventHandler(this.btnCre_Click);
            // 
            // Calculatrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(437, 671);
            this.Controls.Add(this.btnCre);
            this.Controls.Add(this.btnCbe);
            this.Controls.Add(this.btnRcn);
            this.Controls.Add(this.btnDif);
            this.Controls.Add(this.btnNeg);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnvgl);
            this.Controls.Add(this.btnRst);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btnPrd);
            this.Controls.Add(this.btnExp);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnPct);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtAffichage);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculatrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculatrice";
            this.Load += new System.EventHandler(this.Calculatrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAffichage;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnPct;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btnPrd;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNeg;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnvgl;
        private System.Windows.Forms.Button btnRst;
        private System.Windows.Forms.Button btnDif;
        private System.Windows.Forms.Button btnRcn;
        private System.Windows.Forms.Button btnCbe;
        private System.Windows.Forms.Button btnCre;
    }
}

