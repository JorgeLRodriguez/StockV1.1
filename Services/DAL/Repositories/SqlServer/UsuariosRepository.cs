using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer
{
    class UsuariosRepository
    {
        //PermisosRepository repoPermisos;
        public UsuariosRepository()
        {
            // repoPermisos = new PermisosRepository();
        }
        private string GetConnectionString()
        {
            //var cs = new SqlConnectionStringBuilder();
            //cs.IntegratedSecurity = true;
            //cs.DataSource = ".";
            //cs.InitialCatalog = "upf";
            //return cs.ConnectionString;
            return ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        public List<User> GetAll()
        {
            var cnn = new SqlConnection(GetConnectionString());
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"select * from usuarios;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<User>();

            while (reader.Read())
            {
                User c = new User();
                c.ID = reader.GetGuid(reader.GetOrdinal("ID"));
                c.Name = reader.GetString(reader.GetOrdinal("Name"));
                lista.Add(c);
            }

            reader.Close();
            cnn.Close();

            //vinculo los usuarios con las patentes y familias que tiene configuradas.
            //foreach (var item in lista)
            //{
            //   repoPermisos.FillUserPermissions(item);
            //}



            return lista;
        }
        public void GuardarPermisos(User u)
        {

            try
            {
                var cnn = new SqlConnection(GetConnectionString());
                cnn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                cmd.CommandText = $@"delete from usuarios_permisos where id_usuario=@id;";
                cmd.Parameters.Add(new SqlParameter("ID", u.ID));
                cmd.ExecuteNonQuery();

                foreach (var item in u.Permisos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandText = $@"insert into usuarios_permisos (id_usuario,id_permiso) values (@id_usuario,@id_permiso) "; ;
                    cmd.Parameters.Add(new SqlParameter("id_usuario", u.ID));
                    cmd.Parameters.Add(new SqlParameter("id_permiso", item.ID));

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
