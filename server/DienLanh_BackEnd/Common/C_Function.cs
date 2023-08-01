namespace DienLanh_BackEnd.Common
{
    public static class C_Function
    {
        public static string randomID()
        {
            Random random = new Random();
            string result = "";

            for (int i = 0; i < 10; i++)
            {
                result += random.Next(10).ToString();
            }

            return result;
        }

        public static string randomFileID()
        {
            Random random = new Random();
            string result = "";

            for (int i = 0; i < 15; i++)
            {
                result += random.Next(10).ToString();
            }

            return result;
        }
    }
}
