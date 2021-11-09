using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class TrainerRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public TrainerRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public TrainerRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<TrainerModel> GetAllTrainers()
        {
            List<TrainerModel> trainerList = new List<TrainerModel>();
            foreach (Trainer dbTrainers in dbContext.Trainers)
            {
                trainerList.Add(MapDbObjectToModel(dbTrainers));
            }
            return trainerList;
        }

        public TrainerModel GetTrainerById(int id)
        {
            return MapDbObjectToModel(dbContext.Trainers.FirstOrDefault(x => x.TrainerId == id));
        }

        public void InsertTrainer(TrainerModel trainerModel)
        {
            dbContext.Trainers.InsertOnSubmit(MapModelToDbObject(trainerModel));
            dbContext.SubmitChanges();
        }

        public void UpdateTrainer(TrainerModel trainerModel)
        {
            Trainer trainer = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == trainerModel.TrainerId);
            if (trainer != null)
            {
                trainer.TrainerId = trainerModel.TrainerId;
                trainer.FirstName = trainerModel.FirstName;
                trainer.LastName = trainerModel.LastName;
                trainer.Email = trainerModel.Email;
                trainer.PhoneNo = trainerModel.PhoneNo;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteTrainer(int id)
        {
            Trainer trainer = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == id);
            if (trainer != null)
            {
                dbContext.Trainers.DeleteOnSubmit(trainer);
                dbContext.SubmitChanges();
            }
        }

        private Trainer MapModelToDbObject(TrainerModel trainerModel)
        {
            Trainer dbTrainers = new Trainer();
            if (trainerModel != null)
            {
                dbTrainers.TrainerId = trainerModel.TrainerId;
                dbTrainers.FirstName = trainerModel.FirstName;
                dbTrainers.LastName = trainerModel.LastName;
                dbTrainers.Email = trainerModel.Email;
                dbTrainers.PhoneNo = trainerModel.PhoneNo;

                return dbTrainers;
            }
            return null;
        }

        private TrainerModel MapDbObjectToModel(Trainer dbTrainers)
        {
            TrainerModel trainerModel = new TrainerModel();
            if (dbTrainers != null)
            {
                trainerModel.TrainerId = dbTrainers.TrainerId;
                trainerModel.FirstName = dbTrainers.FirstName;
                trainerModel.LastName = dbTrainers.LastName;
                trainerModel.Email = dbTrainers.Email;
                trainerModel.PhoneNo = dbTrainers.PhoneNo;

                return trainerModel;
            }
            return null;
        }
    }
}