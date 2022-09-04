import { EntityRepository } from "./entity-repository";
export class EntityRepositoryFactory {
    create(name, $http, create) {
        return window['$' + name] = new EntityRepository(name, $http, create);
    }
}
