public interface IAppServiceModel: IModel
{

    public object GetRoot();
    public void Connect(string url);


    public IEntityFasade<MyApplicationModel> Applications { get; set; }
    public IEntityFasade<MyControllerModel> Controllers { get; set; }
    public IEntityFasade<MyActionModel> Actions { get; set; }
    public IEntityFasade<MyParameterDeclarationModel> Parameters { get; set; }

    
}