using AutoMapper;

using Pear.Africa.Assessment.Data;
using Pear.Africa.Assessment.Domain.Entities;
using Pear.Africa.Assessment.Integration.Interfaces;
using Pear.Africa.Assessment.Common.Dtos;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pear.Africa.Assessment.Integration.Repository.Core
{
    public class FavouriteService : IFavouriteService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FavouriteService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FavouritesDTO>> GetFavoutireSeriesById(int faveId)
        {
            var favourites = await _db.Favourites.Where(x => x.FaveId == faveId).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<FavouritesDTO>>(favourites);
        }

        public async Task<FavouritesDTO> GetFavouriteById(int id)
        {
            var comment = await _db.Favourites.FindAsync(id);
            return _mapper.Map<FavouritesDTO>(comment);
        }

        public async Task AddFavourite(AddFavouritesDTO favouritesDTO)
        {
            if (FavouritesDTO.FaveId == null)
            {
                throw new DataException($"faveId={FavouritesDTO.FaveId} is null");

            }
            var favourites = _mapper.Map<Favourite>(FavouritesDTO);
            await _db.Favourites.AddAsync(favourites);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateFavourite(int id, EditFavouritesDTO favouritesDTO)
        {
            if (favouritesDTO.FaveId == null)
            {
                throw new DataException($"faveId={favouritesDTO.FaveId} is null");

            }

            var fav = _db.Favourites.FirstOrDefault(_ => _.Id.Equals(id)); 
            var favourite = _mapper.Map(favouritesDTO, fav);
            favourite.Updated = DateTime.Now;
            _db.Entry(favourite).State = EntityState.Modified;
            //_db.Entry(favourite).Property(x => x.Created).IsModified = false;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteFavourite(int id)
        {
            var favourite = await _db.Favourites.FindAsync(id);

            if (favourite == null)
            {
                throw new DataException($"This id => {id} not found.");
            }

            _db.Favourites.Remove(favourite);
            await _db.SaveChangesAsync();
        }

        public bool FavouritestItemExists(int id) => _db.Favourites.Any(_ => _.Id == id);

    }
}
