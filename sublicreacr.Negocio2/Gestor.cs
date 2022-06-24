using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Gestor
    {

        private GestorBase ges = new GestorBase();
        private Validaciones val = new Validaciones();
        #region mostrar
        public List<Categoria> mostrarCategoria(int _idCategoria=-1)
        {
            try
            {
                List<Categoria> cat = new List<Categoria>();
                DataRowCollection datos = ges.mostrarCategoria(_idCategoria).Tables[0].Rows;

                for (int i=0; i< datos.Count; i++)
                {
                    cat.Add(new Categoria((int)datos[i]["id_categoria"]
                        , datos[i]["nombre_categoria"].ToString()));
                }
                return cat;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Articulo> mostrarArticulo(int _idArticulo = -1)
        {
            try
            {
                List<Articulo> art = new List<Articulo>();
                DataRowCollection datos = ges.mostrarArticulo(_idArticulo).Tables[0].Rows;

                for (int i = 0; i < datos.Count; i++)
                {
                    Articulo articulo = new Articulo();
                    articulo.IdArticulo = Int32.Parse(datos[i]["id_articulo"].ToString());
                    articulo.Nombre = datos[i]["nombre"].ToString();
                    articulo.PrecioVenta = float.Parse(datos[i]["precio_venta"].ToString());
                    articulo.CantidadDisponible = Int32.Parse(datos[i]["cantidad_disponible"].ToString());
                    articulo.FechaActualizacion = DateTime.Parse(datos[i]["fecha_actualizacion"].ToString());
                    articulo.FkCedulaJuridica = Int32.Parse(datos[i]["fk_cedula_juridica"].ToString());
                    articulo.FkIdCategoria = Int32.Parse(datos[i]["fk_id_categoria"].ToString());
                    if (bool.Parse(datos[i]["estado"].ToString()))
                    {
                        articulo.EstadoLeyenda = "Activo";
                    }
                    else
                    {
                        articulo.EstadoLeyenda = "Inactivo";

                    }

                    if (_idArticulo != -1)
                    {
                        byte[] img = (byte[])datos[i]["imagen"];
                        articulo.Imagen = img;

                    }

                    art.Add(articulo);

                }
                return art;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

        public List<TipoUsuario> mostrarTipoUsuario(int _tipoUusario=-1)
        {
            try
            {
                List<TipoUsuario> tipUsu = new List<TipoUsuario>();
                DataRowCollection datos = ges.mostrarTipoUsuario(_tipoUusario).Tables[0].Rows;

                for (int i = 0; i < datos.Count; i++)
                {
                    tipUsu.Add(new TipoUsuario((int)datos[i]["id_tipo_usuario"]
                        , datos[i]["nombre_tipo_usuario"].ToString()));
                }
                return tipUsu;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Usuario> mostrarUsuarios(string _email="n/a")
        {
            try
            {
                List<Usuario> usu = new List<Usuario>();
                DataRowCollection datos = ges.mostrarUsuarios(_email).Tables[0].Rows;
                

                   
                for (int i = 0; i < datos.Count; i++)
                {
                    Usuario u = new Usuario();

                    u.Apellidos = (string)datos[i]["apellidos"];
                    u.Email = (string)datos[i]["email"];
                    u.Nombre = (string)datos[i]["nombre"];
                    u.Telefono = (long)datos[i]["telefono"];
                    u.FkEmpresa = (long)datos[i]["fk_empresa"];
                    u.FkTipoUsuario = (int)datos[i]["fk_tipo_usuario"];


                    if ((bool)datos[i]["estado"] == true)
                    {
                        u.EstadoLeyenda = "Activo";
                    }
                    else
                    {
                        u.EstadoLeyenda = "Inactivo";
                    }

                    if (datos[i]["foto_perfil"] != DBNull.Value)
                    {
                        u.FotoPerfil = (byte[])datos[i]["foto_perfil"];

                    }
                    else
                    {
                        u.FotoPerfil = null;

                    }

                    usu.Add(u);
                }

                return usu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empresa> mostrarEmpresa(long _cedulaJuridica=-1)
        {
            try
            {
                List<Empresa> emp = new List<Empresa>();
                DataRowCollection datos = ges.mostrarEmpresa(_cedulaJuridica).Tables[0].Rows;

                for (int i = 0; i < datos.Count; i++)
                {
                    Empresa e = new Empresa();

                    e.CedulaJuridica = (long)datos[i]["cedula_juridica"];
                    e.NombreEmpresa = datos[i]["nombre_empresa"].ToString();
                    e.Telefono = (long)datos[i]["telefono"];
                    e.Estado = (bool)datos[i]["estado"];
                    if (datos[i]["logo"].ToString().Length>0)
                    {
                        byte[] img = (byte[])datos[i]["logo"];

                        e.Logo = img;
                    }
                    

                    if (bool.Parse(datos[i]["estado"].ToString()))
                    {
                        e.EstadoLeyenda = "Activo";
                    }
                    else
                    {
                        e.EstadoLeyenda = "Inactivo";

                    }
                    emp.Add(e);
                }
                return emp;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region agregar
        public bool agregarCategoria(Categoria cat)
        {
            try
            {
                return ges.agregarCategoria(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool agregarArticulo(Articulo art)
        {
            try
            {
                return ges.agregarArticulo(art);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool agregarEmpresa(Empresa emp)
        {
            try
            {
               return ges.agregarEmpresa(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool agregarUsuario(Usuario usu)
        {
            try
            {
                return ges.agregarUsuario(usu);

            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public bool agregarBitacora(Bitacora bit)
        {
            try
            {
                return ges.agregarBitacora(bit);

            }
            catch (Exception e)
            {
                throw e;

            }
        }

        #endregion

        #region actualizar
        public bool actualizarCategoria(Categoria cat)
        {
            try
            {
                return ges.actualizarCategoria(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool actualizarArticulo(Articulo art)
        {
            try
            {
                return ges.actualizarArticulo(art);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool actualizarEmpresa(Empresa emp)
        {
            try
            {
                return ges.actualizarEmpresa(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool actualizarUsuario(Usuario usu)
        {
            try
            {
                return ges.actualizarUsuario(usu);

            }
            catch (Exception e)
            {
                throw e;

            }
        }

        #endregion
        public DataSet informacionLogin(Usuario usu)
        {
            try
            {                
                return ges.informacionLogin(usu); ;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

       
    }
}
