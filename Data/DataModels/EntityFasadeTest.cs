using System;
using System.Collections.Generic;
using System.Linq;

public class EntityFasadeTest : TestingElement
{
    public EntityFasadeTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        using (var db = new AuthorizationDataModel())
        {
            var unit = new EntityFasade<UserAccount>(db);
            try
            {
                UserAccount account = null;
                this.Info(unit.GetAll().ToJsonOnScreen());
                unit.Create(account=new UserAccount()
                {
                    Email = "user",
                    Password = "sgdf1423"
                });
                Messages.Add("Реализация " + typeof(IEntityFasade<>).GetNameOfType() + " корректно регистрирует данные в таблицах");

                this.Info(unit.Search("user").ToList().ToJsonOnScreen());
                Messages.Add("Реализация " + typeof(IEntityFasade<>).GetNameOfType() + " корректно выполняет поиск данных в таблицах");
                if (unit.Search("user").ToList().Any() == false)
                {
                    throw new Exception("Не удалось найти созданную запись");
                }
                unit.Delete(account.ID);
                Messages.Add("Реализация " + typeof(IEntityFasade<>).GetNameOfType() + " корректно удаляет данные из таблиц");
                this.Info(unit.Search("user").ToList().ToJsonOnScreen());
                
                

            }
            catch (Exception ex)
            {
                throw new Exception("Реализация "+typeof(IEntityFasade<>).GetNameOfType()+" не корректна: "+ex.Message);
            }
            return Messages;
        }
    }
}