using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyExpenses.Data;
using MyExpenses.Enums;
using MyExpenses.Interfaces;

namespace MyExpenses.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class MyExpensesRepository : IDisposable
    {
        MyExpensesDatabase db = null;

        public MyExpensesRepository()
        {
            db = new MyExpensesDatabase();
        }

        public void Dispose() { }

        #region Expense
        /// <summary>
        /// Gets the expense
        /// </summary>
        /// <returns></returns>
        public List<Expense> GetExpense()
        {
            return db.GetItems<Expense>();
        }

        /// <summary>
        /// Gets the expense
        /// </summary>)
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Expense GetExpense(int id)
        {
            return db.GetItem<Expense>(id);
        }

        /// <summary>
        /// Saves the expense
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int SaveExpense(Expense item)
        {
            db.SaveItem<Expense>(item);
            return item.Id;
        }

        /// <summary>
        /// Deletes the expense
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteExpense(int id)
        {
            return db.DeleteItem<Expense>(id);
        }

        /// <summary>
        /// Gets list of expense by function.
        /// </summary>
        /// <param name="func">Function</param>
        /// <returns>The list of expense.</returns>
        public List<Expense> GetExpense(Expression<Func<Expense, bool>> func)
        {
            return db.GetItems<Expense>(func);
        }
        #endregion
        #region Images
        /// <summary>
        /// Gets the images
        /// </summary>
        /// <returns></returns>
        public List<Images> GetImages()
        {
            return db.GetItems<Images>();
        }

        /// <summary>
        /// Gets the images
        /// </summary>)
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Images GetImages(int id)
        {
            return db.GetItem<Images>(id);
        }

        /// <summary>
        /// Saves the images
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int SaveImages(Images item)
        {
            db.SaveItem<Images>(item);
            return item.Id;
        }

        /// <summary>
        /// Deletes the images
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public int DeleteImages(int id)
        {
            return db.DeleteItem<Images>(id);
        }

        /// <summary>
        /// Gets list of images by function.
        /// </summary>
        /// <param name="func">Function</param>
        /// <returns>The list of images.</returns>
        public List<Images> GetImages(Expression<Func<Images, bool>> func)
        {
            return db.GetItems<Images>(func);
        }
        #endregion

        /// <summary>
        /// Gets the first image.
        /// </summary>
        /// <param name="SectionImage">The section.</param>
        /// <returns>Images.</returns>
        public Images GetFirstImage(SectionImage Section, int ItemId)
        {
            Images rtn = null;

            List<Images> list = GetImages(Section, ItemId);
            if (list != null)
            {
                if (list.Count > 0)
                {
                    rtn = new Images();
                    rtn = list.First();
                }
            }

            return rtn;
        }

        /// <summary>
        /// Gets the images for room.
        /// </summary>
        /// <returns>The images for room.</returns>
        /// <param name="Section">Section Image.</param>
        /// <param name="Id">Identifier.</param>
        public List<Images> GetImages(SectionImage Section, int Id)
        {
            return db.GetItems<Images>().Where(w => w.Section == Section && w.ItemSectionId == Id).ToList();
        }

        /// <summary>
        /// Gets the image number.
        /// </summary>
        /// <returns>The image number.</returns>
        public int GetImageNumber(SectionImage Section, int Id)
        {
            return GetImages(Section, Id).Count();
        }
    }
}