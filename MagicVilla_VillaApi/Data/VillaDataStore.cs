using MagicVilla_VillaApi.Models.DTO;

namespace MagicVilla_VillaApi.Data;

public static class VillaDataStore
{
    public static List<VillaDTO> villalist = new List<VillaDTO>
    {
        new VillaDTO { Id = 1, MyProperty = "Pool View" },
        new VillaDTO { Id = 2, MyProperty = "Beach View" }

    };
}