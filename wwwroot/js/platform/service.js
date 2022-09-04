function Service(options) {
    return function specification(constructor) {
        $application().services.push({
            options: options,
            constructor: constructor
        });
    };
}
class ServiceDescription {
}
