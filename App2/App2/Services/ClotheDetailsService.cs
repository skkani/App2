using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using SQLite;
using App2.Models;

namespace App2.Services
{
    public static class ClotheDetailsService
    {
        static SQLiteAsyncConnection db;
       static async Task Init()
        {
            if (db != null)
                return;

          //  var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<ClotheDetails>();
        }

        public static async Task AddClotheDetails(ClotheDetails clotheDetails)
        {
            await Init();
            var id = 0;
            //string clotheName = string.Empty;
            //string clotheGender = string.Empty;
            //int quantity = 0;
            //clotheName = clotheDetails.ClotheName;
            //clotheGender = clotheDetails.ClotheGender;
            //quantity = clotheDetails.Quantity;
            if (clotheDetails.ClotheId != 0)
            {
                 id = await db.UpdateAsync(clotheDetails);
            }
            else
                 id = await db.InsertAsync(clotheDetails);


        }


        public static async Task<List<ClotheDetails>> GetClotheDetails()
        {
            await Init();
            var ClotheDetails = await db.Table<ClotheDetails>().ToListAsync();
            return ClotheDetails;
        }

        public static async Task<ClotheDetails> GetClotheDetails(int clotheId)
        {
            await Init();
            var clotheDetails = await db.Table<ClotheDetails>().Where(i => i.ClotheId == clotheId).FirstOrDefaultAsync();
            return clotheDetails;
        }

        public static async Task<int> DeleteClotheDetails(ClotheDetails cloth)
        {
            return await db.DeleteAsync(cloth);
        }


    }
}
