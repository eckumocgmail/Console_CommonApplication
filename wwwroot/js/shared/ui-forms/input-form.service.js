var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let InputFormService = class InputFormService {
    constructor() {
        this.icons = ["add", "3d_rotation", "ac_unit", "access_alarm", "access_alarms", "access_time", "accessibility", "accessible", "account_balance", "account_balance_wallet", "account_box", "account_circle", "adb", "add_a_photo", "add_alarm", "add_alert", "add_box", "add_circle", "add_circle_outline", "add_location", "add_shopping_cart", "add_to_photos", "add_to_queue", "adjust", "airline_seat_flat", "airline_seat_flat_angled", "airline_seat_individual_suite", "airline_seat_legroom_extra", "airline_seat_legroom_normal", "airline_seat_legroom_reduced", "airline_seat_recline_extra", "airline_seat_recline_normal", "airplanemode_active", "airplanemode_inactive", "airplay", "airport_shuttle", "alarm", "alarm_add", "alarm_off", "alarm_on", "album", "all_inclusive", "all_out", "android", "announcement", "apps", "archive", "arrow_back", "arrow_downward", "arrow_drop_down", "arrow_drop_down_circle", "arrow_drop_up", "arrow_forward", "arrow_upward", "art_track", "aspect_ratio", "assessment", "assignment", "assignment_ind", "assignment_late", "assignment_return", "assignment_returned", "assignment_turned_in", "assistant", "assistant_photo", "attach_file", "attach_money", "attachment", "audiotrack", "autorenew", "av_timer", "backspace", "backup", "battery_alert", "battery_charging_full", "battery_full", "battery_std", "battery_unknown", "beach_access", "beenhere", "block", "bluetooth", "bluetooth_audio", "bluetooth_connected", "bluetooth_disabled", "bluetooth_searching", "blur_circular", "blur_linear", "blur_off", "blur_on", "book", "bookmark", "bookmark_border", "border_all", "border_bottom", "border_clear", "border_color", "border_horizontal", "border_inner", "border_left", "border_outer", "border_right", "border_style", "border_top", "border_vertical", "branding_watermark", "brightness_1", "brightness_2", "brightness_3", "brightness_4", "brightness_5", "brightness_6", "brightness_7", "brightness_auto", "brightness_high", "brightness_low", "brightness_medium", "broken_image", "brush", "bubble_chart", "bug_report", "build", "burst_mode", "business", "business_center", "cached", "cake", "call", "call_end", "call_made", "call_merge", "call_missed", "call_missed_outgoing", "call_received", "call_split", "call_to_action", "camera", "camera_alt", "camera_enhance", "camera_front", "camera_rear", "camera_roll", "cancel", "card_giftcard", "card_membership", "card_travel", "casino", "cast", "cast_connected", "center_focus_strong", "center_focus_weak", "change_history", "chat", "chat_bubble", "chat_bubble_outline", "check", "check_box", "check_box_outline_blank", "check_circle", "chevron_left", "chevron_right", "child_care", "child_friendly", "chrome_reader_mode", "class", "clear", "clear_all", "close", "closed_caption", "cloud", "cloud_circle", "cloud_done", "cloud_download", "cloud_off", "cloud_queue", "cloud_upload", "code", "collections", "collections_bookmark", "color_lens", "colorize", "comment", "compare", "compare_arrows", "computer", "confirmation_number", "contact_mail", "contact_phone", "contacts", "content_copy", "content_cut", "content_paste", "control_point", "control_point_duplicate", "copyright", "create", "create_new_folder", "credit_card", "crop", "crop_16_9", "crop_3_2", "crop_5_4", "crop_7_5", "crop_din", "crop_free", "crop_landscape", "crop_original", "crop_portrait", "crop_rotate", "crop_square", "dashboard", "data_usage", "date_range", "dehaze", "delete", "delete_forever", "delete_sweep", "description", "desktop_mac", "desktop_windows", "details", "developer_board", "developer_mode", "device_hub", "devices", "devices_other", "dialer_sip", "dialpad", "directions", "directions_bike", "directions_boat", "directions_bus", "directions_car", "directions_railway", "directions_run", "directions_subway", "directions_transit", "directions_walk", "disc_full", "dns", "do_not_disturb", "do_not_disturb_alt", "do_not_disturb_off", "do_not_disturb_on", "dock", "domain", "done", "done_all", "donut_large", "donut_small", "drafts", "drag_handle", "drive_eta", "dvr", "edit", "edit_location", "eject", "email", "enhanced_encryption", "equalizer", "error", "error_outline", "euro_symbol", "ev_station", "event", "event_available", "event_busy", "event_note", "event_seat", "exit_to_app", "expand_less", "expand_more", "explicit", "explore", "exposure", "exposure_neg_1", "exposure_neg_2", "exposure_plus_1", "exposure_plus_2", "exposure_zero", "extension", "face", "fast_forward", "fast_rewind", "favorite", "favorite_border", "featured_play_list", "featured_video", "feedback", "fiber_dvr", "fiber_manual_record", "fiber_new", "fiber_pin", "fiber_smart_record", "file_download", "file_upload", "filter", "filter_1", "filter_2", "filter_3", "filter_4", "filter_5", "filter_6", "filter_7", "filter_8", "filter_9", "filter_9_plus", "filter_b_and_w", "filter_center_focus", "filter_drama", "filter_frames", "filter_hdr", "filter_list", "filter_none", "filter_tilt_shift", "filter_vintage", "find_in_page", "find_replace", "fingerprint", "first_page", "fitness_center", "flag", "flare", "flash_auto", "flash_off", "flash_on", "flight", "flight_land", "flight_takeoff", "flip", "flip_to_back", "flip_to_front", "folder", "folder_open", "folder_shared", "folder_special", "font_download", "format_align_center", "format_align_justify", "format_align_left", "format_align_right", "format_bold", "format_clear", "format_color_fill", "format_color_reset", "format_color_text", "format_indent_decrease", "format_indent_increase", "format_italic", "format_line_spacing", "format_list_bulleted", "format_list_numbered", "format_paint", "format_quote", "format_shapes", "format_size", "format_strikethrough", "format_textdirection_l_to_r", "format_textdirection_r_to_l", "format_underlined", "forum", "forward", "forward_10", "forward_30", "forward_5", "free_breakfast", "fullscreen", "fullscreen_exit", "functions", "g_translate", "gamepad", "games", "gavel", "gesture", "get_app", "gif", "golf_course", "gps_fixed", "gps_not_fixed", "gps_off", "grade", "gradient", "grain", "graphic_eq", "grid_off", "grid_on", "group", "group_add", "group_work", "hd", "hdr_off", "hdr_on", "hdr_strong", "hdr_weak", "headset", "headset_mic", "healing", "hearing", "help", "help_outline", "high_quality", "highlight", "highlight_off", "history", "home", "hot_tub", "hotel", "hourglass_empty", "hourglass_full", "http", "https", "image", "image_aspect_ratio", "import_contacts", "import_export", "important_devices", "inbox", "indeterminate_check_box", "info", "info_outline", "input", "insert_chart", "insert_comment", "insert_drive_file", "insert_emoticon", "insert_invitation", "insert_link", "insert_photo", "invert_colors", "invert_colors_off", "iso", "keyboard", "keyboard_arrow_down", "keyboard_arrow_left", "keyboard_arrow_right", "keyboard_arrow_up", "keyboard_backspace", "keyboard_capslock", "keyboard_hide", "keyboard_return", "keyboard_tab", "keyboard_voice", "kitchen", "label", "label_outline", "landscape", "language", "laptop", "laptop_chromebook", "laptop_mac", "laptop_windows", "last_page", "launch", "layers", "layers_clear", "leak_add", "leak_remove", "lens", "library_add", "library_books", "library_music", "lightbulb_outline", "line_style", "line_weight", "linear_scale", "link", "linked_camera", "list", "live_help", "live_tv", "local_activity", "local_airport", "local_atm", "local_bar", "local_cafe", "local_car_wash", "local_convenience_store", "local_dining", "local_drink", "local_florist", "local_gas_station", "local_grocery_store", "local_hospital", "local_hotel", "local_laundry_service", "local_library", "local_mall", "local_movies", "local_offer", "local_parking", "local_pharmacy", "local_phone", "local_pizza", "local_play", "local_post_office", "local_printshop", "local_see", "local_shipping", "local_taxi", "location_city", "location_disabled", "location_off", "location_on", "location_searching", "lock", "lock_open", "lock_outline", "looks", "looks_3", "looks_4", "looks_5", "looks_6", "looks_one", "looks_two", "loop", "loupe", "low_priority", "loyalty", "mail", "mail_outline", "map", "markunread", "markunread_mailbox", "memory", "menu", "merge_type", "message", "mic", "mic_none", "mic_off", "mms", "mode_comment", "mode_edit", "monetization_on", "money_off", "monochrome_photos", "mood", "mood_bad", "more", "more_horiz", "more_vert", "motorcycle", "mouse", "move_to_inbox", "movie", "movie_creation", "movie_filter", "multiline_chart", "music_note", "music_video", "my_location", "nature", "nature_people", "navigate_before", "navigate_next", "navigation", "near_me", "network_cell", "network_check", "network_locked", "network_wifi", "new_releases", "next_week", "nfc", "no_encryption", "no_sim", "not_interested", "note", "note_add", "notifications", "notifications_active", "notifications_none", "notifications_off", "notifications_paused", "offline_pin", "ondemand_video", "opacity", "open_in_browser", "open_in_new", "open_with", "pages", "pageview", "palette", "pan_tool", "panorama", "panorama_fish_eye", "panorama_horizontal", "panorama_vertical", "panorama_wide_angle", "party_mode", "pause", "pause_circle_filled", "pause_circle_outline", "payment", "people", "people_outline", "perm_camera_mic", "perm_contact_calendar", "perm_data_setting", "perm_device_information", "perm_identity", "perm_media", "perm_phone_msg", "perm_scan_wifi", "person", "person_add", "person_outline", "person_pin", "person_pin_circle", "personal_video", "pets", "phone", "phone_android", "phone_bluetooth_speaker", "phone_forwarded", "phone_in_talk", "phone_iphone", "phone_locked", "phone_missed", "phone_paused", "phonelink", "phonelink_erase", "phonelink_lock", "phonelink_off", "phonelink_ring", "phonelink_setup", "photo", "photo_album", "photo_camera", "photo_filter", "photo_library", "photo_size_select_actual", "photo_size_select_large", "photo_size_select_small", "picture_as_pdf", "picture_in_picture", "picture_in_picture_alt", "pie_chart", "pie_chart_outlined", "pin_drop", "place", "play_arrow", "play_circle_filled", "play_circle_outline", "play_for_work", "playlist_add", "playlist_add_check", "playlist_play", "plus_one", "poll", "polymer", "pool", "portable_wifi_off", "portrait", "power", "power_input", "power_settings_new", "pregnant_woman", "present_to_all", "print", "priority_high", "public", "publish", "query_builder", "question_answer", "queue", "queue_music", "queue_play_next", "radio", "radio_button_checked", "radio_button_unchecked", "rate_review", "receipt", "recent_actors", "record_voice_over", "redeem", "redo", "refresh", "remove", "remove_circle", "remove_circle_outline",
            "remove_from_queue", "remove_red_eye", "remove_shopping_cart", "reorder", "repeat", "repeat_one", "replay", "replay_10", "replay_30", "replay_5", "reply", "reply_all", "report", "report_problem", "restaurant", "restaurant_menu", "restore", "restore_page", "ring_volume", "room", "room_service", "rotate_90_degrees_ccw", "rotate_left", "rotate_right", "rounded_corner", "router", "rowing", "rss_feed", "rv_hookup", "satellite", "save", "scanner", "schedule", "school", "screen_lock_landscape", "screen_lock_portrait", "screen_lock_rotation", "screen_rotation", "screen_share", "sd_card", "sd_storage", "search", "security", "select_all", "send", "sentiment_dissatisfied", "sentiment_neutral", "sentiment_satisfied", "sentiment_very_dissatisfied", "sentiment_very_satisfied", "settings", "settings_applications", "settings_backup_restore", "settings_bluetooth", "settings_brightness", "settings_cell", "settings_ethernet", "settings_input_antenna", "settings_input_component", "settings_input_composite", "settings_input_hdmi", "settings_input_svideo", "settings_overscan", "settings_phone", "settings_power", "settings_remote", "settings_system_daydream", "settings_voice", "share", "shop", "shop_two", "shopping_basket", "shopping_cart", "short_text", "show_chart", "shuffle", "signal_cellular_4_bar", "signal_cellular_connected_no_internet_4_bar", "signal_cellular_no_sim", "signal_cellular_null", "signal_cellular_off", "signal_wifi_4_bar", "signal_wifi_4_bar_lock", "signal_wifi_off", "sim_card", "sim_card_alert", "skip_next", "skip_previous", "slideshow", "slow_motion_video", "smartphone", "smoke_free", "smoking_rooms", "sms", "sms_failed", "snooze", "sort", "sort_by_alpha", "spa", "space_bar", "speaker", "speaker_group", "speaker_notes", "speaker_notes_off", "speaker_phone", "spellcheck", "star", "star_border", "star_half", "stars", "stay_current_landscape", "stay_current_portrait", "stay_primary_landscape", "stay_primary_portrait", "stop", "stop_screen_share", "storage", "store", "store_mall_directory", "straighten", "streetview", "strikethrough_s", "style", "subdirectory_arrow_left", "subdirectory_arrow_right", "subject", "subscriptions", "subtitles", "subway", "supervisor_account", "surround_sound", "swap_calls", "swap_horiz", "swap_vert", "swap_vertical_circle", "switch_camera", "switch_video", "sync", "sync_disabled", "sync_problem", "system_update", "system_update_alt", "tab", "tab_unselected", "tablet", "tablet_android", "tablet_mac", "tag_faces", "tap_and_play", "terrain", "text_fields", "text_format", "textsms", "texture", "theaters", "thumb_down", "thumb_up", "thumbs_up_down", "time_to_leave", "timelapse", "timeline", "timer", "timer_10", "timer_3", "timer_off", "title", "toc", "today", "toll", "tonality", "touch_app", "toys", "track_changes", "traffic", "train", "tram", "transfer_within_a_station", "transform", "translate", "trending_down", "trending_flat", "trending_up", "tune", "turned_in", "turned_in_not", "tv", "unarchive", "undo", "unfold_less", "unfold_more", "update", "usb", "verified_user", "vertical_align_bottom", "vertical_align_center", "vertical_align_top", "vibration", "video_call", "video_label", "video_library", "videocam", "videocam_off", "videogame_asset", "view_agenda", "view_array", "view_carousel", "view_column", "view_comfy", "view_compact", "view_day", "view_headline", "view_list", "view_module", "view_quilt", "view_stream", "view_week", "vignette", "visibility", "visibility_off", "voice_chat", "voicemail", "volume_down", "volume_mute", "volume_off", "volume_up", "vpn_key", "vpn_lock", "wallpaper", "warning", "watch", "watch_later", "wb_auto", "wb_cloudy", "wb_incandescent", "wb_iridescent", "wb_sunny", "wc", "web", "web_asset", "weekend", "whatshot", "widgets", "wifi", "wifi_lock", "wifi_tethering", "work", "wrap_text", "youtube_searched_for", "zoom_in", "zoom_out", "zoom_out_map"];
    }
    getProperty(properties, name) { return Object.getOwnPropertyDescriptor(properties, name); }
    getValidators(target, prop) { return validators.get(target, prop); }
    getDescription(target, prop) { return description(target, prop); }
    getInputModel(target, prop) { return description(target, prop).input; }
    fromTableModel(metadata) {
        console.log(metadata);
        const ctrl = this;
        const prototype = {};
        prototype['__proto__'] = {
            __descriptor__: {}
        };
        let annotationFn = null;
        Object.getOwnPropertyNames(metadata.columns).forEach((name) => {
            if (metadata.columns[name].primary) {
                return;
            }
            switch (metadata.columns[name].type.toLowerCase()) {
                case 'blob':
                    prototype[name] = null;
                    annotationFn = ctrl.getFileTypeByLogicalName(name) || controlTypes.file;
                    annotationFn()(prototype, name);
                    break;
                case 'varchar':
                    prototype[name] = null;
                    inputTypes.text()(prototype, name);
                    annotationFn = ctrl.getTextTypeByLogicalName(name);
                    if (annotationFn) {
                        annotationFn()(prototype, name);
                    }
                    break;
                case 'char':
                    prototype[name] = null;
                    inputTypes.text()(prototype, name);
                    validators.maxLength(1)(prototype, name);
                    break;
                case 'int':
                case 'integer':
                case 'long':
                    prototype[name] = 1;
                    inputTypes.number()(prototype, name);
                    break;
                case 'float':
                    prototype[name] = 1;
                    inputTypes.number()(prototype, name);
                    break;
                case 'date':
                    prototype[name] = new Date();
                    inputTypes.date()(prototype, name);
                    break;
                case 'datetime':
                    prototype[name] = new Date();
                    inputTypes.date()(prototype, name);
                    break;
                default: throw new Error('unsupported data type: ' + metadata.columns[name].type);
            }
            if (!metadata.columns[name].nullable) {
                validators.required(true)(prototype, name);
            }
            if (Object.getOwnPropertyNames(metadata.fk).indexOf(name) !== -1) {
                controlTypes.selectbox(['1', '2', '3'])(prototype, name);
            }
        });
        console.log(prototype);
        return prototype;
    }
    getTextTypeByLogicalName(name) {
        let annotationFn = null;
        name.toLocaleLowerCase().split('_').forEach(splice => {
            annotationFn = !annotationFn ? textValidators[splice] : annotationFn;
        });
        return annotationFn;
    }
    getFileTypeByLogicalName(name) {
        let annotationFn = null;
        name.toLocaleLowerCase().split('_').forEach(splice => {
            annotationFn = !annotationFn ? imageTypes[splice] || imageTypes[splice] || imageTypes[splice] : annotationFn;
        });
        return annotationFn;
    }
    formatDateForInput(v) {
        let pvalue = typeof (v) === 'string' ? new Date(v) : v;
        const month = pvalue.getMonth() + 1;
        const mstr = pvalue.getMonth() < 10 ? '0' + month : month;
        const dstr = pvalue.getDate() < 10 ? '0' + pvalue.getDate() : pvalue.getDate();
        const result = pvalue.getFullYear() + '-' + mstr + '-' + dstr;
        return result;
    }
    getType(properties, name) {
        if (typeof (properties[name]) === 'undefined') {
            console.warn(name, ' not defined');
        }
        else {
            if (typeof (properties[name]) === 'boolean' || properties[name] instanceof Boolean) {
                return 'checkbox';
            }
            else if (typeof (properties[name]) === 'number') {
                return 'number';
            }
            else if (typeof (properties[name]) === 'string') {
                if (/^(ftp|http|https):\/\/[^ "]+$/.test(properties[name])) {
                    return 'url';
                }
                if (/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(properties[name])) {
                    return 'email';
                }
                if (this.isMonthValue(properties[name])) {
                    return 'month';
                }
                if (this.isWeekValue(properties[name])) {
                    return 'week';
                }
                if (this.isColor(properties[name])) {
                    return 'color';
                }
                return 'text';
            }
            else if (properties[name] instanceof Date) {
                return 'date';
            }
            else {
                if (typeof (properties[name]) === 'object' && properties[name] instanceof Array) {
                    return 'table';
                }
                else {
                    return 'properties';
                }
                return null;
            }
        }
    }
    getInputValue(property, description) {
        return description.model.input === 'date' ? this.formatDateForInput(property) : property;
    }
    getStructure(properties, name) {
        if (properties[name] instanceof Array) {
            return { type: 'structure', input: 'function' };
        }
        else if (typeof (properties[name]) === 'function') {
            return { type: 'structure', input: 'function' };
        }
        else if (typeof (properties[name]) === 'object') {
            return { type: 'structure', input: 'object' };
        }
        else {
            return { type: 'structure', input: 'object' };
        }
    }
    isColor(value) {
        return /(#([0-9a-f]{3}){1,2}|(rgba|hsla)\(\d{1,3}%?(,\s?\d{1,3}%?){2},\s?(1|0|0?\.\d+)\)|(rgb|hsl)\(\d{1,3}%?(,\s?\d{1,3}%?){2}\))/i.test(value);
    }
    isMonthValue(value) {
        const t1 = this.isNumberString(value.substr(0, 4)) === 0;
        if (!t1) {
            return false;
        }
        const t2 = value[4] === '-';
        if (!t2) {
            return false;
        }
        const t3 = this.isNumberString(value.substr(5, 6)) === 0;
        if (!t3) {
            return false;
        }
        return t1 && t2 && t3;
    }
    isWeekValue(value) {
        const t1 = this.isNumberString(value.substr(0, 4)) === 0;
        if (!t1) {
            return false;
        }
        const t2 = value[4] === '-' && value[5].toUpperCase() === 'W';
        if (!t2) {
            return false;
        }
        const t3 = this.isNumberString(value.substr(6, 7)) === 0;
        if (!t3) {
            return false;
        }
        return t1 && t2 && t3;
    }
    isNumberString(text) {
        const NUBMERS = '0123456789';
        let ctn = 0;
        for (let i = 0; i < text.length; i++) {
            if (NUBMERS.indexOf(text[i]) === -1) {
                ctn++;
            }
        }
        return ctn;
    }
    values(options) {
        const vals = [];
        const names = Object.getOwnPropertyNames(options);
        for (let i = 0; i < options.length; i++) {
            vals.push(options[names[i]]);
        }
        return vals;
    }
};
InputFormService = __decorate([
    Service({
        name: '$inputForm'
    })
], InputFormService);
function Input(id) {
    return function (target, property) {
    };
}
function Output(id) {
    return function (target, property) {
    };
}
function EventEmitter() {
}
let FormViewComponent = class FormViewComponent {
    constructor() {
        this.title = 'Login';
        this.showToolbar = true;
        this.view = 1;
        this.size = 'norm';
        this.fields = [];
        this.state = 'valid';
        this.changed = new EventEmitter();
        this.uniqueValidation = new EventEmitter();
    }
    validateUnique(property, value) {
        this.uniqueValidation.emit({
            property: property,
            value: value
        });
    }
    ngOnInit() {
        const ctrl = this;
        ctrl.validateFields();
        ctrl.updateState();
    }
    onSizeChanged(evt) {
        this.size = evt.target['value'];
        evt.preventDefault();
        evt.stopImmediatePropagation();
    }
    validateFields() {
        const ctrl = this;
        ctrl.fields.forEach(field => {
            field.onValidate(ctrl, field.value);
        });
    }
    onInput(evt) {
        const field = this.fields.find(f => f.name === evt.target.name);
        const value = evt.target.type === 'checkbox' ? evt.target.checked : evt.target.value;
        field.onValidate(this, value);
        this.validateFields();
        this.updateState();
        this.changed.emit(this.getValues());
    }
    getValues() {
        const props = {};
        const ctrl = this;
        ctrl.fields.forEach(field => {
            props[field.name] = field.value;
        });
        return props;
    }
    findField(fieldName) {
        return this.fields.find(f => f.name === fieldName);
    }
    updateState() {
        const ctrl = this;
        ctrl.state = 'undefined';
        ctrl.fields.forEach(field => {
            if (field.state === 'invalid') {
                ctrl.state = 'invalid';
            }
        });
        if (ctrl.state == 'undefined') {
            ctrl.state = 'valid';
        }
    }
};
__decorate([
    Input()
], FormViewComponent.prototype, "title", void 0);
__decorate([
    Input('show-toolbar')
], FormViewComponent.prototype, "showToolbar", void 0);
__decorate([
    Input()
], FormViewComponent.prototype, "fields", void 0);
__decorate([
    Output()
], FormViewComponent.prototype, "changed", void 0);
__decorate([
    Output()
], FormViewComponent.prototype, "uniqueValidation", void 0);
FormViewComponent = __decorate([
    Component({
        selector: 'form-view',
        templateUrl: './form-view.component.html'
    })
], FormViewComponent);
let FormFieldComponent = class FormFieldComponent {
    constructor(context) {
        this.view = 1;
        this.badge = null;
        this.entity = null;
        this.size = 'norm';
        this.type = 'text';
        this.name = 'noname';
        this.value = null;
        this.icon = 'person';
        this.label = 'noname';
        this.mapped = true;
        this.required = null;
        this.state = 'valid';
        this.help = '';
        this.class = 'form-control form-control-lg is-valid';
        this.errors = [];
        this.validators = [];
        this.unique = null;
        this.isControl = false;
        this.context = context;
    }
    onValidate(form, value) {
        const ctrl = this;
        ctrl.errors = [];
        if (ctrl.required && (!value || value == '')) {
            ctrl.errors.push(ctrl.required);
        }
        else {
            if (ctrl.unique) {
                form.validateUnique(ctrl.name, value);
            }
            ctrl.validators.forEach(validator => {
                try {
                    validator(form, this, value);
                }
                catch (e) {
                    ctrl.errors.push(e.message);
                }
            });
        }
        ctrl.value = value;
        ctrl.updateClass();
    }
    updateClass() {
        const ctrl = this;
        ctrl.state = ctrl.errors.length > 0 ? 'invalid' : 'valid';
        const sizeClass = ctrl.size === 'large' ? 'form-control-lg' : ctrl.size == 'norm' ? '' : ctrl.size == 'small' ? 'form-control-sm' : '';
        ctrl.class = 'form-control ' + sizeClass + ' is-' + ctrl.state;
    }
    onInput($event) {
        if (this.transform) {
            $event.target.value = this.transform($event.target.value);
        }
    }
    ngOnChanges(changes) {
        const ctrl = this;
        if (changes.size) {
            ctrl.updateClass();
        }
    }
    toInputForm(date) {
        if (!(date instanceof Date)) {
            date = new Date(date.toString());
        }
        const mstr = (date.getMonth() + 1) < 10 ? ('0' + (date.getMonth() + 1)) : (date.getMonth() + 1).toString();
        const dstr = date.getDate() < 10 ? ('0' + date.getDate()) : date.getDate().toString();
        return date.getFullYear() + '-' + mstr + '-' + dstr;
    }
};
__decorate([
    Input()
], FormFieldComponent.prototype, "view", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "badge", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "entity", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "size", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "type", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "name", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "value", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "icon", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "label", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "mapped", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "required", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "state", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "help", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "class", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "errors", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "validators", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "transform", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "unique", void 0);
__decorate([
    Input()
], FormFieldComponent.prototype, "control", void 0);
FormFieldComponent = __decorate([
    Component({
        selector: 'formField',
        template: `
    <div *ngIf="view==1" (input)="onInput($event)"  [hidden]="type==='hidden'">
      <label [attr.for]="name">
        {{label}}
        <span *ngIf="badge" class="badge badge-secondary" >{{badge}}</span>
      </label>

      <div class="input-group mb-5" >
        <div style="display: flex; flex-direction: row; flex-wrap: nowrap; width: 100%;">
          <div class="input-group-prepend">
                <span class="input-group-text">
                    <i class="material-icons">{{icon}}</i>
                </span>
            </div>
            <div style="width: 100%;">
              <input [attr.id]="name" [attr.name]="name" [attr.type]="type" [attr.class]="class" [attr.placeholder]="label" [attr.value]="type!=='date'? value: toInputForm( value )"
                  style="width: 100%;">
            </div>
          </div>
          <div class="text-info">{{help}}</div>
          <div *ngFor="let error of errors" class="text-danger">
            {{error}}
          </div>

        </div>
    </div>
    <div *ngIf="view==2">
      <div (input)="onInput($event)" [hidden]="type==='hidden'">
        <div class="form-group row">
          <div class="col-4 col-form-label" align="center"><label [attr.for]="name">{{label}}</label></div>
          <div class="col-8">
            <input style="width: 100%;" [attr.id]="name" [attr.name]="name" [attr.type]="type" [attr.class]="class" [attr.placeholder]="label" [attr.value]="type!=='date'? value: toInputForm( value )">
            <div class="form-text text-info ">{{help}}</div>
            <div *ngFor="let error of errors" class="text-danger">
              {{error}}
            </div>
          </div>
        </div>

      </div>
    </div>
    <div *ngIf="view==3">
      <div class="form-group" align="left" (input)="onInput($event)" [hidden]="type==='hidden'">
        <label><b>{{label}}</b></label>
        <input style="width: 100%;" [ngModel]="value" [attr.id]="name" [attr.name]="name" [attr.type]="type"  [attr.class]="class" [attr.placeholder]="label">
        <div class="text-info">{{help}}</div>
        <div *ngFor="let error of errors" class="text-danger">
          {{error}}
        </div>
      </div>
    </div>
  <!-- -->
  `
    })
], FormFieldComponent);
let FormValidationService = class FormValidationService {
    createPhoneValidator(arg0) {
        return function (form, field, value) {
            const message = value;
            if (!message) {
                throw new Error(message);
            }
            else {
                if (message.length !== '7-904-334-1124'.length) {
                    throw new Error(message);
                }
                else {
                    function isNumber(ch) {
                        return '0123456789'.indexOf(ch) !== -1;
                    }
                    if (message[1] !== '-' || message[5] !== '-' || message[9] !== '-') {
                        throw new Error(message);
                    }
                    else {
                        if (isNumber(message[0]) === false ||
                            isNumber(message[2]) === false || isNumber(message[3]) === false || isNumber(message[4]) === false ||
                            isNumber(message[6]) === false || isNumber(message[7]) === false || isNumber(message[8]) === false ||
                            isNumber(message[10]) === false || isNumber(message[11]) === false ||
                            isNumber(message[12]) === false || isNumber(message[13]) === false) {
                            throw new Error(message);
                        }
                    }
                }
            }
        };
    }
    createUrlValidator(error) {
        return function (form, field, value) {
            if (!new RegExp(/^(ftp|http|https):\/\/[^ "]+$/).test(value)) {
                throw new Error(error);
            }
        };
    }
    createRusTextValidator(error) {
        return function (form, field, value) {
            if (!new RegExp(/^[а-яА-ЯёЁ]+$/).test(value)) {
                throw new Error(error);
            }
        };
    }
    createEngTextValidator(error) {
        return function (form, field, value) {
            if (!new RegExp(/^[a-zA-Z]+$/).test(value)) {
                throw new Error(error);
            }
        };
    }
    createEmailValidator(error) {
        return function (form, field, value) {
            if (!new RegExp(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/).test(value)) {
                throw new Error(error);
            }
        };
    }
    createPasswordConfirmationValidator(passwordField, errorMessage) {
        return function (form, field, value) {
            if (form.findField(passwordField).value !== value) {
                throw new Error(errorMessage);
            }
        };
    }
};
FormValidationService = __decorate([
    Service({
        name: '$formValidation'
    })
], FormValidationService);
let FormFieldService = class FormFieldService {
    constructor($formValidation) {
        this.$formValidation = $formValidation;
    }
    createDateField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'date';
        field.value = new Date();
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        return field;
    }
    createPhoneField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'text';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        field.transform = function (phone) {
            let value = '';
            for (let i = 0; i < phone.length; i++) {
                if ("0123456789".indexOf(phone[i]) !== -1) {
                    value += phone[i];
                }
                if (value.length == 11) {
                    break;
                }
            }
            if (value.length > 0)
                value = value.substr(0, 1) + '-' + value.substring(1);
            if (value.length > 4)
                value = value.substr(0, 5) + '-' + value.substring(5);
            if (value.length > 8)
                value = value.substr(0, 9) + '-' + value.substring(9);
            if (field.value.length > phone.length && value.endsWith('-')) {
                value = value.substr(0, value.length - 1);
            }
            return value;
        };
        field.validators.push(this.$formValidation.createPhoneValidator(options.error || 'enter a valid phone number in format X-XXX-XXX-XXXX'));
        return field;
    }
    createUrlField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'text';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        field.validators.push(this.$formValidation.createUrlValidator(options.error || 'enter a valid url'));
        return field;
    }
    createPasswordField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'password';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        return field;
    }
    createPasswordConfirmationField(options, additional) {
        const field = {};
        field.name = options.fieldName;
        field.label = options.labelText || options.fieldName;
        field.help = options.helpMessage;
        field.type = 'password';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        field.validators.push(this.$formValidation.createPasswordConfirmationValidator(options.passwordField, options.errorMessage || 'confirmation not equals password'));
        return field;
    }
    createEmailField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'text';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        field.validators.push(this.$formValidation.createEmailValidator(options.error || 'email address incorrect'));
        return field;
    }
    createEngField(options, additional) {
        const field = {};
        field.name = options.name;
        field.label = options.label || options.name;
        field.help = options.help;
        field.type = 'text';
        if (additional) {
            field.required = additional.required;
            field.icon = additional.icon;
        }
        field.validators.push(this.$formValidation.createEngTextValidator(options.error || 'please input text in english'));
        return field;
    }
};
FormFieldService = __decorate([
    Service({
        name: '$formField'
    })
], FormFieldService);
let FormControlComponent = class FormControlComponent extends FormFieldComponent {
    constructor(context) {
        super();
        this.view = 1;
        this.isControl = true;
        this.context = context;
    }
    ngOnInit() {
        const ctrl = this;
        if (this.control.oninit) {
            this.control.oninit(this);
        }
    }
    onInput($event) {
        console.log($event);
    }
    onValidate(form, value) {
        super.onValidate(form, value);
        form.findField(this.name);
    }
    updateClass() {
        if (this.control.type === 'checkbox') {
            this.class = 'form-check-input is-' + this.state;
        }
        else {
            super.updateClass();
        }
    }
};
__decorate([
    Input()
], FormControlComponent.prototype, "control", void 0);
FormControlComponent = __decorate([
    Component({
        selector: 'form-control',
        template: `

    <div *ngIf="view==1" (input)="onInput($event)"   >
      <label [attr.for]="name">
        {{label}}
        <span *ngIf="badge" class="badge badge-secondary" >{{badge}}</span>
      </label>

      <div class="input-group mb-5" >
        <div style="display: flex; flex-direction: row; flex-wrap: nowrap; width: 100%;">
          <div class="input-group-prepend">
            <span class="input-group-text">
                <i class="material-icons">{{control.type!=='icon'?icon: value? value: 'home'}}</i>
            </span>
          </div>
          <div style="width: 100%;">
            <textarea [attr.class]="class"  *ngIf="control.type==='textarea'"
                      [attr.name]="name" [attr.id]="name" style="width: 100%;">{{value}}</textarea>
            <select [attr.class]="class"  *ngIf="control.type==='selectbox'"
                    [attr.name]="name" [attr.id]="name" style="width: 100%;">
              <option *ngFor="let option of control['options']" [attr.value]="option.value">{{option.text}}</option>
            </select>
            <select [attr.class]="class"  *ngIf="control.type==='icon'"
                    [attr.name]="name" [attr.id]="name" style="width: 100%;">
              <option *ngFor="let option of control['options']" [attr.value]="option.value">{{option.text}}</option>
              <option selected [attr.value]="value.toString()">{{value.toString()}}</option>
            </select>

            <div class="form-check"  *ngIf="control.type==='checkbox'"  style="width: 100%;">
              <input [attr.class]="class" type="checkbox" [attr.name]="name" [attr.id]="name" [attr.checked]="value">
              <label class="form-check-label" [attr.for]="name">{{label}}</label>
            </div>
            <div class="form-check"  style="width: 100%;" *ngIf="control.type==='radiogroup'">
              <div *ngFor="let option of control['options']">
                <input [attr.class]="class" type="radio" [attr.name]="name" [attr.id]="name" [attr.value]="option.value">
                <label class="form-check-label" [attr.for]="name" >{{ option.text }}</label>
              </div>
            </div>

          </div>
        </div>
        <div class="text-info">{{help}}</div>
        <div *ngFor="let error of errors" class="text-danger">
          {{error}}
        </div>

      </div>
    </div>
    <div class="form-group row" *ngIf="view==2" (input)="onInput($event)">
      <div class="col-4 col-form-label" align="center">
        <label [attr.for]="name">{{label}}</label>
      </div>
      <div class="col-8">
        <textarea [attr.class]="class"  *ngIf="control.type==='textarea'"
                      [attr.name]="name" [attr.id]="name" style="width: 100%;">{{value}}</textarea>
        <select [attr.class]="class"  *ngIf="control.type==='selectbox'"
                [attr.name]="name" [attr.id]="name" style="width: 100%;">
          <option *ngFor="let option of control['options']" [attr.value]="option.value">{{option.text}}</option>
        </select>
        <select [attr.class]="class"  *ngIf="control.type==='icon'"
                [attr.name]="name" [attr.id]="name" style="width: 100%;">
          <option *ngFor="let option of control['options']" [attr.value]="option.value">  {{option.text}} </option>
          <option selected [attr.value]="value.toString()">{{value.toString()}}</option>
        </select>
        <div class="form-check"  *ngIf="control.type==='checkbox'"  style="width: 100%;">
          <input [attr.class]="class" type="checkbox" [attr.name]="name" [attr.id]="name" [attr.checked]="value">
          <label class="form-check-label" [attr.for]="name">{{label}}</label>
        </div>
        <div class="form-check"  style="width: 100%;" *ngIf="control.type==='radiogroup'">
          <div *ngFor="let option of control['options']">
            <input [attr.class]="class" type="radio" [attr.name]="name" [attr.id]="name" [attr.value]="option.value">
            <label class="form-check-label" [attr.for]="name" >{{ option.text }}</label>
          </div>
        </div>
        <div class="form-text text-info ">{{help}}</div>
        <div *ngFor="let error of errors" class="text-danger">
          {{error}}
        </div>
      </div>
    </div>


    <div *ngIf="view==3" (input)="onInput($event)">
      <div class="form-group" align="left" (input)="onInput($event)" [hidden]="type==='hidden'">
        <label *ngIf="control.type!=='checkbox'"><b>{{label}}</b></label>
        <textarea [attr.class]="class"  *ngIf="control.type==='textarea'"
                      [attr.name]="name" [attr.id]="name" style="width: 100%;">{{value}}</textarea>
        <select [attr.class]="class"  *ngIf="control.type==='selectbox'"
                [attr.name]="name" [attr.id]="name">
          <option *ngFor="let option of control['options']" [attr.value]="option.value">{{option.text}}</option>
        </select>
        <div class="form-check"  *ngIf="control.type==='checkbox'">
          <input [attr.class]="class" type="checkbox" [attr.name]="name" [attr.id]="name" [attr.checked]="value">
          <label class="form-check-label" [attr.for]="name">{{label}}</label>
        </div>
        <select [attr.class]="class"  *ngIf="control.type==='icon'"
                [attr.name]="name" [attr.id]="name" style="width: 100%;">
          <option *ngFor="let option of control['options']" [attr.value]="option.value">
            {{option.text}}
          </option>
          <option selected [attr.value]="value.toString()">{{value.toString()}}</option>
        </select>
        <div class="form-check"  *ngIf="control.type==='radiogroup'">
          <div *ngFor="let option of control['options']">
            <input [attr.class]="class" type="radio" [attr.name]="name" [attr.id]="name" [attr.value]="option.value">
            <label class="form-check-label" [attr.for]="name" >{{ option.text }}</label>
          </div>
        </div>
        <div class="text-info">{{help}}</div>
        <div *ngFor="let error of errors" class="text-danger">
          {{error}}
        </div>
      </div>
    </div>

  `
    })
], FormControlComponent);
let FormControlService = class FormControlService {
    constructor(validation) {
        this.validation = validation;
    }
    createTextAreaControl(options) {
        const control = new FormControlComponent();
        control.name = options.name;
        control.label = options.label || options.name;
        control.help = options.help;
        control.icon = options.icon;
        control.type = 'text';
        control.control = { type: 'textarea' };
        return control;
    }
    createCheckboxControl(options) {
        const control = new FormControlComponent();
        control.name = options.name;
        control.label = options.label || options.name;
        control.help = options.help;
        control.icon = options.icon;
        control.type = 'text';
        control.control = { type: 'checkbox' };
        return control;
    }
    createRadioGroupControl(options) {
        const control = new FormControlComponent();
        control.name = options.name;
        control.label = options.label || options.name;
        control.help = options.help;
        control.icon = options.icon;
        control.type = 'text';
        control.control = { type: 'radiogroup', options: options.options };
        return control;
    }
    createSelectboxControl(options) {
        const control = new FormControlComponent();
        control.name = options.name;
        control.label = options.label || options.name;
        control.help = options.help;
        control.icon = options.icon;
        control.type = 'text';
        control.control = { type: 'selectbox', options: options.options };
        return control;
    }
};
FormControlService = __decorate([
    Service({
        name: '$formControl'
    })
], FormControlService);
let FormInputService = class FormInputService {
    constructor(fields, controls) {
        this.fields = fields;
        this.controls = controls;
    }
    getLabelFor(typename) {
        const attributes = this.parseEntityType(typename);
        return attributes ? attributes['EntityLabel'] : null;
    }
    parseEntityType(typename) {
        if (typename[0] === typename[0].toLowerCase()) {
            typename = typename.substr(0, 1).toUpperCase() + typename.substr(1);
        }
        const attributes = {};
        try {
            if (!window['spec'][typename]) {
                throw new Error('Сущность ' + typename + ' не зарегистрирована в контексте моделей данных');
            }
            Object.getOwnPropertyNames(window['spec'][typename]).forEach(name => {
                attributes[name] = window['spec'][typename][name][0];
            });
        }
        catch (e) {
            console.error(e);
        }
        return attributes;
    }
    parseFields(target) {
        const ctrl = this;
        const fields = [];
        Object.getOwnPropertyNames(target).forEach(name => {
            const attributes = window['input'][target.constructor.name][name];
            const type = typeof (target[name]);
            let field = ctrl.createField(attributes, name, type, target);
            fields.push(field);
        });
        return fields;
    }
    createField(attributes, name, type, target) {
        let field = new FormFieldComponent();
        field.name = name;
        field.label = name;
        switch (type) {
            case 'boolean':
                field = this.controls.createCheckboxControl({ name: name, label: field.label });
                break;
            case 'number':
                field.type = "number";
                break;
            default:
                field.type = "text";
                break;
        }
        if (attributes) {
            Object.getOwnPropertyNames(attributes).forEach(name => {
                if (!window['provider'][name]) {
                    console.warn('Платформа клиентской стороны не поддерживает атрибут ' + name);
                }
                else {
                    Object.assign(field, window['provider'][name](attributes[name])(field));
                }
            });
        }
        else {
        }
        field.value = target[name];
        return field;
    }
};
FormInputService = __decorate([
    Service({
        name: '$formInput'
    })
], FormInputService);
