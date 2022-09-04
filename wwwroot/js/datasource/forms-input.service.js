var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let FormsInputService = class FormsInputService {
    constructor($client) {
        this.$client = $client;
    }
    $input(modelid, evt, formid, isNotForm) {
        const model = document.getElementById(formid);
        if (!model) {
            throw new Error('Аргумент model не определён');
        }
        console.log(arguments);
        const propertyChangesEvent = {
            Source: modelid,
            Property: evt.target.name,
            Value: evt.target.type == 'checkbox' ? evt.target.checked : evt.target.value
        };
        console.log(modelid, propertyChangesEvent);
        return this.$client.$connection.invoke('OnInput', JSON.stringify(propertyChangesEvent))
            .catch((e, status) => {
            console.error("Ошибка при выполнении запроса к концентратору");
            console.error(status + ' ' + e.status + ' ' + e.statusText);
            alert(status + ' ' + e.status + ' ' + e.statusText);
        })
            .then((resp) => { window['checkout'](); return resp; })
            .then(this.$resolveStateCallback(formid, isNotForm));
    }
    $resolveStateCallback(formid, isNotForm) {
        const ctrl = this;
        if (!formid) {
            throw new Error('Аргумент model не определён');
        }
        return function (resp) {
            console.log(resp);
            if (!resp) {
                return;
            }
            const message = JSON.parse(resp);
            if (resp.Status == 'Error') {
                try {
                    ctrl.$resolveStateFailed(message, formid);
                }
                catch (e) {
                    console.error("Ошибка при обработки ответа на запрос выполненый с ошибкой");
                    console.error(e);
                }
            }
            else {
                try {
                    if (isNotForm) {
                        ctrl.$resolveStateSuccess(message, formid);
                    }
                    else {
                        ctrl.$resolveStateSuccessToForm(message, formid);
                    }
                }
                catch (e) {
                    console.error("Ошибка при обработки ответа на успешный запрос");
                    console.error(e);
                }
            }
            return resp;
        };
    }
    $resolveStateSuccess(resp, formid) {
        const model = window['parse'](document.getElementById(formid));
        const modelids = window['parseForIds'](document.getElementById(formid));
        console.log('modelids', modelids);
        console.log(resp, model);
        if (!resp) {
            console.error('Ответное сообщение не корректно');
            return;
        }
        if (!model) {
            console.error('Данные с формы считались некорректно');
            return;
        }
        let state = '';
        const errors = resp.Result;
        let propertyNames = Object.getOwnPropertyNames(model);
        const names = Object.getOwnPropertyNames(errors);
        const buttons = document.querySelectorAll('#' + formid + ' *.btn #' + formid + ' button');
        if (names.length == 0) {
            state = 'valid';
            for (let i = 0; i < buttons.length; i++) {
                buttons[i].removeAttribute('disabled');
            }
        }
        else {
            for (let i = 0; i < buttons.length; i++) {
                buttons[i].setAttribute('disabled', 'true');
            }
        }
        document.getElementById(formid).classList.remove('is-valid');
        document.getElementById(formid).classList.remove('is-invalid');
        document.getElementById(formid).classList.add('is-' + state);
        for (let i = 0; i < propertyNames.length; i++) {
            const name = propertyNames[i];
            if (name == "ID" || name == "HashCode") {
                continue;
            }
            const errorsContainer = document.getElementById('Error_' + modelids[name]);
            if (!errorsContainer) {
                alert('Не найден блок с идентификатором: Error_' + modelids[name]);
            }
            for (let i = (errorsContainer.childNodes.length - 1); i >= 0; i--) {
                errorsContainer.removeChild(errorsContainer.childNodes[i]);
            }
        }
        for (let i = 0; i < propertyNames.length; i++) {
            if (propertyNames[i] == "ID" || propertyNames[i] == "HashCode") {
                continue;
            }
            const inputElement = document.getElementById(modelids[propertyNames[i]]);
            if (!inputElement) {
                alert('Не найден блок с идентификатором: ' + modelids[propertyNames[i]]);
            }
            inputElement.classList.add('is-valid');
            inputElement.classList.remove('is-invalid');
        }
        for (let i = 0; i < names.length; i++) {
            const name = propertyNames[i];
            console.log(modelids[name + 'Input']);
            const inputElement = document.getElementById(modelids[names[i] + 'Input']);
            if (!inputElement) {
                alert('Не найден блок с идентификатором: ' + modelids[propertyNames[i]]);
            }
            inputElement.classList.remove('is-valid');
            inputElement.classList.add('is-invalid');
            const errorsContainer = document.getElementById('Error_' + modelids[names[i] + 'Input']);
            if (!errorsContainer) {
                alert('Не найден блок с идентификатором: ' + 'Error_' + modelids[names[i] + 'Input']);
            }
            const errorMessages = errors[names[i]];
            for (let j = 0; j < errorMessages.length; j++) {
                const errorAlertBlock = document.createElement('div');
                errorAlertBlock.innerHTML = '<div class="text-danger">' + errorMessages[j] + '</div>';
                errorsContainer.appendChild(errorAlertBlock);
            }
        }
    }
    $resolveStateFailed(resp, model) {
        console.error(resp);
        alert('$resolveStateFailed ' + resp);
    }
    $resolveStateSuccessToForm(resp, formid) {
        const model = window['parse'](document.getElementById(formid));
        const modelids = window['parseForIds'](document.getElementById(formid));
        console.log(resp, model);
        if (!resp) {
            console.error('Ответное сообщение не корректно');
            return;
        }
        if (!model) {
            console.error('Данные с формы считались некорректно');
            return;
        }
        let state = '';
        const errors = resp.Result;
        let propertyNames = Object.getOwnPropertyNames(model);
        const names = Object.getOwnPropertyNames(errors);
        console.log(errors);
        console.log(names);
        const buttons = document.querySelectorAll('#' + formid + ' *.btn #' + formid + ' button');
        if (names.length == 0) {
            state = 'valid';
            for (let i = 0; i < buttons.length; i++) {
                buttons[i].removeAttribute('disabled');
            }
        }
        else {
            for (let i = 0; i < buttons.length; i++) {
                buttons[i].setAttribute('disabled', 'true');
            }
        }
        document.getElementById(formid).classList.remove('is-valid');
        document.getElementById(formid).classList.remove('is-invalid');
        document.getElementById(formid).classList.add('is-' + state);
        for (let i = 0; i < propertyNames.length; i++) {
            const name = propertyNames[i];
            if (name.startsWith('__'))
                continue;
            if (name == "ID" || name == "HashCode") {
                continue;
            }
            console.log(name);
            const errorsContainer = document.getElementById('Error_' + modelids[name]);
            if (!errorsContainer) {
                alert('Не найден блок с ошибками для свойства ' + name + ' с идентификатором: Error_' + modelids[name]);
            }
            for (let i = (errorsContainer.childNodes.length - 1); i >= 0; i--) {
                errorsContainer.removeChild(errorsContainer.childNodes[i]);
            }
        }
        for (let i = 0; i < propertyNames.length; i++) {
            if (propertyNames[i] == "ID" || propertyNames[i] == "HashCode") {
                continue;
            }
            const name = propertyNames[i];
            if (name.startsWith('__'))
                continue;
            const inputElement = document.getElementById(modelids[propertyNames[i]]);
            if (!inputElement) {
                alert('Не найден блок с идентификатором: ' + modelids[propertyNames[i]]);
            }
            inputElement.classList.add('is-valid');
            inputElement.classList.remove('is-invalid');
        }
        for (let i = 0; i < names.length; i++) {
            if (names[i].startsWith('__'))
                continue;
            const inputElement = document.getElementById(modelids[names[i] + 'Input']);
            if (!inputElement) {
                alert('Не найден блок для ' + names[i] + ' с идентификатором: ' + modelids[names[i] + 'Input']);
            }
            else {
                inputElement.classList.remove('is-valid');
                inputElement.classList.add('is-invalid');
                const errorsContainer = document.getElementById('Error_' + modelids[names[i] + 'Input']);
                if (!errorsContainer) {
                    alert('Не найден блок с идентификатором: ' + 'Error_' + modelids[names[i] + 'Input']);
                }
                const errorMessages = errors[names[i]];
                for (let j = 0; j < errorMessages.length; j++) {
                    const errorAlertBlock = document.createElement('div');
                    errorAlertBlock.innerHTML = '<div class="text-danger">' + errorMessages[j] + '</div>';
                    errorsContainer.appendChild(errorAlertBlock);
                }
            }
        }
    }
};
FormsInputService = __decorate([
    Service({
        name: '$input'
    })
], FormsInputService);
