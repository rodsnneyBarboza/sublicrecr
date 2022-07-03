using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Usuario
    {
        private string email;
        private string contrasena;
        private string verificarContrasena;
        private string nombre;
        private string apellidos;
        private long telefono;
        private byte[] fotoPerfil;
        private byte[] logo;
        private bool estado;
        private string estadoLeyenda;
        private int fkTipoUsuario;
        private string tipoUsuario;
        private long fkEmpresa;

        public Usuario()
        {

        }

        public Usuario(string _email, string _contrasena, string _verificarContrasena, string _nombre
            , string _apellidos, long _telefono, byte[] _fotoPerfil, bool _estado, int _fkTipoUsuario
            , long _fkEmpresa, string _tipoUsuario,string _estadoLeyenda, byte[] _logo)
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
            this.tipoUsuario = _tipoUsuario;
            this.estadoLeyenda = _estadoLeyenda;
            this.logo = _logo;
        }

        public string Email { get => email; set => email=value; }
        public string Contrasena { get=> contrasena; set=>contrasena=value; }
        public string VerificacionContrasena { get => verificarContrasena; set => verificarContrasena = value; }
        public string Nombre { get=>nombre; set=>nombre=value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int FkTipoUsuario { get => fkTipoUsuario; set => fkTipoUsuario = value; }
        public long FkEmpresa { get => fkEmpresa; set => fkEmpresa = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string EstadoLeyenda { get => estadoLeyenda; set => estadoLeyenda = value; }
        public byte[] Logo { get => logo; set => logo = value; }

    }
}
