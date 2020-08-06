namespace CNX.UserService.Repository.DataContext
{
    public class SeedData
    {
        public static void RunSeeders(UserContext context)
        {
            RegistrarUsuarioAdmin(context);
        }

        private static void RegistrarUsuarioAdmin(UserContext context)
        {
            //var usuarioAdmin = new Usuario { Id = new Guid("3d654de4-79cb-4f84-95c4-e59938026185"), Ativo = true, };
        }
    }
}
