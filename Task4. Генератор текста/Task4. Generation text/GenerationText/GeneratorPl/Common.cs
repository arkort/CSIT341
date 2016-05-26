using GenerationText.BLL;
using GenerationTextMarvoc.BLL;

namespace GeneratorPl
{
    internal class Common
    {
        private static IGenerationLogic grahpLogic = new GenerationLogic();
        private static GenMarkovText markovLogic = new GenMarkovText();

        public static IGenerationLogic GrahpLogic
        {
            get
            {
                return grahpLogic;
            }
        }

        public static GenMarkovText MarkovLogic
        {
            get
            {
                return markovLogic;
            }
        }
    }
}