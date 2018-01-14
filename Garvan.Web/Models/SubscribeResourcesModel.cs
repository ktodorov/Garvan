using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garvan.Web.Models
{
    public class SubscribeResourcesModel
    {
        public string SomethingHappened { get; set; }

        public string EnterValidEmail { get; set; }

        public string ErrorOccurred { get; set; }

        public string EmailSuccessfullyRegistered { get; set; }

        public SubscribeResourcesModel()
        {
            SomethingHappened = Resources.Resources.SomethingHappenedTryAgain;
            EnterValidEmail = Resources.Resources.PleaseEnterValidEmail;
            ErrorOccurred = Resources.Resources.ErrorOccurredTryAgain;
            EmailSuccessfullyRegistered = Resources.Resources.EmailSuccessfullyRegistered;
        }
    }
}
