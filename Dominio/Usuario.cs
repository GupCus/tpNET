using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Mail { get; private set; }
        public string Contrasena { get; private set; } // en producción guardar hashed
        public DateTime FechaAlta { get; private set; }
        public string Rol { get; private set; }

        private readonly List<Grupo> _grupos = new List<Grupo>();
        public IReadOnlyCollection<Grupo> Grupos => _grupos.AsReadOnly();

        public const string RolAdministrador = "Admini";
        public const string RolUsuarioNormal = "NoAdmin";

        public Usuario(int id, string mail, string nombre, string contrasena, DateTime fechaAlta, string rol)
        {
            SetId(id);
            SetMail(mail);
            SetNombre(nombre);
            SetContrasena(contrasena);
            SetFechaAlta(fechaAlta);
            SetRol(rol);
        }

        public Usuario() { }

        public void SetId(int id)
        {
            if (id < 0) throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetMail(string mail)
        {
            if (!EsEmailValido(mail)) throw new ArgumentException("El mail no tiene un formato válido.", nameof(mail));
            Mail = mail;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetContrasena(string contrasena)
        {
            if (string.IsNullOrWhiteSpace(contrasena)) throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(contrasena));
            Contrasena = contrasena;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default) throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }

        public void SetRol(string rol)
        {
            if (rol != RolAdministrador && rol != RolUsuarioNormal)
                throw new ArgumentException("El rol debe ser 'Administrador' o 'UsuarioNormal'.", nameof(rol));
            Rol = rol;
        }

        public void AddGrupo(Grupo grupo)
        {
            if (grupo == null) throw new ArgumentNullException(nameof(grupo));
            if (!_grupos.Any(g => g.Id == grupo.Id)) _grupos.Add(grupo);
            if (!grupo.Usuarios.Any(u => u.Id == this.Id)) grupo.AddUsuario(this);
        }

        public void RemoveGrupo(int grupoId)
        {
            var g = _grupos.FirstOrDefault(x => x.Id == grupoId);
            if (g != null)
            {
                _grupos.Remove(g);
                g.RemoveUsuario(this.Id);
            }
        }
    }
}