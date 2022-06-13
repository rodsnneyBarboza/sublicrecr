using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sublicreacr.Negocio
{
    public class Validaciones
    {
        #region validacionesCampos
        public string validarCorreo(string correo)
        {
            string mensaje;

            if (correo.Length > 0)
            {
                if (correo.Contains("@") && correo.Contains("."))
                {
                    mensaje = string.Empty;
                }
                else
                {
                    mensaje = "formato del correo electrónico incorrecto";
                }

            }
            else
            {
                mensaje = "debe completar el correo";
            }

            return mensaje;
        }

        public string validarContrasena(string contrasena)
        {
            string mensaje;


            if (contrasena.Length > 0)
            {
                mensaje = string.Empty;
            }
            else
            {
                mensaje = "debe completar el correo";
            }

            return mensaje;
        }
        #endregion

        #region validacionEspeciales
        public string MD5Contrasena(string contrasena)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] entrada = System.Text.Encoding.UTF8.GetBytes(contrasena);
            byte[] hash = md5.ComputeHash(entrada);
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            foreach (byte b in hash)
            {
                s.Append(b.ToString("x2").ToLower());
            }

            return s.ToString();
        }

        public string validarNulos(object objeto, string mensajeRetornar)
        {
            if (objeto != null)
            {
                mensajeRetornar = string.Empty;
            }

            return mensajeRetornar;
        }

        public bool validarSoloNumerosOLetras(KeyPressEventArgs e,string tipo)
        {
            bool bloqueado = false;
            if(tipo == "l" && char.IsNumber(e.KeyChar))
            {
                bloqueado = true;
            }else if(tipo == "n" && !char.IsNumber(e.KeyChar))
            {
              bloqueado = true;
            }
            

            return bloqueado;
        }

        
        #endregion


    }
}
