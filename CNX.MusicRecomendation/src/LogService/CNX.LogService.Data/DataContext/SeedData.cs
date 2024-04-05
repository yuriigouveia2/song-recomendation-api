namespace CNX.LogService.Data.DataContext
{
    public class SeedData
    {
        public static void RunSeeders(LogContext context)
        {
            RegistrarUserAdmin(context);
        }

        private static void RegistrarUserAdmin(LogContext context)
        {
            //var UserAdmin = new User { Id = new Guid("3d654de4-79cb-4f84-95c4-e59938026185"), Ativo = true, };
        }
    }
}
