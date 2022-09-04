import { validators } from './validators.const';
import { description } from './description.function';
import { dataTypes } from './data-types.const';
export const inputTypes = Object['assign']({
    url: function (mimeType) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'url' };
            validators['url']()(target, prop);
        };
    },
    email: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'email' };
            validators['email']()(target, prop);
        };
    },
    text: function (lang, length) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'text' };
        };
    },
    color: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'color' };
        };
    },
    password: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'password' };
        };
    },
    confirmation: function (property, message) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'password' };
            validators.confirmation(property, message)(target, prop);
        };
    },
    week: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'week' };
        };
    },
    month: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'month' };
        };
    },
}, dataTypes);
