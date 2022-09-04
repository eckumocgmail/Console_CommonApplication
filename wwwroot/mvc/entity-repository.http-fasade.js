var App;
(function (App) {
    class EntityRepositoryRepsonse {
    }
    class EntityRepository {
        constructor(type, $http) {
            this.timestamp = new Date().getTime();
            this.cachetimeout = 10000;
            this.items = [];
            this.type = type;
            this.$http = $http;
        }
        Find(id) {
            return this.$http({
                method: 'GET',
                url: `/Database/` + this.type + '/Find?args=' +
                    JSON.stringify({
                        id: id
                    })
            });
        }
        List() {
            const ctrl = this;
            return this.$http({
                method: 'GET',
                url: `/Database/` + this.type + '/List'
            }).then((resp) => {
                ctrl.timestamp = new Date().getTime();
                ctrl.items = resp.data.Result;
                console.log(resp);
                return resp;
            });
        }
        Delete(id) {
            return this.$http({
                method: 'GET',
                url: `/Database/` + this.type + '/Delete/' +
                    JSON.stringify({
                        id: id
                    })
            });
        }
        GetView() {
            throw new Error("Method not implemented.");
        }
        Update(model) {
            return this.$http({
                method: 'GET',
                url: `/Database/` + this.type + '/Delete/' +
                    JSON.stringify({
                        model: model
                    })
            });
        }
        Create(model) {
            throw new Error("Method not implemented.");
        }
    }
    App.EntityRepository = EntityRepository;
})(App || (App = {}));
