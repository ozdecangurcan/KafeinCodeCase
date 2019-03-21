using Kcs.WebUI.Models.FakeProvienceDistrict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kcs.WebUI.Helper
{
    public static class ProvienceDistrictHelper
    {
        public static List<Provience> GetProvienceList()
        {
            List<Provience> provienceList = new List<Provience>
            {
                new Provience{ ProvienceId=34,ProvienceName="İstanbul"},
                new Provience{ ProvienceId=6,ProvienceName="Ankara"}
            };
            return provienceList;
        }

        public static List<District> GetDistrictList(int provienceId)
        {
            List<District> districtList = new List<District>
            {
                new District{ DistrictId=1, DistrictName="Şişli", ProvienceId=34},
                new District{ DistrictId=2, DistrictName="Beşiktaş", ProvienceId=34},
                new District{ DistrictId=3, DistrictName="Mamak", ProvienceId=6},
                new District{ DistrictId=4, DistrictName="Ulus", ProvienceId=6}
            };

            return districtList.Where(x => x.ProvienceId == provienceId).ToList();
        }

        public static List<District> GetDistrictList()
        {
            List<District> districtList = new List<District>
            {
                new District{ DistrictId=1, DistrictName="Şişli", ProvienceId=34},
                new District{ DistrictId=2, DistrictName="Beşiktaş", ProvienceId=34},
                new District{ DistrictId=3, DistrictName="Mamak", ProvienceId=6},
                new District{ DistrictId=4, DistrictName="Ulus", ProvienceId=6}
            };

            return districtList;
        }
    }
}
