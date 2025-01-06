using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Database.Data;
using Restaurant_Models.Entities;

namespace Restaurant_BL.Repositories
{
    public  interface ITableRepository
    {
        Task<List<TableModel>> GetTables();
        Task<TableModel> CreateTable(TableModel tableModel);
        Task<TableModel> GetTables(int Id);
        Task<bool> TableModelExist(int Id);
        Task UpdateTable(TableModel tableModel);

        Task DeleteProduct(int Id);
    }
    public class TableRepository(AppDbContext dbContext) : ITableRepository
    {
        public Task<List<TableModel>> GetTables()
        {
            return dbContext.Tables.ToListAsync();
        }
        public async Task<TableModel> CreateTable(TableModel tableModel)
        {
            dbContext.Tables.Add(tableModel);
            await dbContext.SaveChangesAsync();
            return tableModel;
        }

        public async Task DeleteProduct(int Id)
        {
            var table = dbContext.Tables.FirstOrDefault(t => t.Id == Id);
            dbContext.Tables.Remove(table); 
            await dbContext.SaveChangesAsync();
        }

      

        public Task<TableModel> GetTables( int Id)
        {
            return dbContext.Tables.FirstOrDefaultAsync(n => n.Id==Id);
        }

        public Task<bool> TableModelExist(int Id)
        {
            return dbContext.Tables.AnyAsync(e => e.Id==Id);
        }

        public async Task UpdateTable(TableModel tableModel)
        {
            dbContext.Entry(tableModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
