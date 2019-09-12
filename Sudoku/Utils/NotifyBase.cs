// Comment this line out to witch to advanced task behaviour. Only available in target .NET Frameworks >= 4.5 .
#define TASKS_AVAILABLE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sudoku.Utils
{
    public abstract class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
#if DEBUG
            if (!PropertieExistingOnObject(name)) throw new Exception(String.Format("Property '{0}' not found on class '{1}'", name, this.GetType().Name));
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependencies(name);
            ExecuteActions(name);
        }

        protected bool NotifyDependenciesAsync { get; set; }
        protected bool ExecuteActionsAsync { get; set; }
        public NotifyBase()
        {
            NotifyDependenciesAsync = true;
            ExecuteActionsAsync = true;
            LoadAttributeDependencies();
        }


        private Dictionary<string, List<string>> _dependencies;
        protected void RegisterDependChange(string baseProperty, params string[] dependedProperties)
        {
            if (_dependencies == null) _dependencies = new Dictionary<string, List<string>>();
            if (!_dependencies.ContainsKey(baseProperty))
                _dependencies.Add(baseProperty, new List<string>());
            _dependencies[baseProperty].AddRange(dependedProperties);
        }

        protected void RemoveDependChange(string baseProperty, params string[] toRemoveProperties)
        {
            if (_dependencies == null) return;
            if (_dependencies.ContainsKey(baseProperty))
                _dependencies[baseProperty].RemoveAll(x => toRemoveProperties.Contains(x));
        }

        private Dictionary<string, List<Action>> _notifyActions;
        protected void RegisterNotifyAction(string baseProperty, Action action)
        {
            if (_notifyActions == null) _notifyActions = new Dictionary<string, List<Action>>();
            if (!_notifyActions.ContainsKey(baseProperty))
                _notifyActions.Add(baseProperty, new List<Action>());
            _notifyActions[baseProperty].Add(action);
        }

        protected void RemoveNotifyAction(string baseProperty)
        {
            if (_notifyActions == null) return;
            if (_notifyActions.ContainsKey(baseProperty))
                _notifyActions.Remove(baseProperty);
        }

        private void RaiseDependencies(string baseProperty)
        {
            if (_dependencies == null) return;
            if (_dependencies.ContainsKey(baseProperty))
                foreach (var v in _dependencies[baseProperty])
                    if (NotifyDependenciesAsync)
                        RunAsync(() => RaisePropertyChanged(v));
                    else RaisePropertyChanged(v);
        }

        private void ExecuteActions(string baseProperty)
        {
            if (_notifyActions == null) return;
            if (_notifyActions.ContainsKey(baseProperty))
                foreach (var v in _notifyActions[baseProperty])
                    if (ExecuteActionsAsync)
                        RunAsync(v);
                    else
                        v();
        }

        private void RunAsync(Action action)
        {
#if TASKS_AVAILABLE
            System.Threading.Tasks.Task.Factory.StartNew(action);
#else
            System.Threading.ThreadPool.QueueUserWorkItem(x => action());
#endif
        }

        private void LoadAttributeDependencies()
        {
            foreach (var prop in this.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                if (Attribute.IsDefined(prop, typeof(DependsOnAttribute)))
                {
                    var dependencies = Attribute.GetCustomAttributes(prop, typeof(DependsOnAttribute)).Select(x => ((DependsOnAttribute)x).DependencyName);
                    RegisterDependChange(prop.Name, dependencies.ToArray());
                }
        }

#if DEBUG
        private List<string> _approvedProperties;
        private bool PropertieExistingOnObject(string name)
        {
            if (_approvedProperties == null) _approvedProperties = new List<string>();
            if (_approvedProperties.Contains(name)) return true;
            if (this.GetType().GetProperties().Any(x => x.Name == name))
            {
                _approvedProperties.Add(name);
                return true;
            }
            return false;
        }
#endif
    }
}
