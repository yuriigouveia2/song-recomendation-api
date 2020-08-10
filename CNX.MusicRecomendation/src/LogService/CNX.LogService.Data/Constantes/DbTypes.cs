namespace CNX.LogService.Repository.Constantes
{
    public class DbTypes
    {
        public class PostreSQL
        {
            public const string Varchar = "character varying";
            public const string VarBit = "Varbit";
            public const string JsonB = "jsonb";
            public const string Text = "text";
            public const string Point = "point";
            public const string Int4 = "int4";
            public const string Int8 = "int8";
            internal static object datetime;

            public static string DecimalType(int presicion1, int presicion2)
            {
                return $"decimal({presicion1}, {presicion2})";
            }
        }
    }
}
