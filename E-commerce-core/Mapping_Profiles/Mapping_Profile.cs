using E_commerce_core.DTO_s;
using E_commerce_core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_core.Mapping_Profiles
{
    public class Mapping_Profile
    {
       private static readonly TypeAdapterConfig _config=new TypeAdapterConfig();
        static Mapping_Profile()
        {
            _config.NewConfig<Items, ItemDTOs>().
                Map(x => x.ItemUnits, x => x.ItemsUnits.Select(unit => unit.Units.Name).ToList()).
                Map(x => x.Stores, x => x.InvItemStores.Select(stores => stores.Stores.Name).ToList());
        }
        public static TypeAdapterConfig Config => _config;

       
    }
}
