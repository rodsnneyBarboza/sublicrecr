using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    class Usuario
    {
        private string email;
        private string contrasena;
        private string verificarContrasena;
        private string nombre;
        private string apellidos;
        private int telefono;
        private byte[] fotoPerfil;
        private bool estado;
        private int fkTipoUsuario;
        private int fkEmpresa;

        public Usuario(string _email, string _contrasena, string _verificarContrasena, string _nombre
            , string _apellidos, int _telefono, byte[] _fotoPerfil, bool _estado, int _fkTipoUsuario
            , int _fkEmpresa)
        {
            this.email = _email;
            this.contrasena = _contrasena;
            this.verificarContrasena = _verificarContrasena;
            this.nombre = _nombre;
            this.apellidos = _apellidos;
            this.telefono = _telefono;
            this.fotoPerfil = _fotoPerfil;
            this.estado = _estado;
            this.fkTipoUsuario = _fkTipoUsuario;
            this.fkEmpresa = _fkEmpresa;
        }

        public string Email { get => email; set => email=value; }
        public string Contrasena { get=> contrasena; set=>contrasena=value; }
        public string VerificacionContrasena { get => verificarContrasena; set => verificarContrasena = value; }
        public string Nombre { get=>nombre; set=>nombre=value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int FkTipoUsuario { get => fkTipoUsuario; set => fkTipoUsuario = value; }
        public int FkEmpresa { get => FkEmpresa; set => fkEmpresa = value; }





    }
}
