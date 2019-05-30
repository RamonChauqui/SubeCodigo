using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Seguridad.Usuario.DTOs;
using static Presentacion.Helpers.CadenaCaracteres;

namespace XCommerce.Servicio.Seguridad.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public void CambiarEstado(string nombreUsuario, bool estado)
        {
            using (var conetxt = new ModeloXCommerceContainer())
            {
                var usuario = conetxt.Usuarios
                    .FirstOrDefault(usu => usu.Nombre == nombreUsuario);

                if(usuario == null)
                    throw new Exception($"No se encontro el Usuario: {nombreUsuario}.");

                usuario.EstaBloqueado = estado;

                conetxt.SaveChanges();
            }
        }

        public void Crear(long personaId, string apellido, string nombre)
        {
            var nombreUsuario = CrearNombreUsuario(apellido, nombre);

            using (var context = new ModeloXCommerceContainer())
            {
                context.Usuarios.Add(new AccesoDatos.Usuario
                {
                    PersonaId = personaId,
                    EstaBloqueado = false,
                    Nombre = nombreUsuario.ToLower(),
                    Password = Encriptar("P$assword")
                });
                context.SaveChanges();
            }
        }

        private string CrearNombreUsuario(string apellido, string nombre)
        {
            // 1- Crear el nombre
            // 2- Verificar que no exista
            int contadorLetras = 1;
            int digito = 1;

            var usuarioNuevo = $"{nombre.Trim().Substring(0, contadorLetras)}{apellido.Trim()}";

            using (var context = new ModeloXCommerceContainer())
            {
                while (context.Usuarios.Any(x => x.Nombre == usuarioNuevo))
                {
                    if (contadorLetras <= nombre.Trim().Length)
                    {
                        contadorLetras++;
                        usuarioNuevo = $"{nombre.Trim().Substring(0, contadorLetras)}{apellido.Trim()}";
                    }
                    else
                    {
                        usuarioNuevo = $"{nombre.Trim().Substring(0, contadorLetras)}{apellido.Trim()}{digito}";
                        digito++;
                    }
                }
            }   
            return usuarioNuevo;
        }
                 
        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas
                    .AsNoTracking()
                    .Where(x => !x.EstaEliminado
                    && (x.Apellido.Contains(cadenaBuscar) || x.Nombre.Contains(cadenaBuscar)))
                    .Select(x => new UsuarioDto
                    {
                        PersonaId = x.Id,
                        ApellidoPersona = x.Apellido,
                        NombrePersona = x.Nombre,
                        Nombre = x.Usuarios.Any()             //Traer todos los usuarios de esa persona
                        ? x.Usuarios.FirstOrDefault().Nombre //Si tiene algo trae el primero
                        : "NO ASIGNADO",                     //De lo contrario pone no asignado (IF lineal)

                        Id = x.Usuarios.Any()                 //Traer todos los usuarios de ese Id
                        ? x.Usuarios.FirstOrDefault().Id     //Si tiene algo trae el primero
                            : 0,                                 //De lo contrario CERO (IF lineal) 

                        EstaBloqueado = x.Usuarios.Any() && x.Usuarios.FirstOrDefault().EstaBloqueado
                    }).ToList();
            }
        }
    }
}









