using GenerationText.DAL;

namespace GenerationText.BLL
{
    public static class Common
    {
        private static IGenerationDAO data = new GenerationDAO();

        public static IGenerationDAO Data
        {
            get
            {
                return data;
            }
        }
    }
}