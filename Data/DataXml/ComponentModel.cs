

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class ComponentModel: ComponentEvents
    {
        public InputParams Input { get; set; }
        
        public object Target { get; set; }
        public Action<object> Output { get; set; }
        public object View { get; set; }
        public BaseEntity Model { get; set; }
        //public Controller Ctrl { get; set; }


 
        public void OnInit()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }

        public void OnChanges()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }

        public void OnUpdate()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }

        public void OnDestroy()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }
    }
