var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ApplicationDbContext = class ApplicationDbContext {
    constructor($http) {
        this.$spec = window['spec'];
        this.$http = $http;
        this.fileCatalog = new EntityRepository('FileCatalog', $http);
        this.fileResource = new EntityRepository('FileResource', $http);
        this.account = new EntityRepository('Account', $http);
        this.calendar = new EntityRepository('Calendar', $http);
        this.group = new EntityRepository('Group', $http);
        this.groupMessage = new EntityRepository('GroupMessage', $http);
        this.imageResource = new EntityRepository('ImageResource', $http);
        this.loginFact = new EntityRepository('LoginFact', $http);
        this.message = new EntityRepository('Message', $http);
        this.news = new EntityRepository('News', $http);
        this.person = new EntityRepository('Person', $http);
        this.resource = new EntityRepository('Resource', $http);
        this.settings = new EntityRepository('Settings', $http);
        this.user = new EntityRepository('User', $http);
        this.userGroups = new EntityRepository('UserGroups', $http);
        this.businessDataset = new EntityRepository('BusinessDataset', $http);
        this.businessDatasource = new EntityRepository('BusinessDatasource', $http);
        this.businessFunction = new EntityRepository('BusinessFunction', $http);
        this.businessIndicator = new EntityRepository('BusinessIndicator', $http);
        this.businessLogic = new EntityRepository('BusinessLogic', $http);
        this.businessReport = new EntityRepository('BusinessReport', $http);
        this.businessResource = new EntityRepository('BusinessResource', $http);
        this.dev = new EntityRepository('Dev', $http);
        this.granularity = new EntityRepository('Granularity', $http);
        this.groupsBusinessFunctions = new EntityRepository('GroupsBusinessFunctions', $http);
        this.messageAttribute = new EntityRepository('MessageAttribute', $http);
        this.messageProperty = new EntityRepository('MessageProperty', $http);
        this.messageProtocol = new EntityRepository('MessageProtocol', $http);
        this.dataInput = new EntityRepository('DataInput', $http);
        this.datasetIndicators = new EntityRepository('DatasetIndicators', $http);
        this.targetObject = new EntityRepository('TargetObject', $http);
        this.targetObjectDatasets = new EntityRepository('TargetObjectDatasets', $http);
        this.businessProcess = new EntityRepository('BusinessProcess', $http);
        this.validationModel = new EntityRepository('ValidationModel', $http);
    }
};
ApplicationDbContext = __decorate([
    Service({ name: '$applicationDbContext' })
], ApplicationDbContext);
