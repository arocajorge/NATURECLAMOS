using info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.general
{
    public class tbl_usuario_data
    {
        public tbl_usuario_info get_info(string IdUsuario, string us_contrasenia)
        {
            try
            {
                tbl_usuario_info info;
                using (Entities_general Context = new Entities_general())
                {
                    info = (from q in Context.tbl_usuario
                            where q.IdUsuario == IdUsuario
                            && q.us_contrasenia == us_contrasenia
                            && q.us_estado == true
                            select new tbl_usuario_info
                            {
                                IdUsuario = q.IdUsuario,
                                us_tipo = q.us_tipo,
                                us_contrasenia = q.us_contrasenia,
                                us_nombre = q.us_nombre,
                                us_estado = q.us_estado
                            }).FirstOrDefault();
                }
                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public tbl_usuario_info get_info(string IdUsuario)
        {
            try
            {
                tbl_usuario_info info;
                using (Entities_general Context = new Entities_general())
                {
                    info = (from q in Context.tbl_usuario
                            where q.IdUsuario == IdUsuario
                            && q.us_estado == true
                            select new tbl_usuario_info
                            {
                                IdUsuario = q.IdUsuario,
                                us_tipo=q.us_tipo,
                                us_contrasenia = q.us_contrasenia,
                                us_nombre = q.us_nombre,
                                us_estado = q.us_estado
                            }).FirstOrDefault();
                }
                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<tbl_usuario_info> get_list(string us_tipo)
        {
            try
            {
                List<tbl_usuario_info> Lista;
                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.tbl_usuario
                             where q.us_estado == true
                             && q.us_tipo ==(us_tipo=="" ? q.us_tipo : us_tipo)
                             select new tbl_usuario_info
                             {
                                 IdUsuario = q.IdUsuario,
                                 us_contrasenia = q.us_contrasenia,
                                 us_nombre = q.us_nombre,
                                 us_estado = q.us_estado
                             }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool guardarDB(tbl_usuario_info info, ref string mensaje)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    var lst = from q in Context.tbl_usuario
                              where q.IdUsuario == info.IdUsuario
                              select q;
                    if (lst.Count() > 0)
                    {
                        mensaje = "Usuario ya existe";
                        return false;
                    }

                    tbl_usuario Entity = new tbl_usuario
                    {
                        IdUsuario = info.IdUsuario,
                        us_tipo = info.us_tipo,
                        us_contrasenia = info.us_contrasenia,
                        us_nombre = info.us_nombre,
                        us_estado = info.us_estado = true
                    };
                    Context.tbl_usuario.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool modificarDB(tbl_usuario_info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_usuario Entity = Context.tbl_usuario.FirstOrDefault(q => q.IdUsuario == info.IdUsuario);
                    if (Entity != null)
                    {
                        Entity.us_contrasenia = info.us_contrasenia;
                        Entity.us_tipo = info.us_tipo;
                        Entity.us_nombre = info.us_nombre;
                        Context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool anularDB(tbl_usuario_info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    tbl_usuario Entity = Context.tbl_usuario.FirstOrDefault(q => q.IdUsuario == info.IdUsuario);
                    if (Entity != null)
                    {
                        Entity.us_estado = false;
                        Context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
