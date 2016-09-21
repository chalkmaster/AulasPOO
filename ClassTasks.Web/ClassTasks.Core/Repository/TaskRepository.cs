using ClassTasks.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassTasks.Core.Repository
{
    internal class TaskRepository
    {
        private List<Task> _taskTable;

        internal TaskRepository()
        {
            _taskTable = new List<Task>();
        }

        internal Task GetById(int id)
        {
            return _taskTable.Where(task => task.Id == id).SingleOrDefault();
        }

        internal void Add(Task taskToAdd)
        {
            taskToAdd.Id = _taskTable.Any() ?  _taskTable.Max(task => task.Id) + 1 : 1;
            _taskTable.Add(taskToAdd);
        }

        internal void Update(Task taskToUpdate)
        {
            var taskToRemove = _taskTable.Where(task => task.Id == taskToUpdate.Id).SingleOrDefault();
            _taskTable.Remove(taskToRemove);
            _taskTable.Add(taskToUpdate);
        }

        internal List<Task> FindAll()
        {
            return _taskTable;
        }

        internal List<Task> FindBySubject(string subject)
        {
            return _taskTable.Where(task => task.Subject.Contains(subject)).ToList();
        }

        internal List<Task> FindByDescription(string description)
        {
            return _taskTable.Where(task => task.Description.Contains(description)).ToList();
        }

        internal List<Task> FindByCourse(Course course)
        {
            return _taskTable.Where(task => task.Course.Id == course.Id).ToList();
        }
    }
}
