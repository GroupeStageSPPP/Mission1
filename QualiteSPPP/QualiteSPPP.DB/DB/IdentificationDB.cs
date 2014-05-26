using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class IdentificationDB
    {
        public bool Verification(string login, string motDePasse)
        {
            /*
            * Code verification Identifiants sur la color de donnée
            */
            if ((login == "admin") && (motDePasse == "admin"))
            {
                return true;
            }
            else if ((login == "nonadmin") && (motDePasse == "nonadmin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificationAdminAcess(string login)
        {
            /*
            * Code verification si Accès Admin ou non sur la color de donnée
            */
            if (login == "admin")
            {
                return true;
            }
            else if (login == "nonadmin")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
