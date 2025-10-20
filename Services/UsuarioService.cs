using Repository;
using DTOs;
using Dominio;
namespace Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository=usuarioRepository;
        }
        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var usuarios=await usuarioRepository.GetAll();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Mail = usuario.Mail,
                Contrasena = usuario.Contrasena
            });
        }
   
        public async Task<UsuarioDTO> Add(UsuarioDTO dto)
        {
            if (usuarioRepository.EmailExists(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un usuario con el email {dto.Mail}.");
            }
            var user = new Usuario(dto.Mail, dto.Nombre) { Contrasena = "123" };
            var agregado=await usuarioRepository.Add(user);

            return new UsuarioDTO
            {
                Id = agregado.Id,
                Nombre = agregado.Nombre,
                Mail = agregado.Mail,
            };
        }
        public async Task<bool> Update(UsuarioUpdateDTO dto)
        {
            var user = await usuarioRepository.GetOne(dto.Id);
            if (user == null) return false;
            if (usuarioRepository.EmailExists(dto.Mail, dto.Id)){
                throw new ArgumentException("ya existe ese mail");
            }
            user.Nombre = dto.Nombre;
            user.Mail = dto.Mail;

            return await usuarioRepository.Update(user);
        }
        public async Task<bool> Delete(int id)
        {
            return await usuarioRepository.Delete(id);
        }
        public async Task<UsuarioDTO?> GetOneAsync(int id)
        {
            
            Usuario? user = await usuarioRepository.GetOne(id);

        
            if (user == null) return null;

          
            return new UsuarioDTO
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Mail = user.Mail
            };
        }
    }   
}
