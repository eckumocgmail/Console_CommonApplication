function Filter(options) {
    return function specification(constructor) {
        $application().filters.push({
            options: options,
            constructor: constructor
        });
    };
}
class FilterDefinition {
}
