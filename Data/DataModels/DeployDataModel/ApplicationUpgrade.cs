namespace CoreModel.Ananlitics.DeployDataModel
{
    public class ApplicationUpgrade: DictionaryTable
    {
        public int ApplicationMigrationID { get; set; }

        public int Order { get; set; }
        public string Up { get; set; }
        public string Down { get; set; }
        public bool Complete { get; set; }        

    }
}