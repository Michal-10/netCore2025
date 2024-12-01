using ClubCardsProject.Data;
using ClubCardsProject.Entities;

namespace ClubCards.Data.Repositories
{
    public class BuyingRepository: IRepository<BuyingEntity>
    {
        private readonly DataContext _dataContext;
        public BuyingRepository(DataContext dataContext)
        {
            _dataContext = dataContext ;
        }
        public  List<BuyingEntity> GetAllDB()
        {
            return _dataContext.BuyingsList;
        }
        public BuyingEntity GetByIdDB(int id)
        {
            return _dataContext.BuyingsList.Where(b => b.Id == id).FirstOrDefault();
        }

        public bool AddDB(BuyingEntity buyingEntity)
        {
            try
            {
                _dataContext.BuyingsList.Add(buyingEntity);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, BuyingEntity buyingEntity)
        {
            try
            {
                int index=  _dataContext.BuyingsList.FindIndex(b=>b.Id==id);
                _dataContext.BuyingsList[index] = buyingEntity;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDB(int id)
        {
            try
            {
                BuyingEntity buying = _dataContext.BuyingsList.Find(b => b.Id == id);
                _dataContext.BuyingsList.Remove(buying);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
