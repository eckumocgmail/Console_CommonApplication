function Component(options) {
    return function specification(constructor) {
        $application().components.push({
            options: options,
            constructor: constructor
        });
    };
}
