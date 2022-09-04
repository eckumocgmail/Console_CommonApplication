using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// Класс управляет консолью администратора.
/// </summary>
public class Consolas: ViewItem
{
    public enum Modes
    {
        FIFO,FILO
    }

    public string State
    {
        get => Get<string>("State");
        set => Set<string>("State",value); 
    }

    private string ChangesDir;

    public Consolas( )
    {
        this.ChangesDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Changes").ToString();
        if (System.IO.Directory.Exists(ChangesDir) == false)
            System.IO.Directory.CreateDirectory(ChangesDir);
        this.OnChange += (object changes) =>
        {
            try
            {
                string filename = 
                    System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), System.IO.Directory.GetFiles(ChangesDir).Length + ".json").ToString();
                changes.ToJsonOnScreen().WriteToFile(filename);
            }
            catch (Exception ex)
            {
                this.Error(ex);
            }
        };
    }


    public Task Open(Modes Mode, 
        Func<string, string> cmd)
    {

        return Task.Run(() => {
            switch (Mode)
            {
                case Modes.FILO:
                    cmd(State);
                    break;
                case Modes.FIFO:
                    break;
            }
        });
        
    }

    public class ConsolesTest: TestingElement
    {
        public override List<string> OnTest()
        {
            var console = new Consolas();
            console.Open(Modes.FIFO, ( message ) => {
                return "Не понятно";
            });
            return Messages;
        }
    }
}

