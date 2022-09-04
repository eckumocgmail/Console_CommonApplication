"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicationDbContext = void 0;
var client_connection_model_1 = require("./data-model/client-connection.model");
var file_catalog_model_1 = require("./data-model/file-catalog.model");
var file_resource_model_1 = require("./data-model/file-resource.model");
var c_l_r_library_model_1 = require("./data-model/c-l-r-library.model");
var account_model_1 = require("./data-model/account.model");
var calendar_model_1 = require("./data-model/calendar.model");
var group_model_1 = require("./data-model/group.model");
var login_fact_model_1 = require("./data-model/login-fact.model");
var message_model_1 = require("./data-model/message.model");
var news_model_1 = require("./data-model/news.model");
var person_model_1 = require("./data-model/person.model");
var resource_model_1 = require("./data-model/resource.model");
var role_model_1 = require("./data-model/role.model");
var settings_model_1 = require("./data-model/settings.model");
var user_model_1 = require("./data-model/user.model");
var user_groups_model_1 = require("./data-model/user-groups.model");
var web_app_model_1 = require("./data-model/web-app.model");
var business_datasource_model_1 = require("./data-model/business-datasource.model");
var business_function_model_1 = require("./data-model/business-function.model");
var business_indicator_model_1 = require("./data-model/business-indicator.model");
var business_logic_model_1 = require("./data-model/business-logic.model");
var business_process_model_1 = require("./data-model/business-process.model");
var business_report_model_1 = require("./data-model/business-report.model");
var business_resource_model_1 = require("./data-model/business-resource.model");
var group_message_model_1 = require("./data-model/group-message.model");
var message_attribute_model_1 = require("./data-model/message-attribute.model");
var message_property_model_1 = require("./data-model/message-property.model");
var message_protocol_model_1 = require("./data-model/message-protocol.model");
var validation_model_model_1 = require("./data-model/validation-model.model");
var business_dataset_model_1 = require("./data-model/business-dataset.model");
var core_1 = require("@angular/core");
var staff_model_1 = require("./data-model/staff.model");
var department_model_1 = require("./data-model/department.model");
var rate_model_1 = require("./data-model/rate.model");
var position_model_1 = require("./data-model/position.model");
var skill_model_1 = require("./data-model/skill.model");
var employee_model_1 = require("./data-model/employee.model");
var employee_expirience_model_1 = require("./data-model/employee-expirience.model");
var ApplicationDbContext = (function () {
    function ApplicationDbContext($http, $entityRepositoryFactory) {
        window['app'] = this;
        this.$http = $http;
        this.skill = $entityRepositoryFactory.create('Skill', $http, function () { return new skill_model_1.Skill(); });
        this.employee = $entityRepositoryFactory.create('Employee', $http, function () { return new employee_model_1.Employee(); });
        this.employeeExpirience = $entityRepositoryFactory.create('EmployeeExpirience', $http, function () { return new employee_expirience_model_1.EmployeeExpirience(); });
        this.department = $entityRepositoryFactory.create('Department', $http, function () { return new department_model_1.Department(); });
        this.rate = $entityRepositoryFactory.create('Rate', $http, function () { return new rate_model_1.Rate(); });
        this.position = $entityRepositoryFactory.create('Position', $http, function () { return new position_model_1.Position(); });
        this.staff = $entityRepositoryFactory.create('Staff', $http, function () { return new staff_model_1.Staff(); });
        this.clientConnection = $entityRepositoryFactory.create('ClientConnection', $http, function () { return new client_connection_model_1.ClientConnection(); });
        this.fileCatalog = $entityRepositoryFactory.create('FileCatalog', $http, function () { return new file_catalog_model_1.FileCatalog(); });
        this.fileResource = $entityRepositoryFactory.create('FileResource', $http, function () { return new file_resource_model_1.FileResource(); });
        this.cLRLibrary = $entityRepositoryFactory.create('CLRLibrary', $http, function () { return new c_l_r_library_model_1.CLRLibrary(); });
        this.account = $entityRepositoryFactory.create('Account', $http, function () { return new account_model_1.Account(); });
        this.calendar = $entityRepositoryFactory.create('Calendar', $http, function () { return new calendar_model_1.Calendar(); });
        this.group = $entityRepositoryFactory.create('Group', $http, function () { return new group_model_1.Group(); });
        this.loginFact = $entityRepositoryFactory.create('LoginFact', $http, function () { return new login_fact_model_1.LoginFact(); });
        this.message = $entityRepositoryFactory.create('Message', $http, function () { return new message_model_1.Message(); });
        this.news = $entityRepositoryFactory.create('News', $http, function () { return new news_model_1.News(); });
        this.person = $entityRepositoryFactory.create('Person', $http, function () { return new person_model_1.Person(); });
        this.resource = $entityRepositoryFactory.create('Resource', $http, function () { return new resource_model_1.Resource(); });
        this.role = $entityRepositoryFactory.create('Role', $http, function () { return new role_model_1.Role(); });
        this.settings = $entityRepositoryFactory.create('Settings', $http, function () { return new settings_model_1.Settings(); });
        this.user = $entityRepositoryFactory.create('User', $http, function () { return new user_model_1.User(); });
        this.userGroups = $entityRepositoryFactory.create('UserGroups', $http, function () { return new user_groups_model_1.UserGroups(); });
        this.webApp = $entityRepositoryFactory.create('WebApp', $http, function () { return new web_app_model_1.WebApp(); });
        this.businessDatasource = $entityRepositoryFactory.create('BusinessDatasource', $http, function () { return new business_datasource_model_1.BusinessDatasource(); });
        this.businessFunction = $entityRepositoryFactory.create('BusinessFunction', $http, function () { return new business_function_model_1.BusinessFunction(); });
        this.businessIndicator = $entityRepositoryFactory.create('BusinessIndicator', $http, function () { return new business_indicator_model_1.BusinessIndicator(); });
        this.businessLogic = $entityRepositoryFactory.create('BusinessLogic', $http, function () { return new business_logic_model_1.BusinessLogic(); });
        this.businessProcess = $entityRepositoryFactory.create('BusinessProcess', $http, function () { return new business_process_model_1.BusinessProcess(); });
        this.businessReport = $entityRepositoryFactory.create('BusinessReport', $http, function () { return new business_report_model_1.BusinessReport(); });
        this.businessResource = $entityRepositoryFactory.create('BusinessResource', $http, function () { return new business_resource_model_1.BusinessResource(); });
        this.groupMessage = $entityRepositoryFactory.create('GroupMessage', $http, function () { return new group_message_model_1.GroupMessage(); });
        this.messageAttribute = $entityRepositoryFactory.create('MessageAttribute', $http, function () { return new message_attribute_model_1.MessageAttribute(); });
        this.messageProperty = $entityRepositoryFactory.create('MessageProperty', $http, function () { return new message_property_model_1.MessageProperty(); });
        this.messageProtocol = $entityRepositoryFactory.create('MessageProtocol', $http, function () { return new message_protocol_model_1.MessageProtocol(); });
        this.validationModel = $entityRepositoryFactory.create('ValidationModel', $http, function () { return new validation_model_model_1.ValidationModel(); });
        this.businessDataset = $entityRepositoryFactory.create('BusinessDataset', $http, function () { return new business_dataset_model_1.BusinessDataset(); });
    }
    ApplicationDbContext = __decorate([
        core_1.Injectable({ providedIn: 'root' })
    ], ApplicationDbContext);
    return ApplicationDbContext;
}());
exports.ApplicationDbContext = ApplicationDbContext;
