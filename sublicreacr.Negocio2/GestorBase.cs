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


        public DataSet mostrarCategoria(int idCategoria=-1)
        {
            try
            {
                Parameter[] parametros = { new Parameter("@idCategoria", idCategoria)};
                string sentencia = "select * from TB_CATEGORIA";

                if (idCategoria != -1)
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

        public ArrayList mostrarUsuarios()
        {
            try
            {
                Usuario usu;
                ArrayList lista = new ArrayList();
                string sentencia = "select * from TB_USUARIO";
                Parameter[] parametros = { new Parameter("", 0) };
                DataSet datos = Database.executeDataset(sentencia, parametros);

                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    usu = new Usuario();

                    usu.Apellidos = (string)fila["apellidos"];
                    usu.Email = (string)fila["email"];
                    usu.Nombre = (string)fila["nombre"];
                    usu.Telefono = (int)fila["telefono"];

                    if ((bool)fila["estado"] == true)
                    {
                        usu.EstadoLeyenda = "Activo";
                    }
                    else
                    {
                        usu.EstadoLeyenda = "Inactivo";
                    }

                    if (fila["foto_perfil"]!=DBNull.Value)
                    {
                        usu.FotoPerfil = (byte[])fila["foto_perfil"];

                    }
                    else
                    {
                        usu.FotoPerfil = (byte[]) Encoding.ASCII.GetBytes("n/a");

                    }

                    lista.Add(usu);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList mostrarEmpresas()
        {
            try
            {
                Empresa emp;
                ArrayList lista = new ArrayList();
                string sentencia = "select * from TB_EMPRESA";
                Parameter[] parametros = { new Parameter("", 0) };
                DataSet datos = Database.executeDataset(sentencia, parametros);

                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    emp = new Empresa();

                    emp.CedulaJuridica = (int)fila["cedula_juridica"];
                    emp.NombreEmpresa = (string)fila["nombre_empresa"];
                    emp.Telefono = (int)fila["telefono"];

                    if ((bool)fila["estado"] == true)
                    {
                        emp.EstadoLeyenda = "Activo";
                    }
                    else
                    {
                        emp.EstadoLeyenda = "Inactivo";
                    }

                    if (fila["logo"] != DBNull.Value)
                    {
                        emp.Logo = (byte[])fila["logo"];

                    }
                    else
                    {
                        emp.Logo = (byte[])Encoding.ASCII.GetBytes("n/a");

                    }

                    lista.Add(emp);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet mostrarTipoUsuario()
        {
            try
            {
                string sentencia = "select * from TB_TIPO_USUARIO";
                Parameter[] parametros = { };
                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar tipos de usuario", e);
            }
        }

        public DataSet mostrarEmpresa()
        {
            try
            {
                string sentencia = "select * from TB_EMPRESA";
                Parameter[] parametros = { };
                DataSet datos = Database.executeDataset(sentencia, parametros);



                return datos;

            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("Error al consultar las empresas", e);
            }
        }

        public void agregarCategoria(Categoria cat)
        {
            //try
            //{
                string sentencia;
                sentencia = "INSERT INTO TB_CATEGORIA(nombre_categoria) VALUES(@nombre_categoria)";
                Parameter[] parametros =
                {
                    new Parameter("@nombre_categoria",cat.NombreCategoria)
                };

                Database.exectuteNonQuery(sentencia, parametros);
                

            //}catch(SqlException e)
            //{
            //    throw new InvalidOperationException("Error en agregar categoria", e);
            //}

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
