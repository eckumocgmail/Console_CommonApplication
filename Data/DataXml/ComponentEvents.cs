using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public interface ComponentEvents
    {
        public void OnInit();
        public void OnChanges();
        public void OnUpdate();
        public void OnDestroy();
    }
