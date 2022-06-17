using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Negocio
{
    public class Gestor
    {

        private GestorBase ges = new GestorBase();

        public List<Categoria> mostrarCategoria(int idCategoria=-1)
        {
            try
            {
                List<Categoria> cat = new List<Categoria>();
                DataRowCollection datos = ges.mostrarCategoria(idCategoria).Tables[0].Rows;

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

        public List<TipoUsuario> mostrarTipoUsuario()
        {
            try
            {
                List<TipoUsuario> tipUsu = new List<TipoUsuario>();
                DataRowCollection datos = ges.mostrarTipoUsuario().Tables[0].Rows;

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

        public ArrayList mostrarUsuarios()
        {
            try
            {
                return ges.mostrarUsuarios();
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
                return ges.mostrarEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empresa> mostrarEmpresa()
        {
            try
            {
                List<Empresa> emp = new List<Empresa>();
                DataRowCollection datos = ges.mostrarEmpresa().Tables[0].Rows;

                for (int i = 0; i < datos.Count; i++)
                {
                    Empresa e = new Empresa();

                    e.CedulaJuridica = (int)datos[i]["cedula_juridica"];
                    e.NombreEmpresa = datos[i]["nombre_empresa"].ToString();
                    emp.Add(e);
                }
                return emp;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void agregarCategoria(Categoria cat)
        {
            try
            {
                ges.agregarCategoria(cat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  DataSet informacionLogin(Usuario usu)
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
    }
}
