using Garvan.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garvan.Resources.Interfaces
{
    public interface ITranslationManager
    {
        string GetResource(string resourceKey, TranslationLanguage language);
    }
}
