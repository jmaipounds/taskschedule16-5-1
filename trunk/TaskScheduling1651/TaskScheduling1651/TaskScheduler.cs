using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskScheduling1651
{
    public class TaskScheduler
    { 
        public static TaskScheduler Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new TaskScheduler();
                return _instance; 
            }
        }
        public List<UnitTask> AllTasks
        {
            get { return _allTasks; }
        }
        private List<UnitTask> _allTasks = new List<UnitTask>();

        private static TaskScheduler _instance;
    }
    public class UnitTask :IComparable
    {
        public UnitTask(int _deadline, int _penalty)
        {
            Deadline = _deadline;
            Penalty = _penalty;
        }
        public int Deadline = 0;
        public int Penalty = 0;
        public int Index = 0;//for calculations

        public int CompareTo(object obj)
        {
            UnitTask obj2 = obj as UnitTask;
            if (obj2.Penalty > Penalty)
                return 1;
            else if (obj2.Penalty == Penalty)
            {
                return 0;
            }
            return -1;
        }

        public override string ToString()
        {
            return "(a" + Index + "), d" + Deadline + ", w" + Penalty;
        }
    }

    public class LowestDeadlineFirst : IComparer<UnitTask>
    {
        int IComparer<UnitTask>.Compare(UnitTask obj1, UnitTask obj2)
        {
            if (obj1.Deadline > obj2.Deadline)
                return 1;
            if (obj1.Deadline == obj2.Deadline)
            {
                if (obj2.Penalty > obj1.Penalty)
                    return 1;
                else if (obj2.Penalty == obj1.Penalty)
                {
                    return 0;
                }
                return -1;
            }
            return -1;
        }
    }

    public class TaskSchedulingFunctions
    {
        public static List<UnitTask> GreedyTaskListWithSwaping(List<UnitTask> _tasks)
        {
            List<UnitTask> retList = new List<UnitTask>(_tasks.Count);//doubles as an independant set. 
            List<UnitTask> bouncedList = new List<UnitTask>();//the list of objects which will certainly incur a penalty.
            _tasks.Sort();
            int taskTime = 1;
            for (int i = 0; i < _tasks.Count; i++)
            {
                
                if (_tasks[i].Deadline >= taskTime)//we'll have enough time.
                {
                    retList.Add(_tasks[i]);
                    taskTime++;
                }
                else if (tryAdd(retList, _tasks[i]))//wasn't a trivial add, but a resort could give us a match.
                {
                    taskTime++;
                }
                else
                    bouncedList.Add(_tasks[i]);//add object that we didn't have time for.
            }
            foreach (UnitTask ut in bouncedList)//combine the list
                retList.Add(ut);

            
           

            return retList;
        }

        protected static bool tryAdd(List<UnitTask> tasks, UnitTask task)
        {
            tasks.Add(task);
            tasks.Sort(new LowestDeadlineFirst());//we can sort since it is in theory an independant set. 
            bool fit = true;
            for(int i = 0; i < tasks.Count;i++)
            {
                if (tasks[i].Deadline < i+1)
                    fit = false;
            }
            if (fit)
                return true;
            else
            {
                tasks.Remove(task);//was no longer an independant set
                return false;
            }
        }

        protected static void Swap(List<UnitTask> tasks, int index1, int index2)
        {
            UnitTask a = tasks[index1];
            UnitTask b = tasks[index2];
        }
    }
}
