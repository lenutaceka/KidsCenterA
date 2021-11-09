using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class ChildrenRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public ChildrenRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public ChildrenRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ChildrenModel> GetAllChildren()
        {
            List<ChildrenModel> childrenList = new List<ChildrenModel>();
            foreach (Children dbChildren in dbContext.Childrens)
            {
                childrenList.Add(MapDbObjectToModel(dbChildren));
            }
            return childrenList;
        }


        public ChildrenModel GetChildrenById(int id)
        {
            return MapDbObjectToModel(dbContext.Childrens.FirstOrDefault(x => x.ChildId == id));
        }

        public void InsertChildren(ChildrenModel childrenModel)
        {
            dbContext.Childrens.InsertOnSubmit(MapModelToDbObject(childrenModel));
            dbContext.SubmitChanges();
        }

        public void UpdateChildren(ChildrenModel childrenModel)
        {
            Children children = dbContext.Childrens.FirstOrDefault(x => x.ChildId == childrenModel.ChildId);

            if (children != null)
            {
                children.ChildId = childrenModel.ChildId;
                children.FirstName = childrenModel.FirstName;
                children.LastName = childrenModel.LastName;
                children.Age = childrenModel.Age;
                children.PhoneNo = childrenModel.PhoneNo;
                children.Email = childrenModel.Email;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteChildren(int id)
        {
            Children children = dbContext.Childrens.FirstOrDefault(x => x.ChildId == id);
            if (children != null)
            {
                dbContext.Childrens.DeleteOnSubmit(children);
                dbContext.SubmitChanges();
            }
        }

        private Children MapModelToDbObject(ChildrenModel childrenModel)
        {
            Children dbChildren = new Children();
            if (childrenModel != null)
            {
                dbChildren.ChildId = childrenModel.ChildId;
                dbChildren.FirstName = childrenModel.FirstName;
                dbChildren.LastName = childrenModel.LastName;
                dbChildren.Age = childrenModel.Age;
                dbChildren.PhoneNo = childrenModel.PhoneNo;
                dbChildren.Email = childrenModel.Email;

                return dbChildren;
            }
            return null;
        }

        private ChildrenModel MapDbObjectToModel(Children dbChildren)
        {
            ChildrenModel childrenModel = new ChildrenModel();
            if (dbChildren != null)
            {
                childrenModel.ChildId = dbChildren.ChildId;
                childrenModel.FirstName = dbChildren.FirstName;
                childrenModel.LastName = dbChildren.LastName;
                childrenModel.Age = dbChildren.Age;
                childrenModel.PhoneNo = dbChildren.PhoneNo;
                childrenModel.Email = dbChildren.Email;

                return childrenModel;
            }
            return null;
        }
    }
}