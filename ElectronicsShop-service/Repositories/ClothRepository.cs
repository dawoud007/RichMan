using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using static ElectronicsShop_service.Controllers.ClothController;

namespace ElectronicsShop_service.Repositories;
public class ClothRepository : BaseRepository<Cloth>,IClothRepository
{
    private readonly ApplicationDbContext _context;
    public ClothRepository(ApplicationDbContext context) : base(context)
    {

      _context= context;
    }
    public async Task<List<Cloth>> GetFiltered(ClothSearchDto searchDto)
    {
        IQueryable<Cloth> query = _context.Clothes!;

        // Check if Name is provided and exists in the database
        if (!string.IsNullOrEmpty(searchDto.Name))
        {
            query = query.Where(c => c.Name == searchDto.Name);
            if (query.Count()==0 )
            {
                query = query.Where(c => false);
            }
        }
      

        // Check if Color is provided and exists in the database
        if (!string.IsNullOrEmpty(searchDto.Color))
        {
            query = query.Where(c => c.Color == searchDto.Color);
            if (query.Count() == 0)
            {
                query = query.Where(c => false);
            }
        }
      

        // Check if Make is provided and exists in the database
        if (!string.IsNullOrEmpty(searchDto.Make))
        {
            query = query.Where(c => c.type == searchDto.Make);
            if (query.Count() == 0)
            {
                query = query.Where(c => false);
            }
        }
  
        // Check if Size is provided and exists in the database
        if (searchDto.Size.HasValue)
        {
            query = query.Where(c => c.Size == searchDto.Size);
            if (query.Count() == 0)
            {
                query = query.Where(c => false);
            }
        }

        if (searchDto.Name== null&& searchDto.Color== null && searchDto.Make== null && searchDto.Size==null)
        {
            return new List<Cloth>();
        }



        if (query.Count() > 0)
        {
            return await query.ToListAsync();
        }


        return new List<Cloth>();
    }

}

