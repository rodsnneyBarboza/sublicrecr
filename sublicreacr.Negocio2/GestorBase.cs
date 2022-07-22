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

        public DataSet mostrarProveedores()
        {
            try
            {
                Parameter[] parametros = { };
                string sentencia = "SELECT DISTINCT e.* FROM TB_ARTICULO as a " +
                    "INNER JOIN TB_EMPRESA as e ON a.fk_cedula_juridica = e.cedula_juridica";

                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarArticuloProveedor(long _cedulJuridica = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@CedulaJuridica", _cedulJuridica) };
                string sentencia = "select id_articulo,nombre, precio_venta,cantidad_disponible from TB_ARTICULO WHERE estado=1 ";

                if (_cedulJuridica != -1)
                {
                    sentencia += " AND fk_cedula_juridica=@CedulaJuridica";

                }

                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarVentas(int _id_venta = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idVenta", _id_venta) };
                string sentencia = "SELECT * FROM TB_VENTA WHERE 1=1";

                if (_id_venta != -1)
                {
                    sentencia += " AND id_venta=@idVenta";

                }

                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }

        public DataSet mostrarArticulosPedidosPendientes(long _cedula_juridica = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedJuridica", _cedula_juridica) };
                string sentencia = "SELECT d.id_detalle_venta,d.fk_id_articulo,e.nombre_empresa,a.nombre,v.fecha_venta,d.cantidad,d.precio FROM TB_VENTA as v" +
                    " INNER JOIN TB_DETALLE_VENTA as d ON v.id_venta = d.fk_id_venta INNER JOIN TB_ARTICULO as a" +
                    " ON a.id_articulo = d.fk_id_articulo INNER JOIN TB_USUARIO as u ON u.email = v.fk_email_comprador " +
                    "INNER JOIN TB_EMPRESA as e ON e.cedula_juridica = u.fk_empresa WHERE v.estado=0 AND d.estado=0";

                if (_cedula_juridica != -1)
                {
                    sentencia += " AND e.cedula_juridica=@cedJuridica";

                }

                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarEmpresaPedidosActivo(long _cedula_juridica = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedJuridica", _cedula_juridica) };
                string sentencia = "SELECT DISTINCT e.cedula_juridica,e.nombre_empresa FROM TB_VENTA" +
                    " as v INNER JOIN TB_USUARIO as u ON u.email = v.fk_email_comprador INNER JOIN TB_EMPRESA as e" +
                    " ON u.fk_empresa = e.cedula_juridica WHERE v.estado = 0";

                if (_cedula_juridica != -1)
                {
                    sentencia += " AND v.fk_cedula_juridica_vendedor =@cedJuridica ";

                }

                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarArticulosPedidos(int _idVenta = -1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idVenta", _idVenta) };
                string sentencia = "select d.id_detalle_venta,a.nombre,cantidad,precio from TB_DETALLE_VENTA as d" +
                    " INNER JOIN TB_ARTICULO as a ON d.fk_id_articulo = a.id_articulo WHERE d.fk_id_venta=@idVenta";

      
                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarVentaActual()
        {
            try
            {
                Parameter[] parametros = {  };
                string sentencia = "SELECT MAX(id_venta) as max_venta FROM TB_VENTA WHERE Estado=0";
             

                DataSet datos = Database.executeDataset(sentencia, parametros);

                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar login", e);
            }
        }
        public DataSet mostrarArticulo(int _idArticulo=-1)
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

        public DataSet stockMaximoMinimo(Empresa _emp, string _tipo)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedJuridica", _emp.CedulaJuridica) };

                string sentencia = "SELECT nombre,cantidad_disponible FROM TB_ARTICULO WHERE 1 = 1 AND fk_cedula_juridica = @cedJuridica";

                if (_tipo.Equals("max"))
                {
                    sentencia += " AND cantidad_disponible>50";

                }
                else
                {
                    sentencia += " AND cantidad_disponible<10";
                }
                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet comportamientoArticulosTiempo(Empresa _emp)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedJuridica", _emp.CedulaJuridica) };

                string sentencia = "SELECT a.nombre,sum(dv.cantidad) as total,MONTH(v.fecha_venta) as mes" +
                    ",YEAR(v.fecha_venta) as annio FROM TB_VENTA as v INNER JOIN TB_DETALLE_VENTA as dv " +
                    "ON dv.fk_id_venta = id_venta INNER JOIN TB_ARTICULO as a ON a.id_articulo = dv.fk_id_articulo " +
                    "WHERE v.fk_cedula_juridica_vendedor = @cedJuridica GROUP BY a.nombre ,YEAR(v.fecha_venta)," +
                    "MONTH(v.fecha_venta)";

                
                DataSet datos = Database.executeDataset(sentencia, parametros);


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet pedidosPorProveedor(Empresa _emp)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@cedJuridica", _emp.CedulaJuridica) };

                string sentencia = "SELECT a.nombre,sum(dv.cantidad) as total FROM TB_VENTA as v " +
                    "INNER JOIN TB_DETALLE_VENTA as dv ON dv.fk_id_venta = id_venta INNER JOIN TB_ARTICULO as a" +
                    " ON a.id_articulo = dv.fk_id_articulo WHERE v.fk_cedula_juridica_vendedor = @cedJuridica " +
                    "GROUP BY a.nombre";


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
        public DataSet mostrarEmpresa(long _cedulaJuridica=-1)
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
        public DataSet mostrarBitacora(Bitacora bit=null)
        {
            try
            {
                DataSet datos;
                 
                string sentencia = "select * from TB_BITACORA";
                string filtros = " WHERE 1=1";


                if (bit!=null)
                {
                    if (!bit.TipoMovimiento.Equals("login"))
                    {
                        filtros += " AND fecha_inicio BETWEEN TRY_CONVERT(DATETIME, @FechaInicio) AND TRY_CONVERT(DATETIME,@FechaFin)";
                    }
                    else
                    {
                        filtros += " AND (fecha_inicio BETWEEN TRY_CONVERT(DATETIME,@FechaInicio) AND " +
                            "TRY_CONVERT(DATETIME,@FechaFin)) AND(fecha_fin BETWEEN TRY_CONVERT(DATETIME, @FechaInicio) " +
                            "AND TRY_CONVERT(DATETIME, @FechaFin))";

                    }

                    filtros +=" AND tipo_movimiento=@tipoMovimiento";

                    if (!bit.FkEmail.Equals("n/a"))
                    {
                        filtros += " AND fk_email=@usuario";
                    }
                }
                else
                {
                    Bitacora bit2 = new Bitacora();
                    bit2.FechaInicio = DateTime.Now;
                    bit2.FechaFin = DateTime.Now;
                    bit2.DetalleMovimiento = "n/a";
                    bit2.FkEmail = "n/a";
                    bit2.TipoMovimiento = "n/a";

                    bit = bit2;
                }

                



                Parameter[] parametros = { new Parameter("@FechaInicio", bit.FechaInicio)
                ,new Parameter("@FechaFin", bit.FechaFin)
                ,new Parameter("@usuario", bit.FkEmail)
                ,new Parameter("@tipoMovimiento", bit.TipoMovimiento)};

                sentencia += filtros;

                datos = Database.executeDataset(sentencia, parametros);

                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        #endregion
        #region agregar
        public bool agregarDetalleVenta(DetalleVenta det)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_DETALLE_VENTA(cantidad,precio,descuento,fk_id_articulo,fk_id_venta,estado)" +
                    " values(@cantidad,@precio,@descuento,@idArticulo,@idVenta,@estado)";

                Parameter[] parametros =
                {
                    new Parameter("@cantidad",det.Cantidad),
                    new Parameter("@precio",det.Precio),
                    new Parameter("@descuento",det.Descuento),
                    new Parameter("@idArticulo",det.FkIdArticulo),
                    new Parameter("@idVenta",det.FkIdVenta),
                    new Parameter("@estado",det.Estado)
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
            }
        }

        public bool agregarVenta(Venta ven)
        {
            try
            {
                string sentencia;
                sentencia = "INSERT INTO TB_VENTA(impuesto,fecha_venta,total,estado,archivo_factura" +
                    ",fecha_entrega,fk_email_comprador,fk_cedula_juridica_vendedor)values(@impuesto,@fechaVenta,@total," +
                    "@estado,NULL,@fechaEntrega,@emailComprador,@cedulJuridica)";
                Parameter[] parametros =
                {
                    new Parameter("@impuesto",ven.Impuesto),
                    new Parameter("@fechaVenta",ven.FechaVenta),
                    new Parameter("@total",ven.Total),
                    new Parameter("@estado",ven.Estado),
                    new Parameter("@fechaEntrega",ven.FechaEntrega),
                    new Parameter("@emailComprador",ven.FkEmailComprador),
                    new Parameter("@cedulJuridica",ven.FkCedulaJuridicaVendedor)


                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
            }

        }
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
        #region eliminar
        public bool eliminarVentasErroneas()
        {
            try
            {
                string sentencia;
                sentencia = "DELETE FROM TB_VENTA WHERE id_venta NOT IN (SELECT DISTINCT fk_id_venta FROM TB_DETALLE_VENTA)";
                Parameter[] parametros =
                {
                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
            }

        }

        public bool eliminarDetalleVenta(int _idDetalleVenta)
        {
            try
            {
                string sentencia;
                sentencia = "DELETE FROM TB_DETALLE_VENTA WHERE id_detalle_venta =@idDetalle";
                Parameter[] parametros =
                {
                    new Parameter("@idDetalle",_idDetalleVenta)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;


            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en agregar categoria", e);
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

        public bool actualizarTotalFinal(Venta ven)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_VENTA SET total=@total" +
                    " WHERE id_venta=@idVenta";
                Parameter[] parametros =
                {
                    new Parameter("@total",ven.Total),
                    new Parameter("@idVenta",ven.IdVenta)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en actualizar categoria", e);
            }

        }

        public bool actualizarDetalleVentaEstado(DetalleVenta det)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_DETALLE_VENTA SET estado=@estado" +
                    " WHERE id_detalle_venta=@idDetalle";
                Parameter[] parametros =
                {
                    new Parameter("@estado",det.Estado),
                    new Parameter("@idDetalle",det.IdDetalleVenta)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en actualizar categoria", e);
            }

        }

        public bool actualizarInventario(DetalleVenta det)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_ARTICULO SET cantidad_disponible=cantidad_disponible-@cantidad" +
                    " WHERE id_articulo=@idArticulo";
                Parameter[] parametros =
                {
                    new Parameter("@cantidad",det.Cantidad),
                    new Parameter("@idArticulo",det.FkIdArticulo)

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

        public bool estadoArticulo(Articulo art)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_ARTICULO SET estado=@estado WHERE id_articulo=@id_articulo";

                Parameter[] parametros =
                {
                    new Parameter("@estado",art.Estado),
                    new Parameter("@id_articulo",art.IdArticulo)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error en cambiar el estado del artículo", e);
            }

        }

        public bool estadoUsuario(Usuario usu)
        {
            try
            {
                string sentencia;

                sentencia = "UPDATE TB_USUARIO SET estado=@estado WHERE email=@email";

                Parameter[] parametros = {
                                         new Parameter("@estado",usu.Estado),
                                         new Parameter("@email",usu.Email)

                                      };
                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error al cambiar estado del usuario", e);

            }
        }

        public bool estadoEmpresa(Empresa emp)
        {
            try
            {
                string sentencia;
                sentencia = "UPDATE TB_EMPRESA SET estado=@estado WHERE cedula_juridica=@cedula_juridica";
                Parameter[] parametros =
                {
                    new Parameter("@estado",emp.Estado),
                    new Parameter("@cedula_juridica",emp.CedulaJuridica)

                };

                Database.exectuteNonQuery(sentencia, parametros);

                return true;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al cambiar estado de la empresa", e);
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
                    " INNER JOIN TB_EMPRESA as e ON e.cedula_juridica=u.fk_empresa" +
                    " where (email=@email and contrasena=@contrasena) AND e.estado=1 AND u.estado=1";
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
