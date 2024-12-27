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
        Task<TableModal> AddTable(TableModal table);

        Task<TableModal> UpdateTable(TableModal table);

        Task<bool> DeleteTable(int id);  
    }
    public class TableRespository(AppDbContext dbContext) : ITableRespository
    {
        public Task<List<TableModal>> GetTables()
        {
            return dbContext.Tables.ToListAsync();
        }

        //post for table
        public async Task<TableModal> AddTable(TableModal table)
        {
            await dbContext.Tables.AddAsync(table);
            await dbContext.SaveChangesAsync();
            return table;
        }

        //update 
        public async Task<TableModal> UpdateTable(TableModal table)
        {
            var existingTable = await dbContext.Tables.FindAsync(table.Id);
            if (existingTable == null)
            {
                return null; // Table not found
            }

            // Update the properties of the existing table
            existingTable.Name = table.Name;
            existingTable.Capacity = table.Capacity;
            existingTable.IsBooked = table.IsBooked;

            // Save changes to the database
            await dbContext.SaveChangesAsync();
            return existingTable;
        }

        //Delete
        public async Task<bool> DeleteTable(int id)
        {
            var table = await dbContext.Tables.FindAsync(id);
            if (table == null)
            {
                return false; // Table not found
            }

            dbContext.Tables.Remove(table);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }

}
