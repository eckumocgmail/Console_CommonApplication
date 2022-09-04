class ControllerDescription {
}
function Controller(options) {
    return function specification(constructor) {
        $application().controllers.push({
            options: options,
            constructor: constructor
        });
    };
}
