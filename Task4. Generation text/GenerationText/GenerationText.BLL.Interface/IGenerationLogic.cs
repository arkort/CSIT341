using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationText.BLL.Interface
{
    public interface IGenerationLogic
    {
        string GetGenerateText1();
        string GetGenerateText2(char begWord);
        string GetGenerateText3(int countWords);
    }
}
