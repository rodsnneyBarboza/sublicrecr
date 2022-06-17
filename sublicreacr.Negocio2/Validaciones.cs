using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
            if (tipo == "l" && char.IsNumber(e.KeyChar))
             {
                bloqueado = true;
             }
             else if (tipo == "n" && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
             {
                bloqueado = true;
              }
              

            return bloqueado;
        }

        public byte[] convertirImagenesABytes(string _ruta)
        {
            Image img = Image.FromFile(_ruta);

            MemoryStream ms = new MemoryStream();
            
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] bytes = ms.ToArray();
            

            return bytes;
        }

        public Image convertirBytesAImagenes(byte[] imagen)
        {
            MemoryStream ms = new MemoryStream(imagen);

            Image img = Image.FromStream(ms);

            return img;
        }

        
        #endregion


    }
}
