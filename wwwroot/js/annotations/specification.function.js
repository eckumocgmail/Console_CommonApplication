function specification(definition) {
    return function specification(constructor) {
        if (!definition.label) {
            definition.label = constructor.name;
        }
        Object.assign(constructor, definition);
        Object.assign(constructor, {
            get path() {
                return constructor.name;
            },
            component: constructor
        });
        constructor.prototype.__proto__ = constructor;
    };
}
