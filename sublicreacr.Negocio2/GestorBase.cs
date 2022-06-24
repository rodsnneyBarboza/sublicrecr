using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sublicreacr.Datos;

namespace sublicreacr.Negocio
{
    public class GestorBase
    {

        private Validaciones val = new Validaciones();

        #region mostrar
        public DataSet mostrarCategoria(int _idCategoria=-1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idCategoria", _idCategoria)};
                string sentencia = "select * from TB_CATEGORIA";

                if (_idCategoria != -1)
                {
                    sentencia += " where id_categoria=@idCategoria";

                }
                
                DataSet datos = Database.executeDataset(sentencia, parametros);

           
                
                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }

        public DataSet mostrarArticulo(int _idArticulo = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idArticulo", _idArticulo) };
                string sentencia = "select * from TB_ARTICULO";

                if (_idArticulo != -1)
                {
                    sentencia += " where id_articulo=@idArticulo";

                }

                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }


        public DataSet mostrarUsuarios(string _email="n/a")
        {
            try
            {
                Parameter[] parametros = { new Parameter("@email", _email) };

                string sentencia = "select * from TB_USUARIO";

                if (!_email.Equals("n/a"))
                {
                    sentencia += " where email=@email";

                }
                DataSet datos = Database.executeDataset(sentencia, parametros);

                
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet mostrarTipoUsuario(int _tipoUusario=-1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idTipoUsuario",_tipoUusario) };
                string sentencia = "select * from TB_TIPO_USUARIO";

                if (_tipoUusario != -1)
                {
                    sentencia += " where id_tipo_usuario=@idTipoUsuario";

                }
                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar tipos de usuario", e);
            }
        }
        public DataSet mostrarEmpresa(long _cedulaJuridica)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedulaJuridica", _cedulaJuridica) };

                string sentencia = "select * from TB_EMPRESA";

                if (_cedulaJuridica != -1)
                {
                    sentencia += " where cedula_juridica=@cedulaJuridica";

                }
                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar las empresas", e);
            }
        }

        #endregion

        #region agregar
        public bool agregarCategoria(Categoria cat)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_CATEGORIA(nombre_categoria) VALUES(@nombre_categoria)";
                Parameter[] parametros =
                {
                    new Parameter("@nombre_categoria",cat.NombreCategoria)
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
            }

        }

        public bool agregarArticulo(Articulo art)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_ARTICULO(nombre,precio_venta,cantidad_disponible,imagen,estado,fecha_actualizacion" +
                    ",fk_cedula_juridica, fk_id_categoria) VALUES(@nombre,@precio_venta,@cantidad_disponible" +
                    ",@imagen,@estado,@fecha_actualizacion,@fk_cedula_juridica,@fk_id_categoria)";
                Parameter[] parametros =
                {
                    new Parameter("@nombre",art.Nombre),
                    new Parameter("@precio_venta",art.PrecioVenta),
                    new Parameter("@cantidad_disponible",art.CantidadDisponible),
                    new Parameter("@imagen",art.Imagen),
                    new Parameter("@estado",art.Estado),
                    new Parameter("@fecha_actualizacion",art.FechaActualizacion),
                    new Parameter("@fk_cedula_juridica",art.FkCedulaJuridica),
                    new Parameter("@fk_id_categoria",art.FkIdCategoria)
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar el artículo", e);
            }

        }

        public bool agregarEmpresa(Empresa emp)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_EMPRESA(cedula_juridica,nombre_empresa,telefono,logo,estado)" +
                    "VALUES(@cedula_juridica,@nombre_empresa,@telefono,@logo,@estado)";
                Parameter[] parametros =
                {
                    new Parameter("@cedula_juridica",emp.CedulaJuridica),
                    new Parameter("@nombre_empresa",emp.NombreEmpresa),
                    new Parameter("@telefono",emp.Telefono),
                    new Parameter("@logo",emp.Logo),
                    new Parameter("@estado",emp.Estado)
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar el artículo", e);
            }

        }
        public bool agregarUsuario(Usuario usu)
        {
            try
            {
                string sentencia;
                
                string contrasena = val.MD5Contrasena(usu.Contrasena);
                usu.Contrasena = contrasena;

                sentencia = "insert into TB_USUARIO(email,contrasena,nombre,apellidos,telefono,estado,fk_tipo_usuario,fk_empresa,foto_perfil)" +
                    " values(@email,@contrasena,@nombre,@apellidos,@telefono,@estado,@fk_tipo_usuario,@fk_empresa,@foto_perfil)";
                Parameter[] parametros = {
                                         new Parameter("@email",usu.Email),
                                         new Parameter("@contrasena",usu.Contrasena),
                                         new Parameter("@nombre",usu.Nombre),
                                         new Parameter("@apellidos",usu.Apellidos),
                                         new Parameter("@telefono",usu.Telefono),
                                         new Parameter("@estado",usu.Estado),
                                         new Parameter("@fk_tipo_usuario",usu.FkTipoUsuario),
                                         new Parameter("@fk_empresa",usu.FkEmpresa),
                                         new Parameter("@foto_perfil",usu.FotoPerfil)
                                      };
                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch(Exception e)
            {
                throw new InvalidOperationException("Error al ingresar usuario", e);

            }
        }
        public bool agregarBitacora(Bitacora bit)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO tb_bitacora(fecha_inicio,fecha_fin,tipo_movimiento,detalle_movmiento," +
                    "fk_email) VALUES(@fecha_inicio,@fecha_fin,@tipo_movimiento,@detalle_movimiento,@fk_email)";
                Parameter[] parametros =
                {
                    new Parameter("@fecha_inicio",bit.FechaInicio),
                    new Parameter("@fecha_fin",bit.FechaFin),
                    new Parameter("@tipo_movimiento",bit.TipoMovimiento),
                    new Parameter("@detalle_movimiento",bit.DetalleMovimiento),
                    new Parameter("@fk_email",bit.FkEmail)
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException(e.Message,e);
            }

        }
        #endregion

        #region actualizar
        public bool actualizarCategoria(Categoria cat)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_CATEGORIA SET nombre_categoria=@nombre_categoria" +
                    " WHERE id_categoria=@id_categoria";
                Parameter[] parametros =
                {
                    new Parameter("@nombre_categoria",cat.NombreCategoria),
                    new Parameter("@id_categoria",cat.IdCategoria)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en actualizar categoria", e);
            }

        }

        public bool actualizarArticulo(Articulo art)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_ARTICULO SET nombre=@nombre, precio_venta=@precio_venta, " +
                    "cantidad_disponible=@cantidad_disponible, imagen=@imagen, estado=@estado, " +
                    "fecha_actualizacion=@fecha_actualizacion, fk_cedula_juridica=@fk_cedula_juridica," +
                    " fk_id_categoria=@fk_id_categoria WHERE id_articulo=@id_articulo";
               
                Parameter[] parametros =
                {
                    new Parameter("@nombre",art.Nombre),
                    new Parameter("@precio_venta",art.PrecioVenta),
                    new Parameter("@cantidad_disponible",art.CantidadDisponible),
                    new Parameter("@imagen",art.Imagen),
                    new Parameter("@estado",art.Estado),
                    new Parameter("@fecha_actualizacion",art.FechaActualizacion),
                    new Parameter("@fk_cedula_juridica",art.FkCedulaJuridica),
                    new Parameter("@fk_id_categoria",art.FkIdCategoria),
                    new Parameter("@id_articulo",art.IdArticulo)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en actualizar el artículo", e);
            }

        }

        public bool actualizarEmpresa(Empresa emp)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_EMPRESA SET nombre_empresa=@nombre_empresa,telefono=@telefono" +
                    ",logo=@logo,estado=@estado WHERE cedula_juridica=@cedula_juridica";
                Parameter[] parametros =
                {
                    new Parameter("@nombre_empresa",emp.NombreEmpresa),
                    new Parameter("@telefono",emp.Telefono),
                    new Parameter("@logo",emp.Logo),
                    new Parameter("@estado",emp.Estado),
                    new Parameter("@cedula_juridica",emp.CedulaJuridica)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en actualizar la empresa", e);
            }

        }

        public bool actualizarUsuario(Usuario usu)
        {
            try
            {
                string sentencia;

                sentencia = "UPDATE TB_USUARIO SET ";

                if (!usu.Contrasena.Equals("n/a")) 
                {
                    string contrasena = val.MD5Contrasena(usu.Contrasena);
                    usu.Contrasena = contrasena;
                    sentencia += "contrasena=@contrasena,";
                }

                sentencia += "nombre=@nombre,apellidos=@apellidos," +
                    "telefono=@telefono,estado=@estado,fk_tipo_usuario=@fk_tipo_usuario,fk_empresa=@fk_empresa," +
                    "foto_perfil=@foto_perfil WHERE email=@email";
                Parameter[] parametros = {
                                         new Parameter("@contrasena",usu.Contrasena),
                                         new Parameter("@nombre",usu.Nombre),
                                         new Parameter("@apellidos",usu.Apellidos),
                                         new Parameter("@telefono",usu.Telefono),
                                         new Parameter("@estado",usu.Estado),
                                         new Parameter("@fk_tipo_usuario",usu.FkTipoUsuario),
                                         new Parameter("@fk_empresa",usu.FkEmpresa),
                                         new Parameter("@foto_perfil",usu.FotoPerfil),
                                         new Parameter("@email",usu.Email),

                                      };
                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error al actualizar usuario", e);

            }
        }
        #endregion
        public DataSet informacionLogin(Usuario usu)
        {
            try
            {
                string contrasena = val.MD5Contrasena(usu.Contrasena);
                usu.Contrasena = contrasena;
                string sentencia = "select * from TB_USUARIO as u" +
                    " INNER JOIN TB_TIPO_USUARIO as tu ON u.fk_tipo_usuario = tu.id_tipo_usuario" +
                    " where email=@email and contrasena=@contrasena";
                Parameter[] parametros = { new Parameter("@email", usu.Email), new Parameter("@contrasena", usu.Contrasena) };
                DataSet datos = Database.executeDataset(sentencia, parametros);
                //string record = datos.Tables[0].Rows[0]["nombre"].ToString();
                
                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
            
        }
    }
}
