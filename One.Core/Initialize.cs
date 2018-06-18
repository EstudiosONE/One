using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace One.Core
{
    public class Initialize
    {
        readonly List<Task<bool>> initTask;

        private int TotalTask { get => initTask.Count; }
        private int CompletedTask { get; set; }

        One.Model.Core core;

        public Initialize()
        {
            initTask = new List<Task<bool>>()
            {
                // Operaciones

                // Inicia una instancia nueva de Core
                new Task<bool>(()=>
                {
                    core = new One.Model.Core();
                    Thread.Sleep(500);
                    return true;
                }),

                // Inicia una nueva instancia de Config y la asigna al Core
                new Task<bool>(()=>
                {
                    var config = new Model.Config();
                    core.Config = config;
                    Thread.Sleep(500);
                    return true;
                })
            };
        }

        public async Task<One.Model.Core> StartAsync()
        {
            await TryExecute(initTask);
            return core;
        }

        private async Task TryExecute(List<Task<bool>> initTask)
        {
            for (int i = 0; i < initTask.Count; i++)
            {
                initTask[i].Start();
                var result = await initTask[i];
                OnProgressEvent(new ProgressEventArgs() { TotalTask = TotalTask, CompletedTask = i + 1 });
            }
        }

        protected virtual void OnProgressEvent(ProgressEventArgs e)
        {
            ProgressEvent?.Invoke(this, e);
        }

        public event EventHandler<ProgressEventArgs> ProgressEvent;

        public class ProgressEventArgs : EventArgs
        {
            public int TotalTask { get; set; }
            public int CompletedTask { get; set; }
            public decimal PercentCompleted { get => (CompletedTask / TotalTask); }
        }
    }
}
