using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantApp_Database.Data;
using RestaurantApp_Model.Entities;

namespace RestaaurantApp_BL.Repository
{
    public interface ITableRespository
    {
        Task<List<TableModal>> GetTables();
        Task<TableModal> CreateTable(TableModal tableModal);
      
    }
    public class TableRespository(AppDbContext dbContext) : ITableRespository
    {
        public Task<List<TableModal>> GetTables()
        {
            return dbContext.Table.ToListAsync();
        }
        

        public async Task<TableModal> CreateTable(TableModal tableModal)
        {
            dbContext.Table.Add(tableModal);
            await dbContext.SaveChangesAsync();
            return tableModal;
        }

       
    }

}
