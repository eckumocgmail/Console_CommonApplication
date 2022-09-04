export class EntityRepository {
    constructor(type, $http, create) {
        const ctrl = this;
        this.create = create;
        this.type = type;
        this.$http = function (options) {
            switch (options.method) {
                case 'GET':
                    return $http.get(options.url)
                        .then(ctrl.$ensureSuccessCallback())
                        .catch(err => { console.error(err); alert(err); });
                default:
                    throw new Error('Параметры HTTP заданынекорректно');
            }
        };
    }
    $ensureSuccessCallback() {
        const ctrl = this;
        return function (response) {
            console.log(response);
            if (response.Status == 'Success') {
                return response.Result;
            }
            else {
                throw new Error(response);
            }
        };
    }
    Search(query, page, size) {
        console.log('Search', 'query=' + query);
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Search?args=' +
                JSON.stringify({
                    query: query,
                    page: page,
                    size: size
                })
        });
    }
    Keywords(query) {
        console.log('Search', 'query=' + query);
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Keywords?args=' +
                JSON.stringify({
                    query: query
                })
        });
    }
    Find(id) {
        console.log('Find', id);
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Find?args=' +
                JSON.stringify({
                    id: id
                })
        });
    }
    List() {
        console.log('List');
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/List'
        });
    }
    Page(page, size) {
        console.log('Page');
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Page/?args=' +
                JSON.stringify({
                    page: page,
                    size: size
                })
        });
    }
    Delete(id) {
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Delete/?args=' +
                JSON.stringify({
                    id: id
                })
        });
    }
    GetView() {
        throw new Error("Method not implemented.");
    }
    Update(model) {
        console.log('Update', model);
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Update?args=' +
                JSON.stringify({
                    model: model
                })
        });
    }
    Create(model) {
        console.log('Create', model);
        delete model["ID"];
        return this.$http({
            method: 'GET',
            url: `/CommonDatabase/` + this.type + '/Create?args=' +
                JSON.stringify({
                    model: model
                })
        });
    }
}
