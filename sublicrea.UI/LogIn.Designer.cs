
namespace sublicrea.UI
{
    partial class LogIn
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
            this.lbCorreo = new System.Windows.Forms.Label();
            this.lbContrasena = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContrasena = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnIngresar = new Guna.UI2.WinForms.Guna2Button();
            this.lnIniciarSesion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDesarrolladoPor = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbCorreo
            // 
            this.lbCorreo.AutoSize = true;
            this.lbCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lbCorreo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCorreo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbCorreo.Location = new System.Drawing.Point(81, 106);
            this.lbCorreo.Name = "lbCorreo";
            this.lbCorreo.Size = new System.Drawing.Size(227, 28);
            this.lbCorreo.TabIndex = 0;
            this.lbCorreo.Text = "Correo Electrónico";
            // 
            // lbContrasena
            // 
            this.lbContrasena.AutoSize = true;
            this.lbContrasena.BackColor = System.Drawing.Color.Transparent;
            this.lbContrasena.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContrasena.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbContrasena.Location = new System.Drawing.Point(81, 213);
            this.lbContrasena.Name = "lbContrasena";
            this.lbContrasena.Size = new System.Drawing.Size(147, 28);
            this.lbContrasena.TabIndex = 1;
            this.lbContrasena.Text = "Contraseña";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(86, 139);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(258, 38);
            this.txtEmail.TabIndex = 5;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContrasena.DefaultText = "";
            this.txtContrasena.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContrasena.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContrasena.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContrasena.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContrasena.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContrasena.HideSelection = false;
            this.txtContrasena.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContrasena.Location = new System.Drawing.Point(86, 243);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.PlaceholderText = "";
            this.txtContrasena.SelectedText = "";
            this.txtContrasena.Size = new System.Drawing.Size(258, 36);
            this.txtContrasena.TabIndex = 6;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.BorderColor = System.Drawing.Color.Transparent;
            this.btnIngresar.BorderRadius = 10;
            this.btnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIngresar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(2)))), ((int)(((byte)(126)))));
            this.btnIngresar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(86, 323);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(118, 45);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lnIniciarSesion
            // 
            this.lnIniciarSesion.AutoSize = true;
            this.lnIniciarSesion.BackColor = System.Drawing.Color.Transparent;
            this.lnIniciarSesion.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnIniciarSesion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lnIniciarSesion.Location = new System.Drawing.Point(81, 51);
            this.lnIniciarSesion.Name = "lnIniciarSesion";
            this.lnIniciarSesion.Size = new System.Drawing.Size(164, 28);
            this.lnIniciarSesion.TabIndex = 7;
            this.lnIniciarSesion.Text = "Iniciar Sesión";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(22, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 2);
            this.label2.TabIndex = 10;
            // 
            // lbDesarrolladoPor
            // 
            this.lbDesarrolladoPor.AutoSize = true;
            this.lbDesarrolladoPor.BackColor = System.Drawing.Color.Transparent;
            this.lbDesarrolladoPor.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesarrolladoPor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbDesarrolladoPor.Location = new System.Drawing.Point(87, 413);
            this.lbDesarrolladoPor.Name = "lbDesarrolladoPor";
            this.lbDesarrolladoPor.Size = new System.Drawing.Size(221, 19);
            this.lbDesarrolladoPor.TabIndex = 11;
            this.lbDesarrolladoPor.Text = "Desarrollado por Derek Garribo";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(2)))), ((int)(((byte)(126)))));
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(226, 323);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(118, 45);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Cancelar";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lbDesarrolladoPor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnIniciarSesion);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbContrasena);
            this.Controls.Add(this.lbCorreo);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCorreo;
        private System.Windows.Forms.Label lbContrasena;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtContrasena;
        private Guna.UI2.WinForms.Guna2Button btnIngresar;
        private System.Windows.Forms.Label lnIniciarSesion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDesarrolladoPor;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}